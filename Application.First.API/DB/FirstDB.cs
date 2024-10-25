using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.First.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.First.API.DB
{
    public class FirstDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public FirstDB(DbContextOptions options)
            :base(options)
        {
           
        }
    }
}