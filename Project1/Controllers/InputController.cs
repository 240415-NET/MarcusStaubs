using Project1.Models;

namespace Project1.Controllers;

public class InputController
{
    public static int OutOfCombatInput(string userInput)
    {
        userInput = userInput.ToLower();
        if (String.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("That was... not very enlightening. You literally gave me nothing to work with. Try again.");
            Console.WriteLine("Press any key to continue...");
            return 0;
        }
        switch (userInput)
        {
            case "c":
                return 3;
            case "r":
                return 5;
            case "v":
                return 6;
            case "x":
                return 7;
            case "n":
            case "uparrow":
                return 1;
            case "e":
            case "rightarrow":
                return 2;
            case "s":
            case "downarrow":
                return 4;
            case "w":
            case "leftarrow":
                return 8;
            case "i":
                return 15;
            case "h":
                return 11;
            default:
                Console.WriteLine("I didn't understand what you wanted. Try again.");
                Console.WriteLine("Press any key to continue...");
                return 0;
        }
    }
    public static int InCombatInput(string userInput)
    {
        userInput = userInput.ToLower();
        if (String.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("That was... not very enlightening. You literally gave me nothing to work with. Try again.");
            Console.WriteLine("Press any key to continue...");
            return 0;
        }
        switch (userInput)
        {
            case "a":
                return 9;
            case "f":
                return 10;
            case "h":
                return 11;
            case "i":
                return 17;
            case "d":
                return 14;
            default:
                Console.WriteLine("I didn't understand what you wanted. Try again.");
                Console.WriteLine("Press any key to continue...");
                return 0;
        }
    }
    public static int InventoryInput(string userInput)
    {
        userInput = userInput.ToLower();
        if (String.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("That was... not very enlightening. You literally gave me nothing to work with. Try again.");
            Console.WriteLine("Press any key to continue...");
            return 0;
        }
        switch (userInput)
        {
            case "b":
                return 12;
            case "q":
                return 13;
            case "e":
                return 16;
            case "i":
                return 17;
            case "w":
                return 18;
            case "a":
                return 19;
            case "p":
                return 20;
            case "d":
                return 21;
            default:
                Console.WriteLine("I didn't understand what you wanted. Try again.");
                Console.WriteLine("Press any key to continue...");
                return 0;
        }
    }
    public static int EquipInput(string userInput)
    {
        userInput = userInput.ToLower();
        if (String.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("That was... not very enlightening. You literally gave me nothing to work with. Try again.");
            Console.WriteLine("Press any key to continue...");
            return 0;
        }
        switch (userInput)
        {
            case "a":
                return 1;
            case "w":
                return 2;
            case "d":
                return 3;
            case "i":
                return 17;
            default:
                Console.WriteLine("I didn't understand what you wanted. Try again.");
                Console.WriteLine("Press any key to continue...");
                return 0;
        }
    }
    public static int TownInput(string userInput)
    {
        return 0;
    }
    public static int VendorInput(string userInput)
    {
        return 0;
    }
}