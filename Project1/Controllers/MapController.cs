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
    public static void UpdateMap()
    {
        if (GameSession.currentPlayer.CurrentLocation != 106800)
        {
            if (!HasPlayerExplored())
            {
                GameSession.currentPlayer.ExploredLocations.Add(new ExploredLocation(GameSession.currentPlayer.PlayerID,GameSession.currentPlayer.CurrentLocation));
                FillPlayerMap();
            }
            PutPlayerOnMap();
        }
    }

    public static bool HasPlayerExplored()
    {
        foreach (ExploredLocation location in GameSession.currentPlayer.ExploredLocations)
        {
            if (location.locationHash == GameSession.currentPlayer.CurrentLocation)
            {
                return true;
            }
        }
        return false;
    }

    public static List<string> PutPlayerOnMap()
    {
        if (GameSession.currentPlayer.CurrentLocation != 106800)
        {
            GameSession.displayMap.Clear();
            GameSession.displayMap = MatchDisplayMapToPlayerMap();
            int playerXCoord;
            int playerYCoord;
            string locationStr;
            locationStr = GameSession.currentPlayer.CurrentLocation.ToString();
            playerXCoord = Convert.ToInt32(locationStr.Substring(1, 2));
            playerXCoord *= 5;
            playerXCoord -= 2;
            playerYCoord = Convert.ToInt32(locationStr.Substring(4, 2));
            playerYCoord *= 3;
            playerYCoord -= 1;
            StringBuilder placeCharacter = new StringBuilder(GameSession.displayMap[playerYCoord]);
            placeCharacter[playerXCoord] = '@';
            GameSession.displayMap[playerYCoord] = placeCharacter.ToString();
            //return displayMap;
        }
        return null;
    }

    public static void FillPlayerMap()
    {
        if (GameSession.currentPlayer.CurrentLocation != 106800)
        {
            int playerXCoord;
            int playerYCoord;
            string locationStr;
            Char[,] charArray = new char[3, 5];
            locationStr = GameSession.currentPlayer.CurrentLocation.ToString();
            playerXCoord = Convert.ToInt32(locationStr.Substring(1, 2));
            playerXCoord *= 5;
            playerXCoord -= 4;
            playerYCoord = Convert.ToInt32(locationStr.Substring(4, 2));
            playerYCoord *= 3;
            playerYCoord -= 2;
            int outerCounter = 0;
            for (int j = playerYCoord; j < playerYCoord + 3; j++)
            {
                Char[] subArray1 = GameSession.gameMap[j].ToCharArray();
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
                StringBuilder addToPlayerMap = new StringBuilder(GameSession.currentPlayer.PlayerMap[i].MapLine);
                int innerCounter = 0;
                for (int j = playerXCoord; j < playerXCoord + 5; j++)
                {
                    addToPlayerMap[j] = charArray[outerCounter, innerCounter];
                    innerCounter++;
                }
                outerCounter++;
                GameSession.currentPlayer.PlayerMap[i].MapLine = addToPlayerMap.ToString();
            }
        }
    }

    public static List<string> MatchDisplayMapToPlayerMap()
    {
        List<string> forDisplay = new();
        foreach (PlayerMap mapLine in GameSession.currentPlayer.PlayerMap)
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