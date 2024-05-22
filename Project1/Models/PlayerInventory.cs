using Project1.Controllers;
using Project1.UserInterfaces;
using System.ComponentModel.DataAnnotations;

public class InventoryItem
{
    public Guid PlayerID { get; set; }
    public int playerQuantity { get; set; }

    public InventoryItem(Guid PlayerID, int quantity)
    {
        this.PlayerID = PlayerID;
        this.playerQuantity = quantity;
    }
}
public class PlayerInventoryWeapon : InventoryItem
{
    public string WeaponID { get; set; }

    public PlayerInventoryWeapon(Guid PlayerID, int quantity, string WeaponID) : base(PlayerID, quantity)
    {
        this.WeaponID = WeaponID;
    }
}

public class PlayerInventoryArmor : InventoryItem
{
    public string ArmorID { get; set; }

    public PlayerInventoryArmor(Guid PlayerID, int quantity, string ArmorID) : base(PlayerID, quantity)
    {
        this.ArmorID = ArmorID;
    }    
}

public class PlayerInventoryPotion : InventoryItem
{
    public string PotionID { get; set; }

    public PlayerInventoryPotion(Guid PlayerID, int quantity, string PotionID) : base(PlayerID, quantity)
    {
        this.PotionID = PotionID;
    }    
}

public class PlayerInventoryItem : InventoryItem
{
    public string ItemID { get; set; }

    public PlayerInventoryItem(Guid PlayerID, int quantity, string ItemID) : base(PlayerID, quantity)
    {
        this.ItemID = ItemID;
    }    
}

