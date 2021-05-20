using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace DigitalEventPlaner.Web.Models.MyEvents
{
    public class UploadViewModel
    {
        public List<IFormFile> Imagelist { get; set; }
        public int EventId { get; set; }
    }
}
