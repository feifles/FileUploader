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
    [Route("api/FileTypeTemplate")]
    public class DataFileTemplateController : Controller
    {
        private readonly FileUploaderDbContext context;
        private readonly IMapper mapper;

        public DataFileTemplateController(FileUploaderDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/FileTypeTemplate")]
        public async Task<IEnumerable<DataFileTemplateResource>> GetFileTypeTemplate()
        {
            return null;
        }
    }
}