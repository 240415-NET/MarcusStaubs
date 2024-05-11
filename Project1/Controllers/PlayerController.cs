using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public class PlayerController
{
    private static IPlayerStorage playerStorage = new PlayerStorage();
    private static ILevelStorage levelStorage = new LevelStorage();
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
        Player currentPlayer = playerStorage.GetPlayerInfo(name);
        if (currentPlayer == null)
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
        Player currentPlayer = playerStorage.GetPlayerInfo(name);
        return currentPlayer;
    }
    public static Dictionary<int, LevelChange> InitializeLevelInfo()
    {
        Dictionary<int, LevelChange> levelRef = levelStorage.GetLevelList();
        return levelRef;
    }
    public static int GetXPRequirementFromDictionary(LevelChange levelReference)
    {
        return levelReference.XPRequiredForLevel;
    }
}