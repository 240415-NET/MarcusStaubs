using System.Runtime.CompilerServices;
using System.Text;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers;

public static class MapController
{
    private static IMapStorage mapStorage = new MapStorage();
    public static List<string> LoadFullMap()
    {
        List<string> gameMap = mapStorage.GetGameMap();
        return gameMap;
    }
    public static void UpdateMap(ref Player currentPlayer, List<string> gameMap, ref List<string> displayMap)
    {
        if (!HasPlayerExplored(ref currentPlayer))
        {
            currentPlayer.ExploredLocations.Add(currentPlayer.CurrentLocation);
            FillPlayerMap(ref currentPlayer,gameMap,ref displayMap);
        }
        displayMap = PutPlayerOnMap(ref currentPlayer);
    }

    public static bool HasPlayerExplored(ref Player currentPlayer)
    {
        foreach (int location in currentPlayer.ExploredLocations)
        {
            if (location == currentPlayer.CurrentLocation)
            {
                return true;
            }
        }
        return false;
    }

    public static List<string> PutPlayerOnMap(ref Player currentPlayer)
    {
        List<string> displayMap = new();
        displayMap = MatchDisplayMapToPlayerMap(ref currentPlayer);
        int playerXCoord;
        int playerYCoord;
        string locationStr;
        locationStr = currentPlayer.CurrentLocation.ToString();
        playerXCoord = Convert.ToInt32(locationStr.Substring(1, 2));
        playerXCoord *= 5;
        playerXCoord -= 2;
        playerYCoord = Convert.ToInt32(locationStr.Substring(4, 2));
        playerYCoord *= 3;
        playerYCoord -= 1;
        StringBuilder placeCharacter = new StringBuilder(displayMap[playerYCoord]);
        placeCharacter[playerXCoord] = '@';
        displayMap[playerYCoord] = placeCharacter.ToString();
        return displayMap;
    }

    public static void FillPlayerMap(ref Player currentPlayer, List<string> gameMap,ref List<string> displayMap)
    {
        int playerXCoord;
        int playerYCoord;
        string locationStr;
        Char[,] charArray = new char[3, 5];
        locationStr = currentPlayer.CurrentLocation.ToString();
        playerXCoord = Convert.ToInt32(locationStr.Substring(1, 2));
        playerXCoord *= 5;
        playerXCoord -= 4;
        playerYCoord = Convert.ToInt32(locationStr.Substring(4, 2));
        playerYCoord *= 3;
        playerYCoord -= 2;
        int outerCounter = 0;
        for (int j = playerYCoord; j < playerYCoord + 3; j++)
        {
            Char[] subArray1 = gameMap[j].ToCharArray();
            int innerCounter = 0;
            for (int i = playerXCoord; i < playerXCoord + 5; i++)
            {
                charArray[outerCounter, innerCounter] = subArray1[i];
                innerCounter++;
            }
            outerCounter++;
        }
        outerCounter = 0;
        for(int i = playerYCoord; i < playerYCoord + 3; i++)
        {
            StringBuilder addToPlayerMap = new StringBuilder(currentPlayer.PlayerMap[i]);
            int innerCounter = 0;
            for(int j = playerXCoord; j < playerXCoord + 5; j++)
            {
                addToPlayerMap[j] = charArray[outerCounter,innerCounter];
                innerCounter++;
            }
            outerCounter++;
            currentPlayer.PlayerMap[i] = addToPlayerMap.ToString();
        }
    }

    public static List<string> MatchDisplayMapToPlayerMap(ref Player currentPlayer)
    {
        List<string> forDisplay = new();
        foreach(string mapLine in currentPlayer.PlayerMap)
        {
            forDisplay.Add(mapLine);
        }
        return forDisplay;
    }
    public static void ReloadMapFile()
    {
        mapStorage.InitializeGameMap();
    }
    public static void LoadItemFile()
    {
        ItemStorage.CreateInitialItemsList();
    }

    public static Dictionary<string,Item> GetAllGameItems()
    {
        Dictionary<string,Item> allGameItems = new();
        ItemDTO itemsFromFile = ItemStorage.getAllMyItems();
        foreach(Item item in itemsFromFile.Items)
        {
            allGameItems.Add(item.ItemID,item);
        }
        foreach(Weapon weapon in itemsFromFile.Weapons)
        {
            allGameItems.Add(weapon.ItemID,weapon);
        }
        foreach(Armor armor in itemsFromFile.Armors)
        {
            allGameItems.Add(armor.ItemID,armor);
        }
        foreach(Potion potion in itemsFromFile.Potions)
        {
            allGameItems.Add(potion.ItemID,potion);
        }                        

        return allGameItems;
    }

}