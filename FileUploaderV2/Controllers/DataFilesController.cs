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
using Microsoft.Extensions.Options;

namespace FileUploaderV2.Controllers
{
    [Produces("application/json")]
    [Route("api/users/{userId}/datafiles")]
    public class DataFilesController : Controller
    {
        private readonly DataFileSettings dataFileSettings;
        private readonly IHostingEnvironment host;
        private readonly IDataFileRepository dataFileRepository;
        private readonly IAppUserRepository appUserRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DataFilesController(IHostingEnvironment host, IAppUserRepository appUserRepository, IDataFileRepository dataFileRepository, IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<DataFileSettings> options)
        {
            this.dataFileSettings = options.Value;
            this.host = host;
            this.dataFileRepository = dataFileRepository;
            this.appUserRepository = appUserRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DataFileResource>> GetDataFiles(int userId)
        {
            var dataFiles = await dataFileRepository.GetDataFiles(userId);

            return mapper.Map<IEnumerable<DataFile>, IEnumerable<DataFileResource>>(dataFiles);
        }


        [HttpPost]
        public async Task<IActionResult> Upload(int userId, IFormFile file)
        {
            var user = await appUserRepository.Get(userId, false);
            if (user == null)
                return NotFound();

            if (file == null)
                return BadRequest("Arquivo nulo.");

            if (file.Length == 0)
                return BadRequest("Arquivo vazio.");

            if (file.Length > this.dataFileSettings.MaxBytes)
                return BadRequest("Tamanho do arquivo excedido. (<= 100mb)");

            if (!dataFileSettings.IsSupported(file.FileName))
                return BadRequest("Formato de arquivo inválido.");


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