using Project1.Data;
using Project1.Models;

namespace Project1.Controllers;

public static class MonsterController
{
    public static Dictionary<int,MonsterData> InitializeMonsterInfo()
    {
        return MonsterStorage.GetMonsterList();
    }

    public static Monster SpawnMonster(Location location)
    {
        Random rand = new Random();
        int randNum = rand.Next(0,101);
        switch(location.SpawnOptions.Count())
        {
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
        }

    }

}