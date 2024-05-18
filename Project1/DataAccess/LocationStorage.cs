using System.Text.Json;
using Project1.Models;

namespace Project1.Data;

public class LocationStorage : ILocationStorage
{
    public static readonly string filePath = "./TempDataStorage/Locations.json";
    public Dictionary<int, Location> GetLocationsList()
    {
        Dictionary<int, Location> locationReference = new();
        if(!File.Exists(filePath))
        {
            CreateLocationFile();
        }
        List<Location> locations = JsonSerializer.Deserialize<List<Location>>(File.ReadAllText(filePath));
        foreach (Location location in locations)
        {
            locationReference.Add(location.RoomHash, location);
        }
        return locationReference;
    }
    public void CreateLocationFile()
    {
        List<Location> locationList = new List<Location>();
        List<string> mtnPath = new();
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("                                                                                ");
        mtnPath.Add("   __             _       ,                                          _       ,  ");
        mtnPath.Add("__/  \\           / \\_    / \\_                    /\\ __              / \\_    / \\_");
        mtnPath.Add("`'\\_/\\          /    \\  /    \\,                _/  /  \\            /    \\  /    ");
        mtnPath.Add("    _:\\ _      /\\/\\  /\\/ :' __ \\_           _^/  ^/    `--.       /\\/\\  /\\/ /\\ _");
        mtnPath.Add("\\ .  __/ \\    /    \\/  \\  _/  \\-'\\_________/.' ^_   \\_   .'\\   _ /    \\/  \\/ _/ ");
        mtnPath.Add(" `._/  ^  \\ /\\  .-   `. \\/     \\  \\ . / \\,/;.  _/ \\ -. `_/   \\/ /\\  .^   -. \\/  ");
        mtnPath.Add("`-. `.  -  /  `-.__ ^   / .-'.--\\  |^/   \\|^/  _ `--./ .-'  `-\\/  `-.__/^   / .-");
        mtnPath.Add("   \\  \\  ./        `.  / /       `.\\/     \\/.-'      '-._ `._   '\\   /  '-_     ");

        List<string> mtnPond = new();
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("                                                                                ");
        mtnPond.Add("  __                                             /\\            __             _ ");
        mtnPond.Add(" /  \\__      ___                       __       /  \\  __  /\\__/  \\           / \\");
        mtnPond.Add("/   '  \\____/   \\    _.___________..__/  \\     /    \\/  \\/ .` \\_  \\         /   ");
        mtnPond.Add("  _/  -   __  -  \\__/  |   |     |        `--./.'  ^  `-.\\ _    '  \\_      /\\/\\ ");
        mtnPond.Add("    -__  /- \\____//    | |   |  ||    ' ^ _   \\_   .'\\   _/ \\ .  __/ \\    /    \\");
        mtnPond.Add("\\___/  \\/'    __/      |  |  |   |      _/ \\ -. `_/   \\ /    `._/  ^  \\ /\\  .-  ");
        mtnPond.Add("/       \\    /    '-   |'. .' .`.|     /    `--./ .-'  `-.  `-. `.  -  /  `-.__ ");
        mtnPond.Add("          '    ________|0oOO0oO0o|____/  .-'   / .   .'   \\    \\  \\  ./        `");

        List<string> meadow1 = new();
        meadow1.Add("                                                                                ");
        meadow1.Add("                                                                                ");
        meadow1.Add("                                                                                ");
        meadow1.Add("                                                                                ");
        meadow1.Add("                                                                                ");
        meadow1.Add("                                                                                ");
        meadow1.Add("                                                                         .--.   ");
        meadow1.Add("                                                                       .'_\\/_'. ");
        meadow1.Add("                                                                       '. /\\ .' ");
        meadow1.Add("         .--.                                                            \"||\"   ");
        meadow1.Add("~~~~~~~.'_\\/_'.~~\\/~~~~~~~~~~~~~_~~~~~~~~~~~~~~~~~~~~~~__/)~~~~~~~~~~~~~~~||~/\\~");
        meadow1.Add(" ..    '. /\\ .'   .   --.'    .\\ /.        .-       .-(__(=:   .__     /\\ ||//\\)");
        meadow1.Add("         \"||\"  '             < ~O~ >   \\/        |\\ |    \\)           (/\\\\||/   ");
        meadow1.Add("  .       || /\\   ''__.       '/_\\'          ..  \\ ||         \\/         \\||/   ");
        meadow1.Add("       /\\ ||//\\)         \\/   \\ | /   .'          \\||   .__        '    .-^^--._");
        meadow1.Add("\\/    (/\\\\||/    \\/ .   .'     \\|/        \\/       \\|      '                    ");
        meadow1.Add("-..______\\||/__..__.-._ _ \\/__.'^'.  :  __.-._     _|._  \\/ __ .:._  .,__- \\/ ._");

        List<string> meadow2 = new();
        meadow2.Add("                                                                                ");
        meadow2.Add("                                                                                ");
        meadow2.Add("                                                                                ");
        meadow2.Add("                                                                                ");
        meadow2.Add("                                                                                ");
        meadow2.Add("                                                                                ");
        meadow2.Add("                                                   .--.                         ");
        meadow2.Add("                                                 .'_\\/_'.                       ");
        meadow2.Add("                                                 '. /\\ .'                 .--.  ");
        meadow2.Add("                                                   \"||\"                 .'_\\/_'.");
        meadow2.Add("~~~~~~~~~~_~~~~~~~~~~~~~~~~~~~~~~__/)~~~~~~~~~~~~~~~||~/\\~~~~~~~~~~~~~~~'. /\\ .'");
        meadow2.Add("--.'    .\\ /.        .-       .-(__(=:   .__     /\\ ||//\\)   .-           \"||\"  ");
        meadow2.Add("       < ~O~ >   \\/        |\\ |    \\)           (/\\\\||/         \\/         || /\\");
        meadow2.Add(".       '/_\\'          ..  \\ ||         \\/         \\||/                 /\\ ||//\\");
        meadow2.Add("   \\/   \\ | /   .'          \\||   .__        '    .-^^--.__    --      (/\\\\||/  ");
        meadow2.Add("  .'     \\|/        \\/       \\|      '                       \\/   '       \\||/  ");
        meadow2.Add("_ _ \\/__.'^'.  :  __.-._     _|._  \\/ __ .:._  .,__- \\/ .__        ..^-.__   :._");

        List<string> meadow3 = new();
        meadow3.Add("                                                                                ");
        meadow3.Add("                                                                                ");
        meadow3.Add("                                                                                ");
        meadow3.Add("                                                                                ");
        meadow3.Add("                                                                                ");
        meadow3.Add("                                                                                ");
        meadow3.Add("                                                                                ");
        meadow3.Add("            _                                                                   ");
        meadow3.Add("          .\\ /.                                                           .--.  ");
        meadow3.Add("         < ~O~ >                        .--.                            .'_\\/_'.");
        meadow3.Add("~~~~~~~~~~'/_\\'~~~~~~~~~~~~~~~~~~~~~~~.'_\\/_'.~~\\/~~~~~~~~~~~~~~~~~~~~~~'. /\\ .'");
        meadow3.Add("  \\/..__..\\ | /          \\/  .  ..    '. /\\ .'   .   --.'    .-           \"||\"  ");
        meadow3.Add("\\/         \\|/ \\/   \\/                  \"||\"  '                 \\/         || /\\");
        meadow3.Add("        . .'^'.            \\/    .       || /\\   ''__.                  /\\ ||//\\");
        meadow3.Add(". \\/             .   \\/     .         /\\ ||//\\)         \\/     --      (/\\\\||/  ");
        meadow3.Add("   __...--..__..__       .     \\/    (/\\\\||/    \\/ .   .'    \\/   '       \\||/  ");
        meadow3.Add("\\/  .   .    \\/     \\/    __..--..______\\||/__..__.-._ _ \\/_       ..^-.__   :._");

        List<string> meadow4 = new();
        meadow4.Add("                                                                                ");
        meadow4.Add("                                                                                ");
        meadow4.Add("                                                                                ");
        meadow4.Add("                                                                                ");
        meadow4.Add("                                                                                ");
        meadow4.Add("                                                                                ");
        meadow4.Add("                                                                                ");
        meadow4.Add("            _                                                                   ");
        meadow4.Add("          .\\ /.                                                                 ");
        meadow4.Add("         < ~O~ >                        .--.                                    ");
        meadow4.Add("~~~~~~~~~~'/_\\'~~~~~~~~~~~~~~~~~~~~~~~.'_\\/_'.~~\\/~~~~~~~~~~~~~_~~~~~~~~~~~~~~~~");
        meadow4.Add("  \\/..__..\\ | /          \\/  .  ..    '. /\\ .'   .   --.'    .\\ /.        .-    ");
        meadow4.Add("\\/         \\|/ \\/   \\/                  \"||\"  '             < ~O~ >   \\/        ");
        meadow4.Add("        . .'^'.            \\/    .       || /\\   ''__.       '/_\\'          ..  ");
        meadow4.Add(". \\/             .   \\/     .         /\\ ||//\\)         \\/   \\ | /   .'         ");
        meadow4.Add("   __...--..__..__       .     \\/    (/\\\\||/    \\/ .   .'     \\|/        \\/     ");
        meadow4.Add("\\/  .   .    \\/     \\/    __..--..______\\||/__..__.-._ _ \\/__.'^'.  :  __.-._ ");

        List<string> frstClear = new();
        frstClear.Add("~~\\                                                                             ");
        frstClear.Add("~~~\\                                                                            ");
        frstClear.Add("~~~~\\                                                                           ");
        frstClear.Add("~~~~\\                                                                           ");
        frstClear.Add("\\~~~~\\                                                                         /");
        frstClear.Add("%\\~~~\\       /\\                                                               /%");
        frstClear.Add("%%\\~~~\\     /%%\\                                                             /%%");
        frstClear.Add("%%%\\~~~\\   /%%%%\\                                                           /%%%");
        frstClear.Add("%%%\\~~~~\\  /%%%%\\                                                           /%%%");
        frstClear.Add("%%%%\\~~~~\\/%%%%%%\\                                                          /%%%");
        frstClear.Add("%%%%\\~~~~\\/%%%%%%%\\                   ,~,                                  /%%%%");
        frstClear.Add("%%%%%\\~~~/%%%%%%%%%\\                 ,~~~,                                /%%%%%");
        frstClear.Add(" %%%%%%\\/%%%%%%%%%%%\\_______________,~~~~~,______________________________/%%%%%%");
        frstClear.Add(" %%%%%%\\/%%%%%%%%%%%\\         .'-  ,~~~~~~~,     \\/    '_               /%%%%%%%");
        frstClear.Add("%%%%%%%/%%%%%%%%%%%%%\\    \\/        ,~~;~~,                \\/   --'_   /%%%%%#%/");
        frstClear.Add("%%%%%%/%%%%%%%%%%%%%%%\\          _     |      .'   \\/                   \"\"\"\"\"\"\\/");
        frstClear.Add(" \"\"\"\"\"\"/%%%%%%%%%%%%%%\\    .-^.       ~\"\"\"~               ..'.    \\/     -_     ");

        List<string> forest1 = new();
        forest1.Add("                                                                                ");
        forest1.Add("                                                                                ");
        forest1.Add("                                                                                ");
        forest1.Add("                                                     _                          ");
        forest1.Add("\\      /\\              /\\                    /\\     /%\\      _           /\\     ");
        forest1.Add("~\\    /%%\\     /\\     /~~\\      _           /~~\\   /%%%\\    /~\\         /~~\\    ");
        forest1.Add("~~\\  /%%%%\\   /~~\\   /~~~~\\    /~\\      /\\ /~~~~\\ /%%%%%\\  /~~~\\       /~~~~\\   ");
        forest1.Add("~~~\\/%%%%%%\\/\\~~~~/\\/~~~~~~\\/\\/~~~\\    /%%\\~~~~~~/%%%%%%%\\/~~~~~\\     /~~~~~/\\  ");
        forest1.Add("~~~~/%%%%%%/%%\\~~/%%\\~~~~~~/%%\\~~~~\\  /%%%%\\~~~~/%%%%%%%%%/\\~~~~~/\\ _/~~~~~/%%\\ ");
        forest1.Add("~~~/%%%%%%%/%%\\~~/%%/\\~~~~/%%%%\\~~~~\\/%%%%%%\\~~~/%%%%%%%%/%%\\~~~/%%/%\\~~~~/%%%%\\");
        forest1.Add("~~/%%%%%%%/%%%%\\/%%/%%\\~~~/%%%%\\~~~~\\/%%%%%%\\~~/%%%%%%%%/%%%%\\~/%%/%%%\\~~~/%%%%\\");
        forest1.Add("\"\"/%%%%%%/%%%%%%,%%/%%\\~~/%%%%%%\\~~~/%%%%%%%%\\\"\"/%%%%%%%/%%%%%\\,%%/%%%\\~~/%%%%%%");
        forest1.Add(" /%%%%%%%/%%%%%,~,/%%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\ /%%%%%%%/%%%%%%\\,~,%%%%\\/%%%%%%%");
        forest1.Add(" /%%%%%%/%%%%%,~~~,%%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\/%%%%%%%/%%%%%%%,~~~,%%%%\\/%%%%%%");
        forest1.Add("/%%%%%#%/#%%%,~~~~~,%%%/%%%%%%%%%%/%%%%%%%%%%%%\\%%%%%%%/%%%%%%,~~~~~,%%%/%%%%%%%");
        forest1.Add(" \"\"\"\"\"\"\\/\"\"\",~~~~~~~,\"\"/%%%%%%%%%/%%%%%%%%%%%%%%\\\"\"\"\"\"\"\"\\/\"\"\",~~~~~~~,\"\"/%%%%%%%");
        forest1.Add(" -_          ,~~;~~,    \"\"\"\"\"\"\"\"\"/%%%%%%%%%%%%%%\\ -_          ,~~;~~,    \"\"\"\"\"\"\"");

        List<string> forest2 = new();
        forest2.Add("                                                                                ");
        forest2.Add("\\                                                                               ");
        forest2.Add("~\\                                                                             /");
        forest2.Add("~~\\                                                  _                        /~");
        forest2.Add("~~~\\                                  /\\      /\\    /~\\                      /~~");
        forest2.Add("~~~~\\     /\\                         /%%\\    /~~\\  /~~~\\       _            /~~~");
        forest2.Add("~~~~~\\   /~~\\      /\\               /%%%%\\  /~~~~\\/~~~~~\\     /~\\      /\\  /~~~~");
        forest2.Add("~~~~~~\\/\\~~~~\\    /%%\\             /%%%%%%\\/~~~~~~\\~~~~~~\\ /\\/~~~\\    /%%\\/~~~~~");
        forest2.Add("~~~~~~/%%\\~~~~\\  /%%%%\\           /%%%%%%%%/\\~~~~/\\~~~~~~~/%%\\~~~~\\  /%%%%\\~~~~/");
        forest2.Add("\\~~~~/%%%%\\~~~~\\/%%%%%%\\          /%%%%%%%/%%\\~~/%%/\\~~~~/%%%%\\~~~~\\/%%%%%%\\~~/%");
        forest2.Add("%\\~~~/%%%%\\~~~~\\/%%%%%%\\         /%%%%%%%/%%%%\\/%%/%%\\~~~/%%%%\\~~~~\\/%%%%%%\\~/%%");
        forest2.Add("%\\~~/%%%%%%\\~~~/%%%%%%%%\\       /%%%%%%/%%%%%%,%%/%%\\~~/%%%%%%\\~~~/%%%%%%%%\\/%%%");
        forest2.Add("%%\\/%%%%%%%%\\~/%%%%%%%%%%\\     /%%%%%%/%%%%%%,%%/%%\\~~/%%%%%%\\~~~/%%%%%%%%\\~/%%%");
        forest2.Add("%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\   /%%%%%%/%%%%%,~~~,%%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\/%%%");
        forest2.Add("%%%/%%%%%%%%%%/%%%%%%%%%%%%\\ /%%%%%#%/#%%%,~~~~~,%%%/%%%%%%%%%%/%%%%%%%%%%%%\\%%%");
        forest2.Add(",\"\"/%%%%%%%%%/%%%%%%%%%%%%%%\\ \"\"\"\"\"\"\\/ \"\",~~~~~~~,\"\"/%%%%%%%%%/%%%%%%%%%%%%%%\\%%");
        forest2.Add("    \"\"\"\"\"\"\"\"\"/%%%%%%%%%%%%%%\\  -_         ,~~;~~,    \"\"\"\"\"\"\"\"/%%%%%%%%%%%%%%\\  \"");

        List<string> forest3 = new();
        forest3.Add("                                                                                ");
        forest3.Add("                                                                                ");
        forest3.Add("                                                                                ");
        forest3.Add("\\                                                                               ");
        forest3.Add("%\\                                                     _                        ");
        forest3.Add("%%\\                _                                  /%\\                       ");
        forest3.Add("%%%\\    _         /~\\      /\\      /\\                /%%%\\    /\\                ");
        forest3.Add("%%%%\\  /~\\       /~~~\\ /\\ /~~\\    /%%\\              /%%%%%\\  /~~\\     /\\   /\\   ");
        forest3.Add("%%%%%/\\~~~\\ /\\ _/~~~~~/%%\\~~~~\\  /%%%%\\            /%%%%%%%/\\~~~~/\\  /~~\\ /%%\\ /");
        forest3.Add("%%%%/%%\\~~~/%%/%\\~~~~/%%%%\\~~~~\\/%%%%%%\\          /%%%%%%%/%%\\~~/%%/\\~~~~/%%%%\\~");
        forest3.Add("%%%/%%%%\\~/%%/%%%\\~~~/%%%%\\~~~~\\/%%%%%%\\         /%%%%%%%/%%%%\\/%%/%%\\~~~/%%%%\\~");
        forest3.Add("%%%/%%%%%\\,%%/%%%\\~~/%%%%%%\\~~~/%%%%%%%%\\       /%%%%%%/%%%%%%,%%/%%\\~~/%%%%%%\\~");
        forest3.Add("%%%/%%%%%%\\,~,%%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\     /%%%%%%/%%%%%%,%%/%%\\~~/%%%%%%\\~~");
        forest3.Add("%%/%%%%%%%,~~~,%%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\   /%%%%%%/%%%%%,~~~,%%%%\\/%%%%%%%%\\~");
        forest3.Add("%%/%%%%%%,~~~~~,%%%/%%%%%%%%%%/%%%%%%%%%%%%\\ /%%%%%#%/#%%%,~~~~~,%%%/%%%%%%%%%%/");
        forest3.Add("\"\"\"\\/\"\"\",~~~~~~~,\"\"/%%%%%%%%%/%%%%%%%%%%%%%%\\ \"\"\"\"\"\"\\/ \"\",~~~~~~~,\"\"/%%%%%%%%%/%");
        forest3.Add("         ,~~;~~,    \"\"\"\"\"\"\"\"\"/%%%%%%%%%%%%%%\\  -_         ,~~;~~,    \"\"\"\"\"\"\"\"/%%");

        List<string> forest4 = new();
        forest4.Add("                                                                                ");
        forest4.Add("                                                                                ");
        forest4.Add("                                                                                ");
        forest4.Add("                                                                                ");
        forest4.Add("\\                                                                               ");
        forest4.Add("~\\                    /\\       /\\                                               ");
        forest4.Add("~~\\         _      /\\/~~\\     /%%\\      _                   _      /\\           ");
        forest4.Add("~~~\\   /\\  /~\\    /%%\\~~~\\   /%%%%\\    /~\\        /\\   /\\  /~\\    /%%\\          ");
        forest4.Add("~~~~\\ /%%\\/~~~\\  /%%%%\\~~~\\ /%%%%%%\\ /\\~~~\\ /\\ _ /~~\\ /%%\\/~~~\\  /%%%%\\         ");
        forest4.Add("\\~~~~/%%%%\\~~~~\\/%%%%%%\\~~~/%%%%%%%%/%%\\~~~/%%/%\\~~~~/%%%%\\~~~~\\/%%%%%%\\        ");
        forest4.Add("%\\~~~/%%%%\\~~~~\\/%%%%%%\\~~/%%%%%%%%/%%%%\\~/%%/%%%\\~~~/%%%%\\~~~~\\/%%%%%%\\        ");
        forest4.Add("%\\~~/%%%%%%\\~~~/%%%%%%%%\\\"\"/%%%%%%%/%%%%%\\,%%/%%%\\~~/%%%%%%\\~~~/%%%%%%%%\\       ");
        forest4.Add("%%\\/%%%%%%%%\\~/%%%%%%%%%%\\ /%%%%%%%/%%%%%%\\,~,%%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\     /");
        forest4.Add("%%\\/%%%%%%%%\\~/%%%%%%%%%%\\/%%%%%%%/%%%%%%%,~~~,%%%%\\/%%%%%%%%\\~/%%%%%%%%%%\\   /%");
        forest4.Add("%%/%%%%%%%%%%/%%%%%%%%%%%%\\%%%%%%%/%%%%%%,~~~~~,%%%/%%%%%%%%%%/%%%%%%%%%%%%\\ /%%");
        forest4.Add("\"\"/%%%%%%%%%/%%%%%%%%%%%%%%\\\"\"\"\"\"\"\"\\/\"\"\",~~~~~~~,\"\"/%%%%%%%%%/%%%%%%%%%%%%%%\\ \"\"");
        forest4.Add("   \"\"\"\"\"\"\"\"\"/%%%%%%%%%%%%%%\\ -_          ,~~;~~,    \"\"\"\"\"\"\"\"\"/%%%%%%%%%%%%%%\\  -");

        List<string> well = new();
        well.Add("                                                                                ");
        well.Add("                                                                                ");
        well.Add("                                                                                ");
        well.Add("                                                                                ");
        well.Add("                                                                                ");
        well.Add("                                                                                ");
        well.Add("                                                .--.                            ");
        well.Add("                                              .'_\\/_'.                          ");
        well.Add("                                              '. /\\ .'                 .--.     ");
        well.Add("                                                \"||\"                 .'_\\/_'.   ");
        well.Add("~~~~~~~_~~~~~~~~~~~~~~~~~~~~~~__/)~~~~~~~~~~~~~~~||~/\\~~~~~~~~~~~~~~~'. /\\ .'~~~");
        well.Add("'    .\\ /.   _-------_     .-(__(=:   .__     /\\ ||//\\)   .-           \"||\"     ");
        well.Add("    < ~O~ > |-|_____|-| |\\ |    \\)           (/\\\\||/         \\/         || /\\  -");
        well.Add("     '/_\\'  |_________| \\ ||         \\/         \\||/                 /\\ ||//\\)  ");
        well.Add("\\/   \\ | /  |_________|  \\||   .__        '    .-^^--.__    --      (/\\\\||/     ");
        well.Add("'     \\|/   \\_________/   \\|      '                       \\/   '       \\||/  -'\\");
        well.Add(" \\/__.'^'.  :  __.-._     _|._  \\/ __ .:._  .,__- \\/ .__        ..^-.__   :.__  ");

        List<string> mystDoor = new();
        mystDoor.Add("       ________________________________________________________________         ");
        mystDoor.Add("    '. \\                                                               |        ");
        mystDoor.Add(" --__  |                                                              / '__     ");
        mystDoor.Add("    ' /                                                               |         ");
        mystDoor.Add(" '  . |                                                               \\ ..-     ");
        mystDoor.Add("  -   /                             |__|_ |__|__| _|_ _|               \\  '     ");
        mystDoor.Add("   _  |                              _|_ ,-' ;  ! `-.|__                ..   '  ");
        mystDoor.Add("     -=                            _|__ / :  !  :  . \\ ___|_              |  '  ");
        mystDoor.Add("    .   ;                           _|_|_ ;   __:  ;  |_|__|_             .   ._");
        mystDoor.Add("  .   |                             ___)| .  :)(.  !  |___|__            | :  - ");
        mystDoor.Add("  .   ''                            _|_|\"    (##)  _  |_|_               \\  ;   ");
        mystDoor.Add("    ;  \\                            ___|  :  ;`'  (_) (__|_               #  .  ");
        mystDoor.Add("        |                           _|_|  :  :  .     |_|_                ;     ");
        mystDoor.Add("  . --  | '                         ___)_ !  ,  ;  ;  |__|_               '   - ");
        mystDoor.Add("   . '   \\                          _|_|| .  .  :  :  |_|_               .      ");
        mystDoor.Add("    .  - /                          ___|\" .  |  :  .  |___               |  ..  ");
        mystDoor.Add("          \\__________________________|_|. |'_;----.___|_|________________/   -__");

        List<string> undTunnel = new();
        undTunnel.Add("                                                                                ");
        undTunnel.Add("                                                                                ");
        undTunnel.Add("      ________________________________________________________________          ");
        undTunnel.Add(" -   /         /            /                  \\           \\          \\  '      ");
        undTunnel.Add(" _  |                      .                    }                      ..   '   ");
        undTunnel.Add("   -=         /            |                    .           \\           |  '    ");
        undTunnel.Add(".' -|        |             /                    |            }          / -.    ");
        undTunnel.Add(" #  /        |            |                     }            :          |. .    ");
        undTunnel.Add(".  -|        (            (                     \\            /          / __ .  ");
        undTunnel.Add(" ., |        |             \\                    |            |          |..     ");
        undTunnel.Add("-  .(        /             |                    \\            :          /'  --. ");
        undTunnel.Add("  . {        ;            (                      .           /          ).      ");
        undTunnel.Add(".   |         :            '                    |                      | :  -   ");
        undTunnel.Add(".   ''        \\            {                    )           '          .  ;     ");
        undTunnel.Add("  ;  \\_________\\____________\\___________________/__________/___________/   .    ");
        undTunnel.Add("                                                                                ");
        undTunnel.Add("                                                                                ");

        List<string> bossRoom = new();
        bossRoom.Add("                                                                                ");
        bossRoom.Add("             __________________  ____      ________________________             ");
        bossRoom.Add("        -   /                  \\/    \\ ,  /                        \\  '         ");
        bossRoom.Add("       _   |                          \\ ./                          ..   '      ");
        bossRoom.Add("         -=                           |'/                            |  '       ");
        bossRoom.Add("      .   ;                           \\/                             .   .___   ");
        bossRoom.Add("     .   |                                                           | :  -     ");
        bossRoom.Add("    .   ''                                                            \\  ;      ");
        bossRoom.Add("      __ \\                                                             |.__     ");
        bossRoom.Add("      .--|                                                             :'-      ");
        bossRoom.Add("    '                                                                  | .'     ");
        bossRoom.Add("     ;  /                                                               #  .    ");
        bossRoom.Add("       |                                                                 ;      ");
        bossRoom.Add(".  --  | '                                                               '   - .");
        bossRoom.Add(". '   \\           _          /|      /\\                                   \\     ");
        bossRoom.Add(".  - /           |^\\        /^ \\    |. \\                                  |  .. ");
        bossRoom.Add("     \\__________/^ .|__..--/ . ^\\__/'  ^\\_____|_|. |'_;----.___|_|________/   -_");

        List<string> town = new();
        town.Add("                   _                      _             /  \\       _____________  ");
        town.Add("    ____________ .' '.    _____/----/-\\ .' './=======  / ^^ \\     /=============");
        town.Add("   //// ////// /V_.-._\\  |.-.-.|===| _ |-----| u    u /  []  \\   /==============");
        town.Add("  // /// // ///==\\ u |.  || | ||===||||| |T| |   ||  /________\\ /===============");
        town.Add(" ///////-\\////====\\==|:::::::::::::::::::::::::::::::|        |/================");
        town.Add(" |----/\\u |--|++++|..|'''''''''''::::::::::::::''''''| ^^  ^^ |-----------------");
        town.Add(" |u u|u | |u ||||||..|              '::::::::'       | []  [] |           _____ ");
        town.Add(" |===|  |u|==|++++|==|              .::::::::.       |        |          /_____\\");
        town.Add(" |u u|u | |u ||HH||         \\|/    .::::::::::.      | ^^  ^^ |  ^^  ^^  |  |  |");
        town.Add(" |===|_.|u|_.|+HH+|               .::::::::::::.     | []  [] |  []  []  |  |  |");
        town.Add("                ________         .::::::::::::::.    |    ________       |  |  |");
        town.Add("---------------/       /|       .:::::;;;:::;;:::.   |   |\\       \\-------------");
        town.Add("______________/_______/ |      .::::::;;:::::;;:::.  |___| \\_______\\___________ ");
        town.Add("|       |     [===  =] /|     .:::::;;;::::::;;;:::.     |\\ [==  = ]   |       |");
        town.Add("|_______|_____[ = == ]/ |    .:::::;;;:::::::;;;::::.    | \\[ ===  ]___|_____ _|");
        town.Add("     |       |[  === ] /|   .:::::;;;::::::::;;;:::::.   |\\ [=  ===] |       |  ");
        town.Add("_____|_______|[== = =]/ |  .:::::;;;::::::::::;;;:::::.  | \\[ ==  =]_|_______|__");


        List<int> room101801 = new List<int> { 1341, 1272, 1271 };
        Location loc101801 = new Location(101801, "Well", 6, "This is a forest. But there is a well here.\nA very ugly well that looks like it was drawn by a third grader.\nPretty cool but there isn't anything special about it.", 50, room101801, well);
        locationList.Add(loc101801);

        List<int> room101802 = new List<int> { 1271, 1272 };
        Location loc101802 = new Location(101802, "Forest", 7, "This is a forest. With trees and stuff.\nYou can see more forest to the south and a meadow to the east.", 40, room101802, forest1);
        locationList.Add(loc101802);

        List<int> room101803 = new List<int> { 1271, 1272 };
        Location loc101803 = new Location(101803, "Forest", 7, "This is a forest. With trees and stuff.\nThe bottom of a cliff is to the west and more forest all around you.", 50, room101803, forest2);
        locationList.Add(loc101803);

        List<int> room101804 = new List<int> { 1271, 1272 };
        Location loc101804 = new Location(101804, "Forest", 7, "This is a forest. With trees and stuff.\nYou see a clearing to the east of you and what appears to be a village to the south.", 50, room101804, forest1);
        locationList.Add(loc101804);

        List<int> room101805 = new List<int> { 1151 };
        Location loc101805 = new Location(101805, "Small Village", 3, "A small village. There is an Inn, an Arms merchant, and a potion vender here.\nIt looks like a good place to recover from your journey so far.", 0, room101805, town);
        locationList.Add(loc101805);


        List<int> room102801 = new List<int> { 1271, 1272 };
        Location loc102801 = new Location(102801, "Forest", 14, "This is a forest. With trees and stuff.\nThis small copse of trees is surrounded by meadows on three sides.\nThe mountains to the north are impassible.", 40, room102801, forest4);
        locationList.Add(loc102801);

        List<int> room102802 = new List<int> { 1271, 1272 };
        Location loc102802 = new Location(102802, "Meadow", 15, "This is a meadow. With grass and stuff.\nLovely flowers in this meadow.\nThe meadow continues east with forest in all other directions.", 40, room102802, meadow1);
        locationList.Add(loc102802);

        List<int> room102803 = new List<int> { 1271, 1272 };
        Location loc102803 = new Location(102803, "Forest", 15, "This is a forest. With trees and stuff.\nThere is a meadow to the north and a clearing to the south.\nMore forest in the other directions.", 50, room102803, forest4);
        locationList.Add(loc102803);

        List<int> room102804 = new List<int> { 1341, 1272, 1271 };
        Location loc102804 = new Location(102804, "Forest Clearing", 15, "This is a clearing in the forest. With grass and shrubs and stuff.\nLooks like a nice spot for a picnic but you have things to do.", 55, room102804, frstClear);
        locationList.Add(loc102804);

        List<int> room102805 = new List<int> { 1271, 1272 };
        Location loc102805 = new Location(102805, "Forest", 11, "This is a forest. With trees and stuff.\nThe forest keeps going to east with a clearing to the north and a small village to the west.", 50, room102805, forest4);
        locationList.Add(loc102805);


        List<int> room103801 = new List<int> { 1152, 1272, 1271 };
        Location loc103801 = new Location(103801, "Meadow", 14, "This is a meadow. With grass and stuff.\nA nice meadow as meadows go.\nThere is a small copse of trees to the west and more meadow to the east and south.", 35, room103801, meadow3);
        locationList.Add(loc103801);

        List<int> room103802 = new List<int> { 1152, 1272, 1271 };
        Location loc103802 = new Location(103802, "Meadow", 15, "This is a meadow. With grass and stuff.\nKind of a crap meadow with a forest south.\nOtherwise the meadow continues in other directions.", 35, room103802, meadow2);
        locationList.Add(loc103802);

        List<int> room103803 = new List<int> { 1152, 1272, 1271 };
        Location loc103803 = new Location(103803, "Forest", 15, "This is a forest. With trees and stuff.\nMore forest stretch out to the west and south.\n Meadows to the north and east.", 35, room103803, forest1);
        locationList.Add(loc103803);

        List<int> room103804 = new List<int> { 1271, 1272 };
        Location loc103804 = new Location(103804, "Forest", 15, "This is a forest. With trees and stuff.\nMuch like other forest locations, there are lots of trees.\nThere is a clearing to the west but more forest in all other directions.", 50, room103804, forest2);
        locationList.Add(loc103804);

        List<int> room103805 = new List<int> { 1271, 1272 };
        Location loc103805 = new Location(103805, "Forest", 11, "This is a forest. With trees and stuff.\nA massive cliff looms over you to the south.\nThe forest continues in all other directions.", 50, room103805, forest3);
        locationList.Add(loc103805);


        List<int> room104801 = new List<int> { 1271, 1272 };
        Location loc104801 = new Location(104801, "Meadow", 12, "This is a meadow. With grass and stuff.\nA lovely meadow with mountains on two sides.\nThe meadow continues south and west.", 35, room104801, meadow4);
        locationList.Add(loc104801);

        List<int> room104802 = new List<int> { 1271, 1272 };
        Location loc104802 = new Location(104802, "Meadow", 15, "This is a meadow. With grass and stuff.\nOooh! Look at all the pretty flowers!\nThere is a path through the mountains to the east.", 35, room104802, meadow3);
        locationList.Add(loc104802);

        List<int> room104803 = new List<int> { 1271, 1272 };
        Location loc104803 = new Location(104803, "Meadow", 13, "This is a meadow. With grass and stuff.\nJust another meadow. More meadow to the north.\nThere is a forest to the west and south.", 35, room104803, meadow1);
        locationList.Add(loc104803);

        List<int> room104804 = new List<int> { 1341, 1272, 1271 };
        Location loc104804 = new Location(104804, "Forest", 13, "This is a forest. With trees and stuff.\nIt's kinda creepy here. That nice meadow is to the north.\nThe trees keep going south and west as far as you can see.", 40, room104804, forest1);
        locationList.Add(loc104804);

        List<int> room104805 = new List<int> { 1271, 1272 };
        Location loc104805 = new Location(104805, "Forest", 9, "This is a forest. With trees and stuff.\nThe canopy overhead is thick enough that not much light gets to you.\nAnything could be hiding in the underbrush...", 40, room104805, forest2);
        locationList.Add(loc104805);


        List<int> room105802 = new List<int> { 1151 };
        Location loc105802 = new Location(105802, "Mountain Path", 10, "A mountain path. You can see a meadow ahead.\nIt looks nice, you should go check that out.", 30, room105802, mtnPath);
        locationList.Add(loc105802);


        List<int> room106801 = new List<int> { 1151, 1271 };
        Location loc106801 = new Location(106801, "Small Pond", 4, "You see a small pond. Too bad you can't swim.\nYou do take a few minutes to soak your aching feet.", 30, room106801, mtnPond);
        locationList.Add(loc106801);

        List<int> room106802 = new List<int> { 1151, 1271 };
        Location loc106802 = new Location(106802, "Crossroads", 15, "A fork in the mountain path. You can see a waterfall to the north.\nThere is a cave to the east, and it looks like a pass out of the mountains to the west.", 25, room106802, mtnPath);
        locationList.Add(loc106802);

        List<int> room106803 = new List<int> { 1151 };
        Location loc106803 = new Location(106803, "Mountain Path", 5, "A narrow dirt path. There are mountains on either side.\nThe path continues north toward a waterfall you can just make out in the distance.\nThe landslide that trapped you here is in the distance to the south.", 25, room106803, mtnPath);
        locationList.Add(loc106803);

        List<int> room106804 = new List<int> { 1151 };
        Location loc106804 = new Location(106804, "Mountain Path", 5, "A narrow dirt path. There are mountains on either side.\nThe path continues north and south.", 20, room106804, mtnPath);
        locationList.Add(loc106804);

        List<int> room106805 = new List<int> { 1151 };
        Location loc106805 = new Location(106805, "Mountain Path", 1, "A narrow dirt path. There are mountains on either side and the path behind you was blocked by a landslide.\nThe path leads north.", 0, room106805, mtnPath);
        locationList.Add(loc106805);


        List<int> room107802 = new List<int> { 1251 };
        Location loc107802 = new Location(107802, "Cave Entrance", 10, "You've entered a cave. It is kinda dark in here...\nYou can see a path west.", 30, room107802, undTunnel);
        locationList.Add(loc107802);


        List<int> room108802 = new List<int> { 1251 };
        Location loc108802 = new Location(108802, "Underground Tunnel", 12, "An underground tunnel much like any other. The walls appear to have been carved. Poorly.", 35, room108802, undTunnel);
        locationList.Add(loc108802);

        List<int> room108803 = new List<int> { 1251, 1321 };
        Location loc108803 = new Location(108803, "Underground Tunnel", 7, "Another section of the underground tunnel. The walls appear to have been carved. Poorly.", 35, room108803, undTunnel);
        locationList.Add(loc108803);

        List<int> room108804 = new List<int> { 1251, 1321 };
        Location loc108804 = new Location(108804, "Underground Tunnel", 1, "An underground alcove. The walls appear to have been carved. Poorly.\nThis looks like a dead end.", 35, room108804, undTunnel);
        locationList.Add(loc108804);


        List<int> room109803 = new List<int> { 1251, 1321 };
        Location loc109803 = new Location(109803, "Underground Tunnel", 10, "You guessed it, you're still in an underground tunnel.\nThese walls also appear to have been poorly carved", 35, room109803, undTunnel);
        locationList.Add(loc109803);


        List<int> room110801 = new List<int> { 1251, 1321, 1471 };
        Location loc110801 = new Location(110801, "Underground Tunnel", 6, "Still in an underground tunnel. The walls appear to have been carved very poorly.", 40, room110801, undTunnel);
        locationList.Add(loc110801);

        List<int> room110802 = new List<int> { 1251, 1321, 1471 };
        Location loc110802 = new Location(110802, "Underground Tunnel", 5, "The same underground tunnel. The same poorly carved walls.", 40, room110802, undTunnel);
        locationList.Add(loc110802);

        List<int> room110803 = new List<int> { 1251, 1321, 1471 };
        Location loc110803 = new Location(110803, "Underground Tunnel", 13, "I mean, it's a tunnel. Poorly carved rock walls.", 40, room110803, undTunnel);
        locationList.Add(loc110803);

        List<int> room110804 = new List<int> { 1251, 1321, 1471 };
        Location loc110804 = new Location(110804, "Underground Tunnel", 5, "Yep, an underground tunnel. You can guess what it looks like", 40, room110804, undTunnel);
        locationList.Add(loc110804);

        List<int> room110805 = new List<int> { 1251, 1321, 1471, 1571 };
        Location loc110805 = new Location(110805, "Underground Tunnel", 1, "An underground alcove. This one has a small puddle in the corner.\nIt is still a dead end.", 60, room110805, undTunnel);
        locationList.Add(loc110805);


        List<int> room111801 = new List<int> { 1251, 1321, 1471 };
        Location loc111801 = new Location(111801, "Underground Tunnel", 10, "An underground tunnel. The walls look like... rock.", 40, room111801, undTunnel);
        locationList.Add(loc111801);


        List<int> room112801 = new List<int> { 1251, 1321, 1471 };
        Location loc112801 = new Location(112801, "Underground Tunnel", 10, "<sigh> an underground tunnel. The walls appear rough... and... rocky.", 50, room112801, undTunnel);
        locationList.Add(loc112801);

        List<int> room112803 = new List<int> { 1251, 1321, 1471 };
        Location loc112803 = new Location(112803, "Underground Tunnel", 6, "A poorly carved underground tunnel. Definitely a little warmer than other areas.", 50, room112803, undTunnel);
        locationList.Add(loc112803);

        List<int> room112804 = new List<int> { 1251, 1321, 1471 };
        Location loc112804 = new Location(112804, "Mysterious Door", 5, "A warm underground tunnel. There is a mysterious door to the south glowing with power that refuses to open no matter how much you jiggle the handle", 40, room112804, mystDoor);
        locationList.Add(loc112804);

        List<int> room112805 = new List<int> { 1151 };
        Location loc112805 = new Location(112805, "Boss Lair", 1, "You have entered a massive cavern. The ceiling and walls are well beyond the limits of your sight.\nThe heat here is maybe a little oppressive.\nThe mysterious door has closed behind you and is glowing again.\nChecking you find it is sealed and unable to be opened.", 0, room112805, bossRoom);
        locationList.Add(loc112805);


        List<int> room113801 = new List<int> { 1251, 1321, 1471 };
        Location loc113801 = new Location(113801, "Underground Tunnel", 12, "An underground tunnel. Walls. Poorly carved. From stone.", 40, room113801, undTunnel);
        locationList.Add(loc113801);

        List<int> room113802 = new List<int> { 1251, 1321, 1471 };
        Location loc113802 = new Location(113802, "Underground Tunnel", 5, "An underground tunnel. You know what it looks like.", 40, room113802, undTunnel);
        locationList.Add(loc113802);

        List<int> room113803 = new List<int> { 1251, 1321, 1471 };
        Location loc113803 = new Location(113803, "Underground Tunnel", 9, "An underground tunnel. Is it maybe a bit warmer here?", 40, room113803, undTunnel);
        locationList.Add(loc113803);

        //string filePath = "./TempDataStorage/Locations.json";
        string locationListString = JsonSerializer.Serialize(locationList);
        File.WriteAllText(filePath, locationListString);
    }
}