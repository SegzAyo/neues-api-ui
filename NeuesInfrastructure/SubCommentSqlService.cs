using Microsoft.EntityFrameworkCore;
using Neues.Core.Interface;
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
    public class SubCommentSqlService : ISubComment
    {
        private readonly NeuesDbContext _neuesDbContext;

        public SubCommentSqlService(NeuesDbContext neuesDbContext)
        {
            _neuesDbContext = neuesDbContext;
        }


        public async Task<SubComment> DeleteSubComment(Guid Id)
        {

            var subComment = await _neuesDbContext.subComments.FirstOrDefaultAsync(c => c.Id == Id);
            if (subComment != null)
            {
                _neuesDbContext.Remove(subComment);
                await _neuesDbContext.SaveChangesAsync();
                return subComment;
            }
            throw new Exception($"{subComment} not found");
        }


        public async Task<IEnumerable<SubComment>> GetSubComments(MainComment mainComment)
        {
            var subComments = _neuesDbContext.subComments.Where(c => c.MainComment.Id == mainComment.Id);

            if (subComments != null)

                await subComments.ToListAsync();
                var listSorted = subComments.OrderByDescending(d => d.DateCreated);

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

        public async Task UpdateSubComment(SubComment subComment)
        {
            var subCommentUpdate = await _neuesDbContext.subComments.FindAsync(subComment.Id);

            if (subCommentUpdate != null)
            {
                subCommentUpdate.Message = subComment.Message;
                subCommentUpdate.DateUpdated = DateTime.Now;
            }

            await _neuesDbContext.SaveChangesAsync();
        }

        public async Task<SubComment> CreateSubComment(SubComment subComment)
        {
            var commentUser = await _neuesDbContext.Users.FirstOrDefaultAsync(x => x.Id == subComment.UserId);
            if (commentUser == null)
                throw new Exception("User not registered");

            var mainComment = await _neuesDbContext.mainComments.FirstOrDefaultAsync(x => x.Id == subComment.MainCommentId);
            if (mainComment != null)
            {
                var CreateSubComment = new SubComment
                {
                    Id = new Guid(),
                    MainComment = mainComment,
                    UserName = commentUser.UserName,
                    Message = subComment.Message,
                    DateCreated = DateTime.Now,
                    UserId = subComment.UserId
                };

                await _neuesDbContext.subComments.AddAsync(CreateSubComment);
                await _neuesDbContext.SaveChangesAsync();

                return CreateSubComment;
            }

            throw new Exception("Conflict error");
            
        }


    }
}
