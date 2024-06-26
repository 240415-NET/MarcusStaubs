using Project1.Controllers;
using Project1.UserInterfaces;

namespace Project1.Models;

public class Player : LivingThing
{
    public Guid PlayerID { get; set; }
    public int PlayerLevel { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }
    public int PlayerXP { get; set; }
    public int CurrentLocation { get; set; }
    public List<string> PlayerMap { get; set; }
    public List<int> ExploredLocations { get; set; }
    public int PlayerGold { get; set; }
    public List<Item> InventoryItems { get; set; }
    public List<Weapon> InventoryWeapons { get; set; }
    public List<Armor> InventoryArmors { get; set; }
    public List<Potion> InventoryPotions { get; set; }
    public Player() : base()
    {
        PlayerMap = new();
        ExploredLocations = new();
        InventoryItems = new();
        InventoryWeapons = new();
        InventoryPotions = new();
        InventoryArmors = new();
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
        this.EquippedWeapon = new Weapon("weapon1", "Crooked Stick", 1, 1, 1, 0);
        this.EquippedArmor = new Armor("armor1", "Dirty Rags", 1, 1, 0, 0);
        this.PlayerMap = playerMap;
        List<int> exploredLoc = new();
        exploredLoc.Add(106805);
        ExploredLocations = exploredLoc;
        InventoryItems = new List<Item>();
        InventoryWeapons = new List<Weapon>();
        InventoryArmors = new List<Armor>();
        InventoryPotions = new List<Potion>();
        InventoryPotions.Add(new Potion("potion1", "Minor Healing Potion", 2, 1, 5, 1));
    }
    public override string ToString()
    {
        return $"{this.Name}\nLevel {this.PlayerLevel} Warrior\nHitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints}\nStrength: {this.Strength}\nDexterity: {this.Dexterity}\nConstitution: {this.Constitution}\nAttack: {this.Strength / 2}\nDodge: {this.Dexterity / 2}%\nDamage mitigation: {this.Constitution / 8}";

    }
    public string ToString(string XPForNextLevel)
    {
        return $"        .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--.     \n       / .. \\.. \\..  .. \\.. \\.. \\..  .. \\.. \\.. \\.. \\.. \\..  .. \\.. \\.. \\    \n       \\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/ /    \n        \\ \\/\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /     \n         \\ \\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /      \n     /\\   \\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\/ /       \n    /  \\   \\ `'\\ `'  `'\\ `'\\ `'\\ `'  `'\\ `'\\ `'\\ `'\\ `'\\ `'  `'\\ `' /        \n   / /\\ \\   `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'         \n   \\ \\/ /                                                      \n    \\ \\/         \n    /\\ \\         {this.Name} \n    \\ \\/         Level {this.PlayerLevel} Warrior \n    /\\ \\         \n    \\ \\/         Hitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints} \n    /\\ \\         \n   / /\\ \\        Strength: {this.Strength} \n   \\ \\ \\/        Dexterity: {this.Dexterity} \n   /\\ \\ \\        Constitution: {this.Constitution} \n   \\ \\/ /        \n    \\ \\/         Equipped Weapon: {this.EquippedWeapon.ItemName} \n    /\\ \\         Attack: {this.Strength / 2 + this.EquippedWeapon.AttackIncrease} \n    \\ \\/         \n    /\\ \\         Equipped Armor: {this.EquippedArmor.ItemName} \n    \\ \\/         Damage mitigation: {this.Constitution / 8 + this.EquippedArmor.MitigationIncrease} \n    /\\ \\         \n   / /\\ \\        Dodge: {this.Dexterity / 2}% chance \n   \\ \\/ /        \n    \\  /         Gold Coins: {this.PlayerGold}\n     \\/          Experience (XP): {this.PlayerXP}/{XPForNextLevel}\n	   ";
    }
    public int Rest(Location currentLocation)
    {
        int didMonsterSpawn = LocationController.DoesMonsterSpawn(currentLocation);
        if (didMonsterSpawn == 0)
        {
            CurrentHitPoints = MaxHitPoints;
            return 0;
        }
        else
        {
            return didMonsterSpawn;
        }
    }
    public void RestInTheInn()
    {
        SplashScreens.DrawMeAPicture("restInn");
        PlayerGold -= 5;
        CurrentHitPoints = MaxHitPoints;
    }
    public bool DodgeAttack()
    {
        Random rand = new Random();
        int didIDodge = rand.Next(0, 101);
        int dodgeChance = Dexterity / 2;
        if (didIDodge > dodgeChance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public int MyDamageMitigation()
    {
        int damageMitigated = Constitution / 8 + EquippedArmor.MitigationIncrease;
        return damageMitigated;
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
        if(CurrentLocation == 106800)
        {
            this.InventoryWeapons.Add(new Weapon("weapon20","Ultimate Sword",0,1,50,0));
        } 
    }
    public bool DoIHaveStuff()
    {
        if (this.InventoryItems.Count() == 0 && this.InventoryWeapons.Count() == 0 && this.InventoryArmors.Count() == 0 && this.InventoryPotions.Count() == 0)
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
        if (this.InventoryItems.Count() > 0)
        {
            if (outPutString != "") { outPutString += "\n"; }
            outPutString += "<I>tems";
        }
        if (this.InventoryWeapons.Count() > 0)
        {
            if (outPutString != "") { outPutString += "\n"; }
            outPutString += "<W>eapons";
        }
        if (this.InventoryArmors.Count() > 0)
        {
            if (outPutString != "") { outPutString += "\n"; }
            outPutString += "<A>rmors";
        }
        if (this.InventoryPotions.Count() > 0)
        {
            if (outPutString != "") { outPutString += "\n"; }
            outPutString += "<P>otions";
        }
        return outPutString;
    }
    public bool DoIHaveItems()
    {
        if (InventoryItems.Count() > 0)
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
        if (InventoryWeapons.Count() > 0)
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
        if (InventoryArmors.Count() > 0)
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
        if (InventoryPotions.Count() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GetThatLoot(Item loot)
    {
        bool newLoot = true;
        if (loot.GetType() == typeof(Weapon))
        {
            for (int i = 0; i < InventoryWeapons.Count(); i++)
            {
                if (InventoryWeapons[i].ItemID == loot.ItemID)
                {
                    InventoryWeapons[i].QuantityOfItem++;
                    newLoot = false;
                }
            }
            if (newLoot) { InventoryWeapons.Add((Weapon)loot); }
        }
        else
        {
            for (int i = 0; i < InventoryItems.Count(); i++)
            {
                if (InventoryItems[i].ItemID == loot.ItemID)
                {
                    InventoryItems[i].QuantityOfItem++;
                    newLoot = false;
                }
            }
            if (newLoot) { InventoryItems.Add(loot); }
        }


    }
    public void EquipWeapon(Weapon newWeapon)
    {
        bool dupWeapon = false;
        for (int i = 0; i < InventoryWeapons.Count(); i++)
        {
            if (InventoryWeapons[i].ItemID == EquippedWeapon.ItemID)
            {
                InventoryWeapons[i].QuantityOfItem++;
                dupWeapon = true;
            }
            if (InventoryWeapons[i].ItemID == newWeapon.ItemID)
            {
                if (InventoryWeapons[i].QuantityOfItem == 1)
                {
                    InventoryWeapons.RemoveAt(i);
                }
                else
                {
                    InventoryWeapons[i].QuantityOfItem--;
                }
            }
        }
        if (!dupWeapon) { InventoryWeapons.Add(EquippedWeapon); }
        EquippedWeapon = newWeapon;
    }
    public void EquipArmor(Armor newArmor)
    {
        bool dupArmor = false;
        for (int i = 0; i < InventoryArmors.Count(); i++)
        {
            if (InventoryArmors[i].ItemID == EquippedArmor.ItemID)
            {
                InventoryArmors[i].QuantityOfItem++;
                dupArmor = true;
            }
            if (InventoryArmors[i].ItemID == newArmor.ItemID)
            {
                if (InventoryArmors[i].QuantityOfItem == 1)
                {
                    InventoryArmors.RemoveAt(i);
                }
                else
                {
                    InventoryArmors[i].QuantityOfItem--;
                }
            }
        }
        if (!dupArmor) { InventoryArmors.Add(EquippedArmor); }
        EquippedArmor = newArmor;
    }
    public void Ding(LevelChange newLevel)
    {
        PlayerLevel = newLevel.LevelNum;
        Constitution += newLevel.ConstitutionIncrease;
        Dexterity += newLevel.DexterityIncrease;
        Strength += newLevel.StrengthIncrease;
        MaxHitPoints += newLevel.MaxHitPointIncrease;
        CurrentHitPoints = MaxHitPoints;
    }
    public void DrinkPotion(Potion potion)
    {
        CurrentHitPoints += potion.HPRestoration;
        if (CurrentHitPoints > MaxHitPoints) { CurrentHitPoints = MaxHitPoints; }
        for (int i = 0; i < InventoryPotions.Count(); i++)
        {
            if (InventoryPotions[i].ItemID == potion.ItemID)
            {
                if (InventoryPotions[i].QuantityOfItem > 1)
                {
                    InventoryPotions[i].QuantityOfItem--;
                }
                else
                {
                    InventoryPotions.RemoveAt(i);
                }
            }
        }
    }
    public void BuySomething(int typeOfThing, Item thingItself)
    {
        bool alreadyHaveOne = false;
        switch (typeOfThing)
        {
            case 1:
                //1 = Potion
                for (int i = 0; i < InventoryPotions.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryPotions[i].ItemID)
                    {
                        InventoryPotions[i].QuantityOfItem += thingItself.QuantityOfItem;
                        alreadyHaveOne = true;
                    }
                }
                if (!alreadyHaveOne) { InventoryPotions.Add((Potion)thingItself); }
                break;
            case 2:
                //2 = Weapon
                for (int i = 0; i < InventoryWeapons.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryWeapons[i].ItemID)
                    {
                        InventoryWeapons[i].QuantityOfItem += thingItself.QuantityOfItem;
                        alreadyHaveOne = true;
                    }
                }
                if (!alreadyHaveOne) { InventoryWeapons.Add((Weapon)thingItself); }
                break;
            case 3:
                //3 = Armor
                for (int i = 0; i < InventoryArmors.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryArmors[i].ItemID)
                    {
                        InventoryArmors[i].QuantityOfItem += thingItself.QuantityOfItem;
                        alreadyHaveOne = true;
                    }
                }
                if (!alreadyHaveOne) { InventoryArmors.Add((Armor)thingItself); }
                break;
        }
        PlayerGold -= thingItself.ItemBaseValue * thingItself.QuantityOfItem;
    }
    public void SellSomething(int typeOfThing, Item thingItself)
    {
        switch (typeOfThing)
        {
            case 1:
                //1 = Potion
                for (int i = 0; i < InventoryPotions.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryPotions[i].ItemID)
                    {
                        if (InventoryPotions[i].QuantityOfItem - thingItself.QuantityOfItem == 0)
                        {
                            InventoryPotions.RemoveAt(i);
                        }
                        else
                        {
                            InventoryPotions[i].QuantityOfItem -= thingItself.QuantityOfItem;
                        }
                    }
                }
                break;
            case 2:
                //2 = Weapon
                for (int i = 0; i < InventoryWeapons.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryWeapons[i].ItemID)
                    {
                        if (InventoryWeapons[i].QuantityOfItem - thingItself.QuantityOfItem == 0)
                        {
                            InventoryWeapons.RemoveAt(i);
                        }
                        else
                        {
                            InventoryWeapons[i].QuantityOfItem -= thingItself.QuantityOfItem;
                        }
                    }
                }
                break;
            case 3:
                //3 = Armor
                for (int i = 0; i < InventoryArmors.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryArmors[i].ItemID)
                    {
                        if (InventoryArmors[i].QuantityOfItem - thingItself.QuantityOfItem == 0)
                        {
                            InventoryArmors.RemoveAt(i);
                        }
                        else
                        {
                            InventoryArmors[i].QuantityOfItem -= thingItself.QuantityOfItem;
                        }
                    }
                }
                break;
            case 4:
                //4 = Item
                for (int i = 0; i < InventoryItems.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryItems[i].ItemID)
                    {
                        if (InventoryItems[i].QuantityOfItem - thingItself.QuantityOfItem == 0)
                        {
                            InventoryItems.RemoveAt(i);
                        }
                        else
                        {
                            InventoryItems[i].QuantityOfItem -= thingItself.QuantityOfItem;
                        }
                    }
                }
                break;
        }
        PlayerGold += thingItself.ItemBaseValue / 3 * thingItself.QuantityOfItem;
    }
    public List<Item> GetStuffToSell(int typeOfThing)
    {
        List<Item> itemsToSell = new();
        switch (typeOfThing)
        {
            case 1:
                foreach (Item potion in InventoryPotions)
                {
                    itemsToSell.Add(potion);
                }
                break;
            case 2:
                foreach (Item weapon in InventoryWeapons)
                {
                    if (weapon.ItemBaseValue / 3 >= 1)
                    {
                        itemsToSell.Add(weapon);
                    }
                }
                break;
            case 3:
                foreach (Item armor in InventoryArmors)
                {
                    if (armor.ItemBaseValue / 3 >= 1)
                    {
                        itemsToSell.Add(armor);
                    }
                }
                break;
            case 4:
                foreach (Item item in InventoryItems)
                {
                    itemsToSell.Add(item);
                }
                break;
        }
        return itemsToSell;
    }
}
