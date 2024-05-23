using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public ChatterBox(GeneralChatter innChatters, List<KillChatter> killChatters)
    {
        this.innChatters = innChatters;
        this.killChatters = killChatters;
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

[Table("Kill_Chatter")]
public class KillChatter : GeneralChatter
{
    [Required]
    public int monsterType { get; set; }
    public KillChatter()
    {
        messages = new();
    }
    public KillChatter(int monsterType, List<string> messages) : base(messages)
    {
        this.monsterType = monsterType;
    }
}

//[Table("General_Chatter")]
public class GeneralChatter
{
    [Key]
    public int ID {get; set;}
    public List<string>? messages { get; set; }
    public GeneralChatter()
    {
        messages = new();
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