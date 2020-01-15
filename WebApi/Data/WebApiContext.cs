using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;



namespace WebApi.Data
{
    public class WebApiContext : IdentityDbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department { get; set; }
    }
}
