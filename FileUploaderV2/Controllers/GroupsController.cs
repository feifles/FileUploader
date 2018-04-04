using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FileUploaderV2.Models;
using FileUploaderV2.Models.Resources;
using FileUploaderV2.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploaderV2.Controllers
{
    [Produces("application/json")]
    [Route("api/Groups")]
    public class GroupsController : Controller
    {
        private readonly IMapper mapper;
        private readonly FileUploaderDbContext dbContext;

        public GroupsController(IMapper mapper, FileUploaderDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupResource groupResource)
        {
            var group = mapper.Map<GroupResource, Group>(groupResource);
            group.LastUpdate = DateTime.UtcNow;


            await dbContext.AddAsync(group);
            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Group, GroupResource>(group);

            return Ok(result);
        }
    }
}