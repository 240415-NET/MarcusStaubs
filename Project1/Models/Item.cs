
using System.ComponentModel.DataAnnotations;

namespace Project1.Models;

public class Item
{
    [Required]
    public string? ItemID { get; set; }
    public string? ItemName { get; set; }
    public int ItemBaseValue { get; set; }
    public int QuantityOfItem { get; set; }
    public int buyLvlRequirement { get; set; }

    public Item(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem)
    {
        this.ItemID = ItemID;
        this.ItemName = ItemName;
        this.ItemBaseValue = ItemBaseValue;
        this.QuantityOfItem = QuantityOfItem;
        buyLvlRequirement = 0;
    }
    public Item()
    {
        
    }
    public override string ToString()
    {
        //Should add formatting to this output
        if (QuantityOfItem > 1)
        {
            return $"{this.QuantityOfItem} {this.ItemName}s";
        }
        else
        {
            return $"{this.QuantityOfItem} {this.ItemName}";
        }
    }
    public virtual string VendorSellingDisplay()
    {
        //This output should never really be called from anywhere
        return $"{ItemName} worth {ItemBaseValue} each";
    }
    public virtual string PlayerSellingDisplay()
    {
        return String.Format(" {0,3} | {1,-27} |                 | {2,2} GP |", QuantityOfItem, ItemName, ItemBaseValue / 3);
        //$"{ItemName} worth {ItemBaseValue / 3} each";
    }
    public void CopyFromOtherItem(Item itemToCopyFrom, int quantityForMe)
    {
        this.ItemID = itemToCopyFrom.ItemID;
        this.ItemName = itemToCopyFrom.ItemName;
        this.ItemBaseValue = itemToCopyFrom.ItemBaseValue;
        this.QuantityOfItem = quantityForMe;
        this.buyLvlRequirement = itemToCopyFrom.buyLvlRequirement;
    }
}

public class Weapon : Item
{
    public int AttackIncrease { get; set; }
    public Weapon() : base()
    {

    }
    public Weapon(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int AttackIncrease, int buyLvlRequirement) : base(ItemID, ItemName, ItemBaseValue, QuantityOfItem)
    {
        this.AttackIncrease = AttackIncrease;
        this.buyLvlRequirement = buyLvlRequirement;
    }
    public override string ToString()
    {
        //Should add formatting to this output
        if (QuantityOfItem > 1)
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
        //Should add formatting to this output
        return $"{this.ItemName}: Increases attack by {AttackIncrease}";
    }
    public override string VendorSellingDisplay()
    {
        return String.Format(" {0,-27} |  {1,6} Attack  | {2,2} GP |", ItemName, AttackIncrease, ItemBaseValue);
    }
    public override string PlayerSellingDisplay()
    {
        return String.Format(" {0,3} | {1,-27} |  {2,6} Attack  | {3,2} GP |", QuantityOfItem, ItemName, AttackIncrease, ItemBaseValue / 3);
    }
    public void CopyFromOtherWeapon(Weapon itemToCopyFrom, int quantityForMe)
    {
        this.ItemID = itemToCopyFrom.ItemID;
        this.ItemName = itemToCopyFrom.ItemName;
        this.ItemBaseValue = itemToCopyFrom.ItemBaseValue;
        this.QuantityOfItem = quantityForMe;
        this.AttackIncrease = itemToCopyFrom.AttackIncrease;
        this.buyLvlRequirement = itemToCopyFrom.buyLvlRequirement;
    }
}

public class Armor : Item
{
    public int MitigationIncrease { get; set; }

    public Armor() : base()
    {

    }
    public Armor(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int MitigationIncrease, int buyLvlRequirement) : base(ItemID, ItemName, ItemBaseValue, QuantityOfItem)
    {
        this.MitigationIncrease = MitigationIncrease;
        this.buyLvlRequirement = buyLvlRequirement;
    }
    public override string ToString()
    {
        //Should add formatting to this output
        if (QuantityOfItem > 1)
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
        //Should add formatting to this output
        return $"{this.ItemName}: Absorbs {MitigationIncrease} damage";
    }
    public override string VendorSellingDisplay()
    {
        return String.Format(" {0,-27} |  Absorbs {1,2} Dmg | {2,2} GP |", ItemName, MitigationIncrease, ItemBaseValue);
    }
    public override string PlayerSellingDisplay()
    {
        return String.Format(" {0,3} | {1,-27} |  Absorbs {2,2} Dmg | {3,2} GP |", QuantityOfItem, ItemName, MitigationIncrease, ItemBaseValue / 3);
    }
    public void CopyFromOtherArmor(Armor itemToCopyFrom, int quantityForMe)
    {
        this.ItemID = itemToCopyFrom.ItemID;
        this.ItemName = itemToCopyFrom.ItemName;
        this.ItemBaseValue = itemToCopyFrom.ItemBaseValue;
        this.QuantityOfItem = quantityForMe;
        this.MitigationIncrease = itemToCopyFrom.MitigationIncrease;
        this.buyLvlRequirement = itemToCopyFrom.buyLvlRequirement;
    }
}

public class Potion : Item
{
    public int HPRestoration { get; set; }

    public Potion(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int HPRestoration, int buyLvlRequirement) : base(ItemID, ItemName, ItemBaseValue, QuantityOfItem)
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
        //Should add formatting to this output
        if (QuantityOfItem > 1)
        {
            return $"{this.QuantityOfItem} {this.ItemName}s: Restores:{this.HPRestoration}HP";
        }
        else
        {
            return $"{this.QuantityOfItem} {this.ItemName}: Restores:{this.HPRestoration}HP.";
        }
    }
    public override string VendorSellingDisplay()
    {
        return String.Format(" {0,-27} |  Restores {1,2} HP | {2,2} GP |", ItemName, HPRestoration, ItemBaseValue);
    }
    public override string PlayerSellingDisplay()
    {
        return String.Format(" {0,3} | {1,-27} |  Restores {2,2} HP | {3,2} GP |", QuantityOfItem, ItemName, HPRestoration, ItemBaseValue / 3);
    }
    public void CreateCopyOf(Potion potion, int quantityForMe = 1)
    {
        this.ItemID = potion.ItemID;
        this.ItemName = potion.ItemName;
        this.ItemBaseValue = potion.ItemBaseValue;
        this.QuantityOfItem = quantityForMe;
        this.HPRestoration = potion.HPRestoration;
        this.buyLvlRequirement = potion.buyLvlRequirement;
    }
}