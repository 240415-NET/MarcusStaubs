using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public static class LocationController
{
    private static ILocationStorage locationStorage = new LocationStorage();
    public static Dictionary<int, Location> InitializeLocations()
    {
        return locationStorage.GetLocationsList();
    }
    public static int DoesMonsterSpawn()
    {
        Random rand = new Random();
        int pickIt = rand.Next(0, 101);
        if (pickIt < GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].MonsterSpawnChance)
        {
            return PickMonsterSpawn();
        }
        else
        {
            return 0;
        }

    }
    public static int PickMonsterSpawn()
    {
        Random rand = new Random();
        int randNum = rand.Next(0,101);
        switch(GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions.Count())
        {
            case 1:
                return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[0];
                break;
            case 2:
                if(randNum <= 50)
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[0];
                }
                else
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[1];
                }
                break;
            case 3:
                if(randNum <= 33)
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[0];
                }
                else if(randNum > 33 && randNum <= 66)
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[1];
                }
                else
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[2];
                }
                break;
            case 4:
                if(randNum <= 25)
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[0];
                }
                else if(randNum > 25 && randNum <= 50)
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[1];
                }
                else if(randNum > 50 && randNum <= 75)
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[2];
                }                
                else
                {
                    return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[3];
                }
                break;
            default:
                return GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].SpawnOptions[0];
        }

    }    
}