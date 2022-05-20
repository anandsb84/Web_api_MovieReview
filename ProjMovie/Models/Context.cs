using Microsoft.EntityFrameworkCore;
using System;

namespace ProjMovie.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options)
        {

        }

        public  DbSet<MovieDb> MovieDbs { get; set; }
        public DbSet<ReviewDb> ReviewDbs { get; set; }   
    }
}
