using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public class ItemController
{
    public static IItemStorage itemStorage = new EFItemStorage();
    public static IItemStorage alternateItemStorage = new ItemStorage();
    public static Dictionary<string,Item> GetAllGameItems()
    {
        Dictionary<string,Item> allGameItems = new();
        ItemDTO itemsFromFile = new ItemDTO();
        if(StorageHelper.GetSqlConnectionString() != null)
        {
            itemsFromFile = itemStorage.getAllMyItems();
        }
        else
        {
            itemsFromFile = alternateItemStorage.getAllMyItems();
        }
        foreach(Item item in itemsFromFile.Items)
        {
            allGameItems.Add(item.ItemID,item);
        }
        foreach(Weapon weapon in itemsFromFile.Weapons)
        {
            allGameItems.Add(weapon.ItemID,weapon);
        }
        foreach(Armor armor in itemsFromFile.Armors)
        {
            allGameItems.Add(armor.ItemID,armor);
        }
        foreach(Potion potion in itemsFromFile.Potions)
        {
            allGameItems.Add(potion.ItemID,potion);
        }                        

        return allGameItems;
    }    
    public static List<Item> GetItemsForSale(int itemType)
    {
        string strItemType = "";
        switch (itemType)
        {
            case 1:
                strItemType = "potion";
                //Buy potions
                break;
            case 2:
                strItemType = "weapon";
                //Buy weapons
                break;
            case 3:
                strItemType = "armor";
                //Buy armors
                break;
        }
        List<Item> itemsForSale = GameSession.itemsReference.Values.Where(x => x.ItemID.Contains(strItemType)).ToList();
        List<Item> filteredItemsForSale = itemsForSale.Where(x => x.buyLvlRequirement <= GameSession.currentPlayer.PlayerLevel && x.buyLvlRequirement > 0).ToList();
        return filteredItemsForSale;

    }
}