namespace Project1.Models;

public class LivingThing
{
    public string Name {get;set;}
    public int MaxHitPoints {get; set;}
    public int CurrentHitPoints {get; set;}
    public LivingThing()
    {
        
    }
    public LivingThing(string Name)
    {
        this.Name = Name;
    }
    public LivingThing(string Name, int MaxHitPoints, int CurrentHitPoints)
    {
        this.Name = Name;
        this.MaxHitPoints = MaxHitPoints;
        this.CurrentHitPoints = CurrentHitPoints;
    }
}