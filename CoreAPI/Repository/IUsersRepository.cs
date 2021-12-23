using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Repository
{
    public interface IUsersRepository
    {
        /// <summary>
        ///  Get All Users From UserDB
        /// </summary>
        /// <returns> List of Users</returns>
        Task<List<User>> GetAllUsers();

        /// <summary>
        /// Returns Single user based in UserID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        Task<User> Getuser(int UserID);

        /// <summary>
        ///  Create user and return user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> CreateUser(User user);
        /// <summary>
        /// Update user and returnd updated user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> UpdateUser(User user);


        /// <summary>
        /// Delete user and retuns Deleted user
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        Task<User> DeleteUser(int UserID);
    }
}
