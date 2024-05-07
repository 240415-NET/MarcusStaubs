using Project1.Models;
using System.Text.Json;

namespace Project1.Data;

public class MapStorage
{
    public static readonly string filePath = "./TempDataStorage/MapInfo.json";

    public static List<string> GetGameMap()
    {
        List<string> gameMap = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath));
        return gameMap;
    }

    public static void InitializeGameMap()
    {
        List<string> gameMap = new();
        gameMap.Add("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        gameMap.Add("^.....TTTTT..........^^^^^^^H^^^^^^^^^^^^^^^^^********************^");
        gameMap.Add("^..O..TTTTT..........^^^^^^^o^^^^^^^^^^^^^^^^^*                  *^");
        gameMap.Add("^.....TTTTT..........^^^^^^   ^^^^^^^^^^^^^^^^*   ************   *^");
        gameMap.Add("^TTTTT...............^^^^^^   ^^***************   ************   *^");
        gameMap.Add("^TTTTT...............                   *******   ************   *^");
        gameMap.Add("^TTTTT...............^^^^^^   ^^*****   *******   ************   *^");
        gameMap.Add("^TTTTTTTTTTTTTTT.....^^^^^^   ^^^^^^*   *******   ************   *^");
        gameMap.Add("^TTTTTTTTTTTTTTT.....^^^^^^   ^^^^^^*             *******        *^");
        gameMap.Add("^TTTTTTTTTTTTTTT.....^^^^^^   ^^^^^^*   *******   *******   ******^");
        gameMap.Add("^TTTTTTT TTTTTTTTTTTT^^^^^^   ^^^^^^*   *******   *******   ******^");
        gameMap.Add("^TTTTTT   TTTTTTTTTTT^^^^^^   ^^^^^^*   *******   *******   ******^");
        gameMap.Add("^TTTTTTT TTTTTTTTTTTT^^^^^^   ^^^^^^***********   *******   ******^");
        gameMap.Add("^TTTTTTTTTTTTTTTTTTTT^^^^^^   ^^^^^^^^^^^^^^^^*   *******   ******^");
        gameMap.Add("^TTTTTTTTTTTTTTTTTTTT^^^^^^   ^^^^^^^^^^^^^^^^*   *******   ******^");
        gameMap.Add("^TTTTTTTTTTTTTTTTTTTT^^^^^^^^^^^^^^^^^^^^^^^^^********************^");
        gameMap.Add("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        string gameMapString = JsonSerializer.Serialize(gameMap);
        File.WriteAllText(filePath, gameMapString);
    
    }
}