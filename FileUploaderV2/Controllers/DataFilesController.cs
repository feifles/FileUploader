using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FileUploaderV2.Controllers.Resources;
using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploaderV2.Controllers
{
    [Produces("application/json")]
    [Route("api/users/{userId}/datafiles")]
    public class DataFilesController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IAppUserRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DataFilesController(IHostingEnvironment host, IAppUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.host = host;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int userId, IFormFile file)
        {
            var user = await repository.Get(userId, false);
            if (user == null)
                return NotFound();

            var uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");

            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolderPath, fileName);

            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var dataFile = new DataFile() { FileName = fileName };
            user.DataFiles.Add(dataFile);

            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<DataFile, DataFileResource>(dataFile));
        }
    }
}