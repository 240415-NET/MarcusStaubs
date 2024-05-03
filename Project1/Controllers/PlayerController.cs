using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public class PlayerController
{
    public static Player CreateNewPlayer(string name)
    {
        Player currentPlayer  = new Player(name);
        currentPlayer.MaxHitPoints = 10;
        currentPlayer.CurrentHitPoints = 10;
        currentPlayer.CurrentLocation = 106805;
        currentPlayer.Strength = 3;
        currentPlayer.Dexterity = 2;
        currentPlayer.Constitution = 3;
        currentPlayer.PlayerLevel = 1;
        currentPlayer.PlayerXP = 0;   
        PlayerStorage.SavePlayerData(currentPlayer);
        return currentPlayer;     
    }

    public static bool DoesPlayerExist(string name)
    {
        Player currentPlayer = PlayerStorage.GetPlayerInfo(name);
        if(currentPlayer == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static Player LoadExistingCharacter(string name)
    {
        Player currentPlayer = PlayerStorage.GetPlayerInfo(name);
        return currentPlayer;
    }

    public static void Rest(ref Player player, Location currentLocation) 
    {
        bool didMonsterSpawn = LocationController.DoesMonsterSpawn(currentLocation);
        if(!didMonsterSpawn)
        {
            player.CurrentHitPoints = player.MaxHitPoints;
        }
        else
        {
            //summon a monster to fight using current room to determine type of monster
        }
    }

    public static Dictionary<int,LevelChange> InitializeLevelInfo()
    {
        Dictionary<int,LevelChange> levelRef = LevelStorage.GetLevelList();
        return levelRef;
    }

    public static int GetXPRequirementFromDictionary(LevelChange levelReference)
    {
        return levelReference.XPRequiredForLevel;
    }

    public static void LocationUpdate(ref Player currentPlayer,int direction)
    {
        switch(direction)
        {
            case 1:
                currentPlayer.CurrentLocation -= 1;
                break;
            case 2:
                currentPlayer.CurrentLocation +=1000;
                break;
            case 4:
                currentPlayer.CurrentLocation +=1;
                break;
            case 8:
                currentPlayer.CurrentLocation -=1000;
                break;            
        }
    }
    public static bool CheckForMonsterSpawn(Location newLocation)
    {
        return LocationController.DoesMonsterSpawn(newLocation);
    }    
}