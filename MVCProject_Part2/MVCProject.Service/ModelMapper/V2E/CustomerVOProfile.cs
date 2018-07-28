using AutoMapper;
using MVCProject.Data.Entity;
using MVCProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.ModelMapper.V2E
{
    internal class CustomerVOProfile : Profile
    {
        protected override void Configure()
        {
            //V2V CustomerVO to CustomersA
            CreateMap<CustomerVO, CustomersA>()
                .ForMember(t => t.CName, m => m.MapFrom(s => s.CompanyName));

            //V2E CustomerVO to Customers Entity
            CreateMap<CustomerVO, Customers>();
               
        }
    }
}
