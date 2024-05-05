namespace Project1.Models;

public class Location
{
    public int RoomHash {get; set;}
    public string RoomName {get; set;}
    public int EnumMovementOptions {get; set;}
    public string RoomDescription {get; set;}
    public int MonsterSpawnChance {get; set;}
    public List<int> SpawnOptions {get; set;}
    public List<string> LocationDisplay {get; set;}

    public Location(int RoomHash, string RoomName, int EnumMovementOptions, string RoomDescription, int MonsterSpawnChance, List<int> SpawnOptions, List<string> LocationDisplay)
    {
        this.RoomHash = RoomHash;
        this.RoomName = RoomName;
        this.EnumMovementOptions = EnumMovementOptions;
        this.RoomDescription = RoomDescription;
        this.MonsterSpawnChance = MonsterSpawnChance;
        this.SpawnOptions = SpawnOptions;
        this.LocationDisplay = LocationDisplay;
        
    }
}