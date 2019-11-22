using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestGuille.Data.Models;
using TestGuille.Web.Models;

namespace TestGuille.Web.Mapper
{
    public class TestGuilleProfile : Profile
    {
        public TestGuilleProfile()
        {
            CreateMap<Transaction, TransactionModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.NroInvoice))
                .ForMember(x => x.Payment, y => y.MapFrom(z => z.Amount.ToString() + " " + z.CurrencyCode))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status.ToString()));
        }
    }
}