using Project1.Models;
using Microsoft.EntityFrameworkCore;

namespace Project1.Data;
public class EFPlayerStorage : IPlayerStorage
{
    private readonly GameContext _context = new GameContext();
    public void SavePlayerData(Player currentPlayer)
    {
        var foundPlayer = _context.Players
        .Include(p => p.InventoryArmors)
        .Include(p => p.InventoryItems)
        .Include(p => p.InventoryPotions)
        .Include(p => p.InventoryWeapons)
        .Include(p => p.ExploredLocations)
        .Include(p => p.PlayerMap)
        .SingleOrDefault(x => x.PlayerID == currentPlayer.PlayerID);
        if (foundPlayer is null)
        {
            _context.Players.Add(currentPlayer);
        }
        _context.SaveChanges();
    }
    public Player GetPlayerInfo(string playerName)
    {
        var foundPlayer = _context.Players
        .Include(p => p.InventoryArmors)
        .Include(p => p.InventoryItems)
        .Include(p => p.InventoryPotions)
        .Include(p => p.InventoryWeapons)
        .Include(p => p.ExploredLocations)
        .Include(p => p.PlayerMap)
        .SingleOrDefault(x => x.Name == playerName);
        if (foundPlayer is null)
        {
            return null;
        }
        else
        {
            return foundPlayer;
        }
    }
}