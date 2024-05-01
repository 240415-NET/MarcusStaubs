using Project1.Entities;

namespace Project1.Rooms;

public class Room
{
    public int RoomHash;
    public string RoomName;
    public string MovementOptions;
    public int EnumMovementOptions;
    public string RoomDescription;
    public int MonsterSpawnChance;

    public List<int> SpawnOptions = new();

    public Room(int RoomHash, string RoomName, string MovementOptions, int EnumMovementOptions, string RoomDescription, int MonsterSpawnChance, List<int> SpawnOptions)
    {
        this.RoomHash = RoomHash;
        this.RoomName = RoomName;
        this.MovementOptions = MovementOptions;
        this.EnumMovementOptions = EnumMovementOptions;
        this.RoomDescription = RoomDescription;
        this.MonsterSpawnChance = MonsterSpawnChance;
        this.SpawnOptions = SpawnOptions;
        
    }
    public bool RandomMonsterSpawn()
    {
        int spawnIndicator;
        Random rnd = new Random();
        spawnIndicator = rnd.Next(0,101);
        if(spawnIndicator < MonsterSpawnChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}