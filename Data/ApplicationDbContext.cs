using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DSD603_Asseessment_1_Movie_Database_and_API.Models;

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DSD603_Asseessment_1_Movie_Database_and_API.Models.Movie>? Movie { get; set; }
        public DbSet<DSD603_Asseessment_1_Movie_Database_and_API.Models.Cast>? Cast { get; set; }

    }
}