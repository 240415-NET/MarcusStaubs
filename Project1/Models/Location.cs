namespace Project1.Models;

public class Location
{
    public int RoomHash {get; set;}
    public string RoomName {get; set;}
    //public string MovementOptions;
    public int EnumMovementOptions {get; set;}
    public string RoomDescription {get; set;}
    public int MonsterSpawnChance {get; set;}
    public List<int> SpawnOptions {get; set;}

    public Location(int RoomHash, string RoomName, int EnumMovementOptions, string RoomDescription, int MonsterSpawnChance, List<int> SpawnOptions)
    {
        this.RoomHash = RoomHash;
        this.RoomName = RoomName;
        //this.MovementOptions = MovementOptions;
        this.EnumMovementOptions = EnumMovementOptions;
        this.RoomDescription = RoomDescription;
        this.MonsterSpawnChance = MonsterSpawnChance;
        this.SpawnOptions = SpawnOptions;
        
    }
    // public bool RandomMonsterSpawn()
    // {
    //     int spawnIndicator;
    //     Random rnd = new Random();
    //     spawnIndicator = rnd.Next(0,101);
    //     if(spawnIndicator < MonsterSpawnChance)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    // public override string ToString()
    // {
    //     return base.ToString();
    // }
}