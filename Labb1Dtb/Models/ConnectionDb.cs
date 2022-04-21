using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb1Dtb.Models
{
    class ConnectionDb:DbContext
    {
       public DbSet<Anstallda>Employees { get; set; }
       public DbSet<Ledighet>FreeTimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DatabasLabb1;Integrated Security=True");
        }
    }
}
