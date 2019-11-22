using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TestGuille.Data.IService;
using TestGuille.Data.Service;
using TestGuille.Web.IRules;
using TestGuille.Web.Mapper;
using TestGuille.Web.Rules;

namespace TestGuille.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            var config = new MapperConfiguration(x => { x.AddProfile(new TestGuilleProfile()); });
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();

            builder.RegisterType<TestGuilleDbContext>()
                .InstancePerRequest();

            builder.RegisterType<UploadFileData>()
                .As<IUploadFileData>()
                .InstancePerRequest();

            builder.RegisterType<UploadFileRules>()
                .As<IUploadFileRules>()
                .InstancePerRequest();

            builder.RegisterType<TransactionRules>()
                .As<ITransactionRules>()
                .InstancePerRequest();

            builder.RegisterType<TransactionData>()
                .As<ITransactionData>()
                .InstancePerRequest();

            var container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}