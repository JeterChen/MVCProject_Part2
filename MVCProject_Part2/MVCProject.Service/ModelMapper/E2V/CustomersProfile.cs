using AutoMapper;
using MVCProject.Data.Entity;
using MVCProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.ModelMapper.E2V
{
    internal class CustomersProfile : Profile
    {
        protected override void Configure()
        {


            CreateMap<Customers, CustomerVO>()
                .ForMember(t => t.CompanyName, m => m.ResolveUsing((s) => CompanyNameEdit(s.City,s.Country)))
                .ForMember(t => t.List, m => m.ResolveUsing((s) => FuncVO(s)));

            //CreateMap<Customers, TESTVO>()
            //    .ForMember(t => t.A, m => m.MapFrom((s) => s.City))
            //    .ForMember(t => t.B, m => m.MapFrom((s) => s.Country));

        }

        Func<Customers, IEnumerable<TESTVO>> FuncVO = (s) =>
         {
             List<TESTVO> test = new List<TESTVO>();
             test.Add(new TESTVO() { A = s.City, B = s.Country });
             return test;
         };

        Func<string, IEnumerable<string>> listfunc = a =>
         {
             List<string> aa = new List<string>();
             aa.Add("sss");
             aa.Add("bb");
             return aa;
         };

        private string CompanyNameEdit2 (string x)
        {
            return x + "_999";
        }

        private Func<string ,string, string> CompanyNameEdit = (x, y) => $"{x + y}_999";

    }
}
