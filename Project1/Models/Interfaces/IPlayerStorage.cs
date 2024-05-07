namespace Project1.Models;

public interface IPlayerStorage
{
    public void SavePlayerData(Player currentPlayer);

    public Player GetPlayerInfo(string playerName);
}