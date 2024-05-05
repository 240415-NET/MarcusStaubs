using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public static class LocationController
{
    public static Dictionary<int, Location> InitializeLocations()
    {
        return LocationStorage.GetLocationsList();
    }

    public static int DoesMonsterSpawn(Location currentLocation)
    {
        Random rand = new Random();
        int pickIt = rand.Next(0, 101);
        if (pickIt < currentLocation.MonsterSpawnChance)
        {
            return PickMonsterSpawn(currentLocation);
        }
        else
        {
            return 0;
        }

    }
    public static int PickMonsterSpawn(Location location)
    {
        Random rand = new Random();
        int randNum = rand.Next(0,101);
        switch(location.SpawnOptions.Count())
        {
            case 1:
                return location.SpawnOptions[0];
                break;
            case 2:
                if(randNum <= 50)
                {
                    return location.SpawnOptions[0];
                }
                else
                {
                    return location.SpawnOptions[1];
                }
                break;
            case 3:
                if(randNum <= 33)
                {
                    return location.SpawnOptions[0];
                }
                else if(randNum > 33 && randNum <= 66)
                {
                    return location.SpawnOptions[1];
                }
                else
                {
                    return location.SpawnOptions[2];
                }
                break;
            case 4:
                if(randNum <= 25)
                {
                    return location.SpawnOptions[0];
                }
                else if(randNum > 25 && randNum <= 50)
                {
                    return location.SpawnOptions[1];
                }
                else if(randNum > 50 && randNum <= 75)
                {
                    return location.SpawnOptions[2];
                }                
                else
                {
                    return location.SpawnOptions[3];
                }
                break;
            default:
                return location.SpawnOptions[0];
        }

    }    
    public static int PickALocationColor(Location location, int playerLevel)
    {
        switch(location.RoomName)
        {
            case "Mountain Path":
                return 1; //gray
            case "Forest":         
                return 2; //dark green
            case "Meadow":         
                return 3; //green
            case "Small Pond":         
                return 1; 
            case "Crossroads":         
                return 1; 
            case "Well":         
                return 3; 
            case "Forest Clearing":         
                return 2; 
            case "Cave Entrance":         
                return 4; //dark gray
            case "Underground Tunnel":         
                return 4; 
            case "Mysterious Door":  
                if(playerLevel < 10)
                {       
                    return 5; //dark cyan                 
                }
                else
                {
                    return 4;
                }
            default:
                return 1;                                                    
        }
    }
}