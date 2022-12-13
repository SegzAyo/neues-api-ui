using NeuesCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Neues.Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        //public string? ImageFileName { get; set; }

        //public string? VideoFileName { get; set; }

        //public string ThumbNailFileName { get; set; }

        //public string? ImageFilePath { get; set; }

        //public string? VideoFilePath { get; set; }

        //public string ThumbNailFilePath { get; set; }

        public byte[]? Image { get; set; }

        public byte[]? Video { get; set; }

        public byte[] ThumbNail { get; set; }

        public string? Youtube { get; set; }

        public string Description { get; set; }

        public string? Tags { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public virtual ICollection<MainComment>? Comments { get; set; }

    }
}

