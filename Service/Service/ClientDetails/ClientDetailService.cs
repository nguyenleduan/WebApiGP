using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGP.Data;
using WebApiGP.Models;

namespace Service.Service.ClientDetails
{
    public class ClientDetailService : IClientDetailService
    {
        public   Task<bool> CreateClientDetail(ClientDetailRequest request)
        { 
            try
            {
                ClientDetail client = new ClientDetail();
                client.idFamily = request.idFamily;
                client.idGiaPhaChild = request.idGiaPhaChild;
                client.idLocationDied = request.idLocationDied;
                client.firstName = request.firstName;
                client.lastName = request.lastName;
                client.birthDay = request.birthDay;
                client.diedDay = request.diedDay;
                client.status = request.status;
                client.phone = request.phone;
                client.avatar = request.avatar;
                client.idLocationHome = request.idLocationHome; 
                using (var db = new MyDbContext())
                {
                    db.ClientDetail.Add(client);
                    var check =  db.SaveChanges(); 
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

        public Task<bool> DeleteClientDetail(long idClientDetail)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var client = db.ClientDetail.FirstOrDefault(u => u.idClientDetail == idClientDetail);
                    if (client == null)
                    {
                        return Task.FromResult(false);
                    }
                    db.Entry(client).State = EntityState.Deleted;
                    db.SaveChanges();
                    return Task.FromResult(true);
                }
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<Result> GetClientDetail(long idClientDetail)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var clientDetails = db.ClientDetail.FromSqlInterpolated($"EXECUTE [dbo].[GetClientDetail] @idClientDetail={idClientDetail}").ToList();
                    //var clientDetails = db.ClientDetail.FirstOrDefault(u => u.idClientDetail == idClientDetail);
                    if (clientDetails == null || clientDetails.Count == 0)
                    { 
                        return Task.FromResult(Result.Failure("Data empty")); 
                    }
                    return Task.FromResult(Result.Success(clientDetails[0]));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Failure(ex.ToString()));
            }
        }

        public Task<Result> GetAllClientDetailOfFamily(long idFamily)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var clientDetails = db.ClientDetail.FromSqlInterpolated($"EXECUTE [dbo].[getAllClientDetailOfFamily] @idFamily={idFamily}").ToList(); 
                    if (clientDetails == null || clientDetails.Count == 0)
                    {
                        return Task.FromResult(Result.Failure("Data empty"));
                    }
                    return Task.FromResult(Result.Success(clientDetails));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Failure(ex.ToString()));
            }
        }

        public Task<bool> UpdateClientDetail(ClientDetailRequest request,long idClientDetail)
        {
             
            try
            { 
                using (var db = new MyDbContext())
                {
                    var client = db.ClientDetail.FirstOrDefault(u => u.idClientDetail == idClientDetail); 
                    client.idFamily = request.idFamily;
                    client.idGiaPhaChild = request.idGiaPhaChild;
                    client.idLocationDied = request.idLocationDied;
                    client.firstName = request.firstName;
                    client.lastName = request.lastName;
                    client.birthDay = request.birthDay;
                    client.diedDay = request.diedDay;
                    client.status = request.status;
                    client.phone = request.phone;
                    client.avatar = request.avatar;
                    client.idLocationHome = request.idLocationHome;
                    db.Entry(client).State = EntityState.Modified;
                    var check  = db.SaveChanges();
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
    }
}
