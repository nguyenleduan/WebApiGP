using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using WebApiGP.Models;

namespace WebApiGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> listUser = new List<User>();
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(listUser);
        }
        [HttpGet("{id}")]
        public IActionResult getUserID(string id)
        {
            try
            { 
                var user = listUser.SingleOrDefault(u => u.Id == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(new { Success = true, data = user });
            }
            catch
            { 
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult getUpdateUserID(string id,User userEdit)
        {
            try
            { 
                var user = listUser.SingleOrDefault(u => u.Id == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }
                if(id != user.Id.ToString())
                { 
                    return BadRequest();
                }
                user.Name = userEdit.Name;
                user.Count = userEdit.Count;
                user.Address = userEdit.Address;
                return Ok(new { Success = true, data = user });
            }
            catch
            { 
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(InfoUSer info)
        {
            var mUser = new User
            { 
                Id = Guid.NewGuid(),
                Address = info.Address,
                Name = info.Name,
                Count = info.Count
            };
            listUser.Add(mUser);

            return Ok(new { Success  = true,data = listUser});
        }
    }
}
