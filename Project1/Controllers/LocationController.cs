using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public static class LocationController
{
    public static Dictionary<int, Location> InitializeLocations()
    {
        return LocationStorage.GetLocationsList();
    }

    public static bool DoesMonsterSpawn(Location currentLocation)
    {
        Random rand = new Random();
        int pickIt = rand.Next(0, 101);
        if (pickIt < currentLocation.MonsterSpawnChance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}