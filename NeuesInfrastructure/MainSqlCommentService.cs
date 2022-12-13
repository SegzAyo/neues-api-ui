using Microsoft.EntityFrameworkCore;
using Neues.Interface;
using Neues.Model;
using NeuesCore.Data;
using NeuesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Infrastructure
{
    public class MainSqlCommentService : IMainComment
    {
        private readonly NeuesDbContext _neuesDbContext;

        public MainSqlCommentService(NeuesDbContext neuesDbContext)
        {
            _neuesDbContext = neuesDbContext;
        }



        public async Task<MainComment> DeleteMainComment(Guid Id)
        {

            var mainComment =  await _neuesDbContext.mainComments.FirstOrDefaultAsync(c => c.Id == Id);
            if (mainComment != null)
            {
                _neuesDbContext.Remove(mainComment);
                await _neuesDbContext.SaveChangesAsync();
                return mainComment;
            }
            throw new Exception($"{mainComment} not found");
        }


        public async Task<IEnumerable<MainComment>> GetAllMainComment(Post post)
        {
            var mainComments = _neuesDbContext.mainComments.Where(c => c.Post.Id == post.Id);

            if (mainComments != null)

                await mainComments.ToListAsync();
                var listSorted = mainComments.OrderByDescending(d => d.DateCreated);

            return listSorted;

            throw new Exception("No comments");
        }


        //public async Task<MainComment> GetMainComment(Guid Id)
        //{
        //    var mainComments = await _neuesDbContext.Posts.FirstOrDefaultAsync(allPost => allPost.Id.Equals(post.Id));
        //    var maincomment = await _neuesDbContext.mainComments.FindAsync(Id);
        //    if (maincomment == null)
        //    {
        //        throw new Exception("Post not found");
        //    }

        //    return maincomment;
        //}

        public async Task UpdateMainComment(MainComment mainCommentUpdate)
        {
            //var mainCommnetUpdate = await _neuesDbContext.Posts.FirstOrDefaultAsync(c => c.Comments.ToList().Contains(MComment));

            var mainComment = await _neuesDbContext.mainComments.FindAsync(mainCommentUpdate.Id);
            if (mainComment != null)
            {
                mainComment.Message = mainCommentUpdate.Message;
                mainComment.DateUpdated = DateTime.Now;

                await _neuesDbContext.SaveChangesAsync();
            }


        }

        public async Task<MainComment> CreateMainComment(MainComment mainComment)
        {
            var commentUser = await _neuesDbContext.Users.FirstOrDefaultAsync(x => x.Id == mainComment.UserId);
                if (commentUser == null)
                    throw new Exception("User not registered");

            
            var post = await _neuesDbContext.Posts.FirstOrDefaultAsync(x => x.Id == mainComment.PostId);
            if (post == null)
                throw new Exception("Post not found");
            var CreateMainComment = new MainComment
            {
                Id = new Guid(),
                Post = post,
                UserName = commentUser.UserName,
                Message = mainComment.Message,
                DateCreated = DateTime.Now,
                UserId = mainComment.UserId
            };

            await _neuesDbContext.mainComments.AddAsync(CreateMainComment);
            await _neuesDbContext.SaveChangesAsync();

            return CreateMainComment;
        }
    }
}
