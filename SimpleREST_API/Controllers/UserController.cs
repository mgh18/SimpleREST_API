using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleREST_API.Data;
using SimpleREST_API.Models;

namespace SimpleREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private RESTDbContext _dbContext;

        public object EntitiyState { get; private set; }

        public UserController(RESTDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var users = _dbContext.UsersTbl.ToList();
                if (users.Count == 0)
                {
                    return StatusCode(404, "No User Found!");
                }
                return Ok(users);
            }

            catch (Exception)
            {
                return StatusCode(500, "An error has occurred.");
            }

        }

        [HttpPost("CreateUser")]
        public IActionResult Create([FromBody] UserRequest request)
        {
            UsersTbl user = new UsersTbl();
            user.Username = request.Username;
            user.Fullname = request.Fullname;
            user.City = request.City;
            user.Country = request.Country;


            try
            {
                _dbContext.UsersTbl.Add(user);
                _dbContext.SaveChanges();
            }

            catch (Exception)
            {
                return StatusCode(500, "An error has occurred.");
            }

            var users = _dbContext.UsersTbl.ToList();
            return Ok(users);
        }

        [HttpPut("UpdateUser")]
        public IActionResult Update([FromBody] UserRequest request)
        {
            try
            {
                var user = _dbContext.UsersTbl.FirstOrDefault(x => x.Id == request.Id);
                if (User == null)
                {
                    return StatusCode(404, "User Not Found");

                }
               
                user.Username = request.Username;
                user.Fullname = request.Fullname;
                user.City = request.City;
                user.Country = request.Country;

                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occurred.");
            }
            var users = _dbContext.UsersTbl.ToList();
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{Id}")]
        public IActionResult Delete(int id)
        {
            try 
            {
                var user = _dbContext.UsersTbl.FirstOrDefault(x => x.Id == id );
                if (User == null)
                {
                    return StatusCode(404, "User Not Found");

                }
                _dbContext.Entry(user).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occurred.");
            }
            var users = _dbContext.UsersTbl.ToList();
            return Ok(users);
        }

    }
}
