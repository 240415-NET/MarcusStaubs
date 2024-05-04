using System;
using Project1;
using Project1.Controllers;
using Project1.Models;
using Project1.Initialize;
using Project1.Data;

namespace Project1.UserInterfaces;

public static class WelcomeToTheGame
{
    public static Dictionary<int, MonsterData> monsterReference = new();
    public static Dictionary<int, Location> locationReference = new();
    public static Dictionary<int, LevelChange> levelReference = new();
    public static Player currentPlayer = new Player();
    public static void Start()
    {
        string menuChoice;
        int menuSelection;
        bool validInput = false;
        //Dictionary<int, MonsterData> monsterReference = new Dictionary<int, MonsterData>();
        //Dictionary<int, Location> locationReference = new Dictionary<int, Location>();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(".");
        monsterReference = MonsterController.InitializeMonsterInfo();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("....");
        locationReference = LocationController.InitializeLocations();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("...........");
        levelReference = PlayerController.InitializeLevelInfo();
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
        Console.WriteLine("          ()                                 1: Login    2: Create New Character    3: Exit");
        Console.ResetColor();
        do
        {
            menuChoice = Console.ReadLine();
            try
            {
                menuSelection = Convert.ToInt32(menuChoice);
                validInput = true;
                switch (menuSelection)
                {
                    case 1:
                        LoginMenu();
                        MainControlMenu();
                        break;
                    case 2:
                        CreateNewPlayerMenu();
                        MainControlMenu();
                        break;
                    case 3:
                        return;
                    case 996:
                        GameOver();
                        break;
                    // case 4:
                    //     InitializeData.ShowMeTheMonsters();
                    //     break;
                    // case 996:
                    //     LevelStorage.CreateLevelFile();
                    //     break;                    
                    case 997:
                        LocationStorage.CreateLocationFile();
                        break;
                    // case 998:
                    //     MonsterStorage.ReadAndDisplayMonsters();
                    //     break;
                    // case 999:
                    //     MonsterStorage.FirstEverMonsterFileCreation();
                    //     break;
                    default:
                        Console.WriteLine("1, 2, or 3. Pick again");
                        validInput = false;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("1, 2, or 3. Pick again");
                validInput = false;
            }
        } while (!validInput);

    }

    public static void LoginMenu()
    {
        bool exitCondition = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Please enter your character name.");
            string userInput = (Console.ReadLine() ?? "").Trim();
            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("I asked for your name. Silence doesn't cut it. Enter your character's name or go away.");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
                exitCondition = false;
            }
            else
            {
                currentPlayer = PlayerController.LoadExistingCharacter(userInput);
                if (currentPlayer == null)
                {
                    Console.WriteLine("That's not a real name.  Give me your character's real name.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    exitCondition = false;
                }
                else
                {
                    exitCondition = true;
                }
            }
        } while (!exitCondition);
    }
    public static void CreateNewPlayerMenu()
    {
        bool validInput = false;
        string newPlayerName;
        Console.Clear();
        Console.WriteLine("Welcome to new character creation!");
        Console.WriteLine("I know that this can sometimes seem like an intimidating process with the wealth of choices\navailable and the depth of customization options, but let's just get into it.");
        Console.WriteLine("What would you like to name your new character?");
        do
        {
            newPlayerName = (Console.ReadLine() ?? "").Trim();
            if (String.IsNullOrEmpty(newPlayerName))
            {
                Console.WriteLine("I'm not asking for much but I am asking for something. Try entering a name or something, anything.");
                validInput = false;
            }
            else if (PlayerController.DoesPlayerExist(newPlayerName))
            {
                Console.WriteLine($"There is already a player called {newPlayerName}.\nUnfortunately, we can only have one of those and you'll have to choose another name.");
                validInput = false;
            }
            else
            {
                validInput = true;
            }
        } while (!validInput);

        currentPlayer = PlayerController.CreateNewPlayer(newPlayerName);
        Console.Clear();
        Console.WriteLine($"Congratulations! You are now: "); // a level 1 Warrior named {currentPlayer.Name}!");
        // Console.WriteLine($"Hitpoints (HP): {currentPlayer.CurrentHitPoints}/{currentPlayer.MaxHitPoints}");
        // Console.WriteLine($"Strength: {currentPlayer.Strength}");
        // Console.WriteLine($"Dexterity: {currentPlayer.Dexterity}");
        // Console.WriteLine($"Constitution: {currentPlayer.Constitution}");
        Console.WriteLine(currentPlayer);
        Console.WriteLine($"Experience (XP): {currentPlayer.PlayerXP}/{PlayerController.GetXPRequirementFromDictionary(levelReference[2])}");
        Console.WriteLine($"No, you don't have Intelligence, Wisdom, or Charisma stats. You won't need them.");
        Console.WriteLine("I know that was a lot to get through, so let's get to the game already.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Just kidding!  We should probably go over the basics really quickly.");
        Console.WriteLine("Once you're in the game, you will have several options available to you in most situations.");
        Console.WriteLine("If you're in a fight, you can either Attack or Flee, but careful because you won't always manage to run away.");
        Console.WriteLine("Otherwise, you can move in a given direction, view your character, rest to recover HP, save your game, or exit.");
        Console.WriteLine("To move in an available direction, you can type just the first letter of the direction you want to go.");
        Console.WriteLine("If you like typing, you can also type out the entire direction name.");
        Console.WriteLine("If you like to make things harder for yourself, you can enter M or move and then type out the direction.");
        Console.WriteLine("For any of the other actions, just type in the first letter in the word (noted with <>) or the entire word and press enter.");
        Console.WriteLine("Ok, let's get to the game for real this time!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

    }

    public static void MainControlMenu()
    {
        bool exitGame = false;
        int playerAction;
        int monsterSpawn = 0;
        bool amIDead = false;
        do
        {
            playerAction = DisplayCurrentLocation(currentPlayer.CurrentLocation);
            switch (playerAction)
            {
                case 1:
                    //move north
                    monsterSpawn = PlayerController.LocationUpdate(ref currentPlayer, 1, locationReference);
                    if (monsterSpawn != 0)
                    {
                        amIDead = TimeForAFight(monsterSpawn);
                    }
                    break;
                case 2:
                    //move east
                    monsterSpawn = PlayerController.LocationUpdate(ref currentPlayer, 2, locationReference);
                    if (monsterSpawn != 0)
                    {
                        amIDead = TimeForAFight(monsterSpawn);
                    }
                    break;
                case 3:
                    //view character
                    Console.Clear();
                    Console.WriteLine(currentPlayer);
                    if (currentPlayer.PlayerLevel < 20)
                    {
                        Console.WriteLine($"Experience (XP): {currentPlayer.PlayerXP}/{PlayerController.GetXPRequirementFromDictionary(levelReference[currentPlayer.PlayerLevel + 1])}");
                    }
                    else
                    {
                        Console.WriteLine($"Experience (XP): {currentPlayer.PlayerXP}/Max Level Reached!");
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    //move south
                    monsterSpawn = PlayerController.LocationUpdate(ref currentPlayer, 4, locationReference);
                    if (monsterSpawn != 0)
                    {
                        amIDead = TimeForAFight(monsterSpawn);
                    }
                    break;
                case 5:
                    //rest
                    monsterSpawn = PlayerController.Rest(ref currentPlayer, locationReference[currentPlayer.CurrentLocation]);
                    if (monsterSpawn == 0)
                    {
                        Console.WriteLine("You settle down to rest and tend to your wounds.  HP restored.");
                        Console.WriteLine("Press any key to continue your adventure...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You settle down to rest and tend to your wounds. But...");
                        amIDead = TimeForAFight(monsterSpawn);
                    }
                    break;
                case 6:
                    //save
                    PlayerController.SavePlayer(currentPlayer);
                    Console.WriteLine("Your character has been saved.");
                    Console.WriteLine("Press any key to continue your adventure...");
                    Console.ReadKey();
                    break;
                case 7:
                    //Add in a save feature or ask if want to save.
                    return;
                //break;
                case 8:
                    //move west
                    monsterSpawn = PlayerController.LocationUpdate(ref currentPlayer, 8, locationReference);
                    if (monsterSpawn != 0)
                    {
                        amIDead = TimeForAFight(monsterSpawn);
                    }
                    break;
            }
        } while (!exitGame && !amIDead);
        if(amIDead)
        {
            GameOver();
        }

    }
    public static int DisplayCurrentLocation(int locationHash)
    {
        Location currentLocation = locationReference[locationHash];
        bool exitCurrentRoom = false;
        int userChoice;
        do
        {
            Console.Clear();
            Console.WriteLine($"Current Location: {currentLocation.RoomName}");
            if (locationHash != 112804)
            {
                Console.WriteLine(currentLocation.RoomDescription);
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): {(MoveDirection)currentLocation.EnumMovementOptions}");
            }
            else if (currentPlayer.PlayerLevel >= 10)
            {
                Console.WriteLine("The glow has faded from the mysterious door and it appears to be slightly ajar.");
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): {(MoveDirection)currentLocation.EnumMovementOptions}");
            }
            else if (locationHash == 112805)
            {
                Console.WriteLine(currentLocation.RoomDescription);
                //Boss fight time
            }
            else
            {
                Console.WriteLine(currentLocation.RoomDescription);
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): North");
            }
            Console.WriteLine($"\n<M>ove\t\t<C>haracter\t\t<R>est\t\tSa<v>e\t\tE<x>it");
            string userInput = (Console.ReadLine() ?? "").Trim();
            userChoice = UserInputHandler(userInput, false, locationHash);
            if (userChoice != 0)
            {
                exitCurrentRoom = true;
            }
        } while (!exitCurrentRoom);
        return userChoice;
    }

    public static int UserInputHandler(string userInput, bool InCombat, int locationHash)
    {
        string OriginalUserInput = userInput;
        userInput = userInput.ToLower();
        if (String.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("That was... not very enlightening. You literally gave me nothing to work with. Try again.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return 0;
        }
        else if (InCombat)
        {
            if (userInput == "a" || userInput == "attack" || userInput.Contains("attack"))
            {
                return 9;
            }
            if (userInput == "f" || userInput == "flee" || userInput.Contains("flee"))
            {
                return 10;
            }
            Console.WriteLine("I didn't understand what you wanted. Try again.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return 0;
        }
        else
        {
            if (userInput == "c" || userInput == "character" || userInput.Contains("character"))
            {
                return 3;
            }
            if (userInput == "r" || userInput == "rest" || userInput.Contains("rest"))
            {
                return 5;
            }
            if (userInput == "v" || userInput == "save" || userInput.Contains("save"))
            {
                return 6;
            }
            if (userInput == "x" || userInput == "exit" || userInput.Contains("exit"))
            {
                return 7;
            }
            if (userInput == "n" || userInput == "north" || userInput.Contains("north"))
            {
                if (Movement.CanIMoveThisWay(MoveDirection.North, locationReference[locationHash], currentPlayer.PlayerLevel))
                {
                    return 1;
                }
                else
                {
                    Console.WriteLine("You can't go North from here. Try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return 0;
                }
            }
            if (userInput == "e" || userInput == "east" || userInput.Contains("east"))
            {
                if (Movement.CanIMoveThisWay(MoveDirection.East, locationReference[locationHash], currentPlayer.PlayerLevel))
                {
                    return 2;
                }
                else
                {
                    Console.WriteLine("You can't go East from here. Try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return 0;
                }
            }
            if (userInput == "s" || userInput == "south" || userInput.Contains("south"))
            {
                if (Movement.CanIMoveThisWay(MoveDirection.South, locationReference[locationHash], currentPlayer.PlayerLevel))
                {
                    return 4;
                }
                else
                {
                    Console.WriteLine("You can't go South from here. Try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return 0;
                }
            }
            if (userInput == "w" || userInput == "west" || userInput.Contains("west"))
            {
                if (Movement.CanIMoveThisWay(MoveDirection.West, locationReference[locationHash], currentPlayer.PlayerLevel))
                {
                    return 8;
                }
                else
                {
                    Console.WriteLine("You can't go West from here. Try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return 0;
                }
            }
            if (OriginalUserInput == "~IWantToBeStronger" && currentPlayer.PlayerLevel < 20)
            {
                PlayerController.Ding(ref currentPlayer, levelReference[currentPlayer.PlayerLevel + 1]);
                Console.WriteLine($"Cheater! Player leveled up to {currentPlayer.PlayerLevel}.");
                Console.ReadKey();
                return 0;
            }
            Console.WriteLine("I didn't understand what you wanted. Try again.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return 0;
        }
    }
    public static bool TimeForAFight(int monsterSpawn)
    {
        Monster currentMonster = new Monster(monsterReference[monsterSpawn]);
        bool isSomeoneDead = false;
        bool playerRanAway = false;
        string userInput;
        int userChoice;
        int playerAttack;
        int monsterAttack;
        bool amIDead = false;
        Console.WriteLine($"You have encountered a {currentMonster.Name}!");
        Console.WriteLine("Press any key to start the fight...");
        Console.ReadKey();
        do
        {
            Console.Clear();
            for (int i = 0; i < currentMonster.MonsterDisplay.Count(); i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"{currentMonster.MonsterDisplay[i]}  {currentMonster.Name}\t\t\t{currentPlayer.Name}");
                }
                else if (i == 1)
                {
                    Console.WriteLine($"{currentMonster.MonsterDisplay[i]}  HP: {currentMonster.CurrentHitPoints}/{currentMonster.MaxHitPoints}\t\t\tHP: {currentPlayer.CurrentHitPoints}/{currentPlayer.MaxHitPoints}");
                }
                else
                {
                    Console.WriteLine(currentMonster.MonsterDisplay[i]);
                }
            }
            Console.WriteLine("\n\nDo you want to <A>ttack or <F>lee?");
            //isSomeoneDead = true;
            userInput = (Console.ReadLine() ?? "").Trim();
            userChoice = UserInputHandler(userInput, true, currentPlayer.CurrentLocation);
            if (userChoice == 9)
            {
                playerAttack = CombatController.PlayerAttacksMonster(ref currentPlayer, ref currentMonster);
                if (playerAttack > 0)
                {
                    Console.WriteLine(currentMonster.HitText);
                    Console.WriteLine($"You hit {currentMonster.Name} for {playerAttack} damage.");
                }
                else
                {
                    Console.WriteLine($"{currentMonster.Name} {currentMonster.DodgeText}");
                    Console.WriteLine("You missed!");
                }
                Console.ReadKey();
            }
            else if (userChoice == 10)
            {
                Console.WriteLine($"You turn and run for your life!");
                if (CombatController.DoesPlayerFleeSuccessfully(currentMonster.ChanceToFlee))
                {
                    playerRanAway = true;
                }
                else
                {
                    Console.WriteLine("But your path is blocked.");
                    Console.ReadKey();
                }
            }
            if (currentMonster.CurrentHitPoints > 0 && !playerRanAway)
            {
                monsterAttack = CombatController.MonsterAttacksPlayer(ref currentPlayer, ref currentMonster);
                Console.WriteLine($"{currentMonster.Name} {currentMonster.AttackText} at you");
                Console.ReadKey();
                if (monsterAttack == -1)
                {
                    Console.WriteLine("But you dodge in time and they miss!");
                    Console.ReadKey();
                }
                else if (monsterAttack == 0)
                {
                    Console.WriteLine($"{currentMonster.Name} does no damage due to your thickened skin.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"{currentMonster.Name} does {monsterAttack} damage to you.");
                    Console.ReadKey();
                }
                if (currentPlayer.CurrentHitPoints <= 0)
                {
                    isSomeoneDead = true;
                }
            }
            else if (!playerRanAway)
            {
                Console.WriteLine($"You have slain {currentMonster.Name}!");
                Console.ReadKey();
                isSomeoneDead = true;
            }
        } while (!isSomeoneDead && !playerRanAway);
        if (currentPlayer.CurrentHitPoints <= 0 && isSomeoneDead)
        {
            Console.WriteLine("You have died.  Better luck next time.");
            Console.ReadKey();
            return true;
        }
        else if (isSomeoneDead)
        {
            //Congrats on killing monster (random responses eventually)
            //code to receive rewards from monster
            //check if player gained a level and, if so, increase stats
            if (currentPlayer.PlayerLevel < 20)
            {
                Console.WriteLine($"You have gained {currentMonster.RewardXP} experience for killing {currentMonster.Name}.");
                if (currentPlayer.PlayerXP >= PlayerController.GetXPRequirementFromDictionary(levelReference[currentPlayer.PlayerLevel + 1]))
                {
                    PlayerController.Ding(ref currentPlayer, levelReference[currentPlayer.PlayerLevel + 1]);
                    Console.WriteLine($"Congratulations! You have reached level {currentPlayer.PlayerLevel}!");
                }
            }
            else
            {
                Console.WriteLine($"You have gained 0 experience for killing {currentMonster.Name}. You are at max level.");
            }
            Console.ReadKey();
        }
        else
        {
            //move the player in an available direction based on the room they are in. Can spawn another monster lol.
            Console.WriteLine("Run away!!"); //indicate the direction they ran.
            Console.ReadKey();
            //Player ran away - mock them? random based on what they ran from?
        }
        return amIDead;
    }

    public static void GameOver()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(" ▄▄ •  ▄▄▄· •   ▌  ▄  ·. ▄▄▄ .         ▌ ▐ ·▄▄▄ .▄▄▄  ");
        Console.WriteLine("▐█ ▀  ▐█ ▀█ ·██ ▐███  ▀▄.▀·          █·█▌ ▀▄.▀·▀▄ █·");
        Console.WriteLine("▄█ ▀█▄▄█▀▀█ ▐█ ▌▐▌▐█·▐▀▀ ▄     ▄█▀▄ ▐█▐█• ▐▀▀ ▄ ▐▀▀▄ ");
        Console.WriteLine("▐█▄ ▐█▐█  ▐▌██ ██▌▐█▌▐█▄▄▌    ▐█▌.▐▌ ███ ▐█▄▄▌ ▐█  █▌");
        Console.WriteLine("·▀▀▀▀  ▀  ▀ ▀▀  █ ▀▀▀ ▀▀▀      ▀█▄▀ . ▀   ▀▀▀ . ▀  ▀");
        Console.WriteLine("\nYou're dead and the world is doomed or something.\nI don't know. The story for this game was never really fleshed out.\nJust go with your favorite fantasty game trope again.");
        Console.ReadKey();
    }
}




