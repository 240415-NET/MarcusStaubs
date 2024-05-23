using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using Project1.Models;

namespace Project1.Data;

public class GameContext : DbContext
{
    // public GameContext(DbContextOptions<GameContext> options) : base(options)
    // {

    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(StorageHelper.GetSqlConnectionString(true));
    }

    public DbSet<Player> Players { get; set; }

    public DbSet<Item> Items { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Armor> Armors { get; set; }
    public DbSet<Potion> Potions { get; set; }

    public DbSet<GeneralChatter> InnChatter { get; set; }

    public DbSet<KillChatter> KillChatters { get; set; }

    public DbSet<PlayerInventoryWeapon> PlayerInventoryWeapons { get; set; }
    public DbSet<PlayerInventoryArmor> PlayerInventoryArmors { get; set; }
    public DbSet<PlayerInventoryPotion> PlayerInventoryPotions { get; set; }
    public DbSet<PlayerInventoryItem> PlayerInventoryItems { get; set; }

    public DbSet<LevelChange> Levels { get; set; }

    public DbSet<PlayerMap> PlayerMap {get; set;}

    public DbSet<ExploredLocation> ExploredLocation {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerInventoryWeapon>().HasKey(pw => new
        {
            pw.PlayerID,
            pw.WeaponID
        });

        modelBuilder.Entity<PlayerInventoryArmor>().HasKey(pa => new
        {
            pa.PlayerID,
            pa.ArmorID
        });

        modelBuilder.Entity<PlayerInventoryPotion>().HasKey(pp => new
        {
            pp.PlayerID,
            pp.PotionID
        });

        modelBuilder.Entity<PlayerInventoryItem>().HasKey(pi => new
        {
            pi.PlayerID,
            pi.ItemID
        });

        modelBuilder.Entity<Player>().HasOne(p => p.EquippedWeapon).WithMany().HasForeignKey(p => p.EquippedWeaponID).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Player>().HasOne(p => p.EquippedArmor).WithMany().HasForeignKey(p => p.EquippedArmorID).OnDelete(DeleteBehavior.Restrict);
    }

}