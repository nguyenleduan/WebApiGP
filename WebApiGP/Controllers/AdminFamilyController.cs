using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGP.Data;
using WebApiGP.Models;
using WebApiGP.Models.Request;

namespace WebApiGP.Controllers
{
    public class AdminFamilyController : Controller
    {
        [HttpGet("GetAllAdminOfFamily/{idGiaPha}")]
        public IActionResult GetAllAdminOfFamily(long idGiaPha)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.AdminFamily.FromSqlInterpolated($"EXECUTE [dbo].[getAllAdminOfgFamilyGiaPha] @idGiaPha={idGiaPha}").ToList();
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

        [HttpPost("CreateAdminOfFamily")]
        public IActionResult CreateAdminOfFamily([FromBody] AdminFamilyRequest request)
        {

            try
            {
                if (request.idFamily == null)
                {
                    return Ok(Result.Failure("idFamily not null"));
                }
                if (request.idGiaPha == null)
                {
                    return Ok(Result.Failure("idGiaPha not null"));
                }
                if (string.IsNullOrEmpty(request.phone))
                {
                    return Ok(Result.Failure("phone not empty or null"));
                }
                AdminFamily gp = new AdminFamily();
                gp.idGiaPha = (long)request.idGiaPha;
                gp.phone = request.phone;
                gp.idFamily = request.idFamily;
                using (var db = new MyDbContext())
                {
                    db.AdminFamily.Add(gp);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }

            return Ok(Result.Success(1));
        }
        [HttpDelete("DeleteIdAdminOfFamily/{idAdmin}")]
        public IActionResult DeleteIdAdminOfFamily(long idAdmin)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    db.AdminFamily.FromSqlInterpolated($"EXECUTE [dbo].[deleteAdminOfFamily] @idAdminFamily={idAdmin}").ToList();
                }
            }
            catch (Exception  )
            { 

            }

            return Ok(Result.Success(1));
        }
    }
}
