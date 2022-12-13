using Neues.Model;
using NeuesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Interface
{
    public interface IMainComment
    {
        public Task<IEnumerable<MainComment>> GetAllMainComment(Post post);

        //public Task<MainComment> GetMainComment(Guid Id);

        public Task UpdateMainComment(MainComment mainComment);

        public Task<MainComment> DeleteMainComment(Guid Id);

        public Task<MainComment> CreateMainComment(MainComment mainComment);
    }
}
