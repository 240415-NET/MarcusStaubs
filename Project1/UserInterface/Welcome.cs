using System;
using System.Formats.Asn1;
using Project1;
using Project1.Controllers;
using Project1.Models;

namespace Project1.UserInterfaces;

public static class WelcomeToTheGame
{
    public static Dictionary<int, MonsterData> monsterReference = new();
    public static Dictionary<int, Location> locationReference = new();
    public static Dictionary<int, LevelChange> levelReference = new();
    public static Dictionary<string, Item> itemsReference = new();
    public static Player currentPlayer = new Player();
    public static List<string> gameMap = new();
    public static List<string> displayMap = new();
    public static void Start()
    {
        string menuChoice;
        int menuSelection;
        bool validInput = false;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(".");
        //Load monster reference data from data source
        monsterReference = MonsterController.InitializeMonsterInfo();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("....");
        //Load location data from data source
        locationReference = LocationController.InitializeLocations();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("...........");
        //Load level up information from data source
        levelReference = PlayerController.InitializeLevelInfo();
        //Load full map data from data source
        gameMap = MapController.LoadFullMap();
        //Load all items from data source
        itemsReference = MapController.GetAllGameItems();
        do
        {
            MainMenuDisplay();
            menuChoice = Console.ReadLine();
            try
            {
                menuSelection = Convert.ToInt32(menuChoice);
                validInput = true;
                switch (menuSelection)
                {
                    case 1:
                        bool successfulLogin = LoginMenu();
                        if (successfulLogin)
                        {
                            MainControlMenu();
                        }
                        else
                        {
                            validInput = false;
                        }
                        break;
                    case 2:
                        CreateNewPlayerMenu();
                        MainControlMenu();
                        break;
                    case 3:
                        return;
                    case 996:
                        MapController.LoadItemFile();
                        break;
                    case 997:
                        LocationController.RecreateLocationFile();
                        break;
                    case 998:
                        MonsterController.ReloadMonsterList();
                        break;
                    case 999:
                        MapController.ReloadMapFile();
                        break;
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
                Console.ReadKey();
                validInput = false;
            }
        } while (!validInput);

    }
    public static bool LoginMenu()
    {
        bool exitCondition = false;
        do
        {
            //Console.Clear();
            //Console.WriteLine("Please enter your character nameor enter Oops to return to the main menu");
            LoginDisplay();
            string userInput = (Console.ReadLine() ?? "").Trim();
            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("I asked for your name. Silence doesn't cut it. Enter your character's name or go away.");
                Console.WriteLine("Press any key to try again...");
                exitCondition = false;
            }
            else if (userInput.ToLower() == "oops")
            {
                return false;
            }
            else
            {
                currentPlayer = PlayerController.LoadExistingCharacter(userInput);
                if (currentPlayer == null)
                {
                    Console.WriteLine("Yeah... I don't know you or you spelled your own name wrong.\nI really hope it's the first one.");
                    Console.WriteLine("If you made a mistake and meant to create a new character,\nenter oops to return to the main menu.");
                    Console.WriteLine("Press any key to try again...");
                    exitCondition = false;
                }
                else
                {
                    displayMap = MapController.MatchDisplayMapToPlayerMap(ref currentPlayer);
                    DisplayCharacter();
                    return true;
                }
                Console.ReadKey();
            }
        } while (!exitCondition);
        return false;
    }
    public static void CreateNewPlayerMenu()
    {
        bool validInput = false;
        string newPlayerName;
        NewPlayerDisplay();
        do
        {
            Console.Write("Name: ");
            newPlayerName = (Console.ReadLine() ?? "").Trim();
            if (String.IsNullOrEmpty(newPlayerName))
            {
                Console.WriteLine("I'm not asking for much but I am asking for something. Try entering a name or something, anything.");
                validInput = false;
            }
            else if (newPlayerName.Count() > 40)
            {
                Console.WriteLine("That's too long and there is no way I am not going to remember all of that. Pick a shorter name.");
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
        displayMap = MapController.MatchDisplayMapToPlayerMap(ref currentPlayer);
        Console.Clear();
        Console.WriteLine(currentPlayer.ToString(PlayerController.GetXPRequirementFromDictionary(levelReference[currentPlayer.PlayerLevel + 1]).ToString()));
        Console.WriteLine($"No, you don't have Intelligence, Wisdom, or Charisma stats. You won't need them.");
        Console.WriteLine("I know that was a lot to get through, so let's get to the game already.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Just kidding!  We should probably quickly go over the basics.");
        Console.WriteLine("Press any key to view the Help documentation...");
        Console.ReadKey();
        HelpMenu();

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
                case 0:
                    Console.ReadKey();
                    break;
                case 1:
                case 2:
                case 4:
                case 8:
                    //Movement  
                    if (Movement.CanIMoveThisWay(playerAction, locationReference[currentPlayer.CurrentLocation].EnumMovementOptions, locationReference[currentPlayer.CurrentLocation].RoomHash, currentPlayer.PlayerLevel))
                    {

                        currentPlayer.TimeToMove(playerAction);
                        monsterSpawn = LocationController.DoesMonsterSpawn(locationReference[currentPlayer.CurrentLocation]);
                        if (monsterSpawn != 0)
                        {
                            amIDead = TimeForAFight(monsterSpawn);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You can't go {(MoveDirection)playerAction} from here. Try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    //view character
                    DisplayCharacter();
                    break;
                case 5:
                    //rest
                    monsterSpawn = PlayerController.Rest(ref currentPlayer, locationReference[currentPlayer.CurrentLocation]);
                    if (monsterSpawn == 0)
                    {
                        RestMenu();
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
                case 11:
                    HelpMenu();
                    break;
                case 15:
                    InventoryMenu();
                    break;
                case 999:
                    amIDead = true;
                    break;
            }
        } while (!exitGame && !amIDead);
        if (amIDead)
        {
            GameOver();
        }
    }
    public static int DisplayCurrentLocation(int locationHash)
    {
        Location currentLocation = locationReference[locationHash];
        bool exitCurrentRoom = false;
        int userChoice;
        ConsoleKeyInfo keyPress;
        do
        {
            Console.Clear();
            MapController.UpdateMap(ref currentPlayer, gameMap, ref displayMap);
            for (int i = 0; i < 17; i++)
            {
                Console.WriteLine(currentLocation.LocationDisplay[i] + "     " + displayMap[i]);
            }
            Console.WriteLine($"\nCurrent Location: {currentLocation.RoomName}");
            if (locationHash != 112804 && locationHash != 112805)
            {
                Console.WriteLine(currentLocation.RoomDescription);
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): {(MoveDirection)currentLocation.EnumMovementOptions}");
            }
            else if (currentPlayer.PlayerLevel >= 10 && locationHash == 112804)
            {
                Console.WriteLine("There is a mysterious door to the south and it appears to be slightly ajar.");
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): {(MoveDirection)currentLocation.EnumMovementOptions}");
            }
            else if (locationHash == 112805)
            {
                Console.WriteLine(currentLocation.RoomDescription);
                return BossFight();
            }
            else
            {
                Console.WriteLine(currentLocation.RoomDescription);
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): North");
            }
            Console.WriteLine($"\n<C>haracter\t\t<I>nventory\t\t<R>est\t\tSa<v>e\t\tE<x>it\t\t<H>elp");
            keyPress = Console.ReadKey(true);
            string userInput = keyPress.Key.ToString();
            userChoice = UserInputHandler(userInput, false);
            if (userChoice != 0)
            {
                exitCurrentRoom = true;
            }
            else
            {
                Console.ReadKey();
            }
        } while (!exitCurrentRoom);
        return userChoice;
    }
    public static int UserInputHandler(string userInput, bool InCombat, bool InInventory = false)
    {
        string OriginalUserInput = userInput;
        userInput = userInput.ToLower();
        if (String.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("That was... not very enlightening. You literally gave me nothing to work with. Try again.");
            Console.WriteLine("Press any key to continue...");
            return 0;
        }
        else if (InCombat)
        {
            if (userInput == "a")
            {
                return 9;
            }
            if (userInput == "f")
            {
                return 10;
            }
            if (userInput == "h")
            {
                return 11;
            }
            if (userInput == "d")
            {
                return 14;
            }
            Console.WriteLine("I didn't understand what you wanted. Try again.");
            Console.WriteLine("Press any key to continue...");
            return 0;
        }
        else if (!InInventory)
        {
            if (userInput == "c")
            {
                return 3;
            }
            if (userInput == "r")
            {
                return 5;
            }
            if (userInput == "v")
            {
                return 6;
            }
            if (userInput == "x")
            {
                return 7;
            }
            if (userInput == "n" || userInput == "uparrow")
            {
                return 1;
            }
            if (userInput == "e" || userInput == "rightarrow")
            {
                return 2;
            }
            if (userInput == "s" || userInput == "downarrow")
            {
                return 4;
            }
            if (userInput == "w" || userInput == "leftarrow")
            {
                return 8;
            }
            if (userInput == "i")
            {
                return 15;
            }
            if (OriginalUserInput == "~" && currentPlayer.PlayerLevel < 20)
            {
                PlayerController.Ding(ref currentPlayer, levelReference[currentPlayer.PlayerLevel + 1]);
                Console.WriteLine($"Cheater! Player leveled up to {currentPlayer.PlayerLevel}.");
                return 0;
            }
            if (userInput == "h")
            {
                return 11;
            }
        }
        else
        {
            if (userInput == "b")
            {
                return 12;
            }
            if (userInput == "q")
            {
                return 13;
            }
            if (userInput == "e")
            {
                return 16;
            }
            if (userInput == "i")
            {
                return 17;
            }
            if (userInput == "w")
            {
                return 18;
            }
            if (userInput == "a")
            {
                return 19;
            }
            if (userInput == "p")
            {
                return 20;
            }
            if (userInput == "d")
            {
                return 21;
            }
        }
        Console.WriteLine("I didn't understand what you wanted. Try again.");
        Console.WriteLine("Press any key to continue...");
        return 0;
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
        ConsoleKeyInfo keyPress;
        Console.WriteLine($"You have encountered a {currentMonster.Name}!");
        Console.WriteLine("Press any key to start the fight...");
        Console.ReadKey();
        do
        {
            Console.Clear();
            currentMonster.DisplayMonster(currentPlayer.Name, currentPlayer.CurrentHitPoints, currentPlayer.MaxHitPoints);
            Console.WriteLine("\n\nDo you want to <A>ttack or <F>lee?\t\t<H>elp");
            keyPress = Console.ReadKey(true);
            userInput = keyPress.Key.ToString();
            userChoice = UserInputHandler(userInput, true);
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
            else if (userChoice == 11)
            {
                HelpMenu();
            }
            else if (userChoice == 0)
            {
                Console.ReadKey();
            }
            if (currentMonster.CurrentHitPoints > 0 && !playerRanAway && userChoice != 0 && userChoice != 11)
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
            else if (!playerRanAway && userChoice != 0 && userChoice != 11)
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
            //if you're max level (20) you get no xp
            if (currentPlayer.PlayerLevel < 20)
            {
                //code to notify user of rewards from monster
                Console.WriteLine($"You have gained {currentMonster.RewardXP} experience for killing {currentMonster.Name}.");
                //check if player gained a level and, if so, increase stats
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
            string monsterLoot = currentMonster.LootDrop();
            if (monsterLoot != "No loot" && currentMonster.RewardGold == 0)
            {
                Console.WriteLine($"Digging around the corpse of the {currentMonster.Name}, you find 1 {itemsReference[monsterLoot].ItemName}.");
                currentPlayer.GetThatLoot(itemsReference[monsterLoot]);
            }
            else if (monsterLoot != "No loot")
            {
                Console.WriteLine($"Digging around the corpse of the {currentMonster.Name}, you find {currentMonster.RewardGold} gold coins.");
                Console.WriteLine($"You also find 1 {itemsReference[monsterLoot].ItemName}.");
                currentPlayer.GetThatLoot(itemsReference[monsterLoot]);                
            }
            else if (currentMonster.RewardGold > 0)
            {
                Console.WriteLine($"Digging around the corpse of the {currentMonster.Name}, you find {currentMonster.RewardGold} gold coins.");
            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Cheese it!!");
            Console.ReadKey();
            //Player ran away - mock them? random based on what they ran from?
        }
        return amIDead;
    }
    public static int BossFight()
    {
        int turnCounter = 0;
        bool isSomeoneDead = false;
        int playerAttack;
        int monsterAttack;
        Monster bossMonster = new Monster(monsterReference[1941]);
        Location currentLocation = locationReference[112805];
        Console.WriteLine("You start to see a glow approaching from the far end of the cave.");
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkRed;
        foreach (string imageLine in currentLocation.LocationDisplay)
        {
            Console.WriteLine(imageLine);
        }
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
        foreach (string imageLine in currentLocation.LocationDisplay)
        {
            Console.WriteLine(imageLine);
        }
        Console.WriteLine("A massive form slowly appears from the shadows of the far end of the cavern.");
        Console.ReadKey();
        //Thread.Sleep(1000);
        do
        {
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < bossMonster.MonsterDisplay.Count(); i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"{bossMonster.MonsterDisplay[i]}" + String.Format("{0,20}{1,40}", bossMonster.Name, currentPlayer.Name));
                }
                else if (i == 1)
                {
                    string monsterHP = $"HP: {bossMonster.CurrentHitPoints}/{bossMonster.MaxHitPoints}";
                    string playerHP = $"HP: {currentPlayer.CurrentHitPoints}/{currentPlayer.MaxHitPoints}";
                    Console.WriteLine($"{bossMonster.MonsterDisplay[i]}" + String.Format("{0,20}{1,40}", monsterHP, playerHP));
                }
                else
                {
                    Console.WriteLine(bossMonster.MonsterDisplay[i]);
                }
            }
            Console.ResetColor();
            Console.WriteLine($"There is nowhere to run. Press any key to attack the {bossMonster.Name}.");
            Console.ReadKey();
            playerAttack = CombatController.PlayerAttacksMonster(ref currentPlayer, ref bossMonster);
            if (playerAttack > 0)
            {
                Console.WriteLine(bossMonster.HitText);
                Console.WriteLine($"You hit {bossMonster.Name} for {playerAttack} damage.");
            }
            else
            {
                Console.WriteLine($"{bossMonster.Name} {bossMonster.DodgeText}");
                Console.WriteLine("You missed!");
            }
            Console.ReadKey();
            if (bossMonster.CurrentHitPoints > 0)
            {
                monsterAttack = CombatController.MonsterAttacksPlayer(ref currentPlayer, ref bossMonster);
                Console.WriteLine($"{bossMonster.Name} {bossMonster.AttackText} at you");
                Console.ReadKey();
                if (monsterAttack == -1)
                {
                    Console.WriteLine("But you dodge in time and they miss!");
                    Console.ReadKey();
                }
                else if (monsterAttack == 0)
                {
                    Console.WriteLine($"{bossMonster.Name} does no damage due to your thickened skin.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"{bossMonster.Name} does {monsterAttack} damage to you.");
                    Console.ReadKey();
                }
                if (currentPlayer.CurrentHitPoints <= 0)
                {
                    Console.WriteLine("Shockingly, while attempting to fight a huge fire-breathing dragon, you have died.");
                    return 999;
                }
            }
            else
            {
                isSomeoneDead = true;
            }
            turnCounter++;
        } while (!isSomeoneDead && turnCounter < 5);
        if (turnCounter >= 5 && bossMonster.CurrentHitPoints > 0)
        {
            Console.WriteLine($"You feel your hair and clothes whipping around you as the {bossMonster.Name} takes in a long deep breath.");
            Console.WriteLine($"A dull red glow starts to emanate from {bossMonster.Name}'s chest.");
            Thread.Sleep(5000);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 23; i++)
            {
                Console.WriteLine(" ".PadRight(150, ' '));
            }
            Thread.Sleep(300);
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < 23; i++)
            {
                Console.WriteLine(" ".PadRight(150, ' '));
            }
            Thread.Sleep(300);
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < 23; i++)
            {
                Console.WriteLine(" ".PadRight(150, ' '));
            }
            Thread.Sleep(300);
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < 23; i++)
            {
                Console.WriteLine(" ".PadRight(150, ' '));
            }
            Thread.Sleep(300);
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("The room fills with searing fire and, for the briefest moment that seems more like an eternity, you feel your body start to melt");
            Console.WriteLine("Your world is nothing but pain and fire.");
            Console.WriteLine("Then the pain fades away and all goes... black...");
            Console.ReadKey();
            return 999;

        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("VVVVVVVV           VVVVVVVV iiii                               tttt                                                                      !!! ");
            Console.WriteLine("V::::::V           V::::::Vi::::i                           ttt:::t                                                                     !!:!!");
            Console.WriteLine("V::::::V           V::::::V iiii                            t:::::t                                                                     !:::!");
            Console.WriteLine("V::::::V           V::::::V                                 t:::::t                                                                     !:::!");
            Console.WriteLine(" V:::::V           V:::::Viiiiiii     ccccccccccccccccttttttt:::::ttttttt       ooooooooooo   rrrrr   rrrrrrrrryyyyyyy           yyyyyyy!:::!");
            Console.WriteLine("  V:::::V         V:::::V i:::::i   cc:::::::::::::::ct:::::::::::::::::t     oo:::::::::::oo r::::rrr:::::::::ry:::::y         y:::::y !:::!");
            Console.WriteLine("   V:::::V       V:::::V   i::::i  c:::::::::::::::::ct:::::::::::::::::t    o:::::::::::::::or:::::::::::::::::ry:::::y       y:::::y  !:::!");
            Console.WriteLine("    V:::::V     V:::::V    i::::i c:::::::cccccc:::::ctttttt:::::::tttttt    o:::::ooooo:::::orr::::::rrrrr::::::ry:::::y     y:::::y   !:::!");
            Console.WriteLine("     V:::::V   V:::::V     i::::i c::::::c     ccccccc      t:::::t          o::::o     o::::o r:::::r     r:::::r y:::::y   y:::::y    !:::!");
            Console.WriteLine("      V:::::V V:::::V      i::::i c:::::c                   t:::::t          o::::o     o::::o r:::::r     rrrrrrr  y:::::y y:::::y     !:::!");
            Console.WriteLine("       V:::::V:::::V       i::::i c:::::c                   t:::::t          o::::o     o::::o r:::::r               y:::::y:::::y      !!:!!");
            Console.WriteLine("        V:::::::::V        i::::i c::::::c     ccccccc      t:::::t    tttttto::::o     o::::o r:::::r                y:::::::::y        !!! ");
            Console.WriteLine("         V:::::::V        i::::::ic:::::::cccccc:::::c      t::::::tttt:::::to:::::ooooo:::::o r:::::r                 y:::::::y             ");
            Console.WriteLine("          V:::::V         i::::::i c:::::::::::::::::c      tt::::::::::::::to:::::::::::::::o r:::::r                  y:::::y          !!! ");
            Console.WriteLine("           V:::V          i::::::i  cc:::::::::::::::c        tt:::::::::::tt oo:::::::::::oo  r:::::r                 y:::::y          !!:!!");
            Console.WriteLine("            VVV           iiiiiiii    cccccccccccccccc          ttttttttttt     ooooooooooo    rrrrrrr                y:::::y            !!! ");
            Console.WriteLine("                                                                                                                     y:::::y                 ");
            Console.WriteLine("                                                                                                                    y:::::y                  ");
            Console.WriteLine("                                                                                                                   y:::::y                   ");
            Console.WriteLine("                                                                                                                  y:::::y                    ");
            Console.WriteLine("                                                                                                                 yyyyyyy                     ");
            Console.ResetColor();
            Console.WriteLine($"You did it! You managed to kill a {bossMonster.Name} with your bare hands.");
            Console.WriteLine("I don't know if that was clear before but you don't have any weapons.");
            Console.WriteLine("You've been punching and kicking, or in some cases stomping or biting, things to death.");
            Console.WriteLine("Good show! Congratulations! I should probably create some kind of cool or cheesy splash screen to celebrate this occasion.");
            Console.WriteLine("Maybe I'll do that later if I have time but there are other things I want to do here.  Like maybe give you weapons and armor.");
            Console.ReadKey();
            return 7;
        }

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
        Console.WriteLine("            |     When in combat, you can <A>ttack or <Flee>     |    ");
        Console.WriteLine("            |     Outside of combat, you can:                    |    ");
        Console.WriteLine("            |        View your <C>haracter                       |    ");
        Console.WriteLine("            |        <R>est to restore HP                        |    ");
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
        Console.WriteLine("            |     like and intmidating process.          |    ");
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
    public static void DisplayCharacter()
    {
        Console.Clear();
        if (currentPlayer.PlayerLevel < 20)
        {
            Console.WriteLine(currentPlayer.ToString(PlayerController.GetXPRequirementFromDictionary(levelReference[currentPlayer.PlayerLevel + 1]).ToString()));
        }
        else
        {
            Console.WriteLine(currentPlayer.ToString("Max Level Reached!"));
        }
        Console.ReadKey();
    }
    public static void TownMenu()
    {
        /*
        Display location image (separate method used by CurrentLocation and Town Menu?)
        Options to Move (North and East from location info)
        Update location image and description in file
        Monster spawn chance to 0
        Inn Menu
            Rest at Inn (different picture) - costs gold 
            Have a drink - Costs 1 gold. Does nothing.  Maybe part of below rumors
            Listen to rumors - Random list of stuff that could be said
        Vendor - Buys junk items / Sells potions
            Sell menu - List all items in player inventory or say nothing to sell
                Option to sell x quantity or All
            Buy menu - Potions available depends on level of player
                Buy more than one at once?    
        Arms Merchant - Buys and Sells Weapons and Armor (Sell offers are level limited)
            Sell menu - List all weapons and armor in player inventory
                Option to sell x quantity or All
            Buy menu - Weapons and armor separate menus - offers limited by player level    
                Ask to equip after purchase?
        */
    }
    public static void InnMenu()
    {

    }
    public static void VendorMenu()
    {

    }
    public static void ArmsMerchantMenu()
    {

    }
    public static void InventoryMenu()
    {
        bool iMDone = false;
        if (currentPlayer.DoIHaveStuff())
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Would you like to <B>rowse your inventory or E<q>uip an item? <D> when done.");
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                string userInput = keyPress.Key.ToString();
                int userChoice = UserInputHandler(userInput, false, true);
                if (userChoice == 12)
                {
                    ViewInventoryMenu();
                }
                else if (userChoice == 13)
                {
                    if (!currentPlayer.DoIHaveArmors() && !currentPlayer.DoIHaveWeapons())
                    {
                        Console.WriteLine("Nothing to equip. Go find some.");
                        Console.ReadKey();
                    }
                    else
                    {
                        EquipItemMenu();
                    }
                }
                else if (userChoice == 21)
                {
                    iMDone = true;
                }
                else
                {
                    Console.ReadKey();
                }
            } while (!iMDone);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nothing to see here. Move along.");
            Console.ReadKey();
        }
    }
    public static void ViewInventoryMenu()
    {
        bool exitViewInventory = false;
        do
        {
            Console.Clear();
            Console.WriteLine("What kind of items would you like to look at? <D> when done.");
            Console.WriteLine(currentPlayer.KindsOfStuffIHave());
            ConsoleKeyInfo keyPress = Console.ReadKey(true);
            string userInput = keyPress.Key.ToString();
            int userChoice = UserInputHandler(userInput, false, true);
            if (userChoice == 16)
            {
                foreach (Item item in currentPlayer.InventoryItems)
                {
                    Console.WriteLine(item);
                }
                foreach (Weapon weapon in currentPlayer.InventoryWeapons)
                {
                    Console.WriteLine(weapon);
                }
                foreach (Armor armor in currentPlayer.InventoryArmors)
                {
                    Console.WriteLine(armor);
                }
                foreach (Potion potion in currentPlayer.InventoryPotions)
                {
                    Console.WriteLine(potion);
                }
                Console.ReadKey();
            }
            else if (userChoice == 17)
            {
                foreach (Item item in currentPlayer.InventoryItems)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
            else if (userChoice == 18)
            {
                foreach (Weapon weapon in currentPlayer.InventoryWeapons)
                {
                    Console.WriteLine(weapon);
                }
                Console.ReadKey();
            }
            else if (userChoice == 19)
            {
                foreach (Armor armor in currentPlayer.InventoryArmors)
                {
                    Console.WriteLine(armor);
                }
                Console.ReadKey();
            }
            else if (userChoice == 20)
            {
                foreach (Potion potion in currentPlayer.InventoryPotions)
                {
                    Console.WriteLine(potion);
                }
                Console.ReadKey();
            }
            else if (userChoice == 21)
            {
                exitViewInventory = true;
            }
            else
            {
                Console.ReadKey();
            }
        } while (!exitViewInventory);
    }
    public static void EquipItemMenu()
    {
        if(currentPlayer.DoIHaveArmors() && currentPlayer.DoIHaveWeapons())
        {

        }
        else if(currentPlayer.DoIHaveArmors())
        {
            bool newArmorEquipped = false;
            do
            {
            Console.Clear();
            Console.WriteLine($"You are currently wearing {currentPlayer.EquippedArmor.ItemName} which absorbs {currentPlayer.EquippedArmor.MitigationIncrease} damage.");
            for(int i = 0; i < currentPlayer.InventoryArmors.Count(); i++)
            {
                Console.WriteLine($"{i}: {currentPlayer.InventoryArmors[i].EquipOption()}");
            }
            Console.WriteLine("Which armor would you like to equip?");
            try
            {

            }
            catch (Exception e)
            {

            }
            }while(!newArmorEquipped);

        }
        else
        {

        }
    }
}




