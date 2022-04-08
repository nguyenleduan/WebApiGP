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
    public class IDGiaPhaController : Controller
    {

        [HttpGet("GetAllClientInIdGiaPha/{id}")]
        public IActionResult GetAllClientInIdGiaPha(long id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.idGiaPha.FromSqlInterpolated($"EXECUTE [dbo].[getAllIDGiaPha] @id={id}").ToList(); 
                    if (!gp.Any())
                    {
                        return Ok(Result.Failure("Data empty"));
                    }
                    return Ok(Result.Success(gp[0]));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }

        [HttpGet("GetAllIdGiaphaStore/{id}")]
        public IActionResult GetAllIdGiaphaStore(long id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.idGiaPha.FromSqlInterpolated($"EXECUTE [dbo].[getAllIDGiaPha] @id={id}").ToList(); 
                    if (!gp.Any())
                    {
                        return Ok(Result.Failure("Data empty"));
                    }
                    return Ok(Result.Success(gp[0]));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
        [HttpGet("GetAllIdGiaPha")]
        public IActionResult GetAllIdGiaPha()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.idGiaPha.ToList();
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
        [HttpGet("SearchIdGiaPha/{id}")]
        public IActionResult SearchIdGiaPha(long id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.idGiaPha.FirstOrDefault(u => u.idGiaPha == id);
                    if (gp == null)
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


        [HttpPost("CreateClienIdGiaPha")]
        public IActionResult CreateClienIdGiaPha([FromBody] IDGiaPhaRequest request)
        {

            try
            {
                IDGiaPha gp = new IDGiaPha();
                gp.pass = request.pass;
                gp.codeGiaPha = request.codeGiaPha;
                gp.author = request.author; 
                using (var db = new MyDbContext())
                {
                    db.idGiaPha.Add(gp);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }

            return Ok(Result.Success(1));
        }
        [HttpPut("UpdateIdGiaPha/{id}")]
        public IActionResult UpdateIdGiaPha([FromBody] IDGiaPhaRequest request, long id)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.idGiaPha.FirstOrDefault(u => u.idGiaPha == id);
                    if (gp == null)
                    {
                        return Ok(Result.Failure("Data in data base empty"));
                    } 
                    else if (string.IsNullOrEmpty(request.pass))
                    {
                        return Ok(Result.Failure("pass cannot be empty"));
                    }
                    else if (string.IsNullOrEmpty(request.author))
                    {
                        return Ok(Result.Failure("author cannot be empty"));
                    }
                    gp.author = request.author;
                    gp.pass = request.pass;
                    gp.codeGiaPha = request.codeGiaPha;
                    db.Entry(gp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok(Result.Success(1));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
        [HttpDelete("DeleteIdGiaPha/{id}")]
        public IActionResult DeleteIdGiaPha(long id)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.idGiaPha.FirstOrDefault(u => u.idGiaPha == id);
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
