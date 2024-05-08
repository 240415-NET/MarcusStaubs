using Project1.Controllers;

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
    public List<string> PlayerMap {get; set;}
    public List<int> ExploredLocations {get;set;}
    public Player(): base()
    {

    }
    public Player(string Name) : base(Name)
    {
        PlayerID = Guid.NewGuid();
        this.MaxHitPoints = 10;
        this.CurrentHitPoints = 10;
        this.CurrentLocation = 106805;
        this.Strength = 3;
        this.Dexterity = 2;
        this.Constitution = 3;
        this.PlayerLevel = 1;
        this.PlayerXP = 0;
        List<string> playerMap = new();
        playerMap.Add("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                                                                 ^");
        playerMap.Add("^                         ^   ^                                   ^");
        playerMap.Add("^                         ^   ^                                   ^");
        playerMap.Add("^                         ^^^^^                                   ^");
        playerMap.Add("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        this.PlayerMap = playerMap;
        List<int> exploredLoc = new();
        exploredLoc.Add(106805);
        this.ExploredLocations = exploredLoc;        
    }
    public Player(Guid PlayerID, string Name, int MaxHitPoints, int CurrentHitPoints,int PlayerLevel, int Strength, int Dexterity, int Constitution, int PlayerXP, int CurrentLocation, List<string> PlayerMap) : base(Name,MaxHitPoints,CurrentHitPoints)
    {
        this.PlayerID = PlayerID;
        this.PlayerLevel = PlayerLevel;
        this.Strength = Strength;
        this.Dexterity = Dexterity;
        this.Constitution = Constitution;
        this.PlayerXP = PlayerXP;
        this.CurrentLocation = CurrentLocation;
        this.PlayerMap = PlayerMap;
    }
    public override string ToString()
    {
        return $"{this.Name}\nLevel {this.PlayerLevel} Warrior\nHitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints}\nStrength: {this.Strength}\nDexterity: {this.Dexterity}\nConstitution: {this.Constitution}\nAttack: {this.Strength/2}\nDodge: {this.Dexterity/2}%\nDamage mitigation: {this.Constitution/8}";

    }
    public string ToString(string XPForNextLevel)
    {
        return $"     .--..--..--..--..--..--..--..--..--..--..--..--..--..--.     \n    / .. \\.. \\..  .. \\.. \\.. \\..  .. \\.. \\.. \\..  .. \\.. \\.. \\    \n    \\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/ /    \n     \\ \\/\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /     \n      \\ \\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /      \n  /\\   \\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\/ /\n /  \\   \\ `'\\ `'  `'\\ `'\\ `'\\ `'  `'\\ `'\\ `'\\ `'  `'\\ `' /   \n/ /\\ \\   `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'   \n\\ \\/ /                                                      \n \\ \\/         \n /\\ \\         {this.Name}\n \\ \\/         Level {this.PlayerLevel} Warrior\n /\\ \\         \n \\ \\/         Hitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints}\n /\\ \\         \n/ /\\ \\        Strength: {this.Strength}\n\\ \\ \\/        Dexterity: {this.Dexterity}\n/\\ \\ \\        Constitution: {this.Constitution}\n\\ \\/ /        \n \\ \\/         Attack: {this.Strength/2}\n /\\ \\         Dodge: {this.Dexterity/2}\n \\ \\/         Damage mitigation: {this.Constitution/8}\n /\\ \\         \n \\ \\/         Experience (XP): {this.PlayerXP}/{XPForNextLevel}\n /\\ \\         \n/ /\\ \\        \n\\ \\/ /        \n \\  /         \n  \\/          ";
    }
}
