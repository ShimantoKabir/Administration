using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Administration.Models
{
    public class EmailRequest
    {
        public List<string> emails { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public List<IFormFile> attachments { get; set; }
    }
}