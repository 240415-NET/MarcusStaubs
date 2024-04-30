namespace Project1.Entities;

public class LivingThing
{
    public string Name {get;set;}
    public int MaxHitPoints {get; set;}
    public int CurrentHitPoints {get; set;}
}
public class Player : LivingThing
{
    public int Strength {get; set;}
    public int Dexterity {get; set;}
    public int Constitution {get; set;}
    public string CurrentRoom {get; set;}

}
public class Monster : LivingThing
{
    public string MonsterID {get; set;}
    public int MonsterStrength {get; set;}
    public int RewardXP {get; set;}
    public int RewardGold {get; set;}

    //public List<Loot> LootTable

}