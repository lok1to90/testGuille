using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestGuille.Data.Enum;
using TestGuille.Web.IRules;
using System.Configuration;
using TestGuille.Data.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Xml;

namespace TestGuille.Web.Controllers
{
    public class UploadFileController : Controller
    {
        private readonly IUploadFileRules db;

        public UploadFileController(IUploadFileRules db)
        {
            this.db = db;
        }
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                var isValidSize = db.IsValidSize(file.ContentLength, Convert.ToInt32(ConfigurationManager.AppSettings["maxSize"].ToString()));
                if (isValidSize)
                {
                    var extension = db.GetValidExtension(file.FileName);
                    if (extension != FormatTypeEnum.OTHER)
                        db.SaveData(file.InputStream, extension);
                    else
                    {
                        Response.StatusCode = 400;
                        Response.StatusDescription = "Unknown format";
                        ViewBag.Message = "Unknown format";
                        return View();
                        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Unknown format"));
                    }
                }
                else
                {
                    Response.StatusCode = 400;
                    Response.StatusDescription = "The Max file size is " + ConfigurationManager.AppSettings["maxSize"] + " bytes";
                    ViewBag.Message = "The Max file size is " + ConfigurationManager.AppSettings["maxSize"] + " bytes";
                    return View();
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The Max file size is " + ConfigurationManager.AppSettings["maxSize"] + " bytes");
                }
                ViewBag.Message = "Uploaded";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }
    }
}