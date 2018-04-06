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
using Microsoft.EntityFrameworkCore;

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
            //Check input based on DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Excess validation
            //Check for constraint error ('FK not found') for companyId
            //var company = await dbContext.Companies.FindAsync(groupResource.CompanyId);
            //if (company == null)
            //{
            //    ModelState.AddModelError("CompanyId", "Invalid companyId.");
            //    return BadRequest(ModelState);
            //}
                

            var group = mapper.Map<GroupResource, Group>(groupResource);
            group.LastUpdate = DateTime.UtcNow;


            await dbContext.AddAsync(group);
            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Group, GroupResource>(group);

            return Ok(result);
        }

        [HttpPut("{id}")] // /api/groups/1
        public async Task<IActionResult> UpdateGroup(int id, [FromBody] GroupResource groupResource)
        {
            //Check input based on DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Excess validation
            //Check for constraint error ('FK not found') for companyId
            //var company = await dbContext.Companies.FindAsync(groupResource.CompanyId);
            //if (company == null)
            //{
            //    ModelState.AddModelError("CompanyId", "Invalid companyId.");
            //    return BadRequest(ModelState);
            //}

            var group = await dbContext.Groups.Include(g => g.AppUsers).SingleOrDefaultAsync(g => g.Id == id);
            if (group == null)
                return NotFound();


            mapper.Map<GroupResource, Group>(groupResource, group);
            group.LastUpdate = DateTime.UtcNow;

            dbContext.Update(group);
            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Group, GroupResource>(group);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteGroup(int id)
        {
            var group = await dbContext.Groups.FindAsync(id);

            if (group == null)
                return NotFound();

            dbContext.Remove(group);
            await dbContext.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup (int id)
        {
            var group = await dbContext.Groups.Include(g => g.AppUsers).SingleOrDefaultAsync(g => g.Id == id);

            if (group == null)
                return NotFound();

            var groupResource = mapper.Map<Group, GroupResource>(group);

            return Ok(groupResource);
        }
    }
}