using System;
using Project1;
using Project1.Controllers;
using Project1.Models;
using Project1.Initialize;

namespace Project1.UserInterfaces;

public static class WelcomeToTheGame
{
    public static void Start()
    {
        string menuChoice;
        int menuSelection;
        bool validInput = false;
        //Dictionary<int, MonsterData> monsterReference = new Dictionary<int, MonsterData>();
        Player currentPlayer = new Player();
        //Dictionary<int, Location> locationReference = new Dictionary<int, Location>();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(".");
        Dictionary<int, MonsterData> monsterReference = MonsterController.InitializeMonsterInfo();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("....");
        Dictionary<int, Location>locationReference = LocationController.InitializeLocations();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("...........");
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("      _,.");
        Console.WriteLine("    ,` -.)");
        Console.WriteLine("   ( _/-\\\\-._                             Warrior's Quest");
        Console.WriteLine("  /,|`--._,-^|            ,         The search for a passing grade");
        Console.WriteLine("  \\_| |`-._/||          ,'|");
        Console.WriteLine("    |  `-, / |         /  /");
        Console.WriteLine("    |     || |        /  /                 1: Login");
        Console.WriteLine("     `r-._||/   __   /  /                  2: Create New Character");
        Console.WriteLine(" __,-<_     )`-/  `./  /                   3: Exit");
        Console.WriteLine("'  \\   `---'   \\   /  /");
        Console.WriteLine("    |           |./  /");
        Console.WriteLine("    /           //  /");
        Console.WriteLine("\\_/' \\         |/  /");
        Console.WriteLine(" |    |   _,^-'/  /");
        Console.WriteLine(" |    , ``  (\\/  /_");
        Console.WriteLine("  \\,.->._    \\X-=/^");
        Console.WriteLine("  (  /   `-._//^`");
        Console.WriteLine("   `Y-.____(__}");
        Console.WriteLine("    |     {__)");
        Console.WriteLine("          ()");
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
                        Console.WriteLine("Log in with an existing a character!");
                        break;
                    case 2:
                        currentPlayer = CreateNewPlayerMenu();
                        break;
                    case 3:
                        return;
                    case 4:
                        InitializeData.ShowMeTheMonsters();
                        break;
                    // case 997:
                    //     LocationStorage.CreateLocationFile();
                    //     break;                        
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
                //Console.WriteLine(e.StackTrace);
                Console.WriteLine("1, 2, or 3. Pick again");
                validInput = false;
            }
        } while (!validInput);

    }
    public static Player CreateNewPlayerMenu()
    {
        bool validInput = false;
        string newPlayerName;
        Console.Clear();
        Console.WriteLine("Welcome to new character creation!");
        Console.WriteLine("I know that this can sometimes seem like an intimidating process with the wealth of choices\navailable and the depth of customization options, but let's just get into it.");
        Console.WriteLine("What would you like to name your new character?");
        do
        {
            newPlayerName = Console.ReadLine();
            if (String.IsNullOrEmpty(newPlayerName.Trim()))
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
        Player currentPlayer = PlayerController.CreateNewPlayer(newPlayerName);
        Console.WriteLine($"Congratulations! You are now a level 1 Warrior named {newPlayerName}!");
        Console.WriteLine("I know that was a lot to get through, so let's get to the game already.");
        return currentPlayer;

    }
}