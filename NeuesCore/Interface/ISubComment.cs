using NeuesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Core.Interface
{
    public interface ISubComment
    {
        public Task<IEnumerable<SubComment>> GetSubComments(MainComment mainComment);

        //public Task<SubComment> GetSubComment(Guid Id);

        public Task UpdateSubComment(SubComment subComment);

        public Task<SubComment> DeleteSubComment(Guid Id);

        public Task<SubComment> CreateSubComment(SubComment subComment);
    }
}
