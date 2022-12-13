using Neues.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuesCore.Models
{
    public class MainComment : Comment
    {
        public Guid PostId { get; set; }

        public Post Post { get; set; }

        //public SubComment SubComment { get; set; }

        public virtual ICollection<SubComment> SubComments { get; set; }



    }
}
