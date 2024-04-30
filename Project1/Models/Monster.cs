namespace Project1.Entities;
public class Monster : LivingThing
{
    public string MonsterID {get; set;}
    public double MonsterAttack {get; set;}
    public int RewardXP {get; set;}
    public int RewardGold {get; set;}
    //public List<Loot> LootTable

    public Monster(string Name, int MaxHitPoints, int CurrentHitPoints, string MonsterID, double MonsterAttack, int RewardXP, int RewardGold) : base(Name,MaxHitPoints,CurrentHitPoints)
    {
        this.MonsterID = MonsterID;
        this.MonsterAttack = MonsterAttack;
        this.RewardXP = RewardXP;
        this.RewardGold = RewardGold;
    }
}