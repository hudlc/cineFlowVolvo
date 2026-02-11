namespace data;
using Microsoft.EntityFrameworkCore;
using model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Filme> Filmes => Set<Filme>();
    public DbSet<Ingresso> Ingressos => Set<Ingresso>();
    public DbSet<Sala> Salas => Set<Sala>();
    public DbSet<Sessao> Sessoes => Set<Sessao>();

}


