using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models;

public class ChatterBox
{
    public List<KillChatter> killChatters { get; set; }
    public List<GeneralChatter> innChatters { get; set; }

    public ChatterBox()
    {
        killChatters = new List<KillChatter>();
        innChatters = new List<GeneralChatter>();
    }
    public ChatterBox(List<GeneralChatter> innChatters, List<KillChatter> killChatters)
    {
        this.innChatters = innChatters;
        this.killChatters = killChatters;
    }
    public string GetChatter()
    {
        Random rand = new Random();
        int myRand = rand.Next(0, innChatters.Count);
        return innChatters[myRand].message;
    }
    public string GetChatter(int monsterType)
    {
        foreach (KillChatter killChatter in killChatters)
        {
            if (killChatter.monsterType == monsterType)
            {
                Random rand = new Random();
                int myRand = rand.Next(0, killChatter.messages.Count);
                return killChatter.messages[myRand].message;
            }
        }
        return String.Empty;
    }
}

[Table("Kill_Chatter")]
public class KillChatter
{
    [Key]
    public int ID {get; set;}
    [Required]
    public int monsterType { get; set; }
    public List<GeneralChatter> messages { get; set; } = new();
    public KillChatter()
    { }
    public KillChatter(int monsterType, List<GeneralChatter> messages)
    {
        this.monsterType = monsterType;
        this.messages = messages;
    }
}

[Table("General_Chatter")]
public class GeneralChatter
{
    [Key]
    public int ID { get; set; }
    public string? message { get; set; }
    public GeneralChatter()
    {

    }
    public GeneralChatter(string messages)
    {
        this.message = messages;
    }
}