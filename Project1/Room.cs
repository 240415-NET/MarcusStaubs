namespace Project1.Rooms;

public class Room()
{
    private string RoomHash;
    private string MovementOptions;

    public bool RandomMonsterSpawn(double ChanceToSpawn)
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