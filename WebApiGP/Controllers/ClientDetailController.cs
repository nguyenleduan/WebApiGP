using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
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
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
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
        [HttpPut("UpdateClientDetail/{id}")]
        public IActionResult UpdateClientDetail([FromBody] ClientDetailRequest request, long id)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var client = db.ClientDetail.FirstOrDefault(u => u.idClientDetail == id);
                    if (client == null)
                    {
                        return Ok(Result.Failure("Data in data base empty"));
                    }  
                     if (request.idFamily == null)
                    {
                        return Ok(Result.Failure("idFamily cannot be empty"));
                    }
                    else if (request.status == null)
                    {
                        return Ok(Result.Failure("status cannot be empty"));
                    }
                    else if (string.IsNullOrEmpty(request.firstName))
                    {
                        return Ok(Result.Failure("firstName cannot be empty"));
                    }
                    else if (string.IsNullOrEmpty(request.lastName))
                    {
                        return Ok(Result.Failure("lastName cannot be empty"));
                    } 
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
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok(Result.Success(1));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
        [HttpDelete("DeleteClientDetail/{id}")]
        public IActionResult DeleteClientDetail(long id)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var client = db.ClientDetail.FirstOrDefault(u => u.idClientDetail == id);
                    if (client == null)
                    {
                        return Ok(Result.Failure("Client Not found"));
                    }
                    db.Entry(client).State = EntityState.Deleted;
                    db.SaveChanges();
                    return Ok(Result.Success(1));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
    }
}
