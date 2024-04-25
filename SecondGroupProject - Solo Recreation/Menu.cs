
namespace FirstFridayGroupProject;

public class Menu()
{
    private static List<string> MainMenuOptions = new List<string>{"1. See what might be on the menu.","2. Add/Update/Remove a dinner idea","3. What's for dinner tonight?","4. Exit"};
    private static bool exitProgram = false;
    private static List<string> AddRemoveOptions = new List<string>{"1. Add a new dinner option", "2. Remove a dinner option", "3. Update an existing dinner option", "4. Return to main menu"};
    private static List<string> UpdateOptions = new List<string>{"1. Update meal name","2. Update meal prep time","3. Update meal cook time","4. Update Ingredients","5. Back to Add/Remove Menu"};
    public static void Start()
    {
        string strUserInput = "";
        JsonHandler handler = new JsonHandler();
        PreLoadMeals loadedMeals = handler.LoadMealsFromFile();
        // foreach(DinnerIdea meal in loadedMeals.AvailableDinnerIdeas)
        // {
        //     //Console.WriteLine(meal);
        //     Console.WriteLine(meal);
        // }
        do
        {
            Console.Clear();
            int mainMenuLimit = DisplayMenu(MainMenuOptions);
            strUserInput = Console.ReadLine().Trim();
            if(ValidateUserInput(strUserInput,"integerOnly",true,mainMenuLimit))
            {
                switch(Int32.Parse(strUserInput))
                {
                    case 1:
                        int numberOfMenuItems = 0;
                        Console.Clear();
                        numberOfMenuItems = DisplayMenu(ref loadedMeals,false);
                        Console.WriteLine("Would you like details about on of the meals? (y/n)");
                        string tempInput = Console.ReadLine().Trim();
                        if(ValidateUserInput(tempInput, "alphaOnly", true))
                        {
                            if(tempInput.ToLower() == "y")
                            {
                                string choiceInput = "";
                                do
                                {
                                    Console.Clear();
                                    numberOfMenuItems = DisplayMenu(ref loadedMeals);
                                    Console.WriteLine("Which item would you like to view in detail?");
                                    choiceInput = Console.ReadLine().Trim();
                                    if(ValidateUserInput(choiceInput,"integerOnly",false,numberOfMenuItems))
                                    {
                                        Console.Clear();
                                        DisplayDinnerDetails(ref loadedMeals,Convert.ToInt32(choiceInput)-1);
                                    }
                                    else
                                    {
                                        Console.ReadKey();
                                    }
                                }while(!ValidateUserInput(choiceInput,"integerOnly",true,numberOfMenuItems));
                                

                            }
                            else if(tempInput.ToLower() == "n")
                            {
                                Console.WriteLine("Ok, back to the main menu.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"{tempInput} wasn't one of the options. We're going back to the main menu now.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("I'm going back to the main menu...");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        bool exitAddRemoveMenu = false;
                        string addRemoveChoiceInput = "";
                        do
                        {
                            Console.Clear();
                            int addRemoveLimiter = DisplayMenu(AddRemoveOptions);
                            addRemoveChoiceInput = Console.ReadLine().Trim();
                            if(ValidateUserInput(addRemoveChoiceInput,"integerOnly",true,addRemoveLimiter))
                            {
                                switch(Int32.Parse(addRemoveChoiceInput))
                                {
                                    case 1:
                                        string newMealName;
                                        string numberInput;
                                        int prepTime = 0;
                                        int cookTime = 0;
                                        bool nextStep;
                                        int ingCounter = 0;
                                        string mealIngredient;                                        
                                        List<string> newIngredients = new();
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("What is the name of the meal being added?");
                                            newMealName = Console.ReadLine().Trim();
                                            nextStep = ValidateUserInput(newMealName,"alphanumeric");
                                            if(!nextStep)
                                            {
                                                Console.ReadKey();
                                            }
                                        }while(!nextStep);
                                        nextStep = false;
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("How many minutes of prep work for this meal?");
                                            numberInput = Console.ReadLine().Trim();
                                            nextStep = ValidateUserInput(numberInput,"numericOnly");
                                            if(!nextStep)
                                            {
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                prepTime = Int32.Parse(numberInput);
                                            }
                                        }while(!nextStep);
                                        nextStep = false;
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("How many minutes of cooking time is required for this meal?");
                                            numberInput = Console.ReadLine().Trim();
                                            nextStep = ValidateUserInput(numberInput,"numbericOnly");
                                            if(!nextStep)
                                            {
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                cookTime = Int32.Parse(numberInput);
                                            }                                            
                                        }while(!nextStep);
                                        nextStep = false;
                                        bool anotherEntry = true;
                                        do
                                        {
                                            ingCounter++;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Please enter ingredient {ingCounter}. Enter stop if done.");
                                                mealIngredient = Console.ReadLine().Trim();
                                                nextStep = ValidateUserInput(mealIngredient,"alphaNumeric");
                                                if(nextStep)
                                                {
                                                    if(mealIngredient.ToLower() == "stop" && ingCounter > 1)
                                                    {
                                                        anotherEntry = false;
                                                    }
                                                    else if(mealIngredient.ToLower() == "stop" && ingCounter <=1)
                                                    {
                                                        Console.WriteLine("You must provide at least one ingredient!");
                                                    }
                                                    else
                                                    {
                                                        newIngredients.Add(mealIngredient);
                                                    }
                                                }
                                            }while(!nextStep);
                                        }while(anotherEntry);
                                        DinnerIdea enteredIdea = new DinnerIdea(newMealName,prepTime,cookTime,newIngredients);
                                        loadedMeals.AvailableDinnerIdeas.Add(enteredIdea);
                                        Console.WriteLine("Item added successfully!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        if(CountOfRemainingMeals(ref loadedMeals) < 1)
                                        {
                                            Console.WriteLine("You're out of meals. Please add more.");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            nextStep = false;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Which meal would you like to remove?");
                                                addRemoveLimiter = DisplayMenu(ref loadedMeals,true);
                                                numberInput = Console.ReadLine().Trim();
                                                nextStep = ValidateUserInput(numberInput, "integerOnly",false,addRemoveLimiter);
                                                if(nextStep)
                                                {
                                                    loadedMeals.AvailableDinnerIdeas.RemoveAt(Int32.Parse(numberInput)-1);
                                                    Console.Clear();
                                                    Console.WriteLine("Meal removed.  Remaining meal options:");
                                                    addRemoveLimiter = DisplayMenu(ref loadedMeals,false);
                                                    Console.ReadKey();
                                                }
                                            }while(!nextStep);
                                        }
                                        break;
                                    case 3:
                                        Console.Clear();
                                        if(CountOfRemainingMeals(ref loadedMeals) < 1)
                                        {
                                            Console.WriteLine("You're out of meals. Please add more.");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            nextStep = false;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Which meal would you like to update?");
                                                addRemoveLimiter = DisplayMenu(ref loadedMeals,true);
                                                numberInput = Console.ReadLine().Trim();
                                                nextStep = ValidateUserInput(numberInput, "integerOnly",false,addRemoveLimiter);    
                                            }while(!nextStep);                                        
                                        }
                                        break;
                                    case 4:
                                        exitAddRemoveMenu = true;
                                        break;
                                }
                            }
                        }while(!exitAddRemoveMenu);
                        break;
                    case 3:
                        Console.Clear();
                        ChooseARandomDinnerOption(ref loadedMeals);
                        break;
                    case 4:
                        SetExitStatus(true);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid menu selection.");
                Console.ReadKey();
            }
        }while(!exitProgram);
    }

    public static int DisplayMenu(List<string> menuList)
    {
        foreach(string option in menuList)
        {
            Console.WriteLine(option);
        }
        return menuList.Count();
    }
    public static int DisplayMenu(ref PreLoadMeals loadedMeals, bool withNumbers = true)
    {
        for(int i=0; i<loadedMeals.AvailableDinnerIdeas.Count();i++)
        {
            if(withNumbers)
            {
                Console.WriteLine($"{i+1}: " + loadedMeals.AvailableDinnerIdeas[i].MealName);
            }
            else
            {
                Console.WriteLine(loadedMeals.AvailableDinnerIdeas[i].MealName);
            }
        }
        return loadedMeals.AvailableDinnerIdeas.Count();
    }
    public static void DisplayDinnerDetails(ref PreLoadMeals loadedMeals,int choice)
    {
        Console.WriteLine(loadedMeals.AvailableDinnerIdeas[choice]);
        Console.ReadKey();
    }
    public static void SetExitStatus(bool statusUpdate)
    {
        exitProgram = statusUpdate;
    }

    public static void ChooseARandomDinnerOption(ref PreLoadMeals loadedMeals)
    {
        if(CountOfRemainingMeals(ref loadedMeals) < 1)
        {
            Console.WriteLine("You're out of options. Please add more.");
            Console.ReadKey();
        }
        else
        {
            Random rnd = new Random();
            int choice = rnd.Next(0,loadedMeals.AvailableDinnerIdeas.Count());
            Console.WriteLine("Tonight for dinner, we are having:");
            DisplayDinnerDetails(ref loadedMeals,choice);
        }
    }

    public static int CountOfRemainingMeals(ref PreLoadMeals loadedMeals)
    {
        return loadedMeals.AvailableDinnerIdeas.Count();
    }
    public static bool ValidateUserInput(string userInput,string validationType, bool isSingleChar = false, int limiter=0)
    {
        if(string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("I asked for something and you gave me... nothing.");
            return false;
        }
        if(isSingleChar && userInput.Count() > 1)
        {
            Console.WriteLine("This should be a single character and no more.");
            return false;
        }
        switch(validationType)
        {
            case "alphaOnly":
                
                break;
            case "alphaNumeric":
                //I'll put something here when I can think of a need for a limiter other than not empty/null and then will need a new generic limiter
                break;
            case "integerOnly":
                int testInt;
                if(!Int32.TryParse(userInput, out testInt))
                {
                    Console.WriteLine("This option should be a whole number.");
                    return false;
                }
                //if(limiter>0 && Convert.ToInt32(userInput) > limiter)
                if(limiter>0 && testInt > limiter)
                {
                    Console.WriteLine($"The maximum number acceptable is {limiter} and you gave me {userInput}. Think about that and try again.");
                    return false;
                }
                return true;
            default:
                return true;
        }
        return true;
    }
    
}