namespace Project1.Data;

public static class StorageHelper
{
    public static string GetSqlConnectionString(bool UseAlternateFile = false)
    {
        string filePath = "";
        if (UseAlternateFile)
        {
            filePath = "C:/Users/U82XLW/LocalEFDB.txt";
        }
        else
        {
            filePath = "C:/Users/U82XLW/LocalDB.txt";
        }

        if (File.Exists(filePath))
        {
            string connString = File.ReadAllText(filePath);
            return connString;
        }
        else
        {
            return null;
        }
    }
}