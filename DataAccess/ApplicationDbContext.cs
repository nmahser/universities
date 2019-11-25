using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using universities.Models;


namespace universities.DataAccess
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Schools> Schools { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<SchoolType> SchoolType { get; set; }



    }
}
