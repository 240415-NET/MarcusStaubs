using Project1.Controllers;
using Project1.UserInterfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Project1.Models;

public class Player : LivingThing
{
    [Key]
    public Guid PlayerID { get; set; }
    public int PlayerLevel { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    [Required]
    public string EquippedWeaponID { get; set; }
    public Weapon EquippedWeapon { get; set; }
    [Required]
    public string EquippedArmorID { get; set; }
    public Armor EquippedArmor { get; set; }
    public int PlayerXP { get; set; }
    public int CurrentLocation { get; set; }
    public List<PlayerMap> PlayerMap { get; set; }
    public List<ExploredLocation> ExploredLocations { get; set; }
    public int PlayerGold { get; set; }
    public List<PlayerInventoryItem> InventoryItems { get; set; }
    public List<PlayerInventoryWeapon> InventoryWeapons { get; set; }
    public List<PlayerInventoryArmor> InventoryArmors { get; set; }
    public List<PlayerInventoryPotion> InventoryPotions { get; set; }
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
        PlayerMap = new();
        //List<string> playerMap = new();
        PlayerMap.Add(new PlayerMap(1, "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^", PlayerID));
        PlayerMap.Add(new PlayerMap(2, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(3, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(4, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(5, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(6, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(7, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(8, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(9, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(10, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(11, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(12, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(13, "^                                                                 ^", PlayerID));
        PlayerMap.Add(new PlayerMap(14, "^                         ^   ^                                   ^", PlayerID));
        PlayerMap.Add(new PlayerMap(15, "^                         ^   ^                                   ^", PlayerID));
        PlayerMap.Add(new PlayerMap(16, "^                         ^^^^^                                   ^", PlayerID));
        PlayerMap.Add(new PlayerMap(17, "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^", PlayerID));
        this.EquippedWeaponID = "weapon1";
        this.EquippedWeapon = new Weapon("weapon1", "Crooked Stick", 1, 1, 1, 0);
        this.EquippedArmorID = "armor1";
        this.EquippedArmor = new Armor("armor1", "Dirty Rags", 1, 1, 0, 0);
        //this.PlayerMap = playerMap;
        // List<int> exploredLoc = new();
        // exploredLoc.Add(106805);
        ExploredLocations = new();
        ExploredLocations.Add(new ExploredLocation(PlayerID, 106805));
        InventoryItems = new List<PlayerInventoryItem>();
        InventoryWeapons = new List<PlayerInventoryWeapon>();
        InventoryArmors = new List<PlayerInventoryArmor>();
        InventoryPotions = new List<PlayerInventoryPotion>();
        InventoryPotions.Add(new PlayerInventoryPotion(this.PlayerID, 1, "potion1"));
    }
    public override string ToString()
    {
        return $"{this.Name}\nLevel {this.PlayerLevel} Warrior\nHitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints}\nStrength: {this.Strength}\nDexterity: {this.Dexterity}\nConstitution: {this.Constitution}\nAttack: {this.Strength / 2}\nDodge: {this.Dexterity / 2}%\nDamage mitigation: {this.Constitution / 8}";

    }
    public string ToString(string XPForNextLevel)
    {
        return $"        .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--.     \n       / .. \\.. \\..  .. \\.. \\.. \\..  .. \\.. \\.. \\.. \\.. \\..  .. \\.. \\.. \\    \n       \\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/ /    \n        \\ \\/\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /     \n         \\ \\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /      \n     /\\   \\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\  /\\ \\/\\/ /       \n    /  \\   \\ `'\\ `'  `'\\ `'\\ `'\\ `'  `'\\ `'\\ `'\\ `'\\ `'\\ `'  `'\\ `' /        \n   / /\\ \\   `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'         \n   \\ \\/ /                                                      \n    \\ \\/         \n    /\\ \\         {this.Name} \n    \\ \\/         Level {this.PlayerLevel} Warrior \n    /\\ \\         \n    \\ \\/         Hitpoints (HP): {this.CurrentHitPoints}/{this.MaxHitPoints} \n    /\\ \\         \n   / /\\ \\        Strength: {this.Strength} \n   \\ \\ \\/        Dexterity: {this.Dexterity} \n   /\\ \\ \\        Constitution: {this.Constitution} \n   \\ \\/ /        \n    \\ \\/         Equipped Weapon: {this.EquippedWeapon.ItemName} \n    /\\ \\         Attack: {this.Strength / 2 + this.EquippedWeapon.AttackIncrease} \n    \\ \\/         \n    /\\ \\         Equipped Armor: {this.EquippedArmor.ItemName} \n    \\ \\/         Damage mitigation: {this.Constitution / 8 + this.EquippedArmor.MitigationIncrease} \n    /\\ \\         \n   / /\\ \\        Dodge: {this.Dexterity / 2}% chance \n   \\ \\/ /        \n    \\  /         Gold Coins: {this.PlayerGold}\n     \\/          Experience (XP): {this.PlayerXP}/{XPForNextLevel}\n	   ";
    }
    public int Rest()
    {
        int didMonsterSpawn = LocationController.DoesMonsterSpawn();
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
        if (CurrentLocation == 106800)
        {
            this.InventoryWeapons.Add(new PlayerInventoryWeapon(this.PlayerID, 1, "weapon20"));
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
                if (InventoryWeapons[i].WeaponID == loot.ItemID)
                {
                    InventoryWeapons[i].playerQuantity++;
                    newLoot = false;
                }
            }
            if (newLoot) { InventoryWeapons.Add(new PlayerInventoryWeapon(this.PlayerID, 1, loot.ItemID)); }
        }
        else
        {
            for (int i = 0; i < InventoryItems.Count(); i++)
            {
                if (InventoryItems[i].ItemID == loot.ItemID)
                {
                    InventoryItems[i].playerQuantity++;
                    newLoot = false;
                }
            }
            if (newLoot) { InventoryItems.Add(new PlayerInventoryItem(this.PlayerID, 1, loot.ItemID)); }
        }


    }
    public void EquipWeapon(Weapon newWeapon)
    {
        bool dupWeapon = false;
        for (int i = 0; i < InventoryWeapons.Count(); i++)
        {
            if (InventoryWeapons[i].WeaponID == EquippedWeapon.ItemID)
            {
                InventoryWeapons[i].playerQuantity++;
                dupWeapon = true;
            }
            if (InventoryWeapons[i].WeaponID == newWeapon.ItemID)
            {
                if (InventoryWeapons[i].playerQuantity == 1)
                {
                    InventoryWeapons.RemoveAt(i);
                }
                else
                {
                    InventoryWeapons[i].playerQuantity--;
                }
            }
        }
        if (!dupWeapon) { InventoryWeapons.Add(new PlayerInventoryWeapon(this.PlayerID, 1, EquippedWeapon.ItemID)); }
        EquippedWeaponID = newWeapon.ItemID;
        EquippedWeapon = newWeapon;
    }
    public void EquipArmor(Armor newArmor)
    {
        bool dupArmor = false;
        for (int i = 0; i < InventoryArmors.Count(); i++)
        {
            if (InventoryArmors[i].ArmorID == EquippedArmor.ItemID)
            {
                InventoryArmors[i].playerQuantity++;
                dupArmor = true;
            }
            if (InventoryArmors[i].ArmorID == newArmor.ItemID)
            {
                if (InventoryArmors[i].playerQuantity == 1)
                {
                    InventoryArmors.RemoveAt(i);
                }
                else
                {
                    InventoryArmors[i].playerQuantity--;
                }
            }
        }
        if (!dupArmor) { InventoryArmors.Add(new PlayerInventoryArmor(this.PlayerID, 1, EquippedArmor.ItemID)); }
        EquippedArmorID = newArmor.ItemID;
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
            if (InventoryPotions[i].PotionID == potion.ItemID)
            {
                if (InventoryPotions[i].playerQuantity > 1)
                {
                    InventoryPotions[i].playerQuantity--;
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
                    if (thingItself.ItemID == InventoryPotions[i].PotionID)
                    {
                        InventoryPotions[i].playerQuantity += thingItself.QuantityOfItem;
                        alreadyHaveOne = true;
                    }
                }
                if (!alreadyHaveOne) { InventoryPotions.Add(new PlayerInventoryPotion(this.PlayerID, 1, thingItself.ItemID)); }
                break;
            case 2:
                //2 = Weapon
                for (int i = 0; i < InventoryWeapons.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryWeapons[i].WeaponID)
                    {
                        InventoryWeapons[i].playerQuantity += thingItself.QuantityOfItem;
                        alreadyHaveOne = true;
                    }
                }
                if (!alreadyHaveOne) { InventoryWeapons.Add(new PlayerInventoryWeapon(this.PlayerID, 1, thingItself.ItemID)); }
                break;
            case 3:
                //3 = Armor
                for (int i = 0; i < InventoryArmors.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryArmors[i].ArmorID)
                    {
                        InventoryArmors[i].playerQuantity += thingItself.QuantityOfItem;
                        alreadyHaveOne = true;
                    }
                }
                if (!alreadyHaveOne) { InventoryArmors.Add(new PlayerInventoryArmor(this.PlayerID, 1, thingItself.ItemID)); }
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
                    if (thingItself.ItemID == InventoryPotions[i].PotionID)
                    {
                        if (InventoryPotions[i].playerQuantity - thingItself.QuantityOfItem == 0)
                        {
                            InventoryPotions.RemoveAt(i);
                        }
                        else
                        {
                            InventoryPotions[i].playerQuantity -= thingItself.QuantityOfItem;
                        }
                    }
                }
                break;
            case 2:
                //2 = Weapon
                for (int i = 0; i < InventoryWeapons.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryWeapons[i].WeaponID)
                    {
                        if (InventoryWeapons[i].playerQuantity - thingItself.QuantityOfItem == 0)
                        {
                            InventoryWeapons.RemoveAt(i);
                        }
                        else
                        {
                            InventoryWeapons[i].playerQuantity -= thingItself.QuantityOfItem;
                        }
                    }
                }
                break;
            case 3:
                //3 = Armor
                for (int i = 0; i < InventoryArmors.Count(); i++)
                {
                    if (thingItself.ItemID == InventoryArmors[i].ArmorID)
                    {
                        if (InventoryArmors[i].playerQuantity - thingItself.QuantityOfItem == 0)
                        {
                            InventoryArmors.RemoveAt(i);
                        }
                        else
                        {
                            InventoryArmors[i].playerQuantity -= thingItself.QuantityOfItem;
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
                        if (InventoryItems[i].playerQuantity - thingItself.QuantityOfItem == 0)
                        {
                            InventoryItems.RemoveAt(i);
                        }
                        else
                        {
                            InventoryItems[i].playerQuantity -= thingItself.QuantityOfItem;
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
                foreach (PlayerInventoryPotion potion in InventoryPotions)
                {
                    Item newPotion = GameSession.itemsReference[potion.PotionID];
                    newPotion.QuantityOfItem = potion.playerQuantity;
                    itemsToSell.Add(newPotion);
                }
                break;
            case 2:
                foreach (PlayerInventoryWeapon weapon in InventoryWeapons)
                {
                    Item newWeapon = GameSession.itemsReference[weapon.WeaponID];
                    newWeapon.QuantityOfItem = weapon.playerQuantity;
                    if (newWeapon.ItemBaseValue / 3 >= 1)
                    {
                        itemsToSell.Add(newWeapon);
                    }
                }
                break;
            case 3:
                foreach (PlayerInventoryArmor armor in InventoryArmors)
                {
                    Item newArmor = GameSession.itemsReference[armor.ArmorID];
                    newArmor.QuantityOfItem = armor.playerQuantity;
                    if (newArmor.ItemBaseValue / 3 >= 1)
                    {
                        itemsToSell.Add(newArmor);
                    }
                }
                break;
            case 4:
                foreach (PlayerInventoryItem item in InventoryItems)
                {
                    Item newItem = GameSession.itemsReference[item.ItemID];
                    newItem.QuantityOfItem = item.playerQuantity;
                    itemsToSell.Add(newItem);
                }
                break;
        }
        return itemsToSell;
    }
}
