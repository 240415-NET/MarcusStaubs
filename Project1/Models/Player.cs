namespace Project1.Models;

public class Player : LivingThing
{
    public Guid PlayerID {get; set;}
    public int PlayerLevel {get; set;}
    public int Strength {get; set;}
    public int Dexterity {get; set;}
    public int Constitution {get; set;}
    public int PlayerXP {get;set;}
    public int CurrentLocation {get; set;}
    public Player(): base()
    {

    }
    public Player(string Name) : base(Name)
    {
        PlayerID = new Guid();
    }
    public Player(Guid PlayerID, string Name, int MaxHitPoints, int CurrentHitPoints,int PlayerLevel, int Strength, int Dexterity, int Constitution, int PlayerXP, int CurrentLocation) : base(Name,MaxHitPoints,CurrentHitPoints)
    {
        this.PlayerID = PlayerID;
        this.PlayerLevel = PlayerLevel;
        this.Strength = Strength;
        this.Dexterity = Dexterity;
        this.Constitution = Constitution;
        this.PlayerXP = PlayerXP;
        this.CurrentLocation = CurrentLocation;
    }


    

}
