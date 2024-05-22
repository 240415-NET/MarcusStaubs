using Project1.Controllers;
using Project1.UserInterfaces;
using System.ComponentModel.DataAnnotations;

public class InventoryItems
{
    public Guid PlayerID { get; set; }
    public int playerQuantity { get; set; }
}
public class PlayerInventoryWeapon : InventoryItems
{
    public string WeaponID { get; set; }
}

public class PlayerInventoryArmor : InventoryItems
{
    public string ArmorID { get; set; }
}

public class PlayerInventoryPotion : InventoryItems
{
    public string PotionID { get; set; }
}

public class PlayerInventoryItem : InventoryItems
{
    public string ItemID { get; set; }
}

