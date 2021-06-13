using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        readonly IBlobStorage _blobStorage;
        public FileController(IBlobStorage blobStorage)
        {
            _blobStorage = blobStorage;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> UploadAsync(string fileName)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                await _blobStorage.UploadAsnyc(fileStream, Path.GetFileName(fileName), "files");
                return Ok(true);
            }
            catch
            {
                return Ok("Beklenmeyen bir hatayla karşılaşıldı.");
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadAsync(string fileName, string containerName)
        {
            try
            {
                Stream stream = await _blobStorage.DownloadAsync(fileName, containerName);
                //return File(stream, "application/octet-stream", fileName);
                return File(stream, "application/text", fileName);
            }
            catch
            {
                return Ok("Beklenmeyen bir hatayla karşılaşıldı.");
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> DeleteAsync(string fileName, string containerName)
        {
            try
            {
                await _blobStorage.DeleteAsync(fileName, containerName);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }
        [HttpGet("[action]")]
        public IActionResult GetNames(string containerName)
        {
            return Ok(_blobStorage.GetNames(containerName));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLogAsync(string fileName)
        {
            return Ok(await _blobStorage.GetLogAsync(fileName));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> SetLogAsync(string text, string fileName)
        {
            try
            {
                await _blobStorage.SetLogAsync(text, fileName);
                return Ok(true);
            }
            catch
            {

                return Ok("Beklenmeyen bir hatayla karşılaşıldı.");
            }
        }
    }
}
