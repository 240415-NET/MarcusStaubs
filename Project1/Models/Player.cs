namespace Project1.Entities;

public class Player : LivingThing
{
    public int PlayerLevel {get; set;}
    public int Strength {get; set;}
    public int Dexterity {get; set;}
    public int Constitution {get; set;}
    public int PlayerXP {get;set;}
    public int CurrentRoom {get; set;}
    public int CurrentRoomIndex {get; set;}
    public bool InCombat {get; set;} = false;

    public Player(string Name, int MaxHitPoints, int CurrentHitPoints,int PlayerLevel, int Strength, int Dexterity, int Constitution, int PlayerXP, int CurrentRoom, int CurrentRoomIndex) : base(Name,MaxHitPoints,CurrentHitPoints)
    {
        this.PlayerLevel = PlayerLevel;
        this.Strength = Strength;
        this.Dexterity = Dexterity;
        this.Constitution = Constitution;
        this.PlayerXP = PlayerXP;
        this.CurrentRoom = CurrentRoom;
        this.CurrentRoomIndex = CurrentRoomIndex;
        InCombat = false;
    }

    public void LevelUp()
    {
        this.Constitution += 2;
        this.Dexterity += 2;
        this.Strength +=3;
        this.MaxHitPoints += 7;
        this.CurrentHitPoints += 7;
    }

    public void Rest(int MonsterChance) //get Monster chance from current room using room index
    {
        Random rand = new Random();
        int rndNum = rand.Next(0,101);
        if(rndNum > MonsterChance)
        {
            this.CurrentHitPoints = this.MaxHitPoints;
        }
        else
        {
            //summon a monster to fight using current room index to determine type of monster
        }
    }
    

}
