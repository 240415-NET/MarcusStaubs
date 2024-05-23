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
            ClearExitingPlayerDataFromDBTables(currentPlayer.PlayerID);  
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
            foreach (ExploredLocation location in currentPlayer.ExploredLocations)
            {
                cmdText = @"INSERT INTO Player_Explored_Locations (PlayerID, LocationID) VALUES (@playerID, @locationID)";
                using SqlCommand cmd2 = new SqlCommand(cmdText, connection);
                cmd2.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd2.Parameters.AddWithValue("@locationID", location.locationHash);
                cmd2.ExecuteNonQuery();
            }
            //Add player's map to player map table
            for (int i = 0; i < currentPlayer.PlayerMap.Count(); i++)
            {
                cmdText = @"INSERT INTO Player_Map (PlayerID, MapLine, MapLineOrder) VALUES (@playerID, @mapLine, @mapLineOrder)";
                using SqlCommand cmd3 = new SqlCommand(cmdText, connection);
                cmd3.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd3.Parameters.AddWithValue("@mapLine", currentPlayer.PlayerMap[i].MapLine);
                cmd3.Parameters.AddWithValue("@mapLineOrder", currentPlayer.PlayerMap[i].MapLineOrder);
                cmd3.ExecuteNonQuery();
            }
            //Add player's weapon inventory to player weapon inventory table
            foreach (PlayerInventoryWeapon weapon in currentPlayer.InventoryWeapons)
            {
                cmdText = @"INSERT INTO Player_Inventory_Weapons (PlayerID, WeaponType, PlayerQuantity) VALUES (@playerID, @weaponType, @playerQuantity)";
                using SqlCommand cmd4 = new SqlCommand(cmdText, connection);
                cmd4.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd4.Parameters.AddWithValue("@weaponType", weapon.WeaponID);
                cmd4.Parameters.AddWithValue("@playerQuantity", weapon.playerQuantity);
                cmd4.ExecuteNonQuery();
            }
            //Add player's armor inventory to player armor inventory table
            foreach (PlayerInventoryArmor armor in currentPlayer.InventoryArmors)
            {
                cmdText = @"INSERT INTO Player_Inventory_Armors (PlayerID, ArmorType, PlayerQuantity) VALUES (@playerID, @armorType, @playerQuantity)";
                using SqlCommand cmd5 = new SqlCommand(cmdText, connection);
                cmd5.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd5.Parameters.AddWithValue("@armorType", armor.ArmorID);
                cmd5.Parameters.AddWithValue("@playerQuantity", armor.playerQuantity);
                cmd5.ExecuteNonQuery();
            }
            //Add player's potion inventory to player potion inventory table
            foreach (PlayerInventoryPotion potion in currentPlayer.InventoryPotions)
            {
                cmdText = @"INSERT INTO Player_Inventory_Potions (PlayerID, PotionType, PlayerQuantity) VALUES (@playerID, @potionType, @playerQuantity)";
                using SqlCommand cmd6 = new SqlCommand(cmdText, connection);
                cmd6.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd6.Parameters.AddWithValue("@potionType", potion.PotionID);
                cmd6.Parameters.AddWithValue("@playerQuantity", potion.playerQuantity);
                cmd6.ExecuteNonQuery();
            }
            //Add player's item inventory to player inventory inventory table
            foreach (PlayerInventoryItem item in currentPlayer.InventoryItems)
            {
                cmdText = @"INSERT INTO Player_Inventory_Items (PlayerID, ItemType, PlayerQuantity) VALUES (@playerID, @itemType, @playerQuantity)";
                using SqlCommand cmd7 = new SqlCommand(cmdText, connection);
                cmd7.Parameters.AddWithValue("@playerID", currentPlayer.PlayerID);
                cmd7.Parameters.AddWithValue("@itemType", item.ItemID);
                cmd7.Parameters.AddWithValue("@playerQuantity", item.playerQuantity);
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
            using SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            string cmdText = @"SELECT PlayerID, Name, CurrentHP, MaximumHP, PlayerLevel, Strength, Dexterity, Constitution, EquippedWeapon, gw.WeaponName, gw.BaseValue, gw.BaseQuantity, gw.BuyLvlRequirement, gw.AttackIncrease,
                            EquippedArmor, ga.ArmorName, ga.BaseValue, ga.BaseQuantity, ga.BuyLvlRequirement, ga.MitigationIncrease, PlayerXP, CurrentLocation, PlayerGold
                            FROM Player pl 
                            JOIN Game_Armors ga on pl.EquippedArmor = ga.ArmorID 
                            Join Game_Weapons gw on pl.EquippedWeapon = gw.WeaponID 
                            WHERE Name = @playerName";
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
                Weapon playerWeapon = new Weapon(reader.GetString(8), reader.GetString(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(13), reader.GetInt32(12));
                foundPlayer.EquippedWeapon = playerWeapon;
                Armor playerArmor = new Armor(reader.GetString(14), reader.GetString(15), reader.GetInt32(16), reader.GetInt32(17), reader.GetInt32(19), reader.GetInt32(18));
                foundPlayer.EquippedArmor = playerArmor;
                foundPlayer.PlayerXP = reader.GetInt32(20);
                foundPlayer.CurrentLocation = reader.GetInt32(21);
                foundPlayer.PlayerGold = reader.GetInt32(22);
            }
            if (foundPlayer.Name == "not found")
            {
                connection.Close();
                return null;
            }
            else
            {
                //pull player's weapon inventory from DB
                cmdText = "SELECT PlayerID, WeaponType, PlayerQuantity FROM Player_Inventory_Weapons where PlayerID = @playerID";
                using SqlCommand cmd3 = new SqlCommand(cmdText, connection);
                cmd3.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    PlayerInventoryWeapon newWeapon = new PlayerInventoryWeapon(new Guid(reader3.GetString(0)), reader3.GetInt32(2), reader3.GetString(1));
                    foundPlayer.InventoryWeapons.Add(newWeapon);
                }
                //pull player's armor inventory from DB
                cmdText = "SELECT PlayerID, ArmorType, PlayerQuantity FROM Player_Inventory_Armors where PlayerID = @playerID";
                using SqlCommand cmd4 = new SqlCommand(cmdText, connection);
                cmd4.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    PlayerInventoryArmor newArmor = new PlayerInventoryArmor(new Guid(reader4.GetString(0)), reader4.GetInt32(2), reader4.GetString(1));
                    foundPlayer.InventoryArmors.Add(newArmor);
                }
                //pull player's potion inventory from DB
                cmdText = "SELECT PlayerID, PotionType, PlayerQuantity FROM Player_Inventory_Potions where PlayerID = @playerID";
                using SqlCommand cmd5 = new SqlCommand(cmdText, connection);
                cmd5.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    PlayerInventoryPotion newPotion = new PlayerInventoryPotion(new Guid(reader5.GetString(0)), reader5.GetInt32(2), reader5.GetString(1));
                    foundPlayer.InventoryPotions.Add(newPotion);
                }
                //pull player's item inventory from DB
                cmdText = "SELECT PlayerID, ItemType, PlayerQuantity FROM Player_Inventory_Items where PlayerID = @playerID";
                using SqlCommand cmd6 = new SqlCommand(cmdText, connection);
                cmd6.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader6 = cmd6.ExecuteReader();
                while (reader6.Read())
                {
                    PlayerInventoryItem newItem = new PlayerInventoryItem(new Guid(reader6.GetString(0)), reader6.GetInt32(2), reader6.GetString(1));
                    foundPlayer.InventoryItems.Add(newItem);
                }
                //pull player's explored locations
                cmdText = "SELECT LocationID FROM Player_Explored_Locations where PlayerID = @playerID";
                using SqlCommand cmd7 = new SqlCommand(cmdText, connection);
                cmd7.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader7 = cmd7.ExecuteReader();
                while (reader7.Read())
                {
                    foundPlayer.ExploredLocations.Add(new ExploredLocation(foundPlayer.PlayerID,reader7.GetInt32(0)));
                }
                //pull player's map from DB
                cmdText = "SELECT Mapline, MapLineOrder FROM Player_Map where PlayerID = @playerID ORDER BY MapLineOrder";
                using SqlCommand cmd8 = new SqlCommand(cmdText, connection);
                cmd8.Parameters.AddWithValue("@playerID", foundPlayer.PlayerID);
                using SqlDataReader reader8 = cmd8.ExecuteReader();
                while (reader8.Read())
                {
                    foundPlayer.PlayerMap.Add(new PlayerMap(reader8.GetInt32(1), reader8.GetString(0), foundPlayer.PlayerID));
                }
                connection.Close();
                return foundPlayer;
            }
        }
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