using AspnetNote.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC.DataContent
{
    public class AspnetNoteDbContext : DbContext // DbContext - from MS EntityFramework
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Connection string"
            optionsBuilder.UseSqlServer(@"Server=ROCKYCHOI\SQLEXPRESS;Database=AspnetNoteDb;User Id=sa;Password=password;");

            // 1. Miagration : Using EntitryFramework Core Tool
            // "add-migration name" on Pacakage Manager Console

            // 2. Make DB : update-database

        }
    }
}
