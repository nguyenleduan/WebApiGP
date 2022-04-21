using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGP.Models;
using WebApiGP.Models.Request;

namespace Service.Service.AdminFamilys
{
    public interface IAdminFamilyService
    {
        Task<Result> GetAllAdminOfFamily(long idGiaPha);
        Task<Result> DeleteAdminOfFamily(long idAdmin);
        Task<Result> CreateAdminfamily(AdminFamilyRequest request);
    }
}
