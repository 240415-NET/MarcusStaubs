using Project1.Data;
using Project1.Models;

namespace Project1.Controllers;

public static class MonsterController
{
    public static Dictionary<int,MonsterData> InitializeMonsterInfo()
    {
        return MonsterStorage.GetMonsterList();
    }

    public static bool DodgeAttack(int monsterDodge, int playerDexterity)
    {
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