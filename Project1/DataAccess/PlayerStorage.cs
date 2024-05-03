using Project1.Models;
using System.Text.Json;

namespace Project1.Data;

public class PlayerStorage
{
    public static readonly string filePath = "./TempDataStorage/PlayerInfo.json";
    public static void SavePlayerData(Player currentPlayer)
    {
        //List<Player> playerList = new();
        //bool playerExists = false;
        //defaults to the path of the current project's file
        //string filePath = ".\\TempDataStorage\\PlayerInfo.json";

        if(File.Exists(filePath))
        {
            List<Player> playerList = JsonSerializer.Deserialize<List<Player>>(File.ReadAllText(filePath));
            foreach(Player player in playerList)
            {
                if(player.PlayerID == currentPlayer.PlayerID)
                {
                    //playerExists = true;
                    playerList.Remove(player);
                    //update player data with currentPlayer data.
                    //player.Constitution = currentPlayer.Constitution;

                }
            }
            playerList.Add(currentPlayer);
            string jsonPlayersString = JsonSerializer.Serialize(playerList);
            File.WriteAllText(filePath,jsonPlayersString);
        }
        else if (!File.Exists(filePath))
        {
            List<Player> playerList = new();
            //Create file and store player info
            playerList.Add(currentPlayer);
            string jsonPlayersString = JsonSerializer.Serialize(playerList);
            File.WriteAllText(filePath,jsonPlayersString);


        }
    }
    public static Player GetPlayerInfo(string playerName)
    {
        Player foundPlayer = new();
        
        if(File.Exists(filePath))
        {
            List<Player>? playerList = JsonSerializer.Deserialize<List<Player>>(File.ReadAllText(filePath));
            foundPlayer = playerList.FirstOrDefault(player => player.Name == playerName);
            return foundPlayer;
        }
        return null;

    }
}