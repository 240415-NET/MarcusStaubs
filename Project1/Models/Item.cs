
namespace Project1.Models;

public class Item
{
    public string? ItemID {get; set;}
    public string? ItemName {get; set;}
    public int ItemBaseValue {get; set;}
    public int QuantityOfItem {get; set;}

    public Item(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem)
    {
        this.ItemID = ItemID;
        this.ItemName = ItemName;
        this.ItemBaseValue = ItemBaseValue;
        this.QuantityOfItem = QuantityOfItem;
    }
    public Item()
    {

    }
    public override string ToString()
    {
        if(QuantityOfItem > 1)
        {
            return $"{this.QuantityOfItem} {this.ItemName}s";
        }
        else
        {
            return $"{this.QuantityOfItem} {this.ItemName}";
        }
    }
}

public class Weapon : Item
{
    public int AttackIncrease {get; set;}
    public int buyLvlRequirement {get; set;}

    public Weapon(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int AttackIncrease, int buyLvlRequirement) : base(ItemID,ItemName,ItemBaseValue, QuantityOfItem)
    {
        this.AttackIncrease = AttackIncrease;
        this.buyLvlRequirement = buyLvlRequirement;
    }
    public override string ToString()
    {
        if(QuantityOfItem > 1)
        {
            return $"{this.QuantityOfItem} {this.ItemName}s: Attack increase:{this.AttackIncrease}.";
        }
        else
        {
            return $"{this.QuantityOfItem} {this.ItemName}: Attack increase:{this.AttackIncrease}.";
        }
    }
        public string EquipOption()
    {
        return $"{this.ItemName}: Increases attack by {AttackIncrease}";
    }
}

public class Armor : Item
{
    public int MitigationIncrease {get; set;}
    public int buyLvlRequirement {get; set;}

    public Armor(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int MitigationIncrease,int buyLvlRequirement) : base(ItemID,ItemName,ItemBaseValue, QuantityOfItem)
    {
        this.MitigationIncrease = MitigationIncrease;
        this.buyLvlRequirement = buyLvlRequirement;
    }
    public override string ToString()
    {
        if(QuantityOfItem > 1)
        {
            return $"{this.QuantityOfItem} {this.ItemName}s: Armor:{this.MitigationIncrease}.";
        }
        else
        {
            return $"{this.QuantityOfItem} {this.ItemName}: Armor:{this.MitigationIncrease}.";
        }
    }
    public string EquipOption()
    {
        return $"{this.ItemName}: Absorbs {MitigationIncrease} damage";
    }
}

public class Potion : Item
{
    public int HPRestoration {get; set;}
    public int buyLvlRequirement {get; set;}

    public Potion(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int HPRestoration, int buyLvlRequirement) : base(ItemID,ItemName,ItemBaseValue, QuantityOfItem)
    {
        this.HPRestoration = HPRestoration;
        this.buyLvlRequirement = buyLvlRequirement;
    }
    public Potion() : base()
    {
        this.ItemID = "potion0";
        this.ItemName = "No potion";
        this.ItemBaseValue = 0;
        this.QuantityOfItem = 0;
        this.HPRestoration = 0;
        this.buyLvlRequirement = 0;
    }
    public override string ToString()
    {
        if(QuantityOfItem > 1)
        {
            return $"{this.QuantityOfItem} {this.ItemName}s: Restores:{this.HPRestoration}HP";
        }
        else
        {
            return $"{this.QuantityOfItem} {this.ItemName}: Restores:{this.HPRestoration}HP.";
        }
    }
    public void CreateCopyOf(Potion potion)
    {
        this.ItemID = potion.ItemID;
        this.ItemName = potion.ItemName;
        this.ItemBaseValue = potion.ItemBaseValue;
        this.QuantityOfItem = potion.QuantityOfItem;
        this.HPRestoration = potion.HPRestoration;  
        this.buyLvlRequirement = potion.buyLvlRequirement;      
    }
}