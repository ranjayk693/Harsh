﻿using Microsoft.EntityFrameworkCore;
using Guide.Model;
namespace Guide.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DbSet<guide> guides { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}
