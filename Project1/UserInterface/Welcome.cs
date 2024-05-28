using System;
using Project1;
using Project1.Controllers;
using Project1.Models;
namespace Project1.UserInterfaces;

public static class WelcomeToTheGame
{
    public static void Start()
    {
        string menuChoice;
        int menuSelection;
        bool validInput = false;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(".");
        //Load monster reference data from data source
        GameSession.monsterReference = MonsterController.InitializeMonsterInfo();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("....");
        //Load location data from data source
        GameSession.locationReference = LocationController.InitializeLocations();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("...........");
        //Load level up information from data source
         GameSession.levelReference = PlayerController.InitializeLevelInfo();
        //Load full map data from data source
        GameSession.gameMap = MapController.LoadFullMap();
        //Load all items from data source
        GameSession.itemsReference = ItemController.GetAllGameItems();
        GameSession.randomMessages = RandomTextController.GetRandomText();
        do
        {
            SplashScreens.MainMenuDisplay();
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
                            validInput = MainControlMenu();
                        }
                        else
                        {
                            validInput = false;
                        }
                        break;
                    case 2:
                        CreateNewPlayerMenu();
                        validInput = MainControlMenu();
                        break;
                    case 3:
                        return;
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
            SplashScreens.LoginDisplay();
            Console.Write("Name:");
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
                GameSession.currentPlayer = PlayerController.LoadExistingCharacter(userInput);
                if (GameSession.currentPlayer == null)
                {
                    Console.WriteLine("Yeah... I don't know you or you spelled your own name wrong.\nI really hope it's the first one.");
                    Console.WriteLine("If you made a mistake and meant to create a new character,\nenter oops to return to the main menu.");
                    Console.WriteLine("Press any key to try again...");
                    exitCondition = false;
                }
                else
                {
                    GameSession.displayMap = MapController.MatchDisplayMapToPlayerMap();
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
        SplashScreens.NewPlayerDisplay();
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
                Console.WriteLine($"There is already a player called {newPlayerName}.\nUnfortunately, we can only have one of those so you'll have to choose another name.");
            }
            else
            {
                validInput = true;
            }
        } while (!validInput);

        GameSession.currentPlayer = PlayerController.CreateNewPlayer(newPlayerName);
        GameSession.displayMap = MapController.MatchDisplayMapToPlayerMap();
        Console.Clear();
        Console.WriteLine(GameSession.currentPlayer.ToString(PlayerController.GetXPRequirementFromDictionary().ToString()));
        Console.WriteLine($"No, you don't have Intelligence, Wisdom, or Charisma stats. You won't need them.");
        Console.WriteLine("I know that was a lot to get through, so let's get to the game already.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Just kidding!  We should probably quickly go over the basics.");
        Console.WriteLine("Press any key to view the Help documentation...");
        Console.ReadKey();
        SplashScreens.HelpMenu();

    }
    public static bool MainControlMenu()
    {
        bool exitGame = false;
        int playerAction;
        int monsterSpawn = 0;
        bool amIDead = false;
        do
        {
            playerAction = DisplayCurrentLocation();
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
                    if (Movement.CanIMoveThisWay(playerAction))
                    {

                        GameSession.currentPlayer.TimeToMove(playerAction);
                        monsterSpawn = LocationController.DoesMonsterSpawn();
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
                    monsterSpawn = GameSession.currentPlayer.Rest();
                    if (monsterSpawn == 0)
                    {
                        SplashScreens.RestMenu();
                    }
                    else
                    {
                        Console.WriteLine("You settle down to rest and tend to your wounds. But...");
                        amIDead = TimeForAFight(monsterSpawn);
                    }
                    break;
                case 6:
                    //save
                    PlayerController.SavePlayer(GameSession.currentPlayer);
                    Console.WriteLine("Your character has been saved.");
                    Console.WriteLine("Press any key to continue your adventure...");
                    Console.ReadKey();
                    break;
                case 7:
                    return true;
                case 11:
                    SplashScreens.HelpMenu();
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
            SplashScreens.GameOver();
            return false;
        }
        return true;
    }
    public static int DisplayCurrentLocation()
    {
        Location currentLocation = GameSession.locationReference[GameSession.currentPlayer.CurrentLocation];
        bool exitCurrentRoom = false;
        int userChoice;
        ConsoleKeyInfo keyPress;
        do
        {
            Console.Clear();
            MapController.UpdateMap();
            if (GameSession.currentPlayer.CurrentLocation == 101805)
            {
                TownMenu();
                Console.Clear();
            }
            for (int i = 0; i < 17; i++)
            {
                Console.WriteLine(currentLocation.LocationDisplay[i] + "     " + GameSession.displayMap[i]);
            }
            Console.WriteLine($"\nCurrent Location: {currentLocation.RoomName}");
            if (currentLocation.RoomHash != 112804 && currentLocation.RoomHash != 112805)
            {
                Console.WriteLine(currentLocation.RoomDescription);
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): {(MoveDirection)currentLocation.EnumMovementOptions}");
            }
            else if (GameSession.currentPlayer.PlayerLevel >= 10 && currentLocation.RoomHash == 112804)
            {
                Console.WriteLine("There is a mysterious door to the south and it appears to be slightly ajar.");
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): {(MoveDirection)currentLocation.EnumMovementOptions}");
            }
            else if (currentLocation.RoomHash == 112805)
            {
                Console.WriteLine(currentLocation.RoomDescription);
                return BossFight();
            }
            else
            {
                Console.WriteLine(currentLocation.RoomDescription);
                Console.WriteLine($"\n\n\nYou can travel in the following direction(s): North");
            }
            if (GameSession.currentPlayer.DoIHavePotions())
            {
                Console.WriteLine($"\n<C>haracter\t\t<I>nventory\t\t<R>est\t\t<D>rink Potion\t\tSa<v>e\t\tE<x>it\t\t<H>elp");
            }
            else
            {
                Console.WriteLine($"\n<C>haracter\t\t<I>nventory\t\t<R>est\t\tSa<v>e\t\tE<x>it\t\t<H>elp");
            }
            keyPress = Console.ReadKey(true);
            string userInput = keyPress.Key.ToString();
            userChoice = InputController.OutOfCombatInput(userInput);
            if (userChoice == 17 && GameSession.currentPlayer.DoIHavePotions())
            {
                Potion drinkThis = PotionMenu();
                if (drinkThis.ItemID == "potion0")
                {
                    userChoice = 0;
                    Console.WriteLine("Well fine. Don't drink a potion then...");
                    Console.ReadKey();
                }
                else
                {
                    GameSession.currentPlayer.DrinkPotion(drinkThis);
                    Console.WriteLine($"You drink a {drinkThis.ItemName}. Current HP: {GameSession.currentPlayer.CurrentHitPoints}.");
                    Console.ReadKey();
                }
            }
            else if (userChoice != 0)
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
    public static bool TimeForAFight(int monsterSpawn)
    {
        Monster currentMonster = new Monster(GameSession.monsterReference[monsterSpawn]);
        bool isSomeoneDead = false;
        bool playerRanAway = false;
        string userInput;
        int userChoice;
        int playerAttack;
        int monsterAttack;
        bool amIDead = false;
        bool leveledUp = false;
        ConsoleKeyInfo keyPress;
        Console.WriteLine($"You have encountered a {currentMonster.Name}!");
        Console.WriteLine("Press any key to start the fight...");
        Console.ReadKey();
        do
        {
            Console.Clear();
            currentMonster.DisplayMonster();
            if (GameSession.currentPlayer.DoIHavePotions())
            {
                Console.WriteLine("\n\nDo you want to <A>ttack <F>lee or <D>rink a potion\t\t<H>elp");
            }
            else
            {
                Console.WriteLine("\n\nDo you want to <A>ttack or <F>lee\t\t<H>elp");
            }
            keyPress = Console.ReadKey(true);
            userInput = keyPress.Key.ToString();
            userChoice = InputController.InCombatInput(userInput);
            if (userChoice == 9)
            {
                playerAttack = CombatController.PlayerAttacksMonster(ref currentMonster);
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
                SplashScreens.HelpMenu();
            }
            else if (userChoice == 17 && GameSession.currentPlayer.DoIHavePotions())
            {
                Potion drinkThis = PotionMenu();
                if (drinkThis.ItemID == "potion0")
                {
                    userChoice = 0;
                    Console.WriteLine("Well fine. Don't drink a potion then...");
                    Console.ReadKey();
                }
                else
                {
                    GameSession.currentPlayer.DrinkPotion(drinkThis);
                    Console.WriteLine($"You drink a {drinkThis.ItemName}. Current HP: {GameSession.currentPlayer.CurrentHitPoints}.");
                    Console.ReadKey();
                }
            }
            else if (userChoice == 17 && !GameSession.currentPlayer.DoIHavePotions())
            {
                userChoice = 0;
            }
            else if (userChoice == 0)
            {
                Console.ReadKey();
            }
            if (currentMonster.CurrentHitPoints > 0 && !playerRanAway && userChoice != 0 && userChoice != 11)
            {
                monsterAttack = CombatController.MonsterAttacksPlayer(ref currentMonster);
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
                if (GameSession.currentPlayer.CurrentHitPoints <= 0)
                {
                    isSomeoneDead = true;
                }
            }
            else if (!playerRanAway && userChoice != 0 && userChoice != 11)
            {
                Console.WriteLine($"You have slain {currentMonster.Name}!");
                Console.WriteLine(GameSession.randomMessages.GetChatter(currentMonster.MonsterID));
                Console.ReadKey();
                isSomeoneDead = true;
            }
        } while (!isSomeoneDead && !playerRanAway);
        if (GameSession.currentPlayer.CurrentHitPoints <= 0 && isSomeoneDead)
        {
            Console.WriteLine("You have died.  Better luck next time.");
            Console.ReadKey();
            return true;
        }
        else if (isSomeoneDead)
        {
            //Congrats on killing monster (random responses eventually)
            //if you're max level (20) you get no xp
            if (GameSession.currentPlayer.PlayerLevel < 20)
            {
                //code to notify user of rewards from monster
                Console.WriteLine($"You have gained {currentMonster.RewardXP} experience for killing {currentMonster.Name}.");
                //check if player gained a level and, if so, increase stats
                if (GameSession.currentPlayer.PlayerXP >= PlayerController.GetXPRequirementFromDictionary())
                {
                    GameSession.currentPlayer.Ding(GameSession.levelReference[GameSession.currentPlayer.PlayerLevel + 1]);
                    Console.WriteLine($"Congratulations! You have reached level {GameSession.currentPlayer.PlayerLevel}!");
                    leveledUp = true;
                }
            }
            else
            {
                Console.WriteLine($"You have gained 0 experience for killing {currentMonster.Name}. You are at max level.");
            }
            string monsterLoot = currentMonster.LootDrop();
            if (monsterLoot != "No loot" && currentMonster.RewardGold == 0)
            {
                Console.WriteLine($"Digging around the corpse of the {currentMonster.Name}, you find 1 {GameSession.itemsReference[monsterLoot].ItemName}.");
                GameSession.currentPlayer.GetThatLoot(GameSession.itemsReference[monsterLoot]);
            }
            else if (monsterLoot != "No loot")
            {
                Console.WriteLine($"Digging around the corpse of the {currentMonster.Name}, you find {currentMonster.RewardGold} gold coins.");
                Console.WriteLine($"You also find 1 {GameSession.itemsReference[monsterLoot].ItemName}.");
                GameSession.currentPlayer.GetThatLoot(GameSession.itemsReference[monsterLoot]);
            }
            else if (currentMonster.RewardGold > 0)
            {
                Console.WriteLine($"Digging around the corpse of the {currentMonster.Name}, you find {currentMonster.RewardGold} gold coins.");
            }
            Console.ReadKey();
            if (leveledUp) { DisplayCharacter(); }
        }
        else
        {
            Console.WriteLine("Cheese it!!");
            Console.ReadKey();
        }
        return amIDead;
    }
    public static int BossFight()
    {
        int turnCounter = 0;
        bool isSomeoneDead = false;
        int playerAttack;
        int monsterAttack;
        Monster bossMonster = new Monster(GameSession.monsterReference[1941]);
        Location currentLocation = GameSession.locationReference[112805];
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
                    Console.WriteLine($"{bossMonster.MonsterDisplay[i]}" + String.Format("{0,20}{1,40}", bossMonster.Name, GameSession.currentPlayer.Name));
                }
                else if (i == 1)
                {
                    string monsterHP = $"HP: {bossMonster.CurrentHitPoints}/{bossMonster.MaxHitPoints}";
                    string playerHP = $"HP: {GameSession.currentPlayer.CurrentHitPoints}/{GameSession.currentPlayer.MaxHitPoints}";
                    Console.WriteLine($"{bossMonster.MonsterDisplay[i]}" + String.Format("{0,20}{1,40}", monsterHP, playerHP));
                }
                else
                {
                    Console.WriteLine(bossMonster.MonsterDisplay[i]);
                }
            }
            Console.ResetColor();
            Console.WriteLine($"There is nowhere to run and no time for a potion. Press any key to attack the {bossMonster.Name}.");
            Console.ReadKey();
            playerAttack = CombatController.PlayerAttacksMonster(ref bossMonster);
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
                monsterAttack = CombatController.MonsterAttacksPlayer(ref bossMonster);
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
                if (GameSession.currentPlayer.CurrentHitPoints <= 0)
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
            SplashScreens.VictoryMenu();
            return 7;
        }

    }
    public static void DisplayCharacter()
    {
        Console.Clear();
        if (GameSession.currentPlayer.PlayerLevel < 20)
        {
            Console.WriteLine(GameSession.currentPlayer.ToString(PlayerController.GetXPRequirementFromDictionary().ToString()));
        }
        else
        {
            Console.WriteLine(GameSession.currentPlayer.ToString("Max Level Reached!"));
        }
        Console.ReadKey();
    }
    public static void TownMenu()
    {
        Location currentLocation = GameSession.locationReference[GameSession.currentPlayer.CurrentLocation];
        bool exitTown = false;
        do
        {
            Console.Clear();
            for (int i = 0; i < 17; i++)
            {
                Console.WriteLine(currentLocation.LocationDisplay[i]);
            }
            Console.WriteLine($"\nCurrent Location: {currentLocation.RoomName}");
            Console.WriteLine("You have entered the village of CleverMadeUpName");
            Console.WriteLine(currentLocation.RoomDescription);
            Console.WriteLine("\nWhere would you like to go?");
            Console.WriteLine("<D>ancing Dragon Inn\t\t<P>otion vendor\t\t<A>rms Merchant\t\t<L>eave Town\t\t<H>elp");
            ConsoleKeyInfo keyPress = Console.ReadKey(true);
            string userInput = keyPress.Key.ToString();
            int userChoice = InputController.TownInput(userInput);
            switch (userChoice)
            {
                case 1:
                    InnMenu();
                    break;
                case 2:
                    VendorMenu();
                    break;
                case 3:
                    ArmsMerchantMenu();
                    break;
                case 4:
                    exitTown = true;
                    break;
                case 5:
                    SplashScreens.HelpMenu();
                    break;
                default:
                    Console.ReadKey();
                    break;
            }
        } while (!exitTown);
    }
    public static void InnMenu()
    {
        //Draw an interior picture for the Inn
        bool exitTheInn = false;
        do
        {
            Console.Clear();
            SplashScreens.DrawMeAPicture("tapRoom");
            Console.WriteLine("You're in the Dancing Dragon Inn. For a small village, there are quite a few patrons.");
            if (GameSession.currentPlayer.PlayerGold < 1)
            {
                Console.WriteLine("You don't have any gold to spend. Press any key to return to town...");
                Console.ReadKey();
                exitTheInn = true;
            }
            else
            {
                if (GameSession.currentPlayer.PlayerGold >= 1 && GameSession.currentPlayer.PlayerGold < 5)
                {
                    Console.WriteLine("<B>elly up to the bar for a drink (1 gold piece)  Can't afford a room (5 gold pieces)  <E>xit the Inn");
                }
                else
                {
                    Console.WriteLine("<B>elly up to the bar for a drink (1 gold piece)  <R>ent a room for the night (5 gold pieces)  E<x>it the Inn");
                }
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                string userInput = keyPress.Key.ToString();
                int userChoice = InputController.InnInput(userInput);
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("You pull up to the bar and order a mug of ale.");
                        Console.WriteLine("While nursing your drink, you overhear chatter from the other patrons.");
                        Console.WriteLine(GameSession.randomMessages.GetChatter());
                        GameSession.currentPlayer.PlayerGold -= 1;
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You go upstairs for a much needed bath");
                        SplashScreens.DrawMeAPicture("bathTime");
                        Thread.Sleep(3000);
                        Console.Clear();
                        GameSession.currentPlayer.RestInTheInn();
                        Console.WriteLine("Then settle into your cot for a restful night of sleep");
                        //Different rest picture than the campfire. Maybe a bed or candle something?
                        Console.ReadKey();
                        break;
                    case 3:
                        exitTheInn = true;
                        break;
                    case 0:
                        Console.ReadKey();
                        break;
                }
            }
        } while (!exitTheInn);
    }
    public static void VendorMenu()
    {
        //Maybe draw a picture of the potion vendor. Street cart with a guy there?
        bool exitTheVendor = false;
        do
        {
            Console.Clear();
            SplashScreens.DrawMeAPicture("vendor");
            Console.WriteLine("You walk over to the vendor's cart to have a look.");
            Console.WriteLine("Potion Vendor: Hello there! What can I interest you in today?");
            Console.WriteLine("<B>uy potions  <S>ell potions  Sell <I>tems  <R>eturn to village square.");
            ConsoleKeyInfo keyPress = Console.ReadKey(true);
            string userInput = keyPress.Key.ToString();
            int userChoice = InputController.VendorInput(userInput);
            if (userChoice == 1)
            {
                if (GameSession.currentPlayer.PlayerGold < 2)
                {
                    Console.WriteLine("You don't have enough gold to buy anything. Press any key...");
                    Console.ReadKey();
                }
                else
                {
                    BuySomethingMenu(1);
                }
            }
            else if (userChoice == 2)
            {
                SellSomethingMenu(1);
            }
            else if (userChoice == 3)
            {
                SellSomethingMenu(4);
            }
            else if (userChoice == 4)
            {
                exitTheVendor = true;
            }
            else
            {
                Console.ReadKey();
            }
        } while (!exitTheVendor);
    }
    public static void ArmsMerchantMenu()
    {
        //Maybe draw a picture of a Weapons and Armor shop counter with stuff on the walls behind it for this
        bool exitTheMerchant = false;
        do
        {
            Console.Clear();
            SplashScreens.DrawMeAPicture("merchant");
            Console.WriteLine("You enter the shop and the merchant comes over to assist you.");
            Console.WriteLine("Arms Merchant: Welcome to my shop. How can I help you today?");
            Console.WriteLine("Buy <W>eapons  Buy <A>rmor  <S>ell Weapons  Se<l>l Armor  <R>eturn to village square.");
            ConsoleKeyInfo keyPress = Console.ReadKey(true);
            string userInput = keyPress.Key.ToString();
            int userChoice = InputController.MerchantInput(userInput);
            if (userChoice == 1)
            {
                if (GameSession.currentPlayer.PlayerGold < 10 || GameSession.currentPlayer.PlayerLevel < 3)
                {
                    Console.WriteLine("I don't have any weapons to sell you that you can use and afford.\nCome back when you have more money or are higher level.");
                    Console.ReadKey();
                }
                else
                {
                    BuySomethingMenu(2);
                }
            }
            else if (userChoice == 2)
            {
                if (GameSession.currentPlayer.PlayerGold < 5)
                {
                    Console.WriteLine("You don't have enough gold to buy anything. Press any key...");
                    Console.ReadKey();
                }
                else
                {
                    BuySomethingMenu(3);
                }
            }
            else if (userChoice == 3)
            {
                SellSomethingMenu(2);
            }
            else if (userChoice == 4)
            {
                SellSomethingMenu(3);
            }
            else if (userChoice == 5)
            {
                exitTheMerchant = true;
            }
            else
            {

            }
        } while (!exitTheMerchant);
    }
    public static void InventoryMenu()
    {
        //Draw a picture for base inventory
        bool iMDone = false;
        if (GameSession.currentPlayer.DoIHaveStuff())
        {
            do
            {
                Console.Clear();
                SplashScreens.DrawMeAPicture("randomStuffGo");
                Console.WriteLine("Would you like to <B>rowse your inventory or E<q>uip an item? <D> when done.");
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                string userInput = keyPress.Key.ToString();
                int userChoice = InputController.InventoryInput(userInput);
                if (userChoice == 12)
                {
                    ViewInventoryMenu();
                }
                else if (userChoice == 13)
                {
                    if (!GameSession.currentPlayer.DoIHaveArmors() && !GameSession.currentPlayer.DoIHaveWeapons())
                    {
                        Console.WriteLine("Nothing to equip. Go find some.");
                        Console.ReadKey();
                    }
                    else
                    {
                        EquipMenu();
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
        //Probably use the same picture as base inventory
        bool exitViewInventory = false;
        do
        {
            Console.Clear();
            SplashScreens.DrawMeAPicture("randomStuffGo");
            Console.WriteLine("What kind of items would you like to look at? <D> when done.");
            Console.WriteLine(GameSession.currentPlayer.KindsOfStuffIHave());
            ConsoleKeyInfo keyPress = Console.ReadKey(true);
            string userInput = keyPress.Key.ToString();
            int userChoice = InputController.InventoryInput(userInput);
            if (userChoice == 21)
            {
                exitViewInventory = true;
            }
            else
            {
                if (userChoice == 17 || userChoice == 16)
                {
                    foreach (PlayerInventoryItem item in GameSession.currentPlayer.InventoryItems)
                    {
                        Item tempItem = GameSession.itemsReference[item.ItemID];
                        tempItem.QuantityOfItem = item.playerQuantity;
                        Console.WriteLine(tempItem);
                    }
                    // if (userChoice != 16) { Console.ReadKey(); }
                }
                if (userChoice == 18 || userChoice == 16)
                {
                    foreach (PlayerInventoryWeapon weapon in GameSession.currentPlayer.InventoryWeapons)
                    {
                        Weapon tempWeapon = (Weapon)GameSession.itemsReference[weapon.WeaponID];
                        tempWeapon.QuantityOfItem = weapon.playerQuantity;
                        Console.WriteLine(tempWeapon);
                    }
                    // if (userChoice != 16) { Console.ReadKey(); }
                }
                if (userChoice == 19 || userChoice == 16)
                {
                    foreach (PlayerInventoryArmor armor in GameSession.currentPlayer.InventoryArmors)
                    {
                        Armor tempArmor = (Armor)GameSession.itemsReference[armor.ArmorID];
                        tempArmor.QuantityOfItem = armor.playerQuantity;
                        Console.WriteLine(tempArmor);
                    }
                    //if (userChoice != 16) { Console.ReadKey(); }
                }
                if (userChoice == 20 || userChoice == 16)
                {
                    foreach (PlayerInventoryPotion potion in GameSession.currentPlayer.InventoryPotions)
                    {
                        Potion tempPotion = (Potion)GameSession.itemsReference[potion.PotionID];
                        tempPotion.QuantityOfItem = potion.playerQuantity;
                        Console.WriteLine(tempPotion);
                    }
                    //Console.ReadKey();
                }
                Console.ReadKey();
            }
        } while (!exitViewInventory);
    }
    public static void EquipMenu()
    {
        //Maybe draw a picture of weapons and/or armor based on what options the user has
        if (GameSession.currentPlayer.DoIHaveArmors() && GameSession.currentPlayer.DoIHaveWeapons())
        {
            bool pickedWhatToEquip = false;
            do
            {
                Console.Clear();
                SplashScreens.DrawMeAPicture("swordAndShield");
                Console.WriteLine("Would you like to equip a new <W>eapon or <A>rmor? <D>one to exit menu.");
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                string userInput = keyPress.Key.ToString();
                int userChoice = InputController.EquipInput(userInput);
                if (userChoice == 1)
                {
                    EquipArmorMenu();
                    pickedWhatToEquip = false;
                }
                else if (userChoice == 2)
                {
                    EquipWeaponMenu();
                    pickedWhatToEquip = false;
                }
                else if (userChoice == 3)
                {
                    pickedWhatToEquip = true;
                }
                else
                {
                    pickedWhatToEquip = false;
                }

            } while (!pickedWhatToEquip);
        }
        else if (GameSession.currentPlayer.DoIHaveArmors())
        {
            EquipArmorMenu();
        }
        else
        {
            EquipWeaponMenu();
        }
    }
    public static void EquipArmorMenu()
    {
        //Maybe display an image of just Armor stuffs
        bool newArmorEquipped = false;
        do
        {
            Console.Clear();
            SplashScreens.DrawMeAPicture("swordAndShield");
            Console.WriteLine($"You are currently wearing {GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID].ItemName} which absorbs {((Armor)GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID]).MitigationIncrease} damage.");
            for (int i = 0; i < GameSession.currentPlayer.InventoryArmors.Count(); i++)
            {
                Armor armorOption = (Armor)GameSession.itemsReference[GameSession.currentPlayer.InventoryArmors[i].ArmorID];
                Console.WriteLine($"{i + 1}: {armorOption.EquipOption()}");
            }
            Console.WriteLine($"{GameSession.currentPlayer.InventoryArmors.Count() + 1}: Don't change equipped armor");
            Console.WriteLine("Which armor would you like to equip?");
            try
            {
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                string keyPressString = keyPress.Key.ToString();
                int armorChoice = Convert.ToInt32(keyPressString.Substring(1, keyPressString.Count() - 1));
                if (armorChoice == GameSession.currentPlayer.InventoryArmors.Count() + 1)
                {
                    newArmorEquipped = true;
                }
                else if (armorChoice > GameSession.currentPlayer.InventoryArmors.Count() + 1 || armorChoice < 1)
                {
                    Console.WriteLine("I put numbers next to your choices for a reason... pick one of those.");
                    Console.ReadKey();
                }
                else
                {
                    Armor armorOption = (Armor)GameSession.itemsReference[GameSession.currentPlayer.InventoryArmors[armorChoice - 1].ArmorID];
                    GameSession.currentPlayer.EquipArmor(armorOption);
                    newArmorEquipped = true;
                    Console.Clear();
                    Console.WriteLine($"{GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID].ItemName} equipped!");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("I put numbers next to your choices for a reason... pick one of those.");
                Console.ReadKey();
                newArmorEquipped = false;
            }
        } while (!newArmorEquipped);
    }
    public static void EquipWeaponMenu()
    {
        //Maybe display and image of just weapon stuffs
        bool newWeaponEquipped = false;
        do
        {
            Console.Clear();
            SplashScreens.DrawMeAPicture("swordAndShield");
            Console.WriteLine($"You are currently wielding {GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID].ItemName} which does {((Weapon)GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID]).AttackIncrease} extra damage.");
            for (int i = 0; i < GameSession.currentPlayer.InventoryWeapons.Count(); i++)
            {
                Weapon weaponOption = (Weapon)GameSession.itemsReference[GameSession.currentPlayer.InventoryWeapons[i].WeaponID];
                Console.WriteLine($"{i + 1}: {weaponOption.EquipOption()}");
            }
            Console.WriteLine($"{GameSession.currentPlayer.InventoryWeapons.Count() + 1}: Don't change equipped weapon");
            Console.WriteLine("Which weapon would you like to equip?");
            try
            {
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                string keyPressString = keyPress.Key.ToString();
                int weaponChoice = Convert.ToInt32(keyPressString.Substring(1, keyPressString.Count() - 1));
                if (weaponChoice == GameSession.currentPlayer.InventoryWeapons.Count() + 1)
                {
                    newWeaponEquipped = true;
                }
                else if (weaponChoice > GameSession.currentPlayer.InventoryWeapons.Count() + 1 || weaponChoice < 1)
                {
                    Console.WriteLine("I put numbers next to your choices for a reason... pick one of those.");
                    Console.ReadKey();
                }
                else
                {
                    Weapon weaponOption = (Weapon)GameSession.itemsReference[GameSession.currentPlayer.InventoryWeapons[weaponChoice - 1].WeaponID];
                    GameSession.currentPlayer.EquipWeapon(weaponOption);
                    newWeaponEquipped = true;
                    Console.WriteLine($"{GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID].ItemName} equipped!");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("I put numbers next to your choices for a reason... pick one of those.");
                Console.ReadKey();
                newWeaponEquipped = false;
            }
        } while (!newWeaponEquipped);
    }
    public static Potion PotionMenu()
    {
        bool potionDrank = false;
        Potion potionPicked = new Potion();
        SplashScreens.DrawMeAPicture("potions");
        Console.WriteLine("Which potion would you like to use?");
        for (int i = 0; i < GameSession.currentPlayer.InventoryPotions.Count(); i++)
        {
            Potion tempPotion = (Potion)GameSession.itemsReference[GameSession.currentPlayer.InventoryPotions[i].PotionID];
            Console.WriteLine($"{i + 1}: {tempPotion}");
        }
        Console.WriteLine($"{GameSession.currentPlayer.InventoryPotions.Count() + 1}: Don't drink a potion");
        do
        {
            ConsoleKeyInfo keyPress = Console.ReadKey(true);
            string keyPressString = keyPress.Key.ToString();
            int potionChoice = Convert.ToInt32(keyPressString.Substring(1, keyPressString.Count() - 1));
            if (potionChoice == GameSession.currentPlayer.InventoryPotions.Count() + 1)
            {
                return potionPicked;
            }
            else if (potionChoice > GameSession.currentPlayer.InventoryPotions.Count() + 1 || potionChoice < 1)
            {
                Console.WriteLine("That wasn't an option. Pick an option or don't drink one.");
                potionDrank = false;
            }
            else
            {
                potionPicked.CreateCopyOf((Potion)GameSession.itemsReference[GameSession.currentPlayer.InventoryPotions[potionChoice - 1].PotionID]);
                return potionPicked;
            }
        } while (!potionDrank);
        return potionPicked;

    }
    public static void BuySomethingMenu(int buyOption)
    {
        bool exitShop = false;
        bool gotAQuantityICanAfford = false;
        List<Item> saleOptions = ItemController.GetItemsForSale(buyOption);
        do
        {
            Console.Clear();
            if (saleOptions.Count() < 1)
            {
                Console.WriteLine("Sorry, I don't have anything I can sell to you. Try checking again when you're stronger.");
                Console.ReadKey();
                exitShop = true;
            }
            else
            {
                Console.WriteLine($"You currently have {GameSession.currentPlayer.PlayerGold} gold pieces.");
                if (buyOption == 2) { Console.WriteLine($"You are using {GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID].ItemName} which increases attack by {((Weapon)GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID]).AttackIncrease}."); }
                if (buyOption == 3) { Console.WriteLine($"You are using {GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID].ItemName} which absorbs {((Armor)GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID]).MitigationIncrease} damage."); }
                Console.WriteLine("\nWhat would you like to purchase?");

                Console.WriteLine(" ___________________________________________________________");
                Console.WriteLine("/   |                             |                 |       \\");
                if (buyOption == 1) { Console.WriteLine("| # |        Potion Name          |   HP Restored   | Cost  |"); }
                if (buyOption == 2) { Console.WriteLine("| # |        Weapon Name          |   Attack Incr   | Cost  |"); }
                if (buyOption == 3) { Console.WriteLine("| # |         Armor Name          |   Absorb Dmg    | Cost  |"); }
                Console.WriteLine("|___|_____________________________|_________________|_______|");
                Console.WriteLine("|   |                             |                 |       |");
                for (int i = 0; i < saleOptions.Count(); i++)
                {
                    Console.WriteLine($"| {i + 1} |{saleOptions[i].VendorSellingDisplay()}");
                }
                Console.WriteLine("|---|-----------------------------|-----------------|-------|");
                Console.WriteLine($"| {saleOptions.Count() + 1} | Leave without purchase      |                 |       |");
                Console.WriteLine("\\___|_____________________________|_________________|_______/");
                try
                {
                    ConsoleKeyInfo keyPress = Console.ReadKey(true);
                    string keyPressString = keyPress.Key.ToString();
                    int userChoice = Convert.ToInt32(keyPressString.Substring(1, keyPressString.Count() - 1));
                    if (userChoice == saleOptions.Count() + 1)
                    {
                        exitShop = true;
                    }
                    else if (userChoice > saleOptions.Count() + 1 || userChoice < 1)
                    {
                        Console.WriteLine("That wasn't an option. Please choose one of the displayed numbers.");
                        Console.ReadKey();
                        exitShop = false;
                    }
                    else
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"You currently have {GameSession.currentPlayer.PlayerGold} gold pieces.");
                            Console.WriteLine($"How many {saleOptions[userChoice - 1].ItemName} would you like to buy?");
                            string userInput = (Console.ReadLine() ?? "").Trim();
                            int numToBuy = InputController.NeedAnIntegerFromUser(userInput);
                            if (numToBuy == -1)
                            {
                                Console.ReadKey();
                            }
                            else
                            {
                                if (GameSession.currentPlayer.PlayerGold < saleOptions[userChoice - 1].ItemBaseValue * numToBuy)
                                {
                                    Console.WriteLine("You can't afford that many. Pick a lower number.");
                                    Console.ReadKey();
                                    gotAQuantityICanAfford = false;
                                }
                                else
                                {
                                    switch (buyOption)
                                    {
                                        case 1:
                                            Potion potionToBuy = new();
                                            potionToBuy.CreateCopyOf((Potion)saleOptions[userChoice - 1], numToBuy);
                                            GameSession.currentPlayer.BuySomething(buyOption, potionToBuy);
                                            break;
                                        case 2:
                                            Weapon weaponToBuy = new();
                                            weaponToBuy.CopyFromOtherWeapon((Weapon)saleOptions[userChoice - 1], numToBuy);
                                            GameSession.currentPlayer.BuySomething(buyOption, weaponToBuy);
                                            break;
                                        case 3:
                                            Armor armorToBuy = new();
                                            armorToBuy.CopyFromOtherArmor((Armor)saleOptions[userChoice - 1], numToBuy);
                                            GameSession.currentPlayer.BuySomething(buyOption, armorToBuy);
                                            break;
                                    }
                                    gotAQuantityICanAfford = true;
                                }
                            }
                        } while (!gotAQuantityICanAfford);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("I didn't understand what you wanted. Please try again using one of the displayed number options.");
                    Console.ReadKey();
                    exitShop = false;
                }

            }
        } while (!exitShop);
    }
    public static void SellSomethingMenu(int sellOption)
    {
        bool exitMerchant = false;
        bool gotAQuantityICanSell = false;
        List<Item> itemsToSell = new();
        do
        {
            itemsToSell.Clear();
            itemsToSell = GameSession.currentPlayer.GetStuffToSell(sellOption);
            Console.Clear();
            if (itemsToSell.Count() < 1)
            {
                Console.WriteLine("Nothing to sell. Go get some stuff!");
                Console.ReadKey();
                exitMerchant = true;
            }
            else
            {
                Console.WriteLine($"You currently have {GameSession.currentPlayer.PlayerGold} gold pieces.");
                if (sellOption == 2) { Console.WriteLine($"You are using {GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID].ItemName} which increases attack by {((Weapon)GameSession.itemsReference[GameSession.currentPlayer.EquippedWeaponID]).AttackIncrease}."); }
                if (sellOption == 3) { Console.WriteLine($"You are using {GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID].ItemName} which absorbs {((Armor)GameSession.itemsReference[GameSession.currentPlayer.EquippedArmorID]).MitigationIncrease} damage."); }
                Console.WriteLine("\nWhat would you like to sell?");

                Console.WriteLine(" __________________________________________________________________");
                Console.WriteLine("/    |     |                             |                 |       \\");
                if (sellOption == 1) { Console.WriteLine("| #  | Qty |        Potion Name          |   HP Restored   | Value |"); }
                if (sellOption == 2) { Console.WriteLine("| #  | Qty |        Weapon Name          |   Attack Incr   | Value |"); }
                if (sellOption == 3) { Console.WriteLine("| #  | Qty |         Armor Name          |   Absorb Dmg    | Value |"); }
                if (sellOption == 4) { Console.WriteLine("| #  | Qty |         Item Name           |                 | Value |"); }
                Console.WriteLine("|____|_____|_____________________________|_________________|_______|");
                Console.WriteLine("|    |     |                             |                 |       |");
                for (int i = 0; i < itemsToSell.Count(); i++)
                {
                    if (i < 9)
                    {
                        Console.WriteLine($"|  {i + 1} |{itemsToSell[i].PlayerSellingDisplay()}");
                    }
                    else
                    {
                        Console.WriteLine($"| {i + 1} |{itemsToSell[i].PlayerSellingDisplay()}");
                    }
                }
                Console.WriteLine("|----|-----|-----------------------------|-----------------|-------|");
                if (itemsToSell.Count() < 9)
                {
                    Console.WriteLine($"|  {itemsToSell.Count() + 1} |     | Leave without selling       |                 |       |");
                }
                else
                {
                    Console.WriteLine($"| {itemsToSell.Count() + 1} |     | Leave without selling       |                 |       |");
                }
                Console.WriteLine("\\____|_____|_____________________________|_________________|_______/");
                try
                {
                    //ConsoleKeyInfo keyPress = Console.ReadKey(true);
                    string keyPressString = (Console.ReadLine() ?? "").Trim();
                    int userChoice = Convert.ToInt32(keyPressString);
                    if (userChoice == itemsToSell.Count() + 1)
                    {
                        exitMerchant = true;
                    }
                    else if (userChoice > itemsToSell.Count() + 1 || userChoice < 1)
                    {
                        Console.WriteLine("That wasn't an option. Please choose one of the displayed numbers.");
                        Console.ReadKey();
                        exitMerchant = false;
                    }
                    else
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"You currently have {GameSession.currentPlayer.PlayerGold} gold pieces.");
                            Console.WriteLine($"You have {itemsToSell[userChoice - 1].QuantityOfItem} to sell.");
                            Console.WriteLine($"How many would you like to sell for {itemsToSell[userChoice - 1].ItemBaseValue / 3} GP each?");
                            string userInput = (Console.ReadLine() ?? "").Trim();
                            int numToSell = InputController.NeedAnIntegerFromUser(userInput);
                            if (numToSell == -1)
                            {
                                Console.ReadKey();
                            }
                            else
                            {
                                if (numToSell > itemsToSell[userChoice - 1].QuantityOfItem)
                                {
                                    Console.WriteLine("You don't have that many. Pick a lower number.");
                                    Console.ReadKey();
                                    gotAQuantityICanSell = false;
                                }
                                else
                                {
                                    switch (sellOption)
                                    {
                                        case 1:
                                            Potion potionToSell = new();
                                            potionToSell.CreateCopyOf((Potion)itemsToSell[userChoice - 1], numToSell);
                                            GameSession.currentPlayer.SellSomething(sellOption, potionToSell);
                                            break;
                                        case 2:
                                            Weapon weaponToSell = new();
                                            weaponToSell.CopyFromOtherWeapon((Weapon)itemsToSell[userChoice - 1], numToSell);
                                            GameSession.currentPlayer.SellSomething(sellOption, weaponToSell);
                                            break;
                                        case 3:
                                            Armor armorToSell = new();
                                            armorToSell.CopyFromOtherArmor((Armor)itemsToSell[userChoice - 1], numToSell);
                                            GameSession.currentPlayer.SellSomething(sellOption, armorToSell);
                                            break;
                                        case 4:
                                            Item itemToSell = new();
                                            itemToSell.CopyFromOtherItem(itemsToSell[userChoice - 1], numToSell);
                                            GameSession.currentPlayer.SellSomething(sellOption, itemToSell);
                                            break;
                                    }
                                    gotAQuantityICanSell = true;
                                }
                            }
                        } while (!gotAQuantityICanSell);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("I didn't understand what you wanted. Please try again using one of the displayed number options.");
                    Console.ReadKey();
                    exitMerchant = false;
                }

            }
        } while (!exitMerchant);
    }
}



