namespace Project1.Entities;

public class Player : LivingThing
{
    public int Strength {get; set;}
    public int Dexterity {get; set;}
    public int Constitution {get; set;}
    public string CurrentRoom {get; set;}

    public Player(string Name, int MaxHitPoints, int CurrentHitPoints, int Strength, int Dexterity, int Constitution, string CurrentRoom) : base(Name,MaxHitPoints,CurrentHitPoints)
    {
        this.Strength = Strength;
        this.Dexterity = Dexterity;
        this.Constitution = Constitution;
        this.CurrentRoom = CurrentRoom;
    }

}
