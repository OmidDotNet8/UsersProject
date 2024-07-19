using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UExample.DataLayer;

namespace UExample.Core
{
    public interface IUser : IDisposable
    {
        #region User Interfaces

        List<User> GetAllUsers();
        User GetUserPassByID(Guid id);
        Task<List<UserDetail>> GetAllUsersDetails();
        Task<UserDetail> GetUserByID(Guid id);
        bool AddToUser(UserViewModel viewModel);
        bool UpdateUser(UserDetail userDetail);
        void DeleteUser(Guid id);

        #endregion
    }
}


//bool DeleteUser(User user);
//bool DeleteUser(Guid userid);