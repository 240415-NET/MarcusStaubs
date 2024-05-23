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
        if (currentPlayer.CurrentLocation != 106800)
        {
            if (!HasPlayerExplored(ref currentPlayer))
            {
                currentPlayer.ExploredLocations.Add(new ExploredLocation(currentPlayer.PlayerID,currentPlayer.CurrentLocation));
                FillPlayerMap(ref currentPlayer, gameMap, ref displayMap);
            }
            displayMap = PutPlayerOnMap(ref currentPlayer);
        }
    }

    public static bool HasPlayerExplored(ref Player currentPlayer)
    {
        foreach (ExploredLocation location in currentPlayer.ExploredLocations)
        {
            if (location.locationHash == currentPlayer.CurrentLocation)
            {
                return true;
            }
        }
        return false;
    }

    public static List<string> PutPlayerOnMap(ref Player currentPlayer)
    {
        if (currentPlayer.CurrentLocation != 106800)
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
        return null;
    }

    public static void FillPlayerMap(ref Player currentPlayer, List<string> gameMap, ref List<string> displayMap)
    {
        if (currentPlayer.CurrentLocation != 106800)
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
            for (int i = playerYCoord; i < playerYCoord + 3; i++)
            {
                StringBuilder addToPlayerMap = new StringBuilder(currentPlayer.PlayerMap[i].MapLine);
                int innerCounter = 0;
                for (int j = playerXCoord; j < playerXCoord + 5; j++)
                {
                    addToPlayerMap[j] = charArray[outerCounter, innerCounter];
                    innerCounter++;
                }
                outerCounter++;
                currentPlayer.PlayerMap[i].MapLine = addToPlayerMap.ToString();
            }
        }
    }

    public static List<string> MatchDisplayMapToPlayerMap(ref Player currentPlayer)
    {
        List<string> forDisplay = new();
        foreach (PlayerMap mapLine in currentPlayer.PlayerMap)
        {
            forDisplay.Add(mapLine.MapLine);
        }
        return forDisplay;
    }
    public static void ReloadMapFile()
    {
        mapStorage.InitializeGameMap();
    }
}