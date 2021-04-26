using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FileUploaderV2.Core.Models;
using FileUploaderV2.Controllers.Resources;
using FileUploaderV2.Core;
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
        private readonly IGroupRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public GroupsController(IMapper mapper, IGroupRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] SaveGroupResource groupResource)
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
                

            var group = mapper.Map<SaveGroupResource, Group>(groupResource);
            group.LastUpdate = DateTime.UtcNow;


            repository.Add(group);
            await unitOfWork.CompleteAsync();

            group = await repository.Get(group.Id);

            var result = mapper.Map<Group, GroupResource>(group);

            return Ok(result);
        }

        [HttpPut("{id}")] // /api/groups/1
        public async Task<IActionResult> UpdateGroup(int id, [FromBody] SaveGroupResource groupResource)
        {
            //Check input based on DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var group = await repository.Get(id);

            if (group == null)
                return NotFound();


            mapper.Map<SaveGroupResource, Group>(groupResource, group);
            group.LastUpdate = DateTime.UtcNow;

            await unitOfWork.CompleteAsync();

            group = await repository.Get(group.Id);

            var result = mapper.Map<Group, GroupResource>(group);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteGroup(int id)
        {
            var group = await repository.Get(id, includeRelated: false);

            if (group == null)
                return NotFound();

            repository.Remove(group);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup (int id)
        {
            var group = await repository.Get(id);

            if (group == null)
                return NotFound();

            var groupResource = mapper.Map<Group, GroupResource>(group);

            return Ok(groupResource);
        }

        [HttpGet("/api/Groups/GetGroups")]
        public async Task<IActionResult> GetGroups(int id)
        {
            //Check input based on DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var groups = await repository.GetGroupsFromCompany(id);

            if (groups == null)
                return NotFound();
            else
                return Ok(mapper.Map<IEnumerable<Group>, IEnumerable<GroupResource>>(groups));

        }

        [HttpGet("/api/Groups/GetAllGroups")]
        public async Task<QueryResultResource<GroupResource>> GetAllGroups(GroupQueryResource filterResource)
        {
            var filter = mapper.Map<GroupQueryResource, GroupQuery>(filterResource);

            var queryResult = await repository.Get(filter);

            return mapper.Map<QueryResult<Group>, QueryResultResource<GroupResource>>(queryResult);

        }
    }
}