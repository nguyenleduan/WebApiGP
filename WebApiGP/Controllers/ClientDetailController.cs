using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Service.ClientDetails;
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

        IClientDetailService _IClientDetailService;
        public ClientDetailController(IClientDetailService iClientDetailService)
        {
            _IClientDetailService = iClientDetailService;
        }

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
        [HttpGet("GetClientDetail/{idClienDetail}")]
        public async Task<IActionResult> GetClientDetailAsync(long idClienDetail)
        {
            try
            {
                if (idClienDetail == null)
                {
                    return Ok(Result.Failure("idClienDetail not null"));
                }
                var result = await _IClientDetailService.GetClientDetail(idClienDetail);
                if (result.Succeeded)
                {
                    return Ok(Result.Success(result.Data));
                }
                return Ok(Result.Failure("Not found"));
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        }   
        
        [HttpGet("GetAllClientDetailOfFamily/{idFamily}")]
        public async Task<IActionResult> GetAllClientDetailOfFamily(long idFamily)
        {
            try
            {
                if(idFamily == null)
                { 
                    return Ok(Result.Failure("idFamily not null"));
                }
                var result = await _IClientDetailService.GetAllClientDetailOfFamily(idFamily);
                if (result.Succeeded)
                {
                    return Ok(Result.Success(result.Data));
                }
                return Ok(Result.Failure("Not found"));
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString()));
            }
        } 


        [HttpPost("CreateClienDetail")]
        public async Task<IActionResult> CraeateClientDetail([FromBody] ClientDetailRequest request)
        {

            try
            {
                if(string.IsNullOrEmpty(request.firstName) || string.IsNullOrEmpty(request.lastName) )
                { 
                    return Ok(Result.Failure("Name cannot be empty or null"));
                }
                if(request.status == null)
                { 
                    return Ok(Result.Failure("status cannot be null"));
                }
                if(request.idFamily == null)
                { 
                    return Ok(Result.Failure("idFamily cannot be null"));
                } 
                var result = await _IClientDetailService.CreateClientDetail(request);
                if (result )
                {
                    return Ok(Result.Success(1));
                }
                return Ok(Result.Failure("Create fail")); 
            } catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString())); 
            }
             
        }
        [HttpPut("UpdateClientDetail/{idClientDetail}")]
        public async Task<IActionResult> UpdateClientDetailAsync([FromBody] ClientDetailRequest request, long idClientDetail)
        { 
            try
            { 
                    if (request == null)
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
                var result = await _IClientDetailService.UpdateClientDetail(request, idClientDetail);
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
        [HttpDelete("DeleteClientDetail/{idClientDetail}")]
        public async Task<IActionResult> DeleteClientDetailAsync(long idClientDetail)
        {
            try
            {
                var result = await _IClientDetailService.DeleteClientDetail(idClientDetail);
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
