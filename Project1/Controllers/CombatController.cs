using Project1.Models;

namespace Project1.Controllers;

public static class CombatController
{
    public static int PlayerAttacksMonster(ref Monster currentMonster)
    {
        //Player attack = weapon attack + 1/2 strength to the lowest whole number
        //Player reduces enemy dodge chance by Dexterity/6 to the lowest whole number
        int playerAttack = ((Weapon)GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID]).AttackIncrease +  GameSession.currentPlayer.Strength / 2;
        if (currentMonster.MonsterDodge > 0)
        {
            if (MonsterController.DodgeAttack(currentMonster.MonsterDodge))
            {
                playerAttack = 0;
            }
        }
        currentMonster.CurrentHitPoints -= playerAttack;
        if (currentMonster.CurrentHitPoints <= 0)
        {
            currentMonster.CurrentHitPoints = 0;
            GameSession.currentPlayer.PlayerXP += currentMonster.RewardXP;
            GameSession.currentPlayer.PlayerGold += currentMonster.RewardGold;
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
    public static int MonsterAttacksPlayer(ref Monster currentMonster)
    {
        //Monster attack is static from property in object
        int monsterAttack = currentMonster.MonsterAttack;        
        //Player dodge chance is Dexterity/2 to the lowest whole number
        if(GameSession.currentPlayer.DodgeAttack())
        {
            monsterAttack = -1;
        }
        else
        {
            //If not dodged, player mitigates Constitution/8 + armor damage from monster attack
            int mitigated = GameSession.currentPlayer.MyDamageMitigation() + ((Armor)GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID]).MitigationIncrease;
            monsterAttack -= GameSession.currentPlayer.MyDamageMitigation();
            if(monsterAttack < 0)
            {
                monsterAttack = 0;
            }
            GameSession.currentPlayer.CurrentHitPoints -= monsterAttack;
        }
        return monsterAttack;
    }
}