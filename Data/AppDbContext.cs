using Microsoft.EntityFrameworkCore;
using MiApi.Models;
using System.Collections.Generic;

namespace MiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tabla Estudiantes
        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}