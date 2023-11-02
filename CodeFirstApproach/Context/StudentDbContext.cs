using CodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApproach.Context
{
    internal class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {

        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ANAMIKA\SQLSERVER;Database=TestDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}