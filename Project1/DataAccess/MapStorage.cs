using Project1.Models;
using System.Text.Json;

namespace Project1.Data;

public class MapStorage : IMapStorage
{
    public static readonly string filePath = "./TempDataStorage/MapInfo.json";

    public List<string> GetGameMap()
    {
        List<string> gameMap = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath));
        return gameMap;
    }

    public void InitializeGameMap()
    {
        List<string> gameMap = new();
        gameMap.Add("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        gameMap.Add("^.....TTTTT.........^^^^^^^^H^^^^^^^^^^^^^^^^^********************^");
        gameMap.Add("^..O..TTTTT.........^^^^^^^^o^^^^^^^^^^^^^^^^^*                  *^");
        gameMap.Add("^.....TTTTT.........^^^^^^^   ^^^^^^^^^^^^^^^^*   ************   *^");
        gameMap.Add("^TTTTT..............^^^^^^^   ^^***************   ************   *^");
        gameMap.Add("^TTTTT...............                   *******   ************   *^");
        gameMap.Add("^TTTTT..............^^^^^^^   ^^*****   *******   ************   *^");
        gameMap.Add("^TTTTTTTTTTTTTTT....^^^^^^^   ^^^^^^*   *******   ************   *^");
        gameMap.Add("^TTTTTTTTTTTTTTT....^^^^^^^   ^^^^^^*             *******        *^");
        gameMap.Add("^TTTTTTTTTTTTTTT....^^^^^^^   ^^^^^^*   *******   *******   ******^");
        gameMap.Add("^TTTTTTT TTTTTTTTTTT^^^^^^^   ^^^^^^*   *******   *******   ******^");
        gameMap.Add("^TTTTTT   TTTTTTTTTT^^^^^^^   ^^^^^^*   *******   *******   ******^");
        gameMap.Add("^TTTTTTT TTTTTTTTTTT^^^^^^^   ^^^^^^***********   *******   ******^");
        gameMap.Add("^TTTTTTTTTTTTTTTTTTT^^^^^^^   ^^^^^^^^^^^^^^^^*   *******   ******^");
        gameMap.Add("^TTTTTTTTTTTTTTTTTTT^^^^^^^   ^^^^^^^^^^^^^^^^*   *******   ******^");
        gameMap.Add("^TTTTTTTTTTTTTTTTTTT^^^^^^^^^^^^^^^^^^^^^^^^^^********************^");
        gameMap.Add("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        string gameMapString = JsonSerializer.Serialize(gameMap);
        File.WriteAllText(filePath, gameMapString);
    
    //^TTTTTTT TT
    //^TTTTTT   T
    //^TTTTTTT TT
    //^  _  TTTTT
    //^ /_\ TTTTT
    //^ |_| TTTTT
    //^^^^^^^^^^^
    }
}