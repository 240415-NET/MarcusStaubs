using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public class PlayerController
{
    private static IPlayerStorage playerStorage = new SqlPlayerStorage();
    private static IPlayerStorage alternatePlayerStorage = new PlayerStorage();
    private static ILevelStorage levelStorage = new SqlLevelStorage();
    private static ILevelStorage alternateLevelStorage = new LevelStorage();
    public static Player CreateNewPlayer(string name)
    {
        Player currentPlayer = new Player(name);
        SavePlayer(currentPlayer);
        return currentPlayer;
    }
    public static void SavePlayer(Player currentPlayer)
    {
        playerStorage.SavePlayerData(currentPlayer);
    }
    public static bool DoesPlayerExist(string name)
    {
        if (StorageHelper.GetSqlConnectionString() == null)
        {
            if (alternatePlayerStorage.GetPlayerInfo(name) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if (playerStorage.GetPlayerInfo(name) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
    public static Player LoadExistingCharacter(string name)
    {
        if (StorageHelper.GetSqlConnectionString() == null)
        {
            Player currentPlayer = alternatePlayerStorage.GetPlayerInfo(name);
            return currentPlayer;
        }
        else
        {
            Player currentPlayer = playerStorage.GetPlayerInfo(name);
            return currentPlayer;            
        }
    }
    public static Dictionary<int, LevelChange> InitializeLevelInfo()
    {
        if (levelStorage.GetLevelList() != null)
        {
            return levelStorage.GetLevelList();
        }
        else
        {
            return alternateLevelStorage.GetLevelList();
        }
    }
    public static int GetXPRequirementFromDictionary(LevelChange levelReference)
    {
        return levelReference.XPRequiredForLevel;
    }
}