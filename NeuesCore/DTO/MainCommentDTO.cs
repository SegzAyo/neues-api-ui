﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Core.DTO
{
    public class MainCommentDTO
    {
        public Guid PostId { get; set; }

        public string Message { get; set; }

        public Guid UserId { get; set; }

    }
}
