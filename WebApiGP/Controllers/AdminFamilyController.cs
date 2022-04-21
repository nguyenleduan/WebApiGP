using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Service.Service.AdminFamilys;
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

        private IAdminFamilyService _IAdminFamilyService;


        public AdminFamilyController(IAdminFamilyService iAdminFamilyService)
        {
            _IAdminFamilyService = iAdminFamilyService;
        }

        [HttpGet("GetAllAdminOfFamily/{idGiaPha}")]
        public async Task<IActionResult> GetAllAdminOfFamily(long idGiaPha)
        { 
            try
            { 
                var result = await _IAdminFamilyService.GetAllAdminOfFamily(idGiaPha);
                if (result.Succeeded == false )
                {
                    return BadRequest(result);
                }
                return Ok(Result.Success(result.Data));
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }

        [HttpPost("CreateAdminOfFamily")]
        public async Task<IActionResult> CreateAdminOfFamily([FromBody] AdminFamilyRequest request)
        {
            try
            {
                var result = await _IAdminFamilyService.CreateAdminfamily(request);
                if (result.Succeeded == false)
                {
                    return BadRequest(result);
                }
                return Ok(Result.Success(result.Data));
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }   
        }
        [HttpDelete("DeleteIdAdminOfFamily/{idAdmin}")]
        public async Task<IActionResult> DeleteIdAdminOfFamily(long idAdmin)
        {
            try
            {
                var result = await _IAdminFamilyService.DeleteAdminOfFamily(idAdmin);
                if (result.Succeeded == false)
                {
                    return BadRequest(result);
                }
                return Ok(Result.Success(result.Data));
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }
    }
}
