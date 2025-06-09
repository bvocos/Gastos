using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Gasto> Gastos => Set<Gasto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.Property(e => e.Monto).HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(e => e.Descripcion).HasMaxLength(250).IsRequired();
            entity.Property(e => e.NombreComercio).HasMaxLength(250).IsRequired();
        });
    }
}

