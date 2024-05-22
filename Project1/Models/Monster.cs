using System.ComponentModel.DataAnnotations;

namespace Project1.Models;
public class Monster : LivingThing
{
    public int MonsterID { get; set; }
    public int MonsterAttack { get; set; }
    public int MonsterDodge { get; set; }
    public int RewardXP { get; set; }
    public int RewardGold { get; set; }
    public string AttackText { get; set; }
    public string DodgeText { get; set; }
    public string HitText { get; set; }
    public int ChanceToFlee { get; set; }
    public List<string> MonsterDisplay { get; set; }
    public List<string> LootTable { get; set; }
    public Monster(MonsterData baseMonster) : base(baseMonster.Name, baseMonster.MaxHitPoints, baseMonster.CurrentHitPoints)
    {
        MonsterID = baseMonster.MonsterID;
        MonsterAttack = baseMonster.MonsterAttack;
        MonsterDodge = baseMonster.MonsterDodge;
        RewardXP = baseMonster.RewardXP;
        RewardGold = baseMonster.RewardGold;
        AttackText = baseMonster.AttackText;
        DodgeText = baseMonster.DodgeText;
        HitText = baseMonster.HitText;
        ChanceToFlee = baseMonster.ChanceToFlee;
        MonsterDisplay = baseMonster.MonsterDisplay;
        LootTable = baseMonster.LootTable;
    }
    public Monster(string Name, int MaxHitPoints, int CurrentHitPoints, int MonsterID, int MonsterAttack, int MonsterDodge, int RewardXP, int RewardGold, string AttackText, string DodgeText, string HitText, int ChanceToFlee, List<string> MonsterDisplay) : base(Name, MaxHitPoints, CurrentHitPoints)
    {
        this.MonsterID = MonsterID;
        this.MonsterAttack = MonsterAttack;
        this.MonsterDodge = MonsterDodge;
        this.RewardXP = RewardXP;
        this.RewardGold = RewardGold;
        this.AttackText = AttackText;
        this.DodgeText = DodgeText;
        this.HitText = HitText;
        this.ChanceToFlee = ChanceToFlee;
        this.MonsterDisplay = MonsterDisplay;
    }
    public void DisplayMonster(string playerName, int playerHP, int playerMaxHP)
    {
        for (int i = 0; i < MonsterDisplay.Count(); i++)
        {
            if (i == 0)
            {
                Console.WriteLine($"{MonsterDisplay[i]}" + String.Format("{0,20}{1,40}", Name, playerName));
            }
            else if (i == 1)
            {
                string monsterHP = $"HP: {CurrentHitPoints}/{MaxHitPoints}";
                string playersHP = $"HP: {playerHP}/{playerMaxHP}";
                Console.WriteLine($"{MonsterDisplay[i]}" + String.Format("{0,20}{1,40}", monsterHP, playersHP));
            }
            else
            {
                Console.WriteLine(MonsterDisplay[i]);
            }
        }
    }
    public string LootDrop()
    {
        Random rand = new Random();
        int result = rand.Next(0, 101);
        for (int i = 1; i <= LootTable.Count(); i++)
        {
            if (result < 80 / LootTable.Count() * i)
            {
                return LootTable[i - 1];
            }
        }
        return "No loot";
    }
}

public struct MonsterData
{
    public string Name { get; set; }
    public int MaxHitPoints { get; set; }
    public int CurrentHitPoints { get; set; }
    [Required]
    public int MonsterID { get; set; }
    public int MonsterAttack { get; set; }
    public int MonsterDodge { get; set; }
    public int RewardXP { get; set; }
    public int RewardGold { get; set; }
    public string AttackText { get; set; }
    public string DodgeText { get; set; }
    public string HitText { get; set; }
    public int ChanceToFlee { get; set; }
    public List<string> MonsterDisplay { get; set; }
    public List<string> LootTable { get; set; }

    public MonsterData(string Name, int MaxHitPoints, int CurrentHitPoints, int MonsterID, int MonsterAttack, int MonsterDodge, int RewardXP, int RewardGold, string AttackText, string DodgeText, string HitText, int ChanceToFlee, List<string> MonsterDisplay, List<string> LootTable)
    {
        this.Name = Name;
        this.MaxHitPoints = MaxHitPoints;
        this.CurrentHitPoints = CurrentHitPoints;
        this.MonsterID = MonsterID;
        this.MonsterAttack = MonsterAttack;
        this.MonsterDodge = MonsterDodge;
        this.RewardXP = RewardXP;
        this.RewardGold = RewardGold;
        this.AttackText = AttackText;
        this.DodgeText = DodgeText;
        this.HitText = HitText;
        this.ChanceToFlee = ChanceToFlee;
        this.MonsterDisplay = MonsterDisplay;
        this.LootTable = LootTable;
    }
}

