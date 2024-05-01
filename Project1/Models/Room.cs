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
    //Temporary until I can read from the DB
    public Monster SpawnMonster(string MonsterType)
    {
        switch(MonsterType)
        {
            case "rat":
                Monster newRat = new Monster("Rat",1,1,1151,1,0,2,0,"nips","impossible!","squeak!");
                return newRat;
                break;
            case "large rat":
                Monster newLargeRat = new Monster("Large Rat",5,5,1271,3,2,5,1,"bites","hops out of the way","Squeak!");
                return newLargeRat;
                break;
            case "giant rat":
                Monster newGiantRat = new Monster("Giant Rat",10,10,1341,8,5,15,3,"chomps","lumbers aside","SQUEAK!");
                return newGiantRat;
                break;
            case "spider":
                Monster newSpider = new Monster("Spider",1,1,1152,1,50,5,0,"bites","nimbly hops away","splat");
                return newSpider;
                break;
            case "giant spider":
                Monster newGiantSpider = new Monster("Giant Spider",10,10,1272,7,15,15,3,"bites","sways to the side","Skreee!");
                return newGiantSpider;
                break;
            case "kobold worker":
                Monster newKoboldWorker = new Monster("Kobold Worker",4,4,1251,2,1,4,0,"swings its satchel","stumbles out of the way","hiss!");
                return newKoboldWorker;
                break;
            case "kobold scout":
                Monster newKoboldScout = new Monster("Kobold Scout",10,10,1321,7,10,15,3,"fires its bow","ducks","grrk!");
                return newKoboldScout;
                break;
            case "kobold warrior":
                Monster newKoboldWarrior = new Monster("Kobold Warrior",15,15,1471,10,25,25,5,"swings its sword","swats the attack away","...");
                return newKoboldWarrior;
                break;
            case "kobold chief":
                Monster newKoboldChief = new Monster("Kobold Chief",30,30,1571,15,20,50,10,"swings its great axe","casually steps out of range","You die, human!");
                return newKoboldChief;
                break;
        }
        Monster newMonster = new Monster("Rat",1,1,1151,1,0,2,0,"nips","impossible!","squeak!");
        return newMonster;        
    }
}