using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDetroit.Service
{
    public static class AutoMapperServiceConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Data.Models.UserProfile, Service.Models.UserProfile>();
                cfg.CreateMap<Data.Models.Location, Service.Models.Location>();
            });
        }
    }
}