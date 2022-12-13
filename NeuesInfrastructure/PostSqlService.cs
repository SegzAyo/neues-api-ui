using Microsoft.EntityFrameworkCore;
using Neues.Core.Models;
using Neues.Interface;
using Neues.Model;
using NeuesCore.Data;
using System;
using System.Web;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
namespace Neues.Infrastructure
{
    public class PostSqlService : IPost
    {

        private readonly NeuesDbContext _neuesDbContext;

        public PostSqlService(NeuesDbContext neuesDbContext)
        {
            _neuesDbContext = neuesDbContext;
        }

        public async Task<Post> DeletePost(Guid Id)
        {
            var post = await _neuesDbContext.Posts.FindAsync(Id);
            try
            {
                if (post != null)
                {
                    _neuesDbContext.Posts.Remove(post);
                    await _neuesDbContext.SaveChangesAsync();
                    
                }
                else
                {
                    throw new Exception($"{post} not found");
                }

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return post;
        }

        public async Task<IEnumerable<Post>> PostHome()
        {
            try
            {
                var Allposts = await _neuesDbContext.Posts.ToListAsync();
                foreach (var post in Allposts)
                {
                    if (post.Image != null)
                    {
                        post.Image = this.GetImage(Convert.ToBase64String(post.Image));
                    }
                    else if (post.Video != null)
                    {
                        post.Video = this.GetImage(Convert.ToBase64String(post.Video));
                    }
                    else if (post.ThumbNail != null)
                    {
                        post.ThumbNail = this.GetImage(Convert.ToBase64String(post.ThumbNail));
                    }
                }

                var selectedPosts = Allposts.Take(40);
                var listSorted = selectedPosts.OrderByDescending(d => d.DateCreated);

                return listSorted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<Post>> GetAllPost(string param)
        {
            try
            {
                var Allposts = await _neuesDbContext.Posts.Where(c => c.Category == param).ToListAsync();

                foreach (var post in Allposts)
                {
                    if (post.Image != null)
                    {
                        post.Image = this.GetImage(Convert.ToBase64String(post.Image));
                    }
                    else if (post.Video != null)
                    {
                        post.Video = this.GetImage(Convert.ToBase64String(post.Video));
                    }
                    else if (post.ThumbNail != null)
                    {
                        post.ThumbNail = this.GetImage(Convert.ToBase64String(post.ThumbNail));
                    }
                }

                var listSorted = Allposts.OrderByDescending(d => d.DateCreated);

                return listSorted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private byte[] GetImage(string Base64Image)
        {
            byte[] imageBytes = null;
            if (!string.IsNullOrEmpty(Base64Image))
            {
                imageBytes = Convert.FromBase64String(Base64Image);
            }
            return imageBytes;
        }


        public async Task<Post> GetPost(Guid Id)
        {
            var post = await _neuesDbContext.Posts.FindAsync(Id);
            if (post == null)
            {
                throw new Exception("Post not found");
            }

            if (post.Image != null)
            {
                post.Image = this.GetImage(Convert.ToBase64String(post.Image));
            }
            else if (post.Video != null)
            {
                post.Video = this.GetImage(Convert.ToBase64String(post.Video));
            }
            else if (post.ThumbNail != null)
            {
                post.ThumbNail = this.GetImage(Convert.ToBase64String(post.ThumbNail));
            }

            return post;
        }

        public async Task UpdatePost(Post post)
        {
            var PostUpdate = await _neuesDbContext.Posts.FindAsync(post.Id);
            if (PostUpdate != null)
            {
                PostUpdate.ThumbNail = post.ThumbNail;
                PostUpdate.Image = post.Image;
                PostUpdate.Video = post.Video;
                PostUpdate.Title = post.Title;
                PostUpdate.Description = post.Description;
                PostUpdate.Category = post.Category;
                PostUpdate.Body = post.Body;
                PostUpdate.Tags = post.Tags;
                PostUpdate.DateModified = DateTime.Now;

                
             }

                await _neuesDbContext.SaveChangesAsync();
                
            }

        public async Task<Post> CreatePost(Post post)
        {
            try
            {
                post.Id = new Guid();

                await _neuesDbContext.Posts.AddAsync(post);
                await _neuesDbContext.SaveChangesAsync();
                return post;
            }
            catch (Exception x)
            {
                var error = x;
                return null;
            }
            
        }

        public async Task<IEnumerable<Post>> RelatedPost(string tag)
        {
            var relatedPost = await _neuesDbContext.Posts.Where(c => c.Tags == tag).ToListAsync();
            
            if (relatedPost == null)
            {
                throw new Exception("No related Post");
            }

            var selectedPosts = relatedPost.Take(5);
            var listSorted = selectedPosts.OrderByDescending(d => d.DateCreated);

            return listSorted;

        }

        //public async Task<Post> CreatePost(Post post)
        //{
        //    var NewPost = new Post
        //    {
        //        Id = new Guid(),
        //        Title = post.Title,
        //        Image =  "" ,
        //        Description = post.Description,
        //        Category = post.Category,
        //        Body = post.Body,
        //        Tags = post.Tags,
        //        DateCreated = DateTime.Now,
        //        DateModified = DateTime.Now,

        //    };
        //    await _neuesDbContext.Posts.AddAsync(NewPost);
        //    await _neuesDbContext.SaveChangesAsync();

        //    return NewPost;
        //}

    }
}

//public class ImageToString
//{
//    private void Index(HttpHostedFileBase file)
//    {
//        byte[] fileByte = new byte[file.Length];
//        file.InputStream.Read(fileByte, 0, file.ContentLength);
//    }

//}

