using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public class PlayerController
{
    private static ILevelStorage levelStorage = new LevelStorage();
    public static Player CreateNewPlayer(string name)
    {
        Player currentPlayer = new Player(name);
        SavePlayer(currentPlayer);
        return currentPlayer;
    }

    public static void SavePlayer(Player currentPlayer)
    {
        PlayerStorage.SavePlayerData(currentPlayer);
    }

    public static bool DoesPlayerExist(string name)
    {
        Player currentPlayer = PlayerStorage.GetPlayerInfo(name);
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
        Player currentPlayer = PlayerStorage.GetPlayerInfo(name);
        return currentPlayer;
    }

    public static int Rest(ref Player player, Location currentLocation)
    {
        int didMonsterSpawn = LocationController.DoesMonsterSpawn(currentLocation);
        if (didMonsterSpawn == 0)
        {
            player.CurrentHitPoints = player.MaxHitPoints;
            return 0;
        }
        else
        {
            return didMonsterSpawn;
        }
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
    public static int LocationUpdate(ref Player currentPlayer, int direction, Dictionary<int, Location> locations)
    {
        switch (direction)
        {
            case 1:
                currentPlayer.CurrentLocation -= 1;
                break;
            case 2:
                currentPlayer.CurrentLocation += 1000;
                break;
            case 4:
                currentPlayer.CurrentLocation += 1;
                break;
            case 8:
                currentPlayer.CurrentLocation -= 1000;
                break;
        }
        return LocationController.DoesMonsterSpawn(locations[currentPlayer.CurrentLocation]);
    }
    public static bool DoesPlayerDodge(int playerDexterity)
    {
        Random rand = new Random();
        int diddeDodge = rand.Next(0, 101);
        int dodgeChance = playerDexterity / 2;
        if (diddeDodge > dodgeChance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static int DamageMitigation(int playerConstitution)
    {
        int damageMitigated = playerConstitution / 8;
        return damageMitigated;
    }
    public static void Ding(ref Player currentPlayer, LevelChange newLevel)
    {
        currentPlayer.PlayerLevel = newLevel.LevelNum;
        currentPlayer.Constitution += newLevel.ConstitutionIncrease;
        currentPlayer.Dexterity += newLevel.DexterityIncrease;
        currentPlayer.Strength += newLevel.StrengthIncrease;
        currentPlayer.MaxHitPoints += newLevel.MaxHitPointIncrease;
        currentPlayer.CurrentHitPoints = currentPlayer.MaxHitPoints;
    }
}