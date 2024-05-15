namespace Project1.Models;

public class ChatterBox
{
    public List<KillChatter> killChatters { get; set; }
    public List<DeathChatter> deathChatters { get; set; }
    public GeneralChatter innChatters { get; set; }

    public ChatterBox()
    {
        killChatters = new List<KillChatter>();
        deathChatters = new List<DeathChatter>();
        innChatters = new GeneralChatter();
    }
    public string GetChatter()
    {
        return innChatters.GetRandomMessage();
    }
    public string GetChatter(int chatType, int monsterType)
    {
        if (chatType == 1)
        {

            foreach (KillChatter messages in killChatters)
            {
                if (messages.monsterType == monsterType)
                {
                    return messages.GetRandomMessage();
                }
            }
        }
        else
        {
            foreach (DeathChatter messages in deathChatters)
            {
                if (messages.monsterType == monsterType)
                {
                    return messages.GetRandomMessage();
                }
            }
        }
        return String.Empty;
    }
}

public class KillChatter : GeneralChatter
{
    public int monsterType { get; set; }

}

public class DeathChatter : GeneralChatter
{
    public int monsterType { get; set; }
}

public class GeneralChatter
{
    public List<string>? messages { get; set; }

    public string GetRandomMessage()
    {
        Random rand = new Random();
        int myRand = rand.Next(0, messages.Count);
        return messages[myRand];
    }
}