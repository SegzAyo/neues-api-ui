using System;
using Neues.Core.Models;

namespace Neues.Core.DTO
{
    public class PutDTO : PostDTO
    {
        public Guid Id { get; set; }
    }

}