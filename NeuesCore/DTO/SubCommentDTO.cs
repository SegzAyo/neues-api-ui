using System;
using NeuesCore.Models;

namespace Neues.Core.Models.DTO
{
    public class SubCommentDTO
    {
        public Guid MainCommentId{ get; set; }

        public string Message { get; set; }

        public Guid UserId { get; set; }
    }
}

