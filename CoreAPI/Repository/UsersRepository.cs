using CoreAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserContext _userContext;
        public UsersRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var result = await _userContext.Users.ToListAsync();
            return result;
        }
        public async Task<User> Getuser(int UserID)
        {
            var result = await _userContext.Users.FirstOrDefaultAsync(user => user.UserID == UserID);
            return result;
        }
        public async Task<User> CreateUser(User user)
        {
            try
            { 
                var result = _userContext.Users.Add(user);
                await _userContext.SaveChangesAsync();
                return (User)result.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<User> UpdateUser(User user)
        {
            try
            {
                User Modifieduser = await _userContext.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
                if (Modifieduser==null)
                {
                    throw new Exception("Record Not Exist for Modification!!");
                }
                Modifieduser.FirstName = user.FirstName;
                Modifieduser.LastName = user.LastName;
                Modifieduser.JobRole = user.JobRole;
                Modifieduser.CarrerLevel = user.CarrerLevel;
                var result = _userContext.Users.Update(Modifieduser);
                await _userContext.SaveChangesAsync();
                return (User)result.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<User> DeleteUser(int UserID)
        {
            try
            {
                User Deleteduser = await _userContext.Users.FirstOrDefaultAsync(u => u.UserID == UserID);
                if (Deleteduser == null)
                {
                    throw new Exception("No Record Exist to delete!!");
                }
                Deleteduser.isdeleted = true;
                var result = _userContext.Users.Update(Deleteduser);
                await _userContext.SaveChangesAsync();
                return (User)result.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
