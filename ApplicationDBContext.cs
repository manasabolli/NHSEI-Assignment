using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi
{
    public partial class ApplicationDBContext : DbContext
    {
        private IConfiguration configuration;

        public ApplicationDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ApplicationDBContext(IConfiguration configuration,DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbAssignmentConnection"));
            //optionsBuilder.UseSqlServer("Server=IN-MH1LPW101830;Database= NHSEI", builder =>
            //{
            //    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            //});
            //base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Acl>()
        //        .HasKey(c => new {  c.ReadUsers });
        //}
        public DbSet<RequestModel> RequestModel { get; set; }
        public DbSet<Respnse> RespnseModel { get; set; }

    }       
}
