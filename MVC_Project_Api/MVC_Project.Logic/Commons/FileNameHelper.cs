using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;

namespace MVC_Project.Logic.Commons
{
    public static class FileNameHelper
    {
        public static string CreateUniqueFileName(IFormFile file)
        {
            var orgFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var result = Guid.NewGuid() + "-" + orgFileName;
            return result;
        }
    }
}
