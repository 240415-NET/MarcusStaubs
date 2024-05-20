using Project1.Models;
using Microsoft.Data.SqlClient;

namespace Project1.Data;

public class SqlPlayerStorage : IPlayerStorage
{
    public void SavePlayerData(Player currentPlayer)
    {
        string connString = StorageHelper.GetSqlConnectionString();
        if (String.IsNullOrEmpty(connString))
        {
            // backup save method if SQL is not available to the user
            PlayerStorage myPlayerStorage = new();
            myPlayerStorage.SavePlayerData(currentPlayer);
        }
        else
        {
            ClearExitingPlayerDataFromDBTables(currentPlayer.PlayerID);  //I should probably update/insert/delete as needed but clearing it all first is the easier path for now
            using SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            //Add player attributes to Player table
            string cmdText =
                @"INSERT INTO Player (PlayerID, Name, CurrentHP, MaximumHP, PlayerLevel, Strength, Dexterity, Constitution, EquippedWeapon, EquippedArmor, PlayerXP, CurrentLocation, PlayerGold)
                VALUES
                (@playerID, @playerName, @currentHP, @maxHP, @playerLevel, @strength, @dexterity, @constitution, @equippedWeapon, @equippedArmor, @playerXP, @currentLocation, @playerGold)";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
            cmd.Parameters.AddWithValue("@playerName", currentPlayer.Name);
            cmd.Parameters.AddWithValue("@currentHP", currentPlayer.CurrentHitPoints);
            cmd.Parameters.AddWithValue("@maxHP", currentPlayer.MaxHitPoints);
            cmd.Parameters.AddWithValue("@playerLevel", currentPlayer.PlayerLevel);
            cmd.Parameters.AddWithValue("@strength", currentPlayer.Strength);
            cmd.Parameters.AddWithValue("@dexterity", currentPlayer.Dexterity);
            cmd.Parameters.AddWithValue("@constitution", currentPlayer.Constitution);
            cmd.Parameters.AddWithValue("@equippedWeapon", currentPlayer.EquippedWeapon.ItemID);
            cmd.Parameters.AddWithValue("@equippedArmor", currentPlayer.EquippedArmor.ItemID);
            cmd.Parameters.AddWithValue("@playerXP", currentPlayer.PlayerXP);
            cmd.Parameters.AddWithValue("@currentLocation", currentPlayer.CurrentLocation);
            cmd.Parameters.AddWithValue("@playerGold", currentPlayer.PlayerGold);
            cmd.ExecuteNonQuery();
            //Add player's explored locations to player explored location table
            foreach (int location in currentPlayer.ExploredLocations)
            {
                cmdText = @"INSERT INTO Player_Explored_Locations (PlayerID, LocationID) VALUES (@playerID, @locationID)";
                using SqlCommand cmd2 = new SqlCommand(cmdText, connection);
                cmd2.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd2.Parameters.AddWithValue("@locationID", location);
                cmd2.ExecuteNonQuery();
            }
            //Add player's map to player map table
            for (int i = 0; i < currentPlayer.PlayerMap.Count(); i++)
            {
                cmdText = @"INSERT INTO Player_Map (PlayerID, MapLine, MapLineOrder) VALUES (@playerID, @mapLine, @mapLineOrder)";
                using SqlCommand cmd3 = new SqlCommand(cmdText, connection);
                cmd3.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd3.Parameters.AddWithValue("@mapLine", currentPlayer.PlayerMap[i]);
                cmd3.Parameters.AddWithValue("@mapLineOrder", i);
                cmd3.ExecuteNonQuery();
            }
            //Add player's weapon inventory to player weapon inventory table
            foreach (Weapon weapon in currentPlayer.InventoryWeapons)
            {
                cmdText = @"INSERT INTO Player_Inventory_Weapons (PlayerID, WeaponType, PlayerQuantity) VALUES (@playerID, @weaponType, @playerQuantity)";
                using SqlCommand cmd4 = new SqlCommand(cmdText, connection);
                cmd4.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd4.Parameters.AddWithValue("@weaponType", weapon.ItemID);
                cmd4.Parameters.AddWithValue("@playerQuantity", weapon.QuantityOfItem);
                cmd4.ExecuteNonQuery();
            }
            //Add player's armor inventory to player armor inventory table
            foreach (Armor armor in currentPlayer.InventoryArmors)
            {
                cmdText = @"INSERT INTO Player_Inventory_Armors (PlayerID, ArmorType, PlayerQuantity) VALUES (@playerID, @armorType, @playerQuantity)";
                using SqlCommand cmd5 = new SqlCommand(cmdText, connection);
                cmd5.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd5.Parameters.AddWithValue("@armorType", armor.ItemID);
                cmd5.Parameters.AddWithValue("@playerQuantity", armor.QuantityOfItem);
                cmd5.ExecuteNonQuery();
            }
            //Add player's potion inventory to player potion inventory table
            foreach (Potion potion in currentPlayer.InventoryPotions)
            {
                cmdText = @"INSERT INTO Player_Inventory_Potions (PlayerID, PotionType, PlayerQuantity) VALUES (@playerID, @potionType, @playerQuantity)";
                using SqlCommand cmd6 = new SqlCommand(cmdText, connection);
                cmd6.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd6.Parameters.AddWithValue("@potionType", potion.ItemID);
                cmd6.Parameters.AddWithValue("@playerQuantity", potion.QuantityOfItem);
                cmd6.ExecuteNonQuery();
            }
            //Add player's item inventory to player inventory inventory table
            foreach (Item item in currentPlayer.InventoryItems)
            {
                cmdText = @"INSERT INTO Player_Inventory_Items (PlayerID, ItemType, PlayerQuantity) VALUES (@playerID, @itemType, @playerQuantity)";
                using SqlCommand cmd7 = new SqlCommand(cmdText, connection);
                cmd7.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd7.Parameters.AddWithValue("@itemType", item.ItemID);
                cmd7.Parameters.AddWithValue("@playerQuantity", item.QuantityOfItem);
                cmd7.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public Player GetPlayerInfo(string playerName)
    {
        Player foundPlayer = new();
        foundPlayer.Name = "not found";
        string connString = StorageHelper.GetSqlConnectionString();
        if (String.IsNullOrEmpty(connString))
        {
            return null;
        }
        else
        {
            string foundEquippedWeapon = "";
            string foundEquippedArmor = "";

            using SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            string cmdText = "SELECT PlayerID, Name, CurrentHP, MaximumHP, PlayerLevel, Strength, Dexterity, Constitution, EquippedWeapon, EquippedArmor, PlayerXP, CurrentLocation, PlayerGold FROM Player where Name = @playerName";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@playerName", playerName);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                foundPlayer.PlayerID = new Guid(reader.GetString(0));
                foundPlayer.Name = reader.GetString(1);
                foundPlayer.CurrentHitPoints = reader.GetInt32(2);
                foundPlayer.MaxHitPoints = reader.GetInt32(3);
                foundPlayer.PlayerLevel = reader.GetInt32(4);
                foundPlayer.Strength = reader.GetInt32(5);
                foundPlayer.Dexterity = reader.GetInt32(6);
                foundPlayer.Constitution = reader.GetInt32(7);
                foundEquippedWeapon = reader.GetString(8);
                foundEquippedArmor = reader.GetString(9);
                foundPlayer.PlayerXP = reader.GetInt32(10);
                foundPlayer.CurrentLocation = reader.GetInt32(11);
                foundPlayer.PlayerGold = reader.GetInt32(12);
            }
            if (foundPlayer.Name == "not found")
            {
                connection.Close();
                return null;
            }
            else
            {
                //pull details of player's equipped weapon from DB
                foundPlayer.EquippedWeapon = GetWeaponInventoryItemFromTable(foundEquippedWeapon, 1);
                //pull details of player's equipped armor from DB
                foundPlayer.EquippedArmor = GetArmorInventoryItemFromTable(foundEquippedArmor, 1);
                //pull player's weapon inventory from DB
                cmdText = "SELECT WeaponType, PlayerQuantity FROM Player_Inventory_Weapons where PlayerID = @playerID";
                using SqlCommand cmd3 = new SqlCommand(cmdText, connection);
                cmd3.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    foundPlayer.InventoryWeapons.Add(GetWeaponInventoryItemFromTable(reader3.GetString(0), reader3.GetInt32(1)));
                }
                //pull player's armor inventory from DB
                cmdText = "SELECT ArmorType, PlayerQuantity FROM Player_Inventory_Armors where PlayerID = @playerID";
                using SqlCommand cmd4 = new SqlCommand(cmdText, connection);
                cmd4.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    foundPlayer.InventoryArmors.Add(GetArmorInventoryItemFromTable(reader4.GetString(0), reader4.GetInt32(1)));
                }
                //pull player's potion inventory from DB
                cmdText = "SELECT PotionType, PlayerQuantity FROM Player_Inventory_Potions where PlayerID = @playerID";
                using SqlCommand cmd5 = new SqlCommand(cmdText, connection);
                cmd5.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    foundPlayer.InventoryPotions.Add(GetPotionInventoryItemFromTable(reader5.GetString(0), reader5.GetInt32(1)));
                }
                //pull player's item inventory from DB
                cmdText = "SELECT ItemType, PlayerQuantity FROM Player_Inventory_Items where PlayerID = @playerID";
                using SqlCommand cmd6 = new SqlCommand(cmdText, connection);
                cmd6.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader6 = cmd6.ExecuteReader();
                while (reader6.Read())
                {
                    foundPlayer.InventoryItems.Add(GetItemInventoryItemFromTable(reader6.GetString(0), reader6.GetInt32(1)));
                }
                //pull player's explored locations
                cmdText = "SELECT LocationID FROM Player_Explored_Locations where PlayerID = @playerID";
                using SqlCommand cmd7 = new SqlCommand(cmdText, connection);
                cmd7.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader7 = cmd7.ExecuteReader();
                while (reader7.Read())
                {
                    foundPlayer.ExploredLocations.Add(reader7.GetInt32(0));
                }
                //pull player's map from DB
                cmdText = "SELECT Mapline FROM Player_Map where PlayerID = @playerID ORDER BY MapLineOrder";
                using SqlCommand cmd8 = new SqlCommand(cmdText, connection);
                cmd8.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader8 = cmd8.ExecuteReader();
                while (reader8.Read())
                {
                    foundPlayer.PlayerMap.Add(reader8.GetString(0));
                }
                connection.Close();
                return foundPlayer;
            }
        }
    }
    public Weapon GetWeaponInventoryItemFromTable(string weaponID, int playerQuantity)
    {
        string connString = StorageHelper.GetSqlConnectionString();
        using SqlConnection connection = new SqlConnection(connString);
        connection.Open();

        string cmdText = "SELECT WeaponID, WeaponName, BaseValue, BuyLvlRequirement, AttackIncrease FROM Game_Weapons where WeaponID = @equippedWeapon";
        using SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@equippedWeapon", weaponID);
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string ItemID = reader.GetString(0);
            string ItemName = reader.GetString(1);
            int ItemBaseValue = reader.GetInt32(2);
            int buyLvlRequirement = reader.GetInt32(3);
            int AttackIncrease = reader.GetInt32(4);

            Weapon foundWeapon = new Weapon(ItemID, ItemName, ItemBaseValue, playerQuantity, AttackIncrease, buyLvlRequirement);
            connection.Close();
            return foundWeapon;
        }
        connection.Close();
        return null;
    }
    public Armor GetArmorInventoryItemFromTable(string armorID, int playerQuantity)
    {
        string connString = StorageHelper.GetSqlConnectionString();
        using SqlConnection connection = new SqlConnection(connString);
        connection.Open();

        string cmdText = "SELECT ArmorID, ArmorName, BaseValue, BuyLvlRequirement, MitigationIncrease FROM Game_Armors where ArmorID = @equippedArmor";
        using SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@equippedArmor", armorID);
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string ItemID = reader.GetString(0);
            string ItemName = reader.GetString(1);
            int ItemBaseValue = reader.GetInt32(2);
            int buyLvlRequirement = reader.GetInt32(3);
            int mitigationIncrease = reader.GetInt32(4);

            Armor foundArmor = new Armor(ItemID, ItemName, ItemBaseValue, playerQuantity, mitigationIncrease, buyLvlRequirement);
            connection.Close();
            return foundArmor;
        }
        connection.Close();
        return null;
    }
    public Potion GetPotionInventoryItemFromTable(string potionID, int playerQuantity)
    {
        string connString = StorageHelper.GetSqlConnectionString();
        using SqlConnection connection = new SqlConnection(connString);
        connection.Open();

        string cmdText = "SELECT PotionID, PotionName, BaseValue, BuyLvlRequirement, HPRestored FROM Game_Potions where PotionID = @potionID";
        using SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@potionID", potionID);
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string ItemID = reader.GetString(0);
            string ItemName = reader.GetString(1);
            int ItemBaseValue = reader.GetInt32(2);
            int buyLvlRequirement = reader.GetInt32(3);
            int hpRestored = reader.GetInt32(4);

            Potion foundPotion = new Potion(ItemID, ItemName, ItemBaseValue, playerQuantity, hpRestored, buyLvlRequirement);
            connection.Close();
            return foundPotion;
        }
        connection.Close();
        return null;
    }
    public Item GetItemInventoryItemFromTable(string itemID, int playerQuantity)
    {
        string connString = StorageHelper.GetSqlConnectionString();
        using SqlConnection connection = new SqlConnection(connString);
        connection.Open();

        string cmdText = "SELECT ItemID, ItemName, BaseValue FROM Game_Items where ItemID = @itemID";
        using SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@itemID", itemID);
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string ItemID = reader.GetString(0);
            string ItemName = reader.GetString(1);
            int ItemBaseValue = reader.GetInt32(2);

            Item foundItem = new Item(ItemID, ItemName, ItemBaseValue, playerQuantity);
            connection.Close();
            return foundItem;
        }
        connection.Close();
        return null;
    }
    public void ClearExitingPlayerDataFromDBTables(Guid playerID)
    {
        string connString = StorageHelper.GetSqlConnectionString();
        if (String.IsNullOrEmpty(connString))
        {
            //Probably do nothing since we wouldn't have to clear JSON data
        }
        else
        {
            using SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            //Add player attributes to Player table
            string cmdText = @"DELETE FROM Player where PlayerID = @playerID";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@playerID", playerID);
            cmd.ExecuteNonQuery();

            cmdText = @"DELETE FROM Player_Explored_Locations where PlayerID = @playerID";
            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);
            cmd2.Parameters.AddWithValue("@playerID", playerID);
            cmd2.ExecuteNonQuery();

            cmdText = @"DELETE FROM Player_Inventory_Weapons where PlayerID = @playerID";
            using SqlCommand cmd3 = new SqlCommand(cmdText, connection);
            cmd3.Parameters.AddWithValue("@playerID", playerID);
            cmd3.ExecuteNonQuery();

            cmdText = @"DELETE FROM Player_Inventory_Armors where PlayerID = @playerID";
            using SqlCommand cmd4 = new SqlCommand(cmdText, connection);
            cmd4.Parameters.AddWithValue("@playerID", playerID);
            cmd4.ExecuteNonQuery();

            cmdText = @"DELETE FROM Player_Inventory_Potions where PlayerID = @playerID";
            using SqlCommand cmd5 = new SqlCommand(cmdText, connection);
            cmd5.Parameters.AddWithValue("@playerID", playerID);
            cmd5.ExecuteNonQuery();

            cmdText = @"DELETE FROM Player_Inventory_Items where PlayerID = @playerID";
            using SqlCommand cmd6 = new SqlCommand(cmdText, connection);
            cmd6.Parameters.AddWithValue("@playerID", playerID);
            cmd6.ExecuteNonQuery();

            cmdText = @"DELETE FROM Player_Map where PlayerID = @playerID";
            using SqlCommand cmd7 = new SqlCommand(cmdText, connection);
            cmd7.Parameters.AddWithValue("@playerID", playerID);
            cmd7.ExecuteNonQuery();
            connection.Close();
        }
        
    }
}