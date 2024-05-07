using Project1.Models;

namespace Project1.Controllers;

public static class CombatController
{
    public static int PlayerAttacksMonster(ref Player currentPlayer, ref Monster currentMonster)
    {
        //Player attack = 1/2 strength to the lowest whole number
        //Player reduces enemy dodge chance by Dexterity/6 to the lowest whole number
        int playerAttack = currentPlayer.Strength / 2;
        if (currentMonster.MonsterDodge > 0)
        {
            if (MonsterController.DodgeAttack(currentMonster.MonsterDodge, currentPlayer.Dexterity))
            {
                playerAttack = 0;
            }
        }
        currentMonster.CurrentHitPoints -= playerAttack;
        if (currentMonster.CurrentHitPoints <= 0)
        {
            currentMonster.CurrentHitPoints = 0;
            currentPlayer.PlayerXP += currentMonster.RewardXP;
        }
        return playerAttack;
    }

    public static bool DoesPlayerFleeSuccessfully(int chanceToFlee)
    {
        Random rand = new Random();
        int myNum = rand.Next(0,101);
        if(myNum > chanceToFlee)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static int MonsterAttacksPlayer(ref Player currentPlayer, ref Monster currentMonster)
    {
        //Monster attack is static from property in object
        int monsterAttack = currentMonster.MonsterAttack;        
        //Player dodge chance is Dexterity/2 to the lowest whole number
        if(PlayerController.DoesPlayerDodge(currentPlayer.Dexterity))
        {
            monsterAttack = -1;
        }
        else
        {
            //If not dodged, player mitigates Constitution/8 damage from monster attack
            int mitigated = PlayerController.DamageMitigation(currentPlayer.Constitution);
            monsterAttack -= PlayerController.DamageMitigation(currentPlayer.Constitution);
            if(monsterAttack < 0)
            {
                monsterAttack = 0;
            }
            currentPlayer.CurrentHitPoints -= monsterAttack;
        }
        return monsterAttack;
    }
}