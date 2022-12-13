using System;
using Neues.Model;
using System.Threading.Tasks;

namespace Neues.Interface
{
    public interface IPost
    {
        public Task<IEnumerable<Post>> GetAllPost(string param);

        public Task<IEnumerable<Post>> PostHome();

        public Task<Post> GetPost(Guid Id);

        public Task UpdatePost(Post post);

        public Task<Post> DeletePost(Guid Id);

        public Task<Post> CreatePost(Post post);

        public Task<IEnumerable<Post>> RelatedPost(string tag);
    }
}

