using FirstFridayGroupProject.JsonHandle;
using FirstFridayGroupProject.Dinner;
using FirstFridayGroupProject.HandleUserInputs;

namespace FirstFridayGroupProject.Menus;

public class Menu()
{
    private static List<string> MenuOptions = new List<string> { "1. I didn't code this", "2. I've clearly messed up", "3. You should just quit now", "4. Exit" };
    private static bool exitProgram = false;
    public static void Start()
    {
        MainMenu mainMenu = new MainMenu();
        mainMenu.DoMenuStuff();
    }
    public void DisplayMenu(string strHeaderMessage, string strFooterMessage, List<string> menuList, bool withNumbers = false, bool includeExitOption = false)
    {
        if (strHeaderMessage != "noMessage")
        {
            Console.WriteLine(strHeaderMessage);
        }
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
        if (strFooterMessage != "noMessage")
        {
            Console.WriteLine(strFooterMessage);
        }
        //return menuList.Count();
    }
    public void DisplayMenu(string strHeaderMessage, string strFooterMessage, ref PreLoadMeals loadedMeals, bool withNumbers = true, bool includeExitOption = false)
    {
        if (strHeaderMessage != "noMessage")
        {
            Console.WriteLine(strHeaderMessage);
        }
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
        if (strFooterMessage != "noMessage")
        {
            Console.WriteLine(strFooterMessage);
        }
        //return loadedMeals.AvailableDinnerIdeas.Count();
    }
    public static void SetExitStatus(bool statusUpdate)
    {
        exitProgram = statusUpdate;
    }
    public string AskForUserInput(string strMessage, string validationType, bool isSingleChar = false, int limiter = 0, int lowerlimit = 0)
    {
        string strUserInput;
        do
        {
            Console.Clear();
            Console.WriteLine(strMessage);
            strUserInput = HandleUserInput.ReturnUserInput(validationType,isSingleChar,limiter,lowerlimit);
        }while(strUserInput == "noCurrentValidInput");        
        return "";
    }
    public string AskForUserInputWithMenu(string strHeaderMessage, string strFooterMessage, List<string> menuList, string validationType, bool isSingleChar = false, bool withNumbers = false, bool includeExitOption = false, int limiter=0, int lowerlimit = 0)
    {
        string strUserInput;
        do
        {
            Console.Clear();
            DisplayMenu(strHeaderMessage,strFooterMessage,menuList,withNumbers,includeExitOption);
            strUserInput = HandleUserInput.ReturnUserInput(validationType,isSingleChar,limiter,lowerlimit);
        }while(strUserInput == "noCurrentValidInput");
        return strUserInput;
    }
    public string AskForUserInputWithMenu(string strHeaderMessage, string strFooterMessage, ref PreLoadMeals loadedMeals, string validationType, bool isSingleChar = false, bool withNumbers = false, bool includeExitOption = false, int limiter=0, int lowerlimit = 0)
    {
        string strUserInput;
        do
        {
            Console.Clear();
            DisplayMenu(strHeaderMessage,strFooterMessage,ref loadedMeals,withNumbers,includeExitOption);
            strUserInput = HandleUserInput.ReturnUserInput(validationType,isSingleChar,limiter,lowerlimit);
        }while(strUserInput == "noCurrentValidInput");
        return strUserInput;
    }
}    
    public class MainMenu : Menu
    {
        private List<string> MainMenuOptions = new List<string> { "1. See what might be on the menu.", "2. Add/Update/Remove a dinner idea", "3. What's for dinner tonight?", "4. Exit" };
        private PreLoadMeals LoadedMeals = new();
        private JsonHandler Handler = new();
        private bool MealsLoadedFromFile = false;
        public void DoMenuStuff()
        {
            bool DoneWithThisMenu = false;
            if (!MealsLoadedFromFile)
            {
                LoadFromJson();
            }
            do
            {
                string menuOption = AskForUserInputWithMenu("Welcome to Dinner Roulette!", "noMessage", MainMenuOptions,"integerOnly", true,false,false, MainMenuOptions.Count());
                switch (Convert.ToInt32(menuOption))
                {
                    case 1:
                        if (LoadedMeals.DoIStillHaveMeals())
                        {
                            bool optionOneExit = false;
                            do
                            {
                                string mealSelection = AskForUserInputWithMenu("The currently available meals are:", "Select a meal to view the details or you can return to the main menu.", ref LoadedMeals,"integerOnly",false, true, true,LoadedMeals.CountOfRemainingMeals() + 1);
                                int selectedNumber = Convert.ToInt32(mealSelection)-1;
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
                            Console.WriteLine("There aren't any meals to look at. Try adding some.");
                        }
                        break;
                    case 2:
                        AddRemoveMenu addRemoveMenu = new AddRemoveMenu();
                        addRemoveMenu.DoMenuStuff(ref LoadedMeals);
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
        public void LoadFromJson()
        {
            this.Handler = new JsonHandler();
            this.LoadedMeals = Handler.LoadMealsFromFile();
            this.MealsLoadedFromFile = true;
        }
    }
    public class AddRemoveMenu : Menu
    {
        private List<string> AddRemoveOptions = new List<string> { "1. Add a new dinner option", "2. Remove a dinner option", "3. Update an existing dinner option", "4. Return to main menu" };
        private bool ExitAddRemoveMenu = false;
        public void DoMenuStuff(ref PreLoadMeals LoadedMeals)
        {
            do
            {
                ExitAddRemoveMenu = false;
                string addRemoveInput = AskForUserInputWithMenu("What would you like to do?", "noMessage", AddRemoveOptions,"integerOnly",true,false,false,AddRemoveOptions.Count());
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
                        newMealName = AskForUserInput("What is the name of the meal being added?","alphaNumeric");
                        numberInput = AskForUserInput("How many minutes of prep work for this meal?","integerOnly");
                        prepTime = Int32.Parse(numberInput);
                        numberInput = AskForUserInput("How many minutes of cooking time is required for this meal?","integerOnly");                        
                        cookTime = Int32.Parse(numberInput);
                        bool anotherEntry = true;
                        do
                        {
                            ingCounter++;
                            mealIngredient = AskForUserInput($"Please enter ingredient {ingCounter}. Enter stop if done.","alphaNumeric");
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
                            numberInput = AskForUserInputWithMenu("Which meal would you like to remove?", "noMessage", ref LoadedMeals,"integerOnly",false,true,true,LoadedMeals.CountOfRemainingMeals() + 1);
                            if (Convert.ToInt32(numberInput) <= LoadedMeals.CountOfRemainingMeals())
                            {
                                LoadedMeals.AvailableDinnerIdeas.RemoveAt(Int32.Parse(numberInput) - 1);
                                Console.Clear();
                                if (LoadedMeals.CountOfRemainingMeals() > 0)
                                {
                                    DisplayMenu("Meal removed.\nRemaining meal options:", "noMessage", ref LoadedMeals, false);
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
                        UpdateMenu updateMenu = new UpdateMenu();
                        updateMenu.DoMenuStuff(ref LoadedMeals);
                        break;
                    case 4:
                        ExitAddRemoveMenu = true;
                        break;
                }
            } while (!ExitAddRemoveMenu);
        }

    }
    public class UpdateMenu : Menu
    {
        private List<string> UpdateOptions = new List<string> { "1. Update meal name", "2. Update meal prep time", "3. Update meal cook time", "4. Update Ingredients", "5. Add Ingredient", "6. Remove Ingredient", "7. Back to Add/Remove Menu" };
        private bool ExitUpdateOuterMenu = false;
        private bool ExitUpdateInnerMenu = false;
        public void DoMenuStuff(ref PreLoadMeals LoadedMeals)
        {
            Console.Clear();
            if (!LoadedMeals.DoIStillHaveMeals())
            {
                Console.WriteLine("You're out of meals. Please add more.");
                Console.ReadKey();
            }
            else
            {
                ExitUpdateOuterMenu = false;
                int intMealSelection;
                string strMenuSelection;
                do
                {
                    Console.Clear();
                    DisplayMenu("Which would you like to update?", "noMessage", ref LoadedMeals, true, true);
                    strMenuSelection = HandleUserInput.ReturnUserInput("integerOnly", false, LoadedMeals.CountOfRemainingMeals() + 1);
                    intMealSelection = Convert.ToInt32(strMenuSelection)-1;
                    if (intMealSelection < LoadedMeals.CountOfRemainingMeals())
                    {
                        do
                        {
                            Console.Clear();
                            DisplayMenu("What would you like to update?", "noMessage", UpdateOptions);
                            strMenuSelection = HandleUserInput.ReturnUserInput("integerOnly", true, UpdateOptions.Count());
                            string strTempInput;
                            Console.Clear();
                            switch (Convert.ToInt32(strMenuSelection))
                            {
                                case 1:
                                    Console.WriteLine($"Current meal name:{LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetMealName()}\nEnter new meal name");
                                    strTempInput = HandleUserInput.ReturnUserInput("alphaNumeric");
                                    LoadedMeals.AvailableDinnerIdeas[intMealSelection].SetMealName(strTempInput);
                                    break;
                                case 2:
                                    Console.WriteLine($"Current prep time:{LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetPrepTime()}\nEnter new prep time");
                                    strTempInput = HandleUserInput.ReturnUserInput("integerOnly");
                                    LoadedMeals.AvailableDinnerIdeas[intMealSelection].SetPrepTime(Convert.ToInt32(strTempInput));
                                    break;
                                case 3:
                                    Console.WriteLine($"Current cook time:{LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetCookTime()}\nEnter new cook time");
                                    strTempInput = HandleUserInput.ReturnUserInput("integerOnly");
                                    LoadedMeals.AvailableDinnerIdeas[intMealSelection].SetCookTime(Convert.ToInt32(strTempInput));
                                    break;
                                case 4:
                                    bool doneWithIngredientUpdates = false;
                                    int ingredientToUpdate;
                                    do
                                    {
                                        Console.Clear();
                                        DisplayMenu("Which ingredient needs to be updated?", "", LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients, true, true);
                                        strTempInput = HandleUserInput.ReturnUserInput("integerOnly", false, LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Count() + 1);
                                        ingredientToUpdate = Convert.ToInt32(strTempInput) - 1;
                                        if (ingredientToUpdate < LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Count())
                                        {
                                            Console.WriteLine($"Current Ingredient: {LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients[ingredientToUpdate]}\nEnter the new ingredient");
                                            strTempInput = HandleUserInput.ReturnUserInput("alphaNumeric");
                                            LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients[ingredientToUpdate] = strTempInput;
                                            bool anotherIngredient = false;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Would you like to update another ingredient? (y/n)");
                                                strTempInput = HandleUserInput.ReturnUserInput("alphaOnly", true);
                                                if (strTempInput.ToLower() == "n")
                                                {
                                                    anotherIngredient = true;
                                                    doneWithIngredientUpdates = true;
                                                }
                                                else if (strTempInput.ToLower() != "y")
                                                {
                                                    Console.WriteLine("Let's not get fancy, champ. Just give me a y or n. I'd even take Y or N.");
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
                                    Console.WriteLine("What is the new ingredient?");
                                    strTempInput = HandleUserInput.ReturnUserInput("alphaNumeric");
                                    LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Add(strTempInput);
                                    Console.WriteLine($"{strTempInput} has been added to {LoadedMeals.AvailableDinnerIdeas[intMealSelection].GetMealName()}");
                                    Console.ReadKey();
                                    break;
                                case 6:
                                    DisplayMenu("Which ingredient needs to be removed?", "", LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients, true, true);
                                    strTempInput = HandleUserInput.ReturnUserInput("integerOnly", false, LoadedMeals.AvailableDinnerIdeas[intMealSelection].Ingredients.Count() + 1);
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
        }
    }


