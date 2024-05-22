using Project1.Data;
using Project1.Models;

namespace Project1.Controllers;

public static class RandomTextController
{
    public static IChatterBoxStorage myChatStorage = new SqlChatterBoxStorage();
    public static IChatterBoxStorage alternateChatStorage = new ChatterBoxStorage();
    public static ChatterBox GetRandomText()
    {
        if (StorageHelper.GetSqlConnectionString() != null)
        {
            ChatterBox myChatBox = myChatStorage.GetChatterBox();
            return myChatBox;
        }
        else
        {
            ChatterBox myChatBox = alternateChatStorage.GetChatterBox();
            return myChatBox;
        }
    }
    public static void InitializeChatterBox()
    {
        myChatStorage.InitializeChatterBox();
    }
}
