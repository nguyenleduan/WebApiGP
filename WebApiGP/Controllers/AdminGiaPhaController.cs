using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Service.AdminGenealogys;
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

        private IAdminGenealogyService _IAdminGenealogy; 

        public AdminGiaPhaController(IAdminGenealogyService iAdminGenealogy)
        {
            _IAdminGenealogy = iAdminGenealogy;
        }

        [HttpGet("GetAllAdminFoGenealogy")]
        public async Task<IActionResult> GetAllAdminFoGenealogy(long idGenealogy)
        {
            try
            {
                var result = await _IAdminGenealogy.GetAllAdminFoGenealogy(idGenealogy);

                return Ok(Result.Success(result.Data));
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }

        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminRequest request)
        { 
            try
            {
                if (request.idGiaPha == null)
                {
                    return Ok(Result.Failure("IdGenealogy not empty"));
                }
                var result = await _IAdminGenealogy.CreateAdminForFamily(request);
                if (result)
                {
                    return Ok(Result.Success(1));
                }
                return Ok(Result.Failure("Create fail"));

            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
        [HttpDelete("DeleteIdAdmin/{idAdmin}")]
        public async Task<IActionResult> DeleteIdAdmin(long idAdmin)
        {

            try
            {
                var result = await _IAdminGenealogy.DeleteIdAdmin(idAdmin);
                if (result)
                {
                    return Ok(Result.Success(1));
                }
                return Ok(Result.Failure("Create fail")); 
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }

    }
}
