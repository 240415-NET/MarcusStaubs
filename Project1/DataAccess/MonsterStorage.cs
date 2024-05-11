using Project1.Models;
using System.Text.Json;

namespace Project1.Data;

public class MonsterStorage : IMonsterStorage
{
    public static readonly string filePath = "./TempDataStorage/Monsters.json";
    public Dictionary<int, MonsterData> GetMonsterList()
    {
        Dictionary<int, MonsterData> monsterCatalog = new Dictionary<int, MonsterData>();
        //string filePath = "./TempDataStorage/Monsters.json";
        List<MonsterData> monsterDataList = JsonSerializer.Deserialize<List<MonsterData>>(File.ReadAllText(filePath));
        foreach(MonsterData myMonster in monsterDataList)
        {
            monsterCatalog.Add(myMonster.MonsterID,myMonster);
        }
        return monsterCatalog;
    }

    public static void ReadAndDisplayMonsters()
    {
        //string filePath = "./TempDataStorage/Monsters.json";
        List<MonsterData> monsterDataList = JsonSerializer.Deserialize<List<MonsterData>>(File.ReadAllText(filePath));
        foreach(MonsterData myMonster in monsterDataList)
        {
            Console.WriteLine($"Name: {myMonster.Name}");
            Console.WriteLine($"HP: {myMonster.CurrentHitPoints}/{myMonster.MaxHitPoints} Attack: {myMonster.MonsterAttack} Dodge: {myMonster.MonsterDodge}");
            foreach(string imageLine in myMonster.MonsterDisplay)
            {
                Console.WriteLine(imageLine);
            }
        }
    }
    public void FirstEverMonsterFileCreation()
    {
        List<MonsterData> monsterList = new();

        List<string> ratPic = new List<string>();
        ratPic.Add("     _   _".PadRight(50, ' '));
        ratPic.Add("    (q\\_/p)".PadRight(50, ' '));
        ratPic.Add(".-.  |. .|".PadRight(50, ' '));
        ratPic.Add("   \\ =\\,/=".PadRight(50, ' '));
        ratPic.Add("    )/ _ \\ ".PadRight(50, ' '));
        ratPic.Add("   (/\\):(/\\".PadRight(50, ' '));
        ratPic.Add("    \\_   _/ ".PadRight(50, ' '));
        ratPic.Add("    `\"\"^\"\"` ".PadRight(50, ' '));
        List<string> ratLoot = new List<string>{"tail","fur"};
        MonsterData newRat = new MonsterData("Rat", 1, 1, 1151, 1, 0, 2, 0, "nips", "impossible!", "squeak!", 95, ratPic, ratLoot);
        monsterList.Add(newRat);

        List<string> largeRatPic = new List<string>();
        largeRatPic.Add("                         ____    .-.".PadRight(50, ' '));
        largeRatPic.Add("                     .-\"`    `\",( __\\_".PadRight(50, ' '));
        largeRatPic.Add("      .-==:;-._    .'         .-.     `'.".PadRight(50, ' '));
        largeRatPic.Add("    .'      `\"-:'-/          (  \\} -=a  .)".PadRight(50, ' '));
        largeRatPic.Add("   /            \\/       \\,== `-  __..-'`".PadRight(50, ' '));
        largeRatPic.Add("'-'              |       |   |  .'\\ `;".PadRight(50, ' '));
        largeRatPic.Add("                  \\    _/---'\\ (   `\"`".PadRight(50, ' '));
        largeRatPic.Add("                 /.`._ )      \\ `;".PadRight(50, ' '));
        largeRatPic.Add("                 \\`-/.'        `\"`".PadRight(50, ' '));
        largeRatPic.Add("                  `\"\\`-.".PadRight(50, ' '));
        largeRatPic.Add("                     `\"`".PadRight(50, ' '));
        List<string> lRatLoot = new List<string>{"fur","rfang","weapon2"};
        MonsterData newLargeRat = new MonsterData("Large Rat", 5, 5, 1271, 3, 2, 5, 1, "bites", "hops out of the way", "Squeak!", 90, largeRatPic, lRatLoot);
        monsterList.Add(newLargeRat);

        List<string> giantRatPic = new List<string>();
        giantRatPic.Add("          __       __     _".PadRight(50, ' '));
        giantRatPic.Add("         /-.\\     /  \\   //".PadRight(50, ' '));
        giantRatPic.Add("         \\  \\|_,_/|  /  ((".PadRight(50, ' '));
        giantRatPic.Add("          `\\ `    `\\\"    \\\\".PadRight(50, ' '));
        giantRatPic.Add("          /  _   _  \\     ))".PadRight(50, ' '));
        giantRatPic.Add("         |  (0\\ /0)  |   //".PadRight(50, ' '));
        giantRatPic.Add("         \\           /  //".PadRight(50, ' '));
        giantRatPic.Add("         /`.== 0 ==.`\\ ((".PadRight(50, ' '));
        giantRatPic.Add("        /   `~~W~~`   \\ \\".PadRight(50, ' '));
        giantRatPic.Add("       |   ,       ,   | ))".PadRight(50, ' '));
        giantRatPic.Add("       \\   \\       /   ///".PadRight(50, ' '));
        giantRatPic.Add("       /`vvvv     vvvv`\\/".PadRight(50, ' '));
        giantRatPic.Add("      |                 |".PadRight(50, ' '));
        giantRatPic.Add("      |   |         |   |".PadRight(50, ' '));
        giantRatPic.Add("     /    (         )    \\".PadRight(50, ' '));
        giantRatPic.Add("    (v(v(v)`=.....=`(v)v)v)".PadRight(50, ' '));
        List<string> gRatLoot = new List<string>{"fur","rfang","paw","weapon4"};
        MonsterData newGiantRat = new MonsterData("Giant Rat", 10, 10, 1341, 8, 5, 15, 3, "chomps", "lumbers aside", "SQUEAK!", 75, giantRatPic,gRatLoot);
        monsterList.Add(newGiantRat);

        List<string> spiderPic = new List<string>();
        spiderPic.Add("  / _ \\".PadRight(50, ' '));
        spiderPic.Add("\\_\\(_)/_/".PadRight(50, ' '));
        spiderPic.Add(" _//\"\\\\_ ".PadRight(50, ' '));
        spiderPic.Add("  /   \\".PadRight(50, ' '));
        List<string> spiderLoot = new List<string>{"silk"};
        MonsterData newSpider = new MonsterData("Spider", 1, 1, 1152, 1, 50, 5, 0, "bites", "nimbly hops away", "splat", 95, spiderPic,spiderLoot);
        monsterList.Add(newSpider);

        List<string> giantSpiderPic = new List<string>();
        giantSpiderPic.Add("           ____                      ,".PadRight(50, ' '));
        giantSpiderPic.Add("          /---.'.__             ____//".PadRight(50, ' '));
        giantSpiderPic.Add("               '--.\\           /.---'".PadRight(50, ' '));
        giantSpiderPic.Add("          _______  \\\\         //".PadRight(50, ' '));
        giantSpiderPic.Add("        /.------.\\  \\|      .'/  ______".PadRight(50, ' '));
        giantSpiderPic.Add("       //  ___  \\ \\ ||/|\\  //  _/_----.\\__".PadRight(50, ' '));
        giantSpiderPic.Add("      |/  /.-.\\  \\ \\:|< >|// _/.'..\\   '--'".PadRight(50, ' '));
        giantSpiderPic.Add("         //   \\'. | \\'.|.'/ /_/ /  \\\\".PadRight(50, ' '));
        giantSpiderPic.Add("        //     \\ \\_\\/\" ' ~\\-'.-'    \\\\".PadRight(50, ' '));
        giantSpiderPic.Add("       //       '-._| :H: |'-.__     \\\\".PadRight(50, ' '));
        giantSpiderPic.Add("      //           (/'==='\\)'-._\\     ||".PadRight(50, ' '));
        giantSpiderPic.Add("      ||                        \\\\    \\|".PadRight(50, ' '));
        giantSpiderPic.Add("      ||                         \\\\    '".PadRight(50, ' '));
        giantSpiderPic.Add("      |/                          \\\\".PadRight(50, ' '));
        giantSpiderPic.Add("                                   ||".PadRight(50, ' '));
        giantSpiderPic.Add("                                   ||".PadRight(50, ' '));
        giantSpiderPic.Add("                                   \\\\".PadRight(50, ' '));
        giantSpiderPic.Add("                                    '".PadRight(50, ' '));
        List<string> gspiderLoot = new List<string>{"silk","fang","weapon4"};
        MonsterData newGiantSpider = new MonsterData("Giant Spider", 10, 10, 1272, 8, 15, 15, 3, "bites", "sways to the side", "Skreee!", 75, giantSpiderPic,gspiderLoot);
        monsterList.Add(newGiantSpider);

        List<string> kWorkerPic = new List<string>();
        kWorkerPic.Add("        _____".PadRight(50, ' '));
        kWorkerPic.Add("    .-,;='';_),-.".PadRight(50, ' '));
        kWorkerPic.Add("     \\_\\(),()/_/".PadRight(50, ' '));
        kWorkerPic.Add("       (,___,)".PadRight(50, ' '));
        kWorkerPic.Add("      ,-/`~`\\-,___".PadRight(50, ' '));
        kWorkerPic.Add("     / /).:.('--|_)".PadRight(50, ' '));
        kWorkerPic.Add("    {_[ (_,_)  _|_|_".PadRight(50, ' '));
        kWorkerPic.Add("        | Y | (_____)".PadRight(50, ' '));
        kWorkerPic.Add("       /  |  \\".PadRight(50, ' '));
        kWorkerPic.Add("       \"\"\" \"\"\"".PadRight(50, ' '));
        List<string> woKobold = new List<string>{"scraps","purse","weapon4"};
        MonsterData newKoboldWorker = new MonsterData("Kobold Worker", 15, 15, 1251, 9, 1, 10, 3, "swings its satchel", "stumbles out of the way", "hiss!", 80, kWorkerPic,woKobold);
        monsterList.Add(newKoboldWorker);

        List<string> kScoutPic = new List<string>();
        kScoutPic.Add("        _____".PadRight(50, ' '));
        kScoutPic.Add("    .-,;='';_),-. ".PadRight(50, ' '));
        kScoutPic.Add("     \\_\\(),()/_/|\\".PadRight(50, ' '));
        kScoutPic.Add("       (,___,)  | \\".PadRight(50, ' '));
        kScoutPic.Add("      ,-/`~`\\-,_|_|)".PadRight(50, ' '));
        kScoutPic.Add("     / /).:.('--._=) ".PadRight(50, ' '));
        kScoutPic.Add("    {_[ (_,_)   | |)".PadRight(50, ' '));
        kScoutPic.Add("        | Y |   | /".PadRight(50, ' '));
        kScoutPic.Add("       /  |  \\  |/".PadRight(50, ' '));
        kScoutPic.Add("       \"\"\" \"\"\"".PadRight(50, ' '));
        List<string> scKobold = new List<string>{"scraps","bow","arrows","weapon5"};
        MonsterData newKoboldScout = new MonsterData("Kobold Scout", 20, 20, 1321, 12, 10, 15, 5, "fires its bow", "ducks", "grrk!", 75, kScoutPic,scKobold);
        monsterList.Add(newKoboldScout);

        List<string> kWarriorPic = new List<string>();
        kWarriorPic.Add("        _____   /\\".PadRight(50, ' '));
        kWarriorPic.Add("    .-,;='';_),-\\/ ".PadRight(50, ' '));
        kWarriorPic.Add("     \\_\\(),()/_/||".PadRight(50, ' '));
        kWarriorPic.Add("       (,___,)  ||".PadRight(50, ' '));
        kWarriorPic.Add("    ___-/`~`\\-,_||".PadRight(50, ' '));
        kWarriorPic.Add("   /   \\).:.('--._) ".PadRight(50, ' '));
        kWarriorPic.Add("  | []  |_,_)   ||".PadRight(50, ' '));
        kWarriorPic.Add("   \\___/| Y |   || ".PadRight(50, ' '));
        kWarriorPic.Add("       /  |  \\  ||".PadRight(50, ' '));
        kWarriorPic.Add("       \"\"\" \"\"\"".PadRight(50, ' '));
        List<string> waKobold = new List<string>{"scraps","shield","spearhead","weapon7"};
        MonsterData newKoboldWarrior = new MonsterData("Kobold Warrior", 25, 25, 1471, 17, 25, 25, 10, "thrusts its spear", "swats the attack away", "...", 50, kWarriorPic,waKobold);
        monsterList.Add(newKoboldWarrior);

        List<string> kChiefPic = new List<string>();
        kChiefPic.Add("                   _".PadRight(50, ' '));
        kChiefPic.Add("      __ __       //_/\\".PadRight(50, ' '));
        kChiefPic.Add("   .-',,^,,'.    //_   \\".PadRight(50, ' '));
        kChiefPic.Add("  / \\(0)(0)/ \\  //  /  /".PadRight(50, ' '));
        kChiefPic.Add("  )/( ,_\"_,)\\( //_ /  /".PadRight(50, ' '));
        kChiefPic.Add("  `  >-`~(   '//_    /".PadRight(50, ' '));
        kChiefPic.Add("_N\\ |(`\\ |___//  /__/".PadRight(50, ' '));
        kChiefPic.Add("\' |/ \\ \\/_-,))".PadRight(50, ' '));
        kChiefPic.Add(" '.(  \\`\\_<//".PadRight(50, ' '));
        kChiefPic.Add("    \\ _\\| //".PadRight(50, ' '));
        kChiefPic.Add("     | |_\\/_".PadRight(50, ' '));
        kChiefPic.Add("     \\_,_>-'".PadRight(50, ' '));
        List<string> chKobold = new List<string>{"gem","herbs","necklace","weapon13"};
        MonsterData newKoboldChief = new MonsterData("Kobold Chief", 50, 50, 1571, 25, 20, 50, 30, "swings its great axe", "casually steps out of range", "You die, human!", 30, kChiefPic,chKobold);
        monsterList.Add(newKoboldChief);

        List<string> BossPic = new();
        BossPic.Add("          /                              )".PadRight(50, ' '));     
        BossPic.Add("          (                             |\\".PadRight(50, ' '));
        BossPic.Add("         /|                              \\\\".PadRight(50, ' '));
        BossPic.Add("        //                                \\\\".PadRight(50, ' '));
        BossPic.Add("       ///                                 \\|".PadRight(50, ' '));
        BossPic.Add("      /( \\                                  )\\".PadRight(50, ' '));
        BossPic.Add("      \\\\  \\_                               //)".PadRight(50, ' '));
        BossPic.Add("       \\\\  :\\__                           ///".PadRight(50, ' '));
        BossPic.Add("        \\\\     )                         // \\".PadRight(50, ' '));
        BossPic.Add("         \\\\:  /                         // |/".PadRight(50, ' '));
        BossPic.Add("          \\\\ / \\                       //  \\".PadRight(50, ' '));
        BossPic.Add("           /)   \\   ___..-'           (|  \\_|".PadRight(50, ' '));
        BossPic.Add("          //     /   _.'              \\ \\  \\".PadRight(50, ' '));
        BossPic.Add("         /|       \\ \\________          \\ | /".PadRight(50, ' '));
        BossPic.Add("        (| _ _  __/          '-.       ) /.'".PadRight(50, ' '));
        BossPic.Add("         \\\\ .  '-.__            \\_    / / \\".PadRight(50, ' '));
        BossPic.Add("          \\\\_'.     > --._ '.     \\  / / /".PadRight(50, ' '));
        BossPic.Add("           \\ \\      \\     \\  \\     .' /.'".PadRight(50, ' '));
        BossPic.Add("            \\ \\  '._ /     \\ )    / .' |".PadRight(50, ' '));
        BossPic.Add("             \\ \\_     \\_   |    .'_/ __/".PadRight(50, ' '));
        BossPic.Add("              \\  \\      \\_ |   / /  _/ \\_".PadRight(50, ' '));
        BossPic.Add("               \\  \\       / _.' /  /     \\".PadRight(50, ' '));
        BossPic.Add("               \\   |     /.'   / .'       '-,_".PadRight(50, ' '));
        BossPic.Add("                \\   \\  .'   _.'_/             \\".PadRight(50, ' '));
        BossPic.Add("   /\\    /\\      ) ___(    /_.'           \\    |".PadRight(50, ' '));
        BossPic.Add("  | _\\__// \\    (.'      _/               |    |".PadRight(50, ' '));
        BossPic.Add("  \\/_  __  /--'`    ,                   __/    /".PadRight(50, ' '));
        BossPic.Add("  (_ ) /b)  \\  '.   :            \\___.-'_/ \\__/".PadRight(50, ' '));
        BossPic.Add("  /:/:  ,     ) :        (      /_.'__/-'|_ _ /".PadRight(50, ' '));
        BossPic.Add(" /:/: __/\\ >  __,_.----.__\\    /        (/(/(/".PadRight(50, ' '));
        BossPic.Add("(_(,_/V .'/--'    _/  __/ |   /".PadRight(50, ' '));
        BossPic.Add(" VvvV  //`    _.-' _.'     \\   \\".PadRight(50, ' '));
        BossPic.Add("   n_n//     (((/->/        |   /".PadRight(50, ' '));
        BossPic.Add("   '--'         ~='          \\  |".PadRight(50, ' '));
        BossPic.Add("                              | |_,,,".PadRight(50, ' '));
        BossPic.Add("                              \\  \\  /".PadRight(50, ' '));
        BossPic.Add("                               '.__)".PadRight(50, ' '));

        List<string> bossLoot = new List<string>();
        MonsterData bossMonster = new MonsterData("Young Red Dragon",120,120,1941,40,35,0,1000,"slashes its claws","ignores your attack","RrRRRooOOaAAR!",0,BossPic,bossLoot);
        monsterList.Add(bossMonster);

        string MonsterListString = JsonSerializer.Serialize(monsterList);
        //string filePath = "./TempDataStorage/Monsters.json";
        File.WriteAllText(filePath,MonsterListString);
    }
}

