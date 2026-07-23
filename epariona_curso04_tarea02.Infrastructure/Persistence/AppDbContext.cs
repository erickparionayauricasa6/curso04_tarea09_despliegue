using epariona_curso04_tarea02.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace epariona_curso04_tarea02.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Libro> Libros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
