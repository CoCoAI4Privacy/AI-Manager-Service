using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ComputationManager.Options;
using ComputationManager.Utilities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ComputationManager.Controllers
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
        public IEnumerable<string> ProcessUrl(Uri url)
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
