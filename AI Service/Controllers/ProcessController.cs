using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AI_Manager_Service.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AI_Manager_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly ILogger<ProcessController> _logger;

        public ProcessController(ILogger<ProcessController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<string> Url(string url)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> FileAsync(IFormFile file)
        {
            if (!Validation.NotNull(file) || !Validation.FileSize(file, 0, 5))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "File must be between 0 and 5 megabytes.");
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
