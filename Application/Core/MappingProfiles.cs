using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            //Finance App
            CreateMap<Expense, Expense>();
            CreateMap<Revenue, Revenue>();
             CreateMap<Item, Item>();
            CreateMap<Category, Category>();

        }
    }
}