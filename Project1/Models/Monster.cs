namespace Project1.Entities;
public class Monster : LivingThing
{
    public int MonsterID {get; set;}
    public int MonsterAttack {get; set;}
    public int MonsterDodge {get; set;}
    public int RewardXP {get; set;}
    public int RewardGold {get; set;}
    public string AttackText {get; set;}
    public string DodgeText {get; set;}
    public string HitText {get; set;}
    //public List<Loot> LootTable

    public Monster(string Name, int MaxHitPoints, int CurrentHitPoints, int MonsterID, int MonsterAttack, int MonsterDodge, int RewardXP, int RewardGold, string AttackText, string DodgeText, string HitText) : base(Name,MaxHitPoints,CurrentHitPoints)
    {
        this.MonsterID = MonsterID;
        this.MonsterAttack = MonsterAttack;
        this.MonsterDodge = MonsterDodge;
        this.RewardXP = RewardXP;
        this.RewardGold = RewardGold;
        this.AttackText = AttackText;
        this.DodgeText = DodgeText;
        this.HitText = HitText;
    }

    public bool DodgeAttack(int PlayerDexterity)
    {
        double QuarterPlayerDex = (double)PlayerDexterity / 4;
        int offSet = (int)QuarterPlayerDex;
        if(MonsterDodge - offSet <= 0)
        {
            return false;
        }
        else
        {
            Random rand = new Random();
            int rndNum = rand.Next(0,101);
            if(rndNum <= MonsterDodge - offSet)
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