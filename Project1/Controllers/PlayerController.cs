using Project1.Models;

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
        return currentPlayer;     
    }

    public static bool DoesPlayerExist(string name)
    {
        return false;
    }

    public static void LoadExistingCharacter(string name)
    {
        //to be implemented once we've got some persistence
    }
    public static void LevelUp(Player player)
    {
        player.Constitution += 2;
        player.Dexterity += 2;
        player.Strength +=3;
        player.MaxHitPoints += 7;
        player.CurrentHitPoints += 7;
    }
    public static void Rest(Player player, int MonsterChance) 
    {
        Random rand = new Random();
        int rndNum = rand.Next(0,101);
        if(rndNum > MonsterChance)
        {
            player.CurrentHitPoints = player.MaxHitPoints;
        }
        else
        {
            //summon a monster to fight using current room to determine type of monster
        }
    }    
}