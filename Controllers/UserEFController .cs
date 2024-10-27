using DotnetAPI.Data;
using DotnetAPI.Dots;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    DataContextEF _entityFramework;
    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
    }


    [HttpGet("GetUsers")]
    // public IEnumerable<User> GetUsers()
    public IEnumerable<User> GetUsers()
    {

        IEnumerable<User> users = _entityFramework.Users.ToList<User>();
        return users;

    }

    [HttpGet("GetSingleUser/{userId}")]
    // public IEnumerable<User> GetUsers()
    public User GetSingleUser(int userId)
    {

        User? user = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();
        if (user != null)
        {
            return user;
        }
        throw new Exception("Can't get an user !");
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        User? userdb = _entityFramework.Users.Where(u => u.UserId == user.UserId).FirstOrDefault<User>();
        if (userdb != null)
        {
            userdb.Active = user.Active;
            userdb.FirstName = user.FirstName;
            userdb.LastName = user.LastName;
            userdb.Email = user.Email;
            userdb.Gender = user.Gender;

            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            throw new Exception("Faild to Update User");

        }
        throw new Exception("Faild to Edit User");
    }




    [HttpPost("AddUser")]
    public IActionResult AddUser(UserDto user)
    {
        User userdb = new User();
        userdb.Active = user.Active;
        userdb.FirstName = user.FirstName;
        userdb.LastName = user.LastName;
        userdb.Email = user.Email;
        userdb.Gender = user.Gender;

        _entityFramework.Add(userdb);
        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok();
        }

        throw new Exception("Failed to Add User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        User? userdb = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();
        if (userdb != null)
        {
            _entityFramework.Remove(userdb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            throw new Exception("Failed to Delete User");
        }
        throw new Exception("Failed to Get User");

    }
}
