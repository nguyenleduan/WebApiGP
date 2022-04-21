using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGP.Models;

namespace Service.Service.ClientDetails
{  
    public interface IClientDetailService
    {
        Task<Result> GetClientDetail(long idClientDetail);
        Task<Result> GetAllClientDetailOfFamily(long idFamily);
        Task<bool> CreateClientDetail(ClientDetailRequest request);
        Task<bool> UpdateClientDetail(ClientDetailRequest request,long idClientDetail);
        Task<bool> DeleteClientDetail(long idClientDetail); 
    }
}
