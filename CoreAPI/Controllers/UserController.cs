using CoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly List<User> users;
        private IConfiguration _configuration;
        private readonly IUsersRepository _userrepository;
        public UserController(IConfiguration configuration, IUsersRepository userRepository)
        {
            _configuration = configuration;
            _userrepository = userRepository;
            //users = new List<User>() {
            //   new User(){ UserID=1,FirstName = "Phaneendra", LastName="phaneendra",JobRole="Programmer",CarrerLevel=11 },
            //   new User(){ UserID=2,FirstName = "Kumar", LastName="Kumar",JobRole="Programmer",CarrerLevel=11 },
            //   new User(){ UserID=3,FirstName = "Poka", LastName="poka",JobRole="Programmer",CarrerLevel=11 }
            //};
        }

        //[HttpGet]
        //[Route("AllUsers")]
        //public  GetAllUsers()
        //{
            
        //}
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _userrepository.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return  StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("Getusers")]
        public async Task<IActionResult> GetUser(int userID)
        {
            try
            {
                var result = await _userrepository.Getuser(userID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                if (user == null || string.IsNullOrEmpty(user.FirstName) ||
                    user.CarrerLevel == 0 || user.CarrerLevel > 13 || 
                    user.CarrerLevel < 1)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }
                User CreatedUser = await _userrepository.CreateUser(user);
                return Ok(CreatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }
                User updateduser = await _userrepository.UpdateUser(user);
                return Ok(updateduser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] int userID)
        {
            try
            {
                if (userID == 0)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }
                User updateduser = await _userrepository.DeleteUser(userID);
                return Ok(updateduser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
