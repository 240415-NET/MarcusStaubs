using Project1.Controllers;

namespace Project1.Models;

public class Player : LivingThing
{
    public Guid PlayerID {get; set;}
    public int PlayerLevel {get; set;}
    public int Strength {get; set;}
    public int Dexterity {get; set;}
    public int Constitution {get; set;}
    public Weapon EquippedWeapon {get; set;}
    public Armor EquippedArmor {get; set;}
    public int PlayerXP {get;set;}
    public int CurrentLocation {get; set;}
    public List<string> PlayerMap {get; set;}
    public List<int> ExploredLocations {get;set;}
    public int PlayerGold {get; set;}
    public List<Item> InventoryItems {get; set;}
    public List<Weapon> InventoryWeapons {get; set;}
    public List<Armor> InventoryArmors {get; set;}
    public List<Potion> InventoryPotions {get; set;}
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
        this.PlayerGold = 0;
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
        this.EquippedWeapon = new Weapon("weapon1","Crooked Stick", 1, 1, 1);
        this.EquippedArmor = new Armor("armor1","Dirty Rags", 1, 1, 0);
        this.PlayerMap = playerMap;
        List<int> exploredLoc = new();
        exploredLoc.Add(106805);
        ExploredLocations = exploredLoc;
        InventoryItems = new List<Item>();
        InventoryWeapons = new List<Weapon>();
        InventoryArmors = new List<Armor>();
        InventoryPotions = new List<Potion>();
        InventoryPotions.Add(new Potion("potion1","Minor Healing Potion", 2, 1, 5));        
    }
    public override string ToString()
    {
        return $"{this.Name}\nLevel {this.PlayerLevel} Warrior\nHitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints}\nStrength: {this.Strength}\nDexterity: {this.Dexterity}\nConstitution: {this.Constitution}\nAttack: {this.Strength/2}\nDodge: {this.Dexterity/2}%\nDamage mitigation: {this.Constitution/8}";

    }
    public string ToString(string XPForNextLevel)
    {
        return $"        .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--.     \n       / .. \\.. \\..  .. \\.. \\.. \\..  .. \\.. \\.. \\.. \\.. \\..  .. \\.. \\.. \\    \n       \\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/ /    \n        \\ \\/\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /     \n         \\ \\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /      \n     /\\   \\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\/ /       \n    /  \\   \\ `'\\ `'  `'\\ `'\\ `'\\ `'  `'\\ `'\\ `'\\ `'\\ `'\\ `'  `'\\ `' /        \n   / /\\ \\   `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'         \n   \\ \\/ /                                                      \n    \\ \\/         \n    /\\ \\         {this.Name} \n    \\ \\/         Level {this.PlayerLevel} Warrior \n    /\\ \\         \n    \\ \\/         Hitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints} \n    /\\ \\         \n   / /\\ \\        Strength: {this.Strength} \n   \\ \\ \\/        Dexterity: {this.Dexterity} \n   /\\ \\ \\        Constitution: {this.Constitution} \n   \\ \\/ /        \n    \\ \\/         Equipped Weapon: {this.EquippedWeapon.ItemName} \n    /\\ \\         Attack: {this.Strength/2 + this.EquippedWeapon.AttackIncrease} \n    \\ \\/         \n    /\\ \\         Equipped Armor: {this.EquippedArmor.ItemName} \n    \\ \\/         Damage mitigation: {this.Constitution/8 + this.EquippedArmor.MitigationIncrease} \n    /\\ \\         \n   / /\\ \\        Dodge: {this.Dexterity/2}% chance \n   \\ \\/ /        \n    \\  /         Gold Coins: {this.PlayerGold}\n     \\/          Experience (XP): {this.PlayerXP}/{XPForNextLevel}\n	   ";
    }
    public void TimeToMove(int direction)
    {
        switch (direction)
        {
            case 1:
                CurrentLocation -= 1;
                break;
            case 2:
                CurrentLocation += 1000;
                break;
            case 4:
                CurrentLocation += 1;
                break;
            case 8:
                CurrentLocation -= 1000;
                break;
        }
    }
    public bool DoIHaveStuff()
    {
        if(this.InventoryItems.Count()==0 && this.InventoryWeapons.Count()==0 && this.InventoryArmors.Count()==0 && this.InventoryPotions.Count() ==0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public string KindsOfStuffIHave()
    {
        string outPutString = "";
        outPutString = "<E>verything";
        if(this.InventoryItems.Count() > 0)
        {
            if(outPutString != ""){outPutString+="\n";}
            outPutString += "<I>tems";
        }
        if(this.InventoryWeapons.Count() > 0)
        {
            if(outPutString != ""){outPutString+="\n";}
            outPutString += "<W>eapons";
        }
        if(this.InventoryArmors.Count() > 0)
        {
            if(outPutString != ""){outPutString+="\n";}
            outPutString += "<A>rmors";
        }
        if(this.InventoryPotions.Count() > 0)
        {
            if(outPutString != ""){outPutString+="\n";}
            outPutString += "<P>otions";
        }
        return outPutString;        
    }
    public bool DoIHaveItems()
    {
        if(InventoryItems.Count()>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DoIHaveWeapons()
    {
        if(InventoryWeapons.Count()>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DoIHaveArmors()
    {
        if(InventoryArmors.Count()>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DoIHavePotions()
    {
        if(InventoryPotions.Count()>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
