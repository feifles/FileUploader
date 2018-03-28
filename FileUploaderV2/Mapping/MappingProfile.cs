using AutoMapper;
using FileUploaderV2.Models;
using FileUploaderV2.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyResource>();
            CreateMap<Group, GroupResource>();
        }
    }
}
