using Project1.Models;
using System.Text.Json;

namespace Project1.Data;

public class PlayerStorage : IPlayerStorage
{
    public static readonly string filePath = "./TempDataStorage/PlayerInfo.json";
    public void SavePlayerData(Player currentPlayer)
    {
        //List<Player> playerList = new();
        bool playerExists = false;
        //defaults to the path of the current project's file
        //string filePath = ".\\TempDataStorage\\PlayerInfo.json";

        if(File.Exists(filePath))
        {
            List<Player> playerList = JsonSerializer.Deserialize<List<Player>>(File.ReadAllText(filePath));
            for(int i = 0; i < playerList.Count(); i++)
            {
                if(playerList[i].PlayerID == currentPlayer.PlayerID)
                {
                    playerExists = true;
                    playerList[i] = currentPlayer;
                }
            }
            if(!playerExists)
            {
                playerList.Add(currentPlayer);
            }
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
    public Player GetPlayerInfo(string playerName)
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