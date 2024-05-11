
namespace Project1.Models;

public class Item
{
    public string ItemID {get; set;}
    public string ItemName {get; set;}
    public int ItemBaseValue {get; set;}
    public int QuantityOfItem {get; set;}

    public Item(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem)
    {
        this.ItemID = ItemID;
        this.ItemName = ItemName;
        this.ItemBaseValue = ItemBaseValue;
        this.QuantityOfItem = QuantityOfItem;
    }
    public override string ToString()
    {
        if(QuantityOfItem > 1)
        {
            return $"{this.QuantityOfItem} {this.ItemName}s: Base value {ItemBaseValue}.";
        }
        else
        {
            return $"{this.QuantityOfItem} {this.ItemName}: Base value {ItemBaseValue}.";
        }
    }
}

public class Weapon : Item
{
    public int AttackIncrease {get; set;}

    public Weapon(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int AttackIncrease) : base(ItemID,ItemName,ItemBaseValue, QuantityOfItem)
    {
        this.AttackIncrease = AttackIncrease;
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

    public Armor(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int MitigationIncrease) : base(ItemID,ItemName,ItemBaseValue, QuantityOfItem)
    {
        this.MitigationIncrease = MitigationIncrease;
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

    public Potion(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int HPRestoration) : base(ItemID,ItemName,ItemBaseValue, QuantityOfItem)
    {
        this.HPRestoration = HPRestoration;
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
}