using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Core.Models
{
    public class PostDTO
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public IFormFile? Image { get; set; }

        public IFormFile? Video { get; set; }

        public IFormFile ThumbNail { get; set; }

        public string? Youtube { get; set; }

        public string Description { get; set; }

        public string? Tags { get; set; }

        public string Category { get; set; }
    }
}

