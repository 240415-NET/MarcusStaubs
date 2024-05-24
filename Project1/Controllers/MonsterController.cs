using Project1.Data;
using Project1.Models;

namespace Project1.Controllers;

public static class MonsterController
{
    private static IMonsterStorage monsterStorage = new MonsterStorage();
    public static Dictionary<int,MonsterData> InitializeMonsterInfo()
    {
        return monsterStorage.GetMonsterList();
    }
    public static bool DodgeAttack(int monsterDodge)
    {
        int playerDexterity = GameSession.currentPlayer.Dexterity;
        double QuarterPlayerDex = (double)playerDexterity / 6;
        int offSet = (int)QuarterPlayerDex;
        if(monsterDodge - offSet <= 0)
        {
            return false;
        }
        else
        {
            Random rand = new Random();
            int rndNum = rand.Next(0,101);
            if(rndNum <= monsterDodge - offSet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}