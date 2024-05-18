using Project1.Models;
using Microsoft.Data.SqlClient;
namespace Project1.Data;

public class SqlItemStorage : IItemStorage
{
    public void CreateInitialItemsList()
    {
        string connString = StorageHelper.GetSqlConnectionString();
        using SqlConnection connection = new SqlConnection(connString);
        connection.Open();

        List<Item> items = new();
        Item spiderSilk = new Item("silk", "Spider Silk", 4, 1);
        items.Add(spiderSilk);
        Item rattail = new Item("tail", "Rat Tail", 3, 1);
        items.Add(rattail);
        Item ratfur = new Item("fur", "Rat Fur", 4, 1);
        items.Add(ratfur);
        Item ratpaw = new Item("paw", "Rat Paw", 6, 1);
        items.Add(ratpaw);
        Item ratfang = new Item("rfang", "Rat Fang", 6, 1);
        items.Add(ratfang);
        Item spiderfang = new Item("fang", "Spider Fang", 6, 1);
        items.Add(spiderfang);
        Item leatherscrap = new Item("scraps", "Leather Scraps", 9, 1);
        items.Add(leatherscrap);
        Item purse = new Item("purse", "Crude Purse", 12, 1);
        items.Add(purse);
        Item brkbow = new Item("bow", "Broken Bow", 15, 1);
        items.Add(brkbow);
        Item arrows = new Item("arrows", "Warped Arrows", 9, 1);
        items.Add(arrows);
        Item brkshield = new Item("shield", "Broken Shield", 15, 1);
        items.Add(brkshield);
        Item sprhead = new Item("spearhead", "Spearhead", 21, 1);
        items.Add(sprhead);
        Item roughgem = new Item("gem", "Rough Gemstone", 30, 1);
        items.Add(roughgem);
        Item herbBundle = new Item("herbs", "Bundle of Herbs", 27, 1);
        items.Add(herbBundle);
        Item cpnecklace = new Item("necklace", "Copper Necklace", 30, 1);
        items.Add(cpnecklace);

        foreach (Item item in items)
        {
            string cmdText =
                @"INSERT INTO Game_Items (ItemID, ItemName, BaseValue, BaseQuantity)
                VALUES
                (@itemID, @itemName, @baseValue, @baseQuantity)";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Parameters.AddWithValue("@itemName", item.ItemName);
            cmd.Parameters.AddWithValue("@baseValue", item.ItemBaseValue);
            cmd.Parameters.AddWithValue("@baseQuantity", item.QuantityOfItem);

            cmd.ExecuteNonQuery();
        }


        List<Potion> potions = new();
        Potion mnrHealingPotion = new Potion("potion1", "Minor Healing Potion", 3, 1, 5, 1);
        potions.Add(mnrHealingPotion);
        Potion lssHealingPotion = new Potion("potion2", "Lesser Healing Potion", 5, 1, 10, 5);
        potions.Add(lssHealingPotion);
        Potion healingPotion = new Potion("potion3", "Healing Potion", 10, 1, 20, 10);
        potions.Add(healingPotion);
        Potion mjrHealingPotion = new Potion("potion4", "Major Healing Potion", 20, 1, 50, 15);
        potions.Add(mjrHealingPotion);

        foreach (Potion potion in potions)
        {
            string cmdText =
                @"INSERT INTO Game_Potions (PotionID, PotionName, BaseValue, BaseQuantity, BuyLvlRequirement, HPRestored)
                VALUES
                (@potionID, @potionName, @baseValue, @baseQuantity, @buyLvlRequirement, @hpRestored)";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@potionID", potion.ItemID);
            cmd.Parameters.AddWithValue("@potionName", potion.ItemName);
            cmd.Parameters.AddWithValue("@baseValue", potion.ItemBaseValue);
            cmd.Parameters.AddWithValue("@baseQuantity", potion.QuantityOfItem);
            cmd.Parameters.AddWithValue("@buyLvlRequirement", potion.buyLvlRequirement);
            cmd.Parameters.AddWithValue("@hpRestored", potion.HPRestoration);

            cmd.ExecuteNonQuery();
        }


        List<Weapon> weapons = new();
        Weapon crStick = new Weapon("weapon1", "Crooked Stick", 1, 1, 1, 0);
        weapons.Add(crStick);
        Weapon trBranch = new Weapon("weapon2", "Tree Branch", 1, 1, 2, 0);
        weapons.Add(trBranch);
        Weapon club = new Weapon("weapon3", "Club", 10, 1, 3, 3);
        weapons.Add(club);
        Weapon rstyDagger = new Weapon("weapon4", "Rusty Dagger", 10, 1, 3, 0);
        weapons.Add(rstyDagger);
        Weapon btnSpear = new Weapon("weapon5", "Bent Spear", 10, 1, 3, 0);
        weapons.Add(btnSpear);
        Weapon dllShortsword = new Weapon("weapon6", "Dull Shortsword", 20, 1, 4, 7);
        weapons.Add(dllShortsword);
        Weapon stdClub = new Weapon("weapon7", "Studded Club", 20, 1, 4, 0);
        weapons.Add(stdClub);
        Weapon shortsword = new Weapon("weapon10", "Shortsword", 40, 1, 5, 10);
        weapons.Add(shortsword);
        Weapon Longsword = new Weapon("weapon12", "Longsword", 60, 1, 6, 15);
        weapons.Add(Longsword);
        Weapon Battleaxe = new Weapon("weapon13", "Battleaxe", 60, 1, 6, 0);
        weapons.Add(Battleaxe);

        foreach (Weapon weapon in weapons)
        {
            string cmdText =
                @"INSERT INTO Game_Weapons (WeaponID, WeaponName, BaseValue, BaseQuantity, BuyLvlRequirement, AttackIncrease)
                VALUES
                (@weaponID, @weaponName, @baseValue, @baseQuantity, @buyLvlRequirement, @attackIncrease)";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@weaponID", weapon.ItemID);
            cmd.Parameters.AddWithValue("@weaponName", weapon.ItemName);
            cmd.Parameters.AddWithValue("@baseValue", weapon.ItemBaseValue);
            cmd.Parameters.AddWithValue("@baseQuantity", weapon.QuantityOfItem);
            cmd.Parameters.AddWithValue("@buyLvlRequirement", weapon.buyLvlRequirement);
            cmd.Parameters.AddWithValue("@attackIncrease", weapon.AttackIncrease);

            cmd.ExecuteNonQuery();
        }

        List<Armor> armors = new();
        Armor rags = new Armor("armor1", "Dirty Rags", 1, 1, 0, 0);
        armors.Add(rags);
        Armor overalls = new Armor("armor2", "Overalls", 5, 1, 1, 1);
        armors.Add(overalls);
        Armor tatteredLeathers = new Armor("armor3", "Tattered Leathers", 10, 1, 2, 3);
        armors.Add(tatteredLeathers);
        Armor leatherArmor = new Armor("armor4", "Leather Armor", 20, 1, 3, 7);
        armors.Add(leatherArmor);
        Armor studdedLeather = new Armor("armor5", "Studded Leather", 40, 1, 4, 10);
        armors.Add(studdedLeather);
        Armor breastPlate = new Armor("armor6", "Breastplate", 60, 1, 5, 15);
        armors.Add(breastPlate);

        foreach (Armor armor in armors)
        {
            string cmdText =
                @"INSERT INTO Game_Armors (ArmorID, ArmorName, BaseValue, BaseQuantity, BuyLvlRequirement, MitigationIncrease)
                VALUES
                (@armorID, @armorName, @baseValue, @baseQuantity, @buyLvlRequirement, @mitigationIncrease)";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@armorID", armor.ItemID);
            cmd.Parameters.AddWithValue("@armorName", armor.ItemName);
            cmd.Parameters.AddWithValue("@baseValue", armor.ItemBaseValue);
            cmd.Parameters.AddWithValue("@baseQuantity", armor.QuantityOfItem);
            cmd.Parameters.AddWithValue("@buyLvlRequirement", armor.buyLvlRequirement);
            cmd.Parameters.AddWithValue("@mitigationIncrease", armor.MitigationIncrease);

            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }

    public ItemDTO getAllMyItems()
    {
        List<Item> myItems = new();
        List<Weapon> myWeapons = new();
        List<Armor> myArmors = new();
        List<Potion> myPotions = new();

        string connString = StorageHelper.GetSqlConnectionString();
        if (String.IsNullOrEmpty(connString))
        {
            return null;
        }
        else
        {
            using SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            string cmdText = "Select ItemID, ItemName, BaseValue, BaseQuantity FROM Game_Items";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string itemID = reader.GetString(0);
                string itemName = reader.GetString(1);
                int baseValue = reader.GetInt32(2);
                int baseQuantity = reader.GetInt32(3);

                Item readItem = new Item(itemID,itemName,baseValue,baseQuantity);
                myItems.Add(readItem);
            }

            cmdText = "Select WeaponID, WeaponName, BaseValue, BaseQuantity, BuyLvlRequirement, AttackIncrease FROM Game_Weapons";
            using SqlCommand cmd2 = new SqlCommand(cmdText,connection);
            using SqlDataReader reader2 = cmd2.ExecuteReader();
            while(reader2.Read())
            {
                string itemID = reader2.GetString(0);
                string itemName = reader2.GetString(1);
                int baseValue = reader2.GetInt32(2);
                int baseQuantity = reader2.GetInt32(3);
                int buyRequirement = reader2.GetInt32(4);
                int attackIncrease = reader2.GetInt32(5);

                Weapon readWeapon = new Weapon(itemID,itemName,baseValue,baseQuantity,attackIncrease,buyRequirement);
                myItems.Add(readWeapon);
            }

            cmdText = "Select ArmorID, ArmorName, BaseValue, BaseQuantity, BuyLvlRequirement, MitigationIncrease FROM Game_Armors";
            using SqlCommand cmd3 = new SqlCommand(cmdText,connection);
            using SqlDataReader reader3 = cmd3.ExecuteReader();
            while(reader3.Read())
            {
                string itemID = reader3.GetString(0);
                string itemName = reader3.GetString(1);
                int baseValue = reader3.GetInt32(2);
                int baseQuantity = reader3.GetInt32(3);
                int buyRequirement = reader3.GetInt32(4);
                int mitigationIncrease = reader3.GetInt32(5);

                Armor readArmor = new Armor(itemID,itemName,baseValue,baseQuantity,mitigationIncrease,buyRequirement);
                myItems.Add(readArmor);
            }                        

            cmdText = "Select PotionID, PotionName, BaseValue, BaseQuantity, BuyLvlRequirement, HPRestored FROM Game_Potions";
            using SqlCommand cmd4 = new SqlCommand(cmdText,connection);
            using SqlDataReader reader4 = cmd4.ExecuteReader();
            while(reader4.Read())
            {
                string itemID = reader4.GetString(0);
                string itemName = reader4.GetString(1);
                int baseValue = reader4.GetInt32(2);
                int baseQuantity = reader4.GetInt32(3);
                int buyRequirement = reader4.GetInt32(4);
                int hpRestored = reader4.GetInt32(5);

                Potion readPotion = new Potion(itemID,itemName,baseValue,baseQuantity,hpRestored,buyRequirement);
                myItems.Add(readPotion);
            } 
            connection.Close();      
            return new ItemDTO(myItems, myWeapons, myArmors, myPotions);
        }
    }
}