using FirstFridayGroupProject.JsonHandle;
using FirstFridayGroupProject.Dinner;

namespace FirstFridayGroupProject.Menus;

public class Menu()
{
    private static List<string> MainMenuOptions = new List<string> { "1. See what might be on the menu.", "2. Add/Update/Remove a dinner idea", "3. What's for dinner tonight?", "4. Exit" };
    private static bool exitProgram = false;
    private static List<string> AddRemoveOptions = new List<string> { "1. Add a new dinner option", "2. Remove a dinner option", "3. Update an existing dinner option", "4. Return to main menu" };
    private static List<string> UpdateOptions = new List<string> { "1. Update meal name", "2. Update meal prep time", "3. Update meal cook time", "4. Update Ingredients", "5. Add Ingredient", "6. Remove Ingredient", "7. Back to Add/Remove Menu" };
    public static void Start()
    {
        string strUserInput = "";
        JsonHandler handler = new JsonHandler();
        PreLoadMeals loadedMeals = handler.LoadMealsFromFile();
        do
        {
            strUserInput = EnforceUserInput("noMessage", "noMessage", "integerOnly", MainMenuOptions, true, false);
            switch (Int32.Parse(strUserInput))
            {
                case 1:
                    if (loadedMeals.DoIStillHaveMeals())
                    {
                        bool exitCon = false;
                        do
                        {
                            string choiceInput = "";
                            choiceInput = EnforceUserInput("Current dinner options\nSelect one to view details of that meal", "noMessage", "integerOnly", ref loadedMeals, true, false, true);
                            Console.Clear();
                            if (Convert.ToInt32(choiceInput) < loadedMeals.AvailableDinnerIdeas.Count())
                            {
                                loadedMeals.DisplayDinnerDetails(Convert.ToInt32(choiceInput) - 1);
                            }
                            else
                            {
                                exitCon = true;
                            }
                        } while (!exitCon);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nothing.  Looks like you're going hungry.\nMaybe you should add a meal or two...");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    bool exitAddRemoveMenu = false;
                    string addRemoveChoiceInput = "";
                    int addRemoveLimiter;
                    do
                    {
                        addRemoveChoiceInput = EnforceUserInput("noMessage", "noMessage", "integerOnly", AddRemoveOptions, true);
                        switch (Int32.Parse(addRemoveChoiceInput))
                        {
                            case 1:
                                string newMealName;
                                string numberInput;
                                int prepTime;
                                int cookTime;
                                int ingCounter = 0;
                                string mealIngredient;
                                List<string> newIngredients = new();
                                newMealName = EnforceUserInput("What is the name of the meal being added?", "alphaNumberic");
                                numberInput = EnforceUserInput("How many minutes of prep work for this meal?", "integerOnly");
                                prepTime = Int32.Parse(numberInput);
                                numberInput = EnforceUserInput("How many minutes of cooking time is required for this meal?", "integerOnly");
                                cookTime = Int32.Parse(numberInput);
                                bool anotherEntry = true;
                                do
                                {
                                    ingCounter++;
                                    mealIngredient = EnforceUserInput($"Please enter ingredient {ingCounter}. Enter stop if done.", "alphaNumeric");
                                    if (mealIngredient.ToLower() == "stop" && ingCounter > 1)
                                    {
                                        anotherEntry = false;
                                    }
                                    else if (mealIngredient.ToLower() == "stop" && ingCounter <= 1)
                                    {
                                        Console.WriteLine("You must provide at least one ingredient!");
                                        Console.ReadKey();
                                        ingCounter--;
                                    }
                                    else
                                    {
                                        newIngredients.Add(mealIngredient);
                                    }
                                } while (anotherEntry);
                                DinnerIdea enteredIdea = new DinnerIdea(newMealName, prepTime, cookTime, newIngredients);
                                loadedMeals.AvailableDinnerIdeas.Add(enteredIdea);
                                Console.WriteLine("Item added successfully!");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                if (!loadedMeals.DoIStillHaveMeals())
                                {
                                    Console.WriteLine("You're out of meals. Please add more.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    numberInput = EnforceUserInput("noMessage", "Which meal would you like to remove?", "integerOnly", ref loadedMeals);
                                    loadedMeals.AvailableDinnerIdeas.RemoveAt(Int32.Parse(numberInput) - 1);
                                    Console.Clear();
                                    if (loadedMeals.CountOfRemainingMeals() > 0)
                                    {
                                        Console.WriteLine("Meal removed.  Remaining meal options:");
                                        addRemoveLimiter = DisplayMenu(ref loadedMeals, false);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You are now out of meals");
                                    }
                                    Console.ReadKey();
                                }
                                break;
                            case 3:
                                int mealToUpdate;
                                Console.Clear();
                                if (!loadedMeals.DoIStillHaveMeals())
                                {
                                    Console.WriteLine("You're out of meals. Please add more.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    numberInput = EnforceUserInput("noMessage", "Which meal would you like to update?", "integerOnly", ref loadedMeals);
                                    mealToUpdate = Convert.ToInt32(numberInput) - 1;
                                    bool breakCondition = false;
                                    do
                                    {
                                        numberInput = EnforceUserInput("noMessage", "noMessage", "integerOnly", UpdateOptions, true);
                                        string strTempInput;
                                        switch (Convert.ToInt32(numberInput))
                                        {
                                            case 1:
                                                strTempInput = EnforceUserInput($"Current meal name:{loadedMeals.AvailableDinnerIdeas[mealToUpdate].GetMealName()}\nEnter new meal name", "alphaNumeric");
                                                loadedMeals.AvailableDinnerIdeas[mealToUpdate].SetMealName(strTempInput);
                                                break;
                                            case 2:
                                                numberInput = EnforceUserInput($"Current prep time:{loadedMeals.AvailableDinnerIdeas[mealToUpdate].GetPrepTime()}\nEnter new prep time", "integerOnly");
                                                loadedMeals.AvailableDinnerIdeas[mealToUpdate].SetPrepTime(Convert.ToInt32(numberInput));
                                                break;
                                            case 3:
                                                numberInput = EnforceUserInput($"Current cook time:{loadedMeals.AvailableDinnerIdeas[mealToUpdate].GetCookTime()}\nEnter new cook time", "integerOnly");
                                                loadedMeals.AvailableDinnerIdeas[mealToUpdate].SetCookTime(Convert.ToInt32(numberInput));
                                                break;
                                            case 4:
                                                bool doneWithIngredientUpdates = false;
                                                int ingredientToUpdate;
                                                do
                                                {
                                                    numberInput = EnforceUserInput("noMessage", "Which ingredient needs to be updated?", "integerOnly", loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients, false, true, true);
                                                    ingredientToUpdate = Convert.ToInt32(numberInput) - 1;
                                                    if (ingredientToUpdate < loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients.Count())
                                                    {
                                                        strTempInput = EnforceUserInput($"Current Ingredient: {loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients[ingredientToUpdate]}\nEnter the new ingredient", "alphaNumeric");
                                                        loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients[ingredientToUpdate] = strTempInput;
                                                        strTempInput = EnforceUserInput("Would you like to update another ingredient? (y/n)", "alphaOnly", true);
                                                        if (strTempInput.ToLower() == "n")
                                                        {
                                                            doneWithIngredientUpdates = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        doneWithIngredientUpdates = true;
                                                    }
                                                } while (!doneWithIngredientUpdates);
                                                break;
                                            case 5:
                                                strTempInput = EnforceUserInput("What is the new ingredient?", "alphaNumeric");
                                                loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients.Add(strTempInput);
                                                Console.WriteLine($"{strTempInput} has been added to the meal");
                                                Console.ReadKey();
                                                break;
                                            case 6:
                                                numberInput = EnforceUserInput("noMessage", "Which ingredient needs to be removed?", "integerOnly", loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients, false, true, true);
                                                ingredientToUpdate = Convert.ToInt32(numberInput) - 1;
                                                if (ingredientToUpdate < loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients.Count())
                                                {
                                                    loadedMeals.AvailableDinnerIdeas[mealToUpdate].Ingredients.RemoveAt(ingredientToUpdate);
                                                    Console.WriteLine("The chosen ingredient has been removed from the meal");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 7:
                                                breakCondition = true;
                                                break;
                                            default:
                                                breakCondition = true;
                                                break;
                                        }
                                    } while (!breakCondition);
                                }
                                break;
                            case 4:
                                exitAddRemoveMenu = true;
                                break;
                            default:
                                break;
                        }
                    } while (!exitAddRemoveMenu);
                    break;
                case 3:
                    Console.Clear();
                    loadedMeals.ChooseARandomDinnerOption();
                    break;
                case 4:
                    SetExitStatus(true);
                    break;
            }
        } while (!exitProgram);
    }

    public static int DisplayMenu(List<string> menuList, bool withNumbers = false, bool includeExitOption = false)
    {
        for (int i = 0; i < menuList.Count(); i++)
        {
            if (withNumbers)
            {
                Console.WriteLine($"{i + 1}: {menuList[i]}");
            }
            else
            {
                Console.WriteLine(menuList[i]);
            }
        }
        if (withNumbers && includeExitOption)
        {
            Console.WriteLine($"{menuList.Count() + 1}: Exit without changes");
        }
        return menuList.Count();
    }
    public static int DisplayMenu(ref PreLoadMeals loadedMeals, bool withNumbers = true, bool includeExitOption = false)
    {
        for (int i = 0; i < loadedMeals.AvailableDinnerIdeas.Count(); i++)
        {
            if (withNumbers)
            {
                Console.WriteLine($"{i + 1}: " + loadedMeals.AvailableDinnerIdeas[i].MealName);
            }
            else
            {
                Console.WriteLine(loadedMeals.AvailableDinnerIdeas[i].MealName);
            }
        }
        if (withNumbers && includeExitOption)
        {
            Console.WriteLine($"{loadedMeals.AvailableDinnerIdeas.Count() + 1}: Exit without changes");
        }
        return loadedMeals.AvailableDinnerIdeas.Count();
    }
    public static void SetExitStatus(bool statusUpdate)
    {
        exitProgram = statusUpdate;
    }
    public static bool ValidateUserInput(string userInput, string validationType, bool isSingleChar = false, int limiter = 0)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("I asked for something and you gave me... nothing.");
            return false;
        }
        if (isSingleChar && userInput.Count() > 1)
        {
            Console.WriteLine("This should be a single character and no more.");
            return false;
        }
        switch (validationType)
        {
            case "alphaOnly":

                break;
            case "alphaNumeric":
                //I'll put something here when I can think of a need for a limiter other than not empty/null and then will need a new generic limiter
                break;
            case "integerOnly":
                int testInt;
                if (!Int32.TryParse(userInput, out testInt))
                {
                    Console.WriteLine("This option should be a whole number.");
                    return false;
                }
                //if(limiter>0 && Convert.ToInt32(userInput) > limiter)
                if (limiter > 0 && testInt > limiter)
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

    public static string EnforceUserInput(string strMessage, string validationType, bool valIsSingleChar = false)
    {
        string strUserInput;
        bool isValid;
        bool keepAsking = true;
        do
        {
            Console.Clear();
            Console.WriteLine(strMessage);
            strUserInput = Console.ReadLine().Trim();
            isValid = ValidateUserInput(strUserInput, validationType, valIsSingleChar);
            if (!isValid)
            {
                Console.ReadKey();
            }
            else
            {
                keepAsking = false;
            }
        } while (keepAsking);
        return strUserInput;
    }
    public static string EnforceUserInput(string strHeaderMessage, string strFooterMessage, string validationType, List<string> menuList, bool valIsSingleChar = false, bool withNumbers = false, bool includeExitOption = false)
    {
        string strUserInput;
        bool isValid;
        bool keepAsking = true;
        do
        {
            Console.Clear();
            if (strHeaderMessage != "noMessage")
            {
                Console.WriteLine(strHeaderMessage);
            }
            int valNumberLimited = DisplayMenu(menuList, withNumbers, includeExitOption);
            if (strFooterMessage != "noMessage")
            {
                Console.WriteLine(strFooterMessage);
            }
            strUserInput = Console.ReadLine().Trim();
            if (includeExitOption)
            {
                valNumberLimited++;
            }
            isValid = ValidateUserInput(strUserInput, validationType, valIsSingleChar, valNumberLimited);
            if (!isValid)
            {
                Console.ReadKey();
            }
            else
            {
                keepAsking = false;
            }
        } while (keepAsking);
        return strUserInput;
    }
    public static string EnforceUserInput(string strHeaderMessage, string strFooterMessage, string validationType, ref PreLoadMeals loadedMeals, bool withNumbers = true, bool valIsSingleChar = false, bool includeExitOption = false)
    {
        string strUserInput;
        bool isValid;
        bool keepAsking = true;
        do
        {
            Console.Clear();
            if (strHeaderMessage != "noMessage")
            {
                Console.WriteLine(strHeaderMessage);
            }
            int valNumberLimited = DisplayMenu(ref loadedMeals, withNumbers, includeExitOption);
            if (strFooterMessage != "noMessage")
            {
                Console.WriteLine(strFooterMessage);
            }
            strUserInput = Console.ReadLine().Trim();
            if (includeExitOption)
            {
                valNumberLimited++;
            }
            isValid = ValidateUserInput(strUserInput, validationType, valIsSingleChar, valNumberLimited);
            if (!isValid)
            {
                Console.ReadKey();
            }
            else
            {
                keepAsking = false;
            }
        } while (keepAsking);
        return strUserInput;
    }

}
