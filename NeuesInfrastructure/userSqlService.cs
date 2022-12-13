using Microsoft.EntityFrameworkCore;
using Neues.Core.Interface;
using Neues.Core.Models;
using Neues.Model;
using NeuesCore.Data;
using NeuesCore.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Infrastructure
{
    public class userSqlService : IUser 
    {
        private readonly NeuesDbContext _neuesDbContext;

        public userSqlService(NeuesDbContext neuesDbContext)
        {
            _neuesDbContext = neuesDbContext;
        }

        public async Task<User> DeleteUser(Guid Id)
        {
            var user = await _neuesDbContext.Users.FindAsync(Id);

            if (user != null)
            {
                _neuesDbContext.Remove(user);
                await _neuesDbContext.SaveChangesAsync();
                return user;
            }
            throw new Exception($"{user} not found");
        }


        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await _neuesDbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<User> GetUser(Guid Id)
        {
            var user = await _neuesDbContext.Users.FindAsync(Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public async Task UpdateUser(User user)
        {
            var userUpdate = await _neuesDbContext.Users.FindAsync(user.Id);
            if (userUpdate != null)
            {
                userUpdate.FullName = user.FullName;
                userUpdate.Password = user.Password;
                userUpdate.Country = user.Country;
                userUpdate.ModifieddDate = DateTime.Now;

                await _neuesDbContext.SaveChangesAsync();

            }


        }

        public async Task<User> CreateUser(User user)
        {
            var NewUser = new User
            {
                Id = new Guid(),
                FullName = user.FullName,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Country = user.Country,
                RegisteredDate = DateTime.Now,
                ModifieddDate = DateTime.Now,

            };
            await _neuesDbContext.Users.AddAsync(NewUser);
            await _neuesDbContext.SaveChangesAsync();

            return NewUser;
        }

        public async Task<bool> UpdateUserPassword(string email, string password)
        {
            var userUpdate = await _neuesDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (userUpdate != null)
            {
                userUpdate.Password = password;
                userUpdate.ModifieddDate = DateTime.Now;
                await _neuesDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> IsUserExist(string email)
        {
            var user = await _neuesDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return true;
        }


        /*public async Task<User> ResetPassword(ForgotPassword password)
        {
            var user = await _neuesDbContext.Users.FindAsync(password.Email);
            if (user == null)
                throw new Exception("User not found");
            else
            
                {
                    //Create URL with above token
                    var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserName, code = token }, "http") + "'>Reset Password</a>";
                    //HTML Template for Send email
                    string subject = "Your changed password";
                    string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;
                    //Get and set the AppSettings using configuration manager.
                    EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);
                    //Call send email methods.
                    EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);
                }
         

            return user;
        }*/
    }
}
