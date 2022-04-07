using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGP.Data;
using WebApiGP.Models;

namespace WebApiGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDetailController : ControllerBase
    {
        //private readonly MyDbContext _dbContext;

        //public ClientDetailController(MyDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //} 

        [HttpGet("GetAllClientDetail")]
        public IActionResult GetAllClientDetail()
        {
            try
            { 
                using (var db = new MyDbContext())
                {
                    var clientDetails = db.ClientDetail.ToList();
                    if (!clientDetails.Any())
                    {
                        return Ok(Result.Failure("Data empty"));
                    } 
                    return Ok(Result.Success(clientDetails));
                } 
            }
            catch (Exception)
            {
                return StatusCode(500, "Error get all client detail");
            }
        }
        [HttpGet("SearchClientDetail/{id}")]
        public IActionResult SearchClientDetail(long id)
        {
            try
            { 
                using (var db = new MyDbContext())
                {
                    var clientDetails = db.ClientDetail.FirstOrDefault(u => u.idClientDetail == id); 
                    if (clientDetails==null)
                    {
                        return Ok(Result.Failure("Data empty"));
                    }  
                    return Ok(Result.Success(clientDetails));
                } 
            }
            catch (Exception)
            { 
                return Ok(Result.Failure("Error get all client detail"));
            }
        } 


        [HttpPost("CreateClienDetail")]
        public IActionResult CraeateClientDetail([FromBody] ClientDetailRequest request)
        {

            try
            {
                ClientDetail client = new ClientDetail();
                client.idFamily = request.idFamily;
                client.idGiaPhaChild = request.idGiaPhaChild;
                client.idLocationDied = request.idLocationDied;
                client.firstName = request.firstName;
                client.lastName = request.lastName;
                client.birthDay = request.birthDay;
                client.diedDay = request.diedDay;
                client.status = request.status;
                client.phone = request.phone;
                client.avatar = request.avatar;
                client.idLocationHome = request.idLocationHome;

                using (var db = new MyDbContext())
                {
                    db.ClientDetail.Add(client);
                    db.SaveChanges();
                }

            } catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString())); 
            }

            return Ok(Result.Success(1));
        }
        [HttpPut("UpdateClientDetail")]
        public IActionResult UpdateClientDetail()
        {
            return Ok();
        }
        [HttpDelete("DeleteClientDetail/{id}")]
        public IActionResult DeleteClientDetail(long Id)
        {
            return Ok();
        }
    }
}
