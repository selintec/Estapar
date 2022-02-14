using Estapar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Estapar.Context
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Manobrista> Manobristas { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Manobra> Manobras { get; set; }

    }
}
