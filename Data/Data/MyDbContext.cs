using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7KMCDNK\NGUYENDUAN;Initial Catalog=GiaPha;Integrated Security=True");
        }

        public MyDbContext(DbContextOptions option) : base(option) { }
        #region Dbset 
        public DbSet<Admin> admin { get; set; }
        public DbSet<IDGiaPha> idGiaPha { get; set; }
        public DbSet<ManagerIDGiaPha> ManagerIDGiaPha { get; set; }
        public DbSet<Family> Family { get; set; }
        public DbSet<AdminFamily> AdminFamily { get; set; }
        public DbSet<ClientDetail> ClientDetail { get; set; }

        public DbSet<LocationDieadDetail> LocationDieadDetail { get; set; }
        public DbSet<LocationDied> LocationDied { get; set; }
        public DbSet<LocationHome> LocationHome { get; set; }
        #endregion
    }
}
