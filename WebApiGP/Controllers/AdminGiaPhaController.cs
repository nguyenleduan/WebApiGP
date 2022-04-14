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
    public class AdminGiaPhaController : Controller
    {
        [HttpGet("GetAdmin/{idGiaPha}")]
        public IActionResult GetAdminGiaPha(long idGiaPha)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.admin.FromSqlInterpolated($"EXECUTE [dbo].[getAdmin] @id={idGiaPha}").ToList();
                    if (!gp.Any())
                    {
                        return Ok(Result.Failure("Data empty"));
                    }
                    return Ok(Result.Success(gp));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminRequest request)
        {

            try
            {
                if(request.idGiaPha == null)
                { 
                    return Ok(Result.Failure("IdGiaPha not empty"));
                }
                Admin gp = new Admin();
                gp.idGiaPha = (long)request.idGiaPha;
                gp.phone = request.phone; 
                using (var db = new MyDbContext())
                {
                    db.admin.Add(gp);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }

            return Ok(Result.Success(1));
        }
        [HttpDelete("DeleteIdAdmin/{id}")]
        public IActionResult DeleteIdAdmin(long id)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.admin.FirstOrDefault(u => u.idAdmin == id);
                    if (gp == null)
                    {
                        return Ok(Result.Failure("Client Not found"));
                    }
                    db.Entry(gp).State = EntityState.Deleted;
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
