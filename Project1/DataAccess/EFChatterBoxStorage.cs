using Project1.Models;
using Microsoft.EntityFrameworkCore;

namespace Project1.Data;
public class EFChatterBoxStorage : IChatterBoxStorage
{
    private readonly GameContext _context = new GameContext();
    public void InitializeChatterBox()
    {
        //List<string> innList = new List<string>();
        _context.InnChatter.Add(new GeneralChatter("<Barfly>  I heard there are creepy little lizard monsters in that cave to the East of the waterfall.\n<Other barfly> Yeah, you would have to be really strong or really dumb to go exploring in there."));
        _context.InnChatter.Add(new GeneralChatter("<Jeff>Have you heard the gospel of biscuits?\n<Crowd>Shut up, Jeff.  You are drunk."));
        _context.InnChatter.Add(new GeneralChatter("<Inn Keep>(sigh) why do I put up with these people… One of these days I'm going to retire to a nice farm in the middle of nowhere."));
        _context.InnChatter.Add(new GeneralChatter("<Drunk Village Guard>I hate (hic) that stupid arms merchant.\n<Sober Village Guard>What is it this time, Phil? Are you still on about that sword?\n<Drunk Village Guard>Yeah! I've got the gold but he won't even show it to me, says I'm not strong enough! Me!? Not strong enough!?!!\n<Sober Village Guard>It's his shop, man. Just have to level up."));
        _context.InnChatter.Add(new GeneralChatter("<Bar Patron>What is the airspeed velocity of an unladen swallow?\n<Village Idiot>I don't know…"));
        _context.InnChatter.Add(new GeneralChatter("<Village Elder>If there's anything more important than my ego around, I want it caught and shot now."));
        _context.InnChatter.Add(new GeneralChatter("<Arthur>This must be Thursday. I never could get the hang of Thursdays."));
        _context.InnChatter.Add(new GeneralChatter("<Bar Patron>There is a well up to the North.\n<Other Bar Patron>I've heard that, what about it?\n<Bar Patron>Well… nothing special I guess. Just saying it's there."));
        _context.InnChatter.Add(new GeneralChatter("<Drunken Philosopher>Anyone who is capable of getting themsevles made village may\nshould on no account be allowed to do the job."));
        _context.InnChatter.Add(new GeneralChatter("<Old Man>I heard there are some fearsome beasties in those caves. Some of em have great big axes even.\n<Drunk Patron>You don't know, old man.  There's nothing in them caves.\n<Old Man>When I was younger\n<Drunk Patron>Oh, just shut it you old coot!"));
        _context.InnChatter.Add(new GeneralChatter("<Deep Thought>The Answer to the Great Question… Of Life, the Universe and Everything… Is… Forty-two."));
        _context.InnChatter.Add(new GeneralChatter("<Farmer>Did I do anything wrong today,or has the world always been like this and I've been too wrapped up in myself to notice?"));
        _context.InnChatter.Add(new GeneralChatter("<Marvin>I think you ought to know I'm feeling very depressed."));

        List<GeneralChatter> kill1151Strings = new();
        kill1151Strings.Add(new GeneralChatter("You killed a rat! Just a regular little rat. Such a hero!"));
        kill1151Strings.Add(new GeneralChatter("Easiest thing to kill ever!"));
        kill1151Strings.Add(new GeneralChatter("That poor little rat, he never had a chance…"));
        kill1151Strings.Add(new GeneralChatter("I've heard those make great pets… but not that one anymore."));
        kill1151Strings.Add(new GeneralChatter("Woo! A rat, this game's equivalent of a participation trophy."));
        kill1151Strings.Add(new GeneralChatter("Good thing it wasn't a rabbit, those things are vicious!"));
        kill1151Strings.Add(new GeneralChatter("Dinner is served! No? Ok, picky eater I guess."));
        kill1151Strings.Add(new GeneralChatter("Are you sure it was alive to begin with?"));
        kill1151Strings.Add(new GeneralChatter("That was easy… maybe too easy."));
        kill1151Strings.Add(new GeneralChatter("How many of these things are there?"));
        KillChatter kill1 = new KillChatter(1151, kill1151Strings);
        _context.KillChatters.Add(kill1);

        List<GeneralChatter> kill1271 = new();
        kill1271.Add(new GeneralChatter("Wow, that was a big rat!"));
        kill1271.Add(new GeneralChatter("That was the size of a small pony!"));
        kill1271.Add(new GeneralChatter("Have you had your rabies shot lately?"));
        kill1271.Add(new GeneralChatter("Ugh! I hate those things."));
        kill1271.Add(new GeneralChatter("That is certainly a rodent of unusual size…"));
        kill1271.Add(new GeneralChatter("Are you sure that wasn't a capybara?"));
        KillChatter kill2 = new KillChatter(1271, kill1271);
        _context.KillChatters.Add(kill2);

        List<GeneralChatter> kill1341 = new();
        kill1341.Add(new GeneralChatter("I wouldn't want to do that again either…"));
        kill1341.Add(new GeneralChatter("How exactly does a rat get to the size of an elephant?"));
        kill1341.Add(new GeneralChatter("What even was that?"));
        kill1341.Add(new GeneralChatter("Wow! I'm actually a little impressed."));
        KillChatter kill3 = new KillChatter(1341, kill1341);
        _context.KillChatters.Add(kill3);

        List<GeneralChatter> kill1152 = new();
        kill1152.Add(new GeneralChatter("It was only the size of your thumbnail. Congrats…"));
        kill1152.Add(new GeneralChatter("Slippery little bugger wasn't it?"));
        kill1152.Add(new GeneralChatter("Now get a paper towel and clean that up."));
        kill1152.Add(new GeneralChatter("You're pretty sure you got it anyway…\nWhy is your neck suddenly so itchy?"));
        kill1152.Add(new GeneralChatter("Really? I guess you just hate little spiders. That's acceptable."));
        KillChatter kill4 = new KillChatter(1152, kill1152);
        _context.KillChatters.Add(kill4);

        List<GeneralChatter> kill1272 = new();
        kill1272.Add(new GeneralChatter("Now that was a spider!"));
        kill1272.Add(new GeneralChatter("Glad that nightmare fuel is dead now."));
        kill1272.Add(new GeneralChatter("That thing had fangs the size of your legs!"));
        kill1272.Add(new GeneralChatter("So much goo… it's everywhere…"));
        kill1272.Add(new GeneralChatter("I really hope they don't get bigger than that…"));
        KillChatter kill5 = new KillChatter(1272, kill1272);
        _context.KillChatters.Add(kill5);

        List<GeneralChatter> kill1251 = new();
        kill1251.Add(new GeneralChatter("I think he had a brick in that purse."));
        kill1251.Add(new GeneralChatter("It's so ugly it's cute. Wait…no, it really isn't."));
        KillChatter kill6 = new KillChatter(1251, kill1251);
        _context.KillChatters.Add(kill6);

        List<GeneralChatter> kill1321 = new();
        kill1321.Add(new GeneralChatter("Ooh, a bow! Too bad you can't have one."));
        KillChatter kill7 = new KillChatter(1321, kill1321);
        _context.KillChatters.Add(kill7);

        List<GeneralChatter> kill1471 = new();
        kill1471.Add(new GeneralChatter("That guy wasn't playing around. Was it a guy? How do you tell?\nNevermind, I don't think I actually want to know."));
        kill1471.Add(new GeneralChatter("Tough little things."));
        KillChatter kill8 = new KillChatter(1471, kill1471);
        _context.KillChatters.Add(kill8);

        List<GeneralChatter> kill1571 = new();
        kill1571.Add(new GeneralChatter("Nice axe… I want one."));
        kill1571.Add(new GeneralChatter("The heck did that guy come from?"));
        kill1571.Add(new GeneralChatter("I wonder how many chiefs they have…"));
        KillChatter kill9 = new KillChatter(1571, kill1571);
        _context.KillChatters.Add(kill9);

        _context.SaveChanges();
    }
    public ChatterBox GetChatterBox()
    {
        ChatterBox newChatBox = new()
        {
            killChatters = _context.KillChatters
            .Include(p => p.messages)
            .AsNoTracking()
            .ToList()
        };
        List<int> killChatIDs = new();
        foreach (KillChatter killChatter in newChatBox.killChatters)
        {
            foreach (GeneralChatter message in killChatter.messages)
            {
                killChatIDs.Add(message.ID);
            }
        }
        newChatBox.innChatters = _context.InnChatter.Where(x => !killChatIDs.Contains(x.ID)).AsNoTracking().ToList();
        return newChatBox;
    }
}