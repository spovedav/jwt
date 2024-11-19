using CAPA.DOMAIN.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace CAPA.INFRE.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TableUsuario> TableUsuario { get; set; }
    }
}
