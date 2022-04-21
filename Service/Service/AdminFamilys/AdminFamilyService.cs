using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGP.Data;
using WebApiGP.Models;
using WebApiGP.Models.Request;

namespace Service.Service.AdminFamilys
{
    public class AdminFamilyService : IAdminFamilyService
    {
        public Task<Result> CreateAdminfamily(AdminFamilyRequest request)
        { 
            try
            {
                AdminFamily gp = new AdminFamily();
                gp.idGiaPha = (long)request.idGiaPha;
                gp.phone = request.phone;
                gp.idFamily = request.idFamily;
                using (var db = new MyDbContext())
                {
                    db.AdminFamily.Add(gp);
                    var check = db.SaveChanges();
                    if (check > 0)
                    { 
                        return Task.FromResult(Result.Success(1));
                    } 
                    return Task.FromResult(Result.Failure("Create fail"));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Failure(ex.ToString()));
            }
        }

        public Task<Result> DeleteAdminOfFamily(long idAdmin)
        {

            try
            { 
                using (var db = new MyDbContext())
                {
                    var check = db.AdminFamily.FromSqlInterpolated($"EXECUTE [dbo].[deleteAdminOfFamily] @idAdminFamily={idAdmin}").ToList();
                    if(check.Count == 0)
                    { 
                        return Task.FromResult(Result.Success(1));
                    }
                    return Task.FromResult(Result.Failure("Delete fail"));
                } 
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Failure(ex.ToString()));
            }
        }

        public  Task<Result> GetAllAdminOfFamily(long idGiaPha)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.AdminFamily.FromSqlInterpolated($"EXECUTE [dbo].[getAllAdminOfgFamilyGiaPha] @idGiaPha={idGiaPha}").ToList();
                    if (!gp.Any())
                    {
                        return Task.FromResult(Result.Failure("Data empty")) ;
                    }
                    return Task.FromResult(Result.Success(gp));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Failure(ex.ToString()));
            }
        } 
    }
}
