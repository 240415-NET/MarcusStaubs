

using Project1.Data;

namespace Project1.Models;

public static class GameSession
{
    public static Dictionary<int, MonsterData> monsterReference { get; set; } = new();
    public static Dictionary<int, Location> locationReference { get; set; } = new();
    public static Dictionary<int, LevelChange> levelReference { get; set; } = new();
    public static Dictionary<string, Item> itemsReference { get; set; } = new();
    public static Player currentPlayer { get; set; }
    public static List<string> gameMap { get; set; } = new();
    public static List<string> displayMap { get; set; } = new();
    public static ChatterBox randomMessages { get; set; }

    static GameSession()
    {

    }
}