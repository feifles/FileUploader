using AutoMapper;
using FileUploaderV2.Core.Models;
using FileUploaderV2.Controllers.Resources;
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
            CreateMap<DataFile, DataFileResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Company, KeyValuePairResource>();
            CreateMap<AppUser, KeyValuePairResource>();
            CreateMap<AppUser, AppUserResource>();
            CreateMap<DBConfig, DbConfigResource>();
            CreateMap<DBConfig, KeyValuePairResource>();
            CreateMap<DataFileTemplate, DataFileTemplateResource>();
            CreateMap<Group, SaveGroupResource>()
                .ForMember(gr => gr.AppUsers, opt => opt.MapFrom(au => au.AppUsers.Select(gr => gr.AppUserId)));
            CreateMap<Group, GroupResource>()
                .ForMember(gr => gr.Company, opt => opt.MapFrom(g => g.Company))
                .ForMember(gr => gr.AppUsers, opt => opt.MapFrom(au => au.AppUsers.Select(gr => new KeyValuePairResource { Id = gr.AppUser.Id, Name = gr.AppUser.Name })));
            CreateMap<Company, CompanyResource>()
                .ForMember(cr => cr.Group, opt => opt.MapFrom(g => g.Groups));

            //API Resource to Domain
            CreateMap<GroupQueryResource, GroupQuery>();
            CreateMap<SaveGroupResource, Group>()
                .ForMember(g => g.Id, opt => opt.Ignore())
                .ForMember(g => g.AppUsers, opt => opt.Ignore())
                .AfterMap((gr, g) => {
                    //Remove Unselected appUsers
                    var removedAppUsers = g.AppUsers.Where(au => !gr.AppUsers.Contains(au.AppUserId)).ToList();
                    foreach (var au in removedAppUsers)
                        g.AppUsers.Remove(au);

                    //Add new AppUsers
                    var addedAppUsers = gr.AppUsers.Where(id => !g.AppUsers.Any(f => f.AppUserId == id)).Select(id => new GroupAppUser { AppUserId = id }).ToList();
                    foreach (var au in addedAppUsers)
                        g.AppUsers.Add(au);

                });
        }
    }
}
