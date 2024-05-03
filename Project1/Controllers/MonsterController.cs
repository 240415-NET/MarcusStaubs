using Project1.Data;
using Project1.Models;

namespace Project1.Controllers;

public static class MonsterController
{
    public static Dictionary<int,MonsterData> InitializeMonsterInfo()
    {
        return MonsterStorage.GetMonsterList();
    }

}