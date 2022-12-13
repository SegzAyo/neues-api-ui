using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuesCore.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public Guid UserId { get; set; }

        public User user { get; set; }
        
    }

}
