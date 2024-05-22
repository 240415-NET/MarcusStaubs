using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base (options)
    {

    }

    public DbSet<Player> Players => Set<Player>();

    public DbSet<Monster> Monsters => Set<Monster>();

    public DbSet<Item> Items => Set<Item>();

    
}