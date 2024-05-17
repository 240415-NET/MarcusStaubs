using Project1.Models;
using Microsoft.Data.SqlClient;

namespace Project1.Data;

public class SqlLevelStorage : ILevelStorage
{
    public Dictionary<int, LevelChange> GetLevelList()
    {
        Dictionary<int, LevelChange> levelReference = new();
        string connString = StorageHelper.GetSqlConnectionString();
        if (String.IsNullOrEmpty(connString))
        {
            return null;
        }
        else
        {
            using SqlConnection connection = new SqlConnection(connString);

            connection.Open();
            string cmdText = "SELECT LevelNumber, XPRequirement, MaxHPIncrease, StrengthIncrease, DexterityIncrease, ConstitutionIncrease FROM Level_Progression";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int lvlNum = reader.GetInt32(0);
                int xpRequired = reader.GetInt32(1);
                int hpIncrease = reader.GetInt32(2);
                int strIncrease = reader.GetInt32(3);
                int dexIncrease = reader.GetInt32(4);
                int conIncrease = reader.GetInt32(5);
                LevelChange lvlChange = new LevelChange(lvlNum, xpRequired, hpIncrease, strIncrease, dexIncrease, conIncrease);
                levelReference.Add(lvlNum, lvlChange);
            }
            connection.Close();
            return levelReference;
        }
    }

    public void CreateLevelFile()
    {
        List<LevelChange> levelChangesList = new();

        LevelChange lvl2 = new LevelChange(2, 10, 5, 2, 2, 2);
        levelChangesList.Add(lvl2);

        LevelChange lvl3 = new LevelChange(3, 25, 5, 1, 3, 3);
        levelChangesList.Add(lvl3);

        LevelChange lvl4 = new LevelChange(4, 70, 5, 2, 2, 2);
        levelChangesList.Add(lvl4);

        LevelChange lvl5 = new LevelChange(5, 130, 10, 3, 5, 6);
        levelChangesList.Add(lvl5);

        LevelChange lvl6 = new LevelChange(6, 300, 5, 3, 2, 3);
        levelChangesList.Add(lvl6);

        LevelChange lvl7 = new LevelChange(7, 500, 5, 3, 3, 4);
        levelChangesList.Add(lvl7);

        LevelChange lvl8 = new LevelChange(8, 750, 5, 2, 2, 3);
        levelChangesList.Add(lvl8);

        LevelChange lvl9 = new LevelChange(9, 1050, 5, 3, 3, 4);
        levelChangesList.Add(lvl9);

        LevelChange lvl10 = new LevelChange(10, 1400, 15, 6, 6, 6);
        levelChangesList.Add(lvl10);

        LevelChange lvl11 = new LevelChange(11, 1800, 5, 3, 4, 4);
        levelChangesList.Add(lvl11);

        LevelChange lvl12 = new LevelChange(12, 1800, 5, 3, 4, 4);
        levelChangesList.Add(lvl12);

        LevelChange lvl13 = new LevelChange(13, 2900, 5, 3, 4, 4);
        levelChangesList.Add(lvl13);

        LevelChange lvl14 = new LevelChange(14, 3600, 5, 4, 3, 5);
        levelChangesList.Add(lvl14);

        LevelChange lvl15 = new LevelChange(15, 4400, 10, 6, 6, 6);
        levelChangesList.Add(lvl15);

        LevelChange lvl16 = new LevelChange(16, 5300, 5, 4, 4, 4);
        levelChangesList.Add(lvl16);

        LevelChange lvl17 = new LevelChange(17, 6300, 5, 5, 5, 5);
        levelChangesList.Add(lvl17);

        LevelChange lvl18 = new LevelChange(18, 7400, 5, 4, 4, 4);
        levelChangesList.Add(lvl18);

        LevelChange lvl19 = new LevelChange(19, 8600, 5, 5, 5, 5);
        levelChangesList.Add(lvl19);

        LevelChange lvl20 = new LevelChange(20, 9900, 20, 7, 12, 5);
        levelChangesList.Add(lvl20);

        string connString = StorageHelper.GetSqlConnectionString();
        using SqlConnection connection = new SqlConnection(connString);

        connection.Open();
        foreach (LevelChange lvl in levelChangesList)
        {
            string cmdText =
                @"INSERT INTO Level_Progression (LevelNumber, XPRequirement, MaxHPIncrease, StrengthIncrease, DexterityIncrease, ConstitutionIncrease)
                VALUES
                (@lvlNum, @xpReq, @maxHP, @strInc, @dexInc, @conInc)";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@lvlNum", lvl.LevelNum);
            cmd.Parameters.AddWithValue("@xpReq", lvl.XPRequiredForLevel);
            cmd.Parameters.AddWithValue("@maxHP", lvl.MaxHitPointIncrease);
            cmd.Parameters.AddWithValue("@strInc", lvl.StrengthIncrease);
            cmd.Parameters.AddWithValue("@dexInc", lvl.DexterityIncrease);
            cmd.Parameters.AddWithValue("@conInc", lvl.ConstitutionIncrease);

            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }
}