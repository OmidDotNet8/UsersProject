using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UExample.DataLayer;

namespace UExample.Core
{
    public class UserServices : IUser
    {
        private UExampleContext db;

        public UserServices(UExampleContext context)
        {
            this.db = context;
        }

        //Services

        public List<User> GetAllUsers()
        {
            return db.users.OrderBy(p => p.Id).ToList();
        }

        public User GetUserPassByID(Guid id)
        {
            return db.users.SingleOrDefault(p => p.Id == id);
        }

        public async Task<List<UserDetail>> GetAllUsersDetails()
        {
            return await db.userDetails.OrderBy(p => p.User_Id).ToListAsync();
        }

        public async Task<UserDetail> GetUserByID(Guid id)
        {
            return await db.userDetails.SingleOrDefaultAsync(p => p.User_Id == id);
        }

        public bool AddToUser(UserViewModel viewModel)
        {
            try
            {
                User user = new User()
                {
                    Id = CodeGenerator.GetId(),
                    Username = viewModel.Username,
                    Password = viewModel.Password
                };
                db.users.Add(user);
                db.SaveChanges();

                UserDetail userDetail = new UserDetail()
                {
                    User_Id = user.Id,
                    Mobile = "",
                    Bio = "Hey Guys! I'm there."
                };
                db.userDetails.Add(userDetail);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUser(UserDetail userDetail)
        {
            try
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DeleteUser(Guid id)
        {
            //User user = db.users.Single(p => p.Id == id);
            User user = GetUserPassByID(id);

            if (user != null)
            {
                db.users.Remove(user);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}


//public bool DeleteUser(Guid userid)
//{
//    try
//    {
//        var U = GetUserPassByID(userid);
//        DeleteUser(U);
//        return true;
//    }
//    catch (Exception)
//    {
//        return false;
//    }
//}

//public bool DeleteUser(User user)
//{
//    try
//    {
//        db.Entry(user).State = EntityState.Deleted;
//        return true;
//    }
//    catch (Exception)
//    {
//        return false;
//    }
//}
