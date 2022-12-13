using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuesCore.Models
{
    public class SubComment : Comment
    {
        public Guid MainCommentId { get; set; }

        public MainComment MainComment { get; set; }
        
    }
}
