using FirstFridayGroupProject.JsonHandle;
using FirstFridayGroupProject.Dinner;
using FirstFridayGroupProject.HandleUserInputs;
using FirstFridayGroupProject.Menus;
using System.Globalization;

namespace FirstFridayGroupProject.AppLayer;

public class Application()
{
    private static PreLoadMeals LoadedMeals = new();
    private static JsonHandler Handler = new();
    private static List<string> MainMenuOptions = new List<string> { "1. See what might be on the menu.", "2. Add/Update/Remove a dinner idea", "3. What's for dinner tonight?", "4. Exit" };
    private static List<string> AddRemoveOptions = new List<string> { "1. Add a new dinner option", "2. Remove a dinner option", "3. Update an existing dinner option", "4. Return to main menu" };
    private static List<string> UpdateOptions = new List<string> { "1. Update meal name", "2. Update meal prep time", "3. Update meal cook time", "4. Update Ingredients", "5. Add Ingredient", "6. Remove Ingredient", "7. Back to Add/Remove Menu" };
    private static bool MealsLoadedFromFile = false;
    public static void Start()
    {
        Menu MainMenu = new Menu(MainMenuOptions);
        Menu AddRemoveMenu = new Menu(AddRemoveOptions);
        Menu UpdateMenu = new Menu(UpdateOptions);
        LoadFromJson();
        bool DoneWithThisMenu = false;
        do
        {
            string menuOption = MainMenu.AskForUserInputWithMenu("Welcome to Dinner Roulette!", "noMessage", MainMenuOptions, "integerOnly", true, false, false, MainMenuOptions.Count());
            switch (Convert.ToInt32(menuOption))
            {
                case 1:
                    if (LoadedMeals.DoIStillHaveMeals())
                    {
                        bool optionOneExit = false;
                        do
                        {
                            string mealSelection = MainMenu.AskForUserInputWithMenu("The currently available meals are:", "Select a meal to view the details or you can return to the main menu.", ref LoadedMeals, "integerOnly", false, true, true, LoadedMeals.CountOfRemainingMeals() + 1);
                            int selectedNumber = Convert.ToInt32(mealSelection) - 1;
                            if (selectedNumber < LoadedMeals.CountOfRemainingMeals())
                            {
                                Console.Clear();
                                LoadedMeals.DisplayDinnerDetails(selectedNumber);
                            }
                            else
                            {
                                optionOneExit = true;
                            }
                        } while (!optionOneExit);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("There aren't any meals to look at. Try adding some.");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    bool ExitAddRemoveMenu = false;
                    do
                    {
                        ExitAddRemoveMenu = false;
                        string addRemoveInput = AddRemoveMenu.AskForUserInputWithMenu("What would you like to do?", "noMessage", AddRemoveOptions, "integerOnly", true, false, false, AddRemoveOptions.Count());
                        switch (Convert.ToInt32(addRemoveInput))
                        {
                            case 1:
                                string newMealName;
                                string numberInput;
                                int prepTime;
                                int cookTime;
                                int ingCounter = 0;
                                string mealIngredient;
                                List<string> newIngredients = new();
                                newMealName = AddRemoveMenu.AskForUserInput("What is the name of the meal being added?", "alphaNumeric");
                                numberInput = AddRemoveMenu.AskForUserInput("How many minutes of prep work for this meal?", "integerOnly");
                                prepTime = Int32.Parse(numberInput);
                                numberInput = AddRemoveMenu.AskForUserInput("How many minutes of cooking time is required for this meal?", "integerOnly");
                                cookTime = Int32.Parse(numberInput);
                                bool anotherEntry = true;
                                do
                                {
                                    ingCounter++;
                                    mealIngredient = AddRemoveMenu.AskForUserInput($"Please enter ingredient {ingCounter}. Enter stop if done.", "alphaNumeric");
                                    if (mealIngredient.ToLower() == "stop" && ingCounter > 1)
                                    {
                                        anotherEntry = false;
                                    }
                                    else if (mealIngredient.ToLower() == "stop" && ingCounter <= 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You must provide at least one ingredient!\nPress any key to continue...");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        ingCounter--;
                                    }
                                    else
                                    {
                                        newIngredients.Add(mealIngredient);
                                    }
                                } while (anotherEntry);
                                DinnerIdea enteredIdea = new DinnerIdea(newMealName, prepTime, cookTime, newIngredients);
                                LoadedMeals.AvailableDinnerIdeas.Add(enteredIdea);
                                Console.WriteLine("Item added successfully!");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                if (!LoadedMeals.DoIStillHaveMeals())
                                {
                                    Console.WriteLine("You're out of meals. Please add more.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    numberInput = AddRemoveMenu.AskForUserInputWithMenu("Which meal would you like to remove?", "noMessage", ref LoadedMeals, "integerOnly", false, true, true, LoadedMeals.CountOfRemainingMeals() + 1);
                                    if (Convert.ToInt32(numberInput) <= LoadedMeals.CountOfRemainingMeals())
                                    {
                                        LoadedMeals.AvailableDinnerIdeas.RemoveAt(Int32.Parse(numberInput) - 1);
                                        Console.Clear();
                                        if (LoadedMeals.CountOfRemainingMeals() > 0)
                                        {
                                            AddRemoveMenu.DisplayMenu("Meal removed.\nRemaining meal options:", "noMessage", ref LoadedMeals, false);
                                        }
                                        else
                                        {
                                            Console.WriteLine("You are now out of meals");
                                        }
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            case 3:
                                Console.Clear();
                                if (!LoadedMeals.DoIStillHaveMeals())
                                {
                                    Console.WriteLine("You're out of meals. Please add more.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    bool ExitUpdateOuterMenu = false;
                                    bool ExitUpdateInnerMenu = false;
                                    int intMealSelection;
                                    string strMenuSelection;
                                    do
                                    {
                                        strMenuSelection = UpdateMenu.AskForUserInputWithMenu("Which would you like to update?", "noMessage", ref LoadedMeals, "integerOnly", false, true, true, LoadedMeals.CountOfRemainingMeals() + 1);
                                        intMealSelection = Convert.ToInt32(strMenuSelection) - 1;
                                        if (intMealSelection < LoadedMeals.CountOfRemainingMeals())
                                        {
                                            do
                                            {
                                                strMenuSelection = UpdateMenu.AskForUserInputWithMenu("What would you like to update?", "noMessage", UpdateOptions, "integerOnly", true, false, false, UpdateOptions.Count());
                                                string strTempInput;
                                                Console.Clear();
                                                switch (Convert.ToInt32(strMenuSelection))
                                                {
                                                    case 1:
                                                        strTempInput = UpdateMenu.AskForUserInput($"Current meal name:{LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetMealName()}\nEnter new meal name", "alphaNumeric");
                                                        LoadedMeals.AvailableDinnerIdeas[intMealSelection].SetMealName(strTempInput);
                                                        break;
                                                    case 2:
                                                        strTempInput = UpdateMenu.AskForUserInput($"Current prep time:{LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetPrepTime()}\nEnter new prep time", "alphaNumeric");
                                                        LoadedMeals.AvailableDinnerIdeas[intMealSelection].SetPrepTime(Convert.ToInt32(strTempInput));
                                                        break;
                                                    case 3:
                                                        strTempInput = UpdateMenu.AskForUserInput($"Current cook time:{LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetCookTime()}\nEnter new cook time", "alphaNumeric");
                                                        LoadedMeals.AvailableDinnerIdeas[intMealSelection].SetCookTime(Convert.ToInt32(strTempInput));
                                                        break;
                                                    case 4:
                                                        bool doneWithIngredientUpdates = false;
                                                        int ingredientToUpdate;
                                                        do
                                                        {
                                                            strTempInput = UpdateMenu.AskForUserInputWithMenu("Which ingredient needs to be updated?", "noMessage", LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients, "integerOnly", false, true, true, LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Count() + 1);
                                                            ingredientToUpdate = Convert.ToInt32(strTempInput) - 1;
                                                            if (ingredientToUpdate < LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Count())
                                                            {
                                                                strTempInput = UpdateMenu.AskForUserInput($"Current Ingredient: {LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients[ingredientToUpdate]}\nEnter the new ingredient", "alphaNumeric");
                                                                LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients[ingredientToUpdate] = strTempInput;
                                                                bool anotherIngredient = false;
                                                                do
                                                                {
                                                                    strTempInput = UpdateMenu.AskForUserInput("Would you like to update another ingredient? (y/n)", "alphaOnly");
                                                                    if (strTempInput.ToLower() == "n")
                                                                    {
                                                                        anotherIngredient = true;
                                                                        doneWithIngredientUpdates = true;
                                                                    }
                                                                    else if (strTempInput.ToLower() != "y")
                                                                    {
                                                                        Console.WriteLine("Let's not get fancy, champ. Just give me a y or n. I'd even take Y or N.\nPress any key to continue...");
                                                                        Console.ReadKey();
                                                                    }
                                                                    else
                                                                    {
                                                                        anotherIngredient = true;
                                                                    }
                                                                } while (!anotherIngredient);
                                                            }
                                                            else
                                                            {
                                                                doneWithIngredientUpdates = true;
                                                            }
                                                        } while (!doneWithIngredientUpdates);
                                                        break;
                                                    case 5:
                                                        strTempInput = UpdateMenu.AskForUserInput("What is the new ingredient?", "alphaNumeric");
                                                        LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Add(strTempInput);
                                                        Console.WriteLine($"{strTempInput} has been added to {LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetMealName()}");
                                                        Console.ReadKey();
                                                        break;
                                                    case 6:
                                                        strTempInput = UpdateMenu.AskForUserInputWithMenu("Which ingredient needs to be removed?", "noMessage", LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients, "integerOnly", false, true, true, LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Count() + 1);
                                                        ingredientToUpdate = Convert.ToInt32(strTempInput) - 1;
                                                        if (ingredientToUpdate < LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Count())
                                                        {
                                                            LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.RemoveAt(ingredientToUpdate);
                                                            Console.WriteLine($"The selected ingredient has been removed from {LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetMealName()}");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case 7:
                                                        ExitUpdateInnerMenu = true;
                                                        ExitUpdateOuterMenu = true;
                                                        break;
                                                }
                                            } while (!ExitUpdateInnerMenu);
                                        }
                                        else
                                        {
                                            ExitUpdateOuterMenu = true;
                                        }
                                    } while (!ExitUpdateOuterMenu);
                                }
                                break;
                            case 4:
                                ExitAddRemoveMenu = true;
                                break;
                        }
                    } while (!ExitAddRemoveMenu);
                    break;
                case 3:
                    LoadedMeals.ChooseARandomDinnerOption();
                    break;
                case 4:
                    DoneWithThisMenu = true;
                    break;
                default:
                    Console.WriteLine("Not sure how you got here but that input was invalid. Try again.");
                    break;
            }
        } while (!DoneWithThisMenu);

    }
    public static void LoadFromJson()
    {
        LoadedMeals = Handler.LoadMealsFromFile();
        MealsLoadedFromFile = true;
    }
}