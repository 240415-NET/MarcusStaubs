namespace Project1.Models;

public class ChatterBox
{
    public List<KillChatter> killChatters { get; set; }
    public GeneralChatter innChatters { get; set; }

    public ChatterBox()
    {
        killChatters = new List<KillChatter>();
        innChatters = new GeneralChatter();
    }
    public string GetChatter()
    {
        return innChatters.GetRandomMessage();
    }
    public string GetChatter(int monsterType)
    {
        foreach (KillChatter messages in killChatters)
        {
            if (messages.monsterType == monsterType)
            {
                return messages.GetRandomMessage();
            }
        }
        return String.Empty;
    }
}

public class KillChatter : GeneralChatter
{
    public int monsterType { get; set; }
    public KillChatter(int monsterType, List<string> messages) : base(messages)
    {
        this.monsterType = monsterType;
    }
}

public class GeneralChatter
{
    public List<string>? messages { get; set; }

    public GeneralChatter()
    {

    }
    public GeneralChatter(List<string> messages)
    {
        this.messages = messages;
    }
    public string GetRandomMessage()
    {
        Random rand = new Random();
        int myRand = rand.Next(0, messages.Count);
        return messages[myRand];
    }
}