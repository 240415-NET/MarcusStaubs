namespace Project1.UserInterfaces;

public class SplashScreens
{
    public static void GameOver()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("");
        Console.WriteLine(" ▄▄ •  ▄▄▄· •   ▌  ▄  ·. ▄▄▄ .         ▌ ▐ ·▄▄▄ .▄▄▄  ");
        Console.WriteLine("▐█ ▀  ▐█ ▀█ ·██ ▐███  ▀▄.▀·          █·█▌ ▀▄.▀·▀▄ █·");
        Console.WriteLine("▄█ ▀█▄▄█▀▀█ ▐█ ▌▐▌▐█·▐▀▀ ▄     ▄█▀▄ ▐█▐█• ▐▀▀ ▄ ▐▀▀▄ ");
        Console.WriteLine("▐█▄ ▐█▐█  ▐▌██ ██▌▐█▌▐█▄▄▌    ▐█▌.▐▌ ███ ▐█▄▄▌ ▐█  █▌");
        Console.WriteLine("·▀▀▀▀  ▀  ▀ ▀▀  █ ▀▀▀ ▀▀▀      ▀█▄▀ . ▀   ▀▀▀ . ▀  ▀");
        Console.WriteLine("\nYou're dead and the world is doomed or something.\nI don't know. The story for this game was never really fleshed out.\nJust go with your favorite fantasty game trope.");
        Console.ReadKey();
    }
    public static void HelpMenu()
    {
        Console.Clear();
        Console.WriteLine("           _____________________________________________________       ");
        Console.WriteLine("         / \\                                                    \\    ");
        Console.WriteLine("        |   |                                                    |    ");
        Console.WriteLine("         \\_ |                                                    |    ");
        Console.WriteLine("            |    Don't Panic!                                    |    ");
        Console.WriteLine("            |                                                    |    ");
        Console.WriteLine("            |     When in combat, you can <A>ttack <Flee>        |    ");
        Console.WriteLine("            |       or <D>rink a potion if you have one          |    ");
        Console.WriteLine("            |     Outside of combat, you can:                    |    ");
        Console.WriteLine("            |        View your <C>haracter                       |    ");
        Console.WriteLine("            |        <R>est to restore HP                        |    ");
        Console.WriteLine("            |        <I>nventory to view or equip stuff          |    ");
        Console.WriteLine("            |        <D>rink a potion if you have one            |    ");
        Console.WriteLine("            |        Sa<v>e your game                            |    ");
        Console.WriteLine("            |        E<x>it the game                             |    ");
        Console.WriteLine("            |        Or move in an available direction           |    ");
        Console.WriteLine("            |                                                    |    ");
        Console.WriteLine("            |     Use the letter inside <> to take the           |    ");
        Console.WriteLine("            |     desired action.                                |    ");
        Console.WriteLine("            |                                                    |    ");
        Console.WriteLine("            |     To move, use the first letter of the           |    ");
        Console.WriteLine("            |     desired directions N,S,E,W or the arrow        |    ");
        Console.WriteLine("            |     key for that direction.                        |    ");
        Console.WriteLine("            |                                                    |    ");
        Console.WriteLine("            |     You can return to this screen by pressing <H>  |	 ");
        Console.WriteLine("            |   _________________________________________________|___ ");
        Console.WriteLine("            |  /                                                    / ");
        Console.WriteLine("            \\_/____________________________________________________/ ");
        Console.ReadKey();
    }
    public static void RestMenu()
    {
        Console.Clear();
        Console.WriteLine("                 (                 ,&&&.          ");
        Console.WriteLine("                  )                .,.&&          ");
        Console.WriteLine("                 (  (              \\=__/         ");
        Console.WriteLine("                     )             ,'-'.          ");
        Console.WriteLine("               (    (  ,,      _.__|/ /|          ");
        Console.WriteLine("                ) /\\ -((------((_|___/ |         ");
        Console.WriteLine("              (  // | (`'      ((  `'--|          ");
        Console.WriteLine("            _ -.;_/ \\\\--._      \\\\ \\-._/.    ");
        Console.WriteLine("           (_;-// | \\ \\-'.\\    <_,\\_\\`--'|   ");
        Console.WriteLine("           ( `.__ _  ___,')      <_,-'__,'        ");
        Console.WriteLine("            `'(_ )_)(_)_)'                        ");
        Console.WriteLine("\nYou settle down to rest and tend to your wounds.  HP restored.");
        Console.WriteLine("Press any key to continue your adventure...");
        Console.ReadKey();
    }
    public static void NewPlayerDisplay()
    {
        Console.Clear();
        Console.WriteLine("           ______________________________________________     ");
        Console.WriteLine("         / \\                                             \\  ");
        Console.WriteLine("        |   |                                            |    ");
        Console.WriteLine("         \\_ |                                            |   ");
        Console.WriteLine("            |    Welcome to new character creation!      |    ");
        Console.WriteLine("            |                                            |    ");
        Console.WriteLine("            |     I know that this can sometimes seem    |    ");
        Console.WriteLine("            |     like an intmidating process.           |    ");
        Console.WriteLine("            |     So many choices to make and the depth  |    ");
        Console.WriteLine("            |     of your customization options.         |    ");
        Console.WriteLine("            |                                            |    ");
        Console.WriteLine("            |     We're going to try to keep it simple.  |    ");
        Console.WriteLine("            |     When you're ready to start, please     |    ");
        Console.WriteLine("            |     enter your character's name            |    ");
        Console.WriteLine("            |                                            |    ");
        Console.WriteLine("            |   _________________________________________|___ ");
        Console.WriteLine("            |  /                                            / ");
        Console.WriteLine("            \\_/____________________________________________/ ");
    }
    public static void MainMenuDisplay()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("                              @@@  @@@  @@@   @@@@@@   @@@@@@@   @@@@@@@   @@@   @@@@@@   @@@@@@@   @@@   @@@@@@");
        Console.WriteLine("                              @@@  @@@  @@@  @@@@@@@@  @@@@@@@@  @@@@@@@@  @@@  @@@@@@@@  @@@@@@@@   @@  @@@@@@@ ");
        Console.WriteLine("                              @@!  @@!  @@!  @@!  @@@  @@!  @@@  @@!  @@@  @@!  @@!  @@@  @@!  @@@  @!   !@@ ");
        Console.WriteLine("      _,.                     !@!  !@!  !@!  !@!  @!@  !@!  @!@  !@!  @!@  !@!  !@!  @!@  !@!  @!@       !@!    ");
        Console.WriteLine("    ,` -.)                    @!!  !!@  @!@  @!@!@!@!  @!@!!@!   @!@!!@!   !!@  @!@  !@!  @!@!!@!        !!@@!!");
        Console.WriteLine("   ( _/-\\\\-._                 !@!  !!!  !@!  !!!@!!!!  !!@!@!    !!@!@!    !!!  !@!  !!!  !!@!@!          !!@!!!");
        Console.WriteLine("  /,|`--._,-^|            ,   !!:  !!:  !!:  !!:  !!!  !!: :!!   !!: :!!   !!:  !!:  !!!  !!: :!!             !:!");
        Console.WriteLine("  \\_| |`-._/||          ,'|   :!:  :!:  :!:  :!:  !:!  :!:  !:!  :!:  !:!  :!:  :!:  !:!  :!:  !:!           !:!");
        Console.WriteLine("    |  `-, / |         /  /    :::: :: :::   ::   :::  ::   :::  ::   :::   ::  ::::: ::  ::   :::       :::: :: ");
        Console.WriteLine("    |     || |        /  /      :: :  : :     :   : :   :   : :   :   : :  :     : :  :    :   : :       :: : :");
        Console.WriteLine("     `r-._||/   __   /  /         ");
        Console.WriteLine(" __,-<_     )`-/  `./  /                      @@@@@@    @@@  @@@  @@@@@@@@   @@@@@@   @@@@@@@");
        Console.WriteLine("'  \\   `---'   \\   /  /                      @@@@@@@@   @@@  @@@  @@@@@@@@  @@@@@@@   @@@@@@@");
        Console.WriteLine("    |           |./  /                       @@!  @@@   @@!  @@@  @@!       !@@         @@!");
        Console.WriteLine("    /           //  /                        !@!  @!@   !@!  @!@  !@!       !@!         !@!");
        Console.WriteLine("\\_/' \\         |/  /                         @!@  !@!   @!@  !@!  @!!!:!    !!@@!!      @!!");
        Console.WriteLine(" |    |   _,^-'/  /                          !@!  !!!   !@!  !!!  !!!!!:     !!@!!!     !!!");
        Console.WriteLine(" |    , ``  (\\/  /_                          !!:!!:!:   !!:  !!!  !!:            !:!    !!:");
        Console.WriteLine("  \\,.->._    \\X-=/^                          :!: :!:    :!:  !:!  :!:           !:!     :!:");
        Console.WriteLine("  (  /   `-._//^`                            ::::: :!   ::::: ::   :: ::::  :::: ::      ::");
        Console.WriteLine("   `Y-.____(__}                               : :  :::   : :  :   : :: ::   :: : :       :   ");
        Console.WriteLine("    |     {__)                          ");
        Console.WriteLine("          ()                           1: Continue Your Quest    2: Create New Character    3: Exit");
        Console.ResetColor();
    }
    public static void LoginDisplay()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\    ");
        Console.WriteLine("  /  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\");
        Console.WriteLine(" / /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\ \\ ");
        Console.WriteLine("/ / / /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\ \\ \\");
        Console.WriteLine("\\ \\ \\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ / / /");
        Console.WriteLine(" \\ \\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /");
        Console.WriteLine("  \\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  /\\  / ");
        Console.WriteLine("   \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/  \\/");
        Console.WriteLine("      _,.                     ");
        Console.WriteLine("    ,` -.)                   @@@        @@@@@@    @@@@@@@@  @@@  @@@  @@@ ");
        Console.WriteLine("   ( _/-\\-._                 @@@       @@@@@@@@  @@@@@@@@@  @@@  @@@@ @@@");
        Console.WriteLine("  /,|`--._,-^|            ,  @@!       @@!  @@@  !@@        @@!  @@!@!@@@  ");
        Console.WriteLine("  \\_| |`-._/||          ,'|  !@!       !@!  @!@  !@!        !@!  !@!!@!@! ");
        Console.WriteLine("    |  `-, / |         /  /  @!!       @!@  !@!  !@! @!@!@  !!@  @!@ !!@!   ");
        Console.WriteLine("    |     || |        /  /   !!!       !@!  !!!  !!! !!@!!  !!!  !@!  !!!");
        Console.WriteLine("     `r-._||/   __   /  /    !!:       !!:  !!!  :!!   !!:  !!:  !!:  !!!");
        Console.WriteLine(" __,-<_     )`-/  `./  /      :!:      :!:  !:!  :!:   !::  :!:  :!:  !:! ");
        Console.WriteLine("'  \\   `---'   \\   /  /       :: ::::  ::::: ::   ::: ::::   ::   ::   ::");
        Console.WriteLine("    |           |./  /       : :: : :   : :  :    :: :: :   :    ::    : ");
        Console.WriteLine("    /           //  /        ");
        Console.WriteLine("\\_/' \\         |/  /       Welcome back... Hero, yeah, we're going ");
        Console.WriteLine(" |    |   _,^-'/  /        to pretend you're a hero.    ");
        Console.WriteLine(" |    , ``  (\\/  /_         ");
        Console.WriteLine("  \\,.->._    \\X-=/^        I don't actually remember who you are or");
        Console.WriteLine("  (  /   `-._//^`          what this whole thing is about.  ");
        Console.WriteLine("   `Y-.____(__}              ");
        Console.WriteLine("    |     {__)             Maybe you throw me a bone and remind me");
        Console.WriteLine("          ()               what your name is?        ");
        Console.ResetColor();
    }
    public static void DrawMeAPicture(string pictureName)
    {
        if (pictureName == "vendor")
        {
            Console.WriteLine("                            _           _       | |");
            Console.WriteLine("                           (c)____c____(c)      | |");
            Console.WriteLine("                            \\ ........../       | |");
            Console.WriteLine("                             |.........|        | |");
            Console.WriteLine("                              |=======|         | |");
            Console.WriteLine("                             __o)\"\"\"\"::?        | |");
            Console.WriteLine("                            C__    c)::;       _| |________________________ ");
            Console.WriteLine("                               >--   ::       |____ _____ _________________");
            Console.WriteLine("                               (____/             | _____`-' |  -|      |.'");
            Console.WriteLine("                               } /\"\"|          ,.-'   |   '-.| - |      |__");
            Console.WriteLine("                    __/       (|V ^ )\\       .' \\     |     / '.-|      | -");
            Console.WriteLine("                    o | _____/ |#/ / |      /    \\    |    /    \\=======|'.");
            Console.WriteLine("           @        o_|}|_____/|/ /  |     ' -._  \\   |   /  _.- ' _____|__");
            Console.WriteLine("                          _____/ /   |    :     '-. .'\"'. .-'     :     |;;");
            Console.WriteLine("              ======ooo}{|______)#   |    ;--------| (o) |--------;========");
            Console.WriteLine("          ~~~~ ;    ;          ###---|8   :     _.- '._.' -._     :     |--");
            Console.WriteLine("        ____;_____;____        ###====     . _.'  /   |  \\   '._ .______|==");
            Console.WriteLine("       (///0///@///@///)       ###@@@@|     \\    /    |   \\     /");
            Console.WriteLine("       /~~~~~~~~~~~~~~~\\       ###@@@@|      `. /     |    \\  .'");
            Console.WriteLine("      |                 |      ###@@@@|        ` . _ _|_ _ .");
            Console.WriteLine("      |                 |      ###xxxxx  \\/     ..-       -..");
            Console.WriteLine("      |                 |      ###|| |   ~~");
            Console.WriteLine("      \\~~~~~~~~~~~~~~~~~/       | || |         .._");
            Console.WriteLine("       \\               /        C |C |   ");
            Console.WriteLine("        \\_____________/          || ||    \\|/");
            Console.WriteLine(" v    \\/ (o)(o) (o)(o)           || ::    ~~~");
            Console.WriteLine(" ~    ~~                      Ccc__)__)                 \\/");
            Console.WriteLine("  \\|/      ~   @* & ~                                   ~~");
            Console.WriteLine("   ~           \\|/        !!        \\ !/ ");
            Console.WriteLine("               ~~~        ~~         ~~          ");
        }

        if (pictureName == "bathTime")
        {
            Console.WriteLine("        o    .   _     .");
            Console.WriteLine("          .     (_)         o");
            Console.WriteLine("   o     @@@@@@           _       o");
            Console.WriteLine("  _     @@@@@@@@  .   o  (_)   .");
            Console.WriteLine(" (_)    @@@@ e(     O             _");
            Console.WriteLine(" o       @@' _/   ,_ ,  o   o    (_)");
            Console.WriteLine("  . O    _/ (_   / _/      .  ,        o");
            Console.WriteLine("     o8o/    \\_/ / ,-.  ,oO8/( -TT");
            Console.WriteLine("    o8o8O | | |  / /   \\Oo8OOo8Oo||     O");
            Console.WriteLine("   Oo(\"\"o8\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"8oo\"\"\"\"\"\"\")");
            Console.WriteLine("  _   `\\`'                  `'   /'   o");
            Console.WriteLine(" (_)    \\                       /    _   .");
            Console.WriteLine("      O  \\           _         /    (_)");
            Console.WriteLine("o   .     `-. .----<(o)_--. .-'");
            Console.WriteLine("   --------(_/------(_<_/--\\_)--------            ");
        }

        if (pictureName == "restInn")
        {
            Console.WriteLine("                            @@@@");
            Console.WriteLine("                           @@@@@@");
            Console.WriteLine("                           @ o o |");
            Console.WriteLine("                           |  >  |");
            Console.WriteLine("                           | ._. |");
            Console.WriteLine("                            \\___/");
            Console.WriteLine("                           __| |__");
            Console.WriteLine("                          /       \\");
            Console.WriteLine("                         | |     | |");
            Console.WriteLine("        _________________| |     | |_____________---__");
            Console.WriteLine("       /                 | |_____| |         /  /  / /|");
            Console.WriteLine("      /                  /_|  _  |_\\        /  /  / / |");
            Console.WriteLine("     /                    / / / /          /  /__/ / /|");
            Console.WriteLine("    /____________________/ / / /__________/___\\_/_/ / |");
            Console.WriteLine("    |____________________| |_| |__________________|/  |");
            Console.WriteLine("    |____________________| |_| |__________________|   /");
            Console.WriteLine("____|              |     | | | | ||               |  /");
            Console.WriteLine("    | o          o | o         o || o           o | /");
            Console.WriteLine("    |______________|_____________||_______________|/");
            Console.WriteLine("_______________________________________________________            ");
        }

        if (pictureName == "merchant")
        {
            Console.WriteLine("   |\\                     /)");
            Console.WriteLine(" /\\_\\\\__               (_//");
            Console.WriteLine("|   `>\\-`     _._       //`) .---.            |`-._/\\_.-`|");
            Console.WriteLine(" \\ /` \\\\  _.-`:::`-._  //   /_____\\           |    ||    |");
            Console.WriteLine("  `    \\|`    :::    `|/    ( '.' )           |___o()o___|");
            Console.WriteLine("        |     :::     |      \\_-_/_           |__((<>))__|");
            Console.WriteLine("        |.....:::.....|   .--`'V'//-.         \\   o\\/o   /");
            Console.WriteLine("        |:::::::::::::|  / ,   |// , \\         \\   ||   /");
            Console.WriteLine("        |     :::     | / /|   //  |\\ \\         \\  ||  /");
            Console.WriteLine("        \\     :::     // / |__//   | \\_\\         '.||.'");
            Console.WriteLine("         \\    :::    / \\ \\/---|[]==| / /           ``");
            Console.WriteLine("          `-. ::: .-'   \\/\\__/ |   \\/\\/");
            Console.WriteLine("           //`:::`\\\\     |/_   |   _\\|");
            Console.WriteLine("          _________________|_______|________________");
            Console.WriteLine("         |\\                                         \\ ");
            Console.WriteLine("         |\\\\                                         \\");
            Console.WriteLine("         | \\\\ ________________________________________\\");
            Console.WriteLine("         |  \\[_________________________________________]");
            Console.WriteLine("         |   [      ]                          |[      ]");
            Console.WriteLine("         |   [      ]                          |[      ]");
            Console.WriteLine("         |   [      ]                          |[      ]");
            Console.WriteLine("         \\   [      ]                          |[      ]");
            Console.WriteLine("          \\  [      ]                          |[      ]");
            Console.WriteLine("           \\ [      ]__________________________|[      ]");
            Console.WriteLine("            \\[______]                          \\[______]");

        }

        if (pictureName == "tapRoom")
        {
            Console.WriteLine(" |    |    |    |____|____|____|____|____|/    |__  __|    |    |   o|    \\    |");
            Console.WriteLine("_|____|____|____| _____________________  |     |  \\/  ,,;;;;;,, |    |    |    |");
            Console.WriteLine("_______________  |   __         __   | | |     |    ,;;:::::::;;,    |    |    |");
            Console.WriteLine("               | |   )(   ___   )(   | | |     |   ,;;::' , ':::;,   |    |    |");
            Console.WriteLine("               | |  (  )  )-(  (  )  o | |  8  |   ;;::  /(   ::;;   |    |   / ");
            Console.WriteLine("               | |__|  |_(   )_|  |_( )| |     /   ;;:: | '\\  ::;;   |  o |   \\ ");
            Console.WriteLine("               | |__|__|_|___|_|__|_|_|| |     \\   ';;::.\\_/.::;;'___|    |    |");
            Console.WriteLine("               | |_____________________| |     |    ';:::\\-/:::;'    |    |    |");
            Console.WriteLine("               | |  )-(   __    )(   | | |     O      '';| |;'' |    |    |    |");
            Console.WriteLine("               | | (   )  )(   (  )  | | |     |      |  '-'    |   / \\   |    8");
            Console.WriteLine("               | |_|   |_(  )__|  |__| | |     |      |    |    |   \\ /   |    |");
            Console.WriteLine("_______________| |_|___|_|__|__|__|___\\| |     /\\     |    |    |    |    |    |");
            Console.WriteLine("_________________|__________________ ____|     \\/     |    |    |    |    |    |");
            Console.WriteLine(" |    |    |    |    |__  | |\\      \\     \\    |__/-__|    |    |    |    |    |");
            Console.WriteLine(" |    |    |    |    |)(  | | \\      \\    |    |      |    |    |    |    |    )");
            Console.WriteLine("_|____|____|____|____( -)_|_|__\\______\\   |    |      0    |    |    |    |   ( ");
            Console.WriteLine("                     {__}             `\\  |    /      |    |    |    |    | __..");
            Console.WriteLine("________________________________________\\ |    |      |    |    |    |  ,-='  /");
            Console.WriteLine("                                        |_|____|      |    |    | ___|_:--..____");
            Console.WriteLine("_____       _____         _____      ___|_//=/  \\     |    |    |/ /    \\.,_____");
            Console.WriteLine("_/_\\_|     |_/_\\_|       |_/_\\_|    |_/_\\_|=|    |    |    |    / /             ");
            Console.WriteLine("|| ||       || ||         || ||      || |||=|~-, |____|____/\\__.-.--------------");
            Console.WriteLine("|| ||       || ||         || ||      || |||=|^.`;|             | |______________");
            Console.WriteLine("|| ||_______|| ||_________|| ||______||_||\\\\=\\`=.:             | | |            ");
            Console.WriteLine("||=||       ||=||         ||=||      ||=||\"\"\"`^-,`.            | | |            ");
            Console.WriteLine("|| ||       || ||         || ||      || ||   `.~,'             | |_]            ");

        }

        if (pictureName == "potions")
        {
            Console.WriteLine("                           _ô_             ");
            Console.WriteLine("                          (___)               ");
            Console.WriteLine("           _ô_             | |       _ô_      ");
            Console.WriteLine("          (___)           _|_|_     (___)  ");
            Console.WriteLine("           | |           . ___ .     | |   ");
            Console.WriteLine("          _|_|_         /       \\   _|_|_     ");
            Console.WriteLine("         . ___ .       /         \\ . ___ .    ");
            Console.WriteLine("        /       \\     /           /       \\   ");
            Console.WriteLine("       /~~~~~~~~~\\   (~~~~~~~~~~~/         \\  ");
            Console.WriteLine("      /~          \\   \\  ~     ~/~~~~~~~~~~~\\ ");
            Console.WriteLine("     (       ~     )   '.______(             )");
            Console.WriteLine("      \\  ~     ~  /             \\  ~     ~  / ");
            Console.WriteLine("       '._______.'               '._______.'      ");
        }

        if (pictureName == "randomStuffGo")
        {
            Console.WriteLine("_|_        ,________________________________       |===============|   ");
            Console.WriteLine("__ .      |__________,-------_ô_._ [____]  ''-,____|     /```\\     |   ");
            Console.WriteLine("    \\             (_(|||||||(___))___________/    )|    /    /\\    |   ");
            Console.WriteLine("~~~~~\\               `-------| |'        [ ))\"-, ( '--._\\   | /_.--'   ");
            Console.WriteLine("      \\__________           _|_|_   ___   .--.  .-`-.,--`\\__\\/`        ");
            Console.WriteLine("   ~ /=//==//=/  \\         . _.--.-\"   \"-' .- | :   :                  ");
            Console.WriteLine("____|=||==||=|    |       /  / .-,`          .'|:TNT:  _    _          ");
            Console.WriteLine("    |=||==||=|~-, |      /~~~\\   `           \\l|\\___: (_\\__/(,_        ");
            Console.WriteLine("    |=||==||=|^.`;|     /~    '.            ! \\__\\    | \\ `_////-._    ");
            Console.WriteLine("     \\=\\\\==\\\\=\\`=.:    (       |     !  .--.  |  |    L_/__ \"=> __/`\\  ");
            Console.WriteLine("      `\"\"\"\"\"\"\"`^-,`.    \\  ~   \\        '--'  /.____  |=====;__/___./  ");
            Console.WriteLine("   .~~~~`\\~~\\  `.~,'     '.____/`-.     \\__,'.'      `\\'-'-'-\"\"\"\"\"\"`   ");
            Console.WriteLine("  ;       ~~ \\ ',~^:,       __/   \\`-.____.-' `\\      /     _n_|_|_,_  ");
            Console.WriteLine("  |           ;             | `---`'-'._/-`     \\----'    _|===.-.===| ");
            Console.WriteLine("-------,______|---.         |,-'`  /             |    _.-' `\\ ((_))  | ");
            Console.WriteLine("        \\-----`    \\       .'     /              |--'`     / |='-'===' ");
            Console.WriteLine("_________`-_______-'      /      /\\              `         | |         ");
            Console.WriteLine("                          |   .\\/  \\      .--. __          \\ |        ");
        }

        if (pictureName == "swordAndShield")
        {
            Console.WriteLine("                                   /¯¯\\");
            Console.WriteLine("                                   \\__/");
            Console.WriteLine("                                   |  |");
            Console.WriteLine(" _________________________         |  |");
            Console.WriteLine("|<><><>     |  |    <><><>|        |  |");
            Console.WriteLine("|<>         |  |        <>|        |  |");
            Console.WriteLine("|           |  |          |        |  |");
            Console.WriteLine("|  (______ <\\-/> ______)  |        |  |");
            Console.WriteLine("|  /_.-=-.\\| \" |/.-=-._\\  |    .--.----.--.");
            Console.WriteLine("|   /_    \\(o_o)/    _\\   |  .-----\\__/-----.");
            Console.WriteLine("|    /_  /\\/ ^ \\/\\  _\\    |  ////¯¯|\\/|¯¯\\\\\\\\");
            Console.WriteLine("|      \\/ | / \\ | \\/      | ////   |  |   \\\\\\\\");
            Console.WriteLine("|_______ /((( )))\\ _______| ¯¯¯    |  |    ¯¯¯");
            Console.WriteLine("|      __\\ \\___/ /__      |       ./  \\.");
            Console.WriteLine("|--- (((---'   '---))) ---|       | /\\ |");
            Console.WriteLine("|           |  |          |       |\\¯¯/| ");
            Console.WriteLine("|           |  |          |       ||\\/ |");
            Console.WriteLine(":           |  |          :       ||   |");
            Console.WriteLine(" \\<>        |  |       <>/        ||   |");
            Console.WriteLine("  \\<>       |  |      <>/         ||   |");
            Console.WriteLine("   \\<>      |  |     <>/          ||   |");
            Console.WriteLine("    `\\<>    |  |   <>/'           ||   |");
            Console.WriteLine("      `\\<>  |  |  <>/'            ||   |");
            Console.WriteLine("        `\\<>|  |<>/'              ||   |");
            Console.WriteLine("          `-.  .-`                ||   |");
            Console.WriteLine("            '--'                  | \\/ |");
            Console.WriteLine("                                  |  | |");
            Console.WriteLine("                                   \\ |/");
            Console.WriteLine("                                    \\/ ");
        }
    }
}