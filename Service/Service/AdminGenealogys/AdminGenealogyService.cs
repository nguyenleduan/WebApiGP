using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGP.Data;
using WebApiGP.Models;

namespace Service.Service.AdminGenealogys
{
    public class AdminGenealogyService : IAdminGenealogyService
    {
        public Task<bool> CreateAdminForFamily(AdminRequest request)
        {
            try
            {
                Admin gp = new Admin();
                gp.idGiaPha = (long)request.idGiaPha;
                gp.phone = request.phone;
                using (var db = new MyDbContext())
                {
                    db.admin.Add(gp); 
                    var check = db.SaveChanges();
                    if (check > 0)
                    {
                        return Task.FromResult(true);
                    }
                    return Task.FromResult(false);
                }
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteIdAdmin(long idAdmin)
        { 
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.admin.FirstOrDefault(u => u.idAdmin == idAdmin);
                    if (gp == null)
                    {
                        return Task.FromResult(false);
                    }
                    db.Entry(gp).State = EntityState.Deleted;
                    var check = db.SaveChanges();
                    if (check > 0)
                    {
                        return Task.FromResult(true);
                    }
                    return Task.FromResult(false);
                }
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<Result> GetAllAdminFoGenealogy(long idGenealogy)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var gp = db.admin.FromSqlInterpolated($"EXECUTE [dbo].[getAdmin] @id={idGenealogy}").ToList();
                    if (!gp.Any())
                    {
                        return Task.FromResult(Result.Failure("Data empty"));
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
