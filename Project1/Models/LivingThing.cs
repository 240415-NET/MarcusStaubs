namespace Project1.Entities;

public class LivingThing
{
    public string Name {get;set;}
    public int MaxHitPoints {get; set;}
    public int CurrentHitPoints {get; set;}

    public LivingThing(string Name, int MaxHitPoints, int CurrentHitPoints)
    {
        this.Name = Name;
        this.MaxHitPoints = MaxHitPoints;
        this.CurrentHitPoints = CurrentHitPoints;
    }
}