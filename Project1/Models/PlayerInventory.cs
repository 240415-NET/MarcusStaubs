using Project1.Controllers;
using Project1.UserInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models;
public class InventoryItem
{
    public Guid PlayerID { get; set; }
    public int playerQuantity { get; set; }

    public InventoryItem()
    {}
    public InventoryItem(Guid PlayerID, int quantity)
    {
        this.PlayerID = PlayerID;
        this.playerQuantity = quantity;
    }
}
[Table("Player_Inventory_Weapons")]
public class PlayerInventoryWeapon : InventoryItem
{
    public string? WeaponID { get; set; }
    public PlayerInventoryWeapon()
    {}
    public PlayerInventoryWeapon(Guid PlayerID, int quantity, string WeaponID) : base(PlayerID, quantity)
    {
        this.WeaponID = WeaponID;
    }
}

[Table("Player_Inventory_Armors")]
public class PlayerInventoryArmor : InventoryItem
{
    public string? ArmorID { get; set; }
    public PlayerInventoryArmor()
    {}
    public PlayerInventoryArmor(Guid PlayerID, int quantity, string ArmorID) : base(PlayerID, quantity)
    {
        this.ArmorID = ArmorID;
    }    
}

[Table("Player_Inventory_Potions")]
public class PlayerInventoryPotion : InventoryItem
{
    public string? PotionID { get; set; }
    public PlayerInventoryPotion()
    {}
    public PlayerInventoryPotion(Guid PlayerID, int quantity, string PotionID) : base(PlayerID, quantity)
    {
        this.PotionID = PotionID;
    }    
}

[Table("Player_Inventory_Items")]
public class PlayerInventoryItem : InventoryItem
{
    public string? ItemID { get; set; }
    public PlayerInventoryItem()
    {}
    public PlayerInventoryItem(Guid PlayerID, int quantity, string ItemID) : base(PlayerID, quantity)
    {
        this.ItemID = ItemID;
    }    
}

