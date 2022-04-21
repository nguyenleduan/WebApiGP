using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGP.Models;

namespace Service.Service.AdminGenealogys
{
    public interface IAdminGenealogyService
    { 
        Task<Result> GetAllAdminFoGenealogy(long idGenealogy);
        Task<bool> CreateAdminForFamily(AdminRequest request);
        Task<bool> DeleteIdAdmin(long idAdmin);
    }
}
