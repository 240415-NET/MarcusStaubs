namespace Project1.Rooms;

public class Room()
{
    public string RoomHash;
    public string RoomName;
    public string MovementOptions;
    public string RoomDescription;
    

    public Room(string RoomHash, string RoomName, string MovementOptions, string RoomDescription) : this()
    {
        this.RoomHash = RoomHash;
        this.RoomName = RoomName;
        this.MovementOptions = MovementOptions;
        this.RoomDescription = RoomDescription;
    }
    public bool RandomMonsterSpawn(int ChanceToSpawn)
    {
        int spawnIndicator;
        Random rnd = new Random();
        spawnIndicator = rnd.Next(0,101);
        if(spawnIndicator < ChanceToSpawn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}