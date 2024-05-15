using Project1.Models;

namespace Project1.Controllers;

public static class RandomTextController
{
    public static string GetGameOverText(int monsterType)
    {
        return " ";
    }

    public static string GetInnChatter()
    {

        return " ";
    }

    public static string GetKillMessge(int monsterType)
    {
        return " ";
    }

    public static ChatterBox InitializeRandomText()
    {
        ChatterBox newChatBox = new ChatterBox();
        List<string> innList = new List<string>();
        innList.Add("<Barfly>  I heard there are creepy little lizard monsters in that cave to the East of the waterfall.\n<Other barfly> Yeah, you'd have to be really strong or really dumb to go exploring in there.");
        innList.Add("<Jeff>Have you heard the gospel of biscuits?\n<Crowd>Shut up, Jeff.  You're drunk.");
        innList.Add("<Inn Keep>(sigh) why do I put up with these people… One of these days I'm going to retire to a nice farm in the middle of nowhere.");
        innList.Add("<Drunk Village Guard>I hate (hic) that stupid arms merchant.\n<Sober Village Guard>What is it this time, Phil? Are you still on about that sword?\n<Drunk Village Guard>Yeah! I've got the gold but he won't even show it to me, says I'm not strong enough! Me!? Not strong enough!?!!\n<Sober Village Guard>It's his shop, man. Just have to level up.");
        innList.Add("<Bar Patron>What is the airspeed velocity of an unladen swallow?\n<Village Idiot>I don't know…");
        innList.Add("<Village Elder>If there's anything more important than my ego around, I want it caught and shot now.");
        innList.Add("<Arthur>This must be Thursday. I never could get the hang of Thursdays.");
        innList.Add("<Bar Patron>There is a well up to the North.\n<Other Bar Patron>I've heard that, what about it?\n<Bar Patron>Well… nothing special I guess. Just saying it's there.");
        innList.Add("<Drunken Philosopher>Anyone who is capable of getting themsevles made village may\nshould on no account be allowed to do the job.");
        innList.Add("<Old Man>I heard there are some fearsome beasties in those caves. Some of em have great big axes even.\n<Drunk Patron>You don't know, old man.  There's nothing in them caves.\n<Old Man>When I was younger\n<Drunk Patron>Oh, just shut it you old coot!");
        innList.Add("<Deep Thought>The Answer to the Great Question… Of Life, the Universe and Everything… Is… Forty-two.");
        innList.Add("<Farmer>Did I do anything wrong today,or has the world always been like this and I've been too wrapped up in myself to notice?");
        innList.Add("<Marvin>I think you ought to know I'm feeling very depressed.");
        newChatBox.innChatters.messages = innList;
        return newChatBox;

    }
}
