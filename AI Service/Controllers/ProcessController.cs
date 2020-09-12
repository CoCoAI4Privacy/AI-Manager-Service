using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AI_Manager_Service.Options;
using AI_Manager_Service.Utilities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AI_Manager_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly ApiOptions ApiOptions;
        private readonly ILogger<ProcessController> Logger;

        public ProcessController(IOptions<ApiOptions> apiOptions, ILogger<ProcessController> logger)
        {
            apiOptions.Should().NotBeNull();

            ApiOptions = apiOptions.Value;
            Logger = logger;
        }

        [HttpPost]
        public IEnumerable<string> Url(string url)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> FileAsync(IFormFile file)
        {
            if (Validation.IsNull(file) || Validation.FileSizeExceedsBounds(file, ApiOptions.MinFileSize, ApiOptions.MaxFileSize))
            {
                Logger.LogDebug("File was either null or exceeded size bounds.");
                return StatusCode(StatusCodes.Status400BadRequest, $"File must be between {ApiOptions.MinFileSize} and {ApiOptions.MaxFileSize} bytes.");
            }
            else
            {
                string filePath = Path.GetTempFileName();

                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream).ConfigureAwait(false);
                }
            }
            throw new NotImplementedException();
        }
    }
}
