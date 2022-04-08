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
    public class FamilyController : Controller
    {

        [HttpGet("GetAllFamily")]
        public IActionResult GetAllFamily()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var Family = db.Family.ToList();
                    if (!Family.Any())
                    {
                        return Ok(Result.Failure("Data empty"));
                    }
                    return Ok(Result.Success(Family));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
        [HttpGet("SearchFamily/{id}")]
        public IActionResult SearchFamily(long id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var family = db.Family.FirstOrDefault(u => u.idFamily == id);
                    if (family == null)
                    {
                        return Ok(Result.Failure("Data empty"));
                    }
                    return Ok(Result.Success(family)); 
                }

            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        } 
        [HttpPost("CreateFamily")]
        public IActionResult CraeateClientDetail([FromBody] FamilyRequest request)
        {


            try
            {
                Family family = new Family();
                family.idGiaPha = request.idGiaPha;
                family.idLocationHome = request.idLocationHome;
                family.bigIdFamily = request.bigIdFamily;
                using (var db = new MyDbContext())
                {
                    db.Family.Add(family);
                    db.SaveChanges();
                }
                return Ok(Result.Success(1));
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
        [HttpPut("UpdateFamily/{id}")]
        public IActionResult UpdateFamily([FromBody] FamilyRequest request, long id)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var family = db.Family.FirstOrDefault(u => u.idFamily == id);
                    if (family == null)
                    {
                        return Ok(Result.Failure("Data empty"));
                    }
                    family.idGiaPha = request.idGiaPha;
                    family.idLocationHome = request.idLocationHome;
                    family.bigIdFamily = request.bigIdFamily; 
                    db.Entry(family).State = EntityState.Deleted;
                    db.Family.Add(family);
                    db.SaveChanges();
                    return Ok(Result.Success(1));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
        [HttpDelete("DeleteFamily/{id}")]
        public IActionResult DeleteFamily(long id)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var family = db.Family.FirstOrDefault(u => u.idFamily == id);
                    if (family == null)
                    {
                        return Ok(Result.Failure("Client Not found"));
                    }
                    db.Entry(family).State = EntityState.Deleted;
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
