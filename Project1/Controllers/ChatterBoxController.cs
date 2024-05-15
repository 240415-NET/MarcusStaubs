using Project1.Models;

namespace Project1.Controllers;

public static class RandomTextController
{
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

        List<string> kill1151Strings = new();
        kill1151Strings.Add("You killed a rat! Just a regular little rat. Such a hero!");
        kill1151Strings.Add("Easiest thing to kill ever!");
        kill1151Strings.Add("That poor little rat, he never had a chance…");
        kill1151Strings.Add("I've heard those make great pets… but not that one anymore.");
        kill1151Strings.Add("Woo! A rat, this game's equivalent of a participation trophy.");
        kill1151Strings.Add("Good thing it wasn't a rabbit, those things are vicious!");
        kill1151Strings.Add("Dinner is served! No? Ok, picky eater I guess.");
        kill1151Strings.Add("Are you sure it was alive to begin with?");
        kill1151Strings.Add("That was easy… maybe too easy.");
        kill1151Strings.Add("How many of these things are there?");
        KillChatter kill1 = new KillChatter(1151, kill1151Strings);

        List<string> kill1271 = new();
        kill1271.Add("Wow, that was a big rat!");
        kill1271.Add("That was the size of a small pony!");
        kill1271.Add("Have you had your rabies shot lately?");
        kill1271.Add("Ugh! I hate those things.");
        kill1271.Add("That is certainly a rodent of unusual size…");
        kill1271.Add("Are you sure that wasn't a capybara?");
        KillChatter kill2 = new KillChatter(1271, kill1271);

        List<string> kill1341 = new();
        kill1341.Add("I wouldn't want to do that again either…");
        kill1341.Add("How exactly does a rat get to the size of an elephant?");
        kill1341.Add("What even was that?");
        kill1341.Add("Wow! I'm actually a little impressed.");
        KillChatter kill3 = new KillChatter(1341, kill1341);

        List<string> kill1152 = new();
        kill1152.Add("It was only the size of your thumbnail. Congrats…");
        kill1152.Add("Slippery little bugger wasn't it?");
        kill1152.Add("Now get a paper towel and clean that up.");
        kill1152.Add("You're pretty sure you got it anyway…\nWhy is your neck suddenly so itchy?");
        kill1152.Add("Really? I guess you just hate little spiders. That's acceptable.");
        KillChatter kill4 = new KillChatter(1152, kill1152);

        List<string> kill1272 = new();
        kill1272.Add("Now that was a spider!");
        kill1272.Add("Glad that nightmare fuel is dead now.");
        kill1272.Add("That thing had fangs the size of your legs!");
        kill1272.Add("So much goo… it's everywhere…");
        kill1272.Add("I really hope they don't get bigger than that…");
        KillChatter kill5 = new KillChatter(1272, kill1272);

        List<string> kill1251 = new();
        kill1251.Add("I think he had a brick in that purse.");
        kill1251.Add("It's so ugly it's cute. Wait…no, it really isn't.");
        KillChatter kill6 = new KillChatter(1251, kill1251);

        List<string> kill1321 = new();
        kill1321.Add("Ooh, a bow! Too bad you can't have one.");
        KillChatter kill7 = new KillChatter(1321, kill1321);

        List<string> kill1471 = new();
        kill1471.Add("That guy wasn't playing around. Was it a guy? How do you tell?\nNevermind, I don't think I actually want to know.");
        kill1471.Add("Tough little things.");
        KillChatter kill8 = new KillChatter(1471, kill1471);

        List<string> kill1571 = new();
        kill1571.Add("Nice axe… I want one.");
        kill1571.Add("The heck did that guy come from?");
        kill1571.Add("I wonder how many chiefs they have…");
        KillChatter kill9 = new KillChatter(1571, kill1571);

        newChatBox.killChatters.Add(kill1);
        newChatBox.killChatters.Add(kill2);
        newChatBox.killChatters.Add(kill3);
        newChatBox.killChatters.Add(kill4);
        newChatBox.killChatters.Add(kill5);
        newChatBox.killChatters.Add(kill6);
        newChatBox.killChatters.Add(kill7);
        newChatBox.killChatters.Add(kill8);
        newChatBox.killChatters.Add(kill9);
       
        return newChatBox;

    }
}
