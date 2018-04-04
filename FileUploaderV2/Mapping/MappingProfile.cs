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
            //Domain to API Resource
            CreateMap<Company, CompanyResource>();
            CreateMap<Group, GroupResource>()
                .ForMember(gr => gr.AppUsers, opt => opt.MapFrom(au => au.AppUsers.Select(gr => gr.AppUserId)));
            CreateMap<AppUser, AppUserResource>();
            CreateMap<DataFileTemplate, DataFileTemplateResource>();


            //API Resource to Domain
            CreateMap<GroupResource, Group>()
                .ForMember(g => g.AppUsers, opt => opt.MapFrom(gr => gr.AppUsers.Select(id => new GroupAppUser { AppUserId = id })));
        }
    }
}
