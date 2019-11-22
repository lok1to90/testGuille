using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestGuille.Web.IRules;
using TestGuille.Web.Models;

namespace TestGuille.Web.Controllers
{
    [RoutePrefix("transaction")]
    public class TransactionController : ApiController
    {
        private readonly ITransactionRules db;
        private readonly IMapper mapper;

        public TransactionController(ITransactionRules db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        [ActionName("getByCurrency")]
        public IHttpActionResult GetTransactionByCurrency(string currency)
        {
            try
            {
                var result = db.GetByCurrency(currency);
                var transactionModelResult = mapper.Map<IEnumerable<TransactionModel>>(result);
                return Ok(transactionModelResult);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [ActionName("getByDateRange")]
        public IHttpActionResult GetTransactionByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = db.GetByDateRange(fromDate, toDate);
                var transactionModelResult = mapper.Map<IEnumerable<TransactionModel>>(result);
                return Ok(transactionModelResult);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [ActionName("getByStatus")]
        public IHttpActionResult GetTransactionByStatus(string status)
        {
            try
            {
                var result = db.GetByStatus(status);
                var transactionModelResult = mapper.Map<IEnumerable<TransactionModel>>(result);
                return Ok(transactionModelResult);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
