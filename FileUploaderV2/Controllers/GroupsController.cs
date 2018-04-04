using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploaderV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploaderV2.Controllers
{
    [Produces("application/json")]
    [Route("api/Groups")]
    public class GroupsController : Controller
    {
        [HttpPost]
        public IActionResult CreateGroup(Group group)
        {
            return Ok(group);
        }
    }
}