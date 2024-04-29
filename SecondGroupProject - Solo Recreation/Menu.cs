using FirstFridayGroupProject.JsonHandle;
using FirstFridayGroupProject.Dinner;
using FirstFridayGroupProject.HandleUserInputs;

namespace FirstFridayGroupProject.Menus;

public class Menu()
{
    private List<string> MenuOptions = new List<string>(); // { "1. I didn't code this", "2. I've clearly messed up", "3. You should just quit now", "4. Exit" };
    private static bool exitProgram = false;
    public Menu(List<string> menuOptions) : this()
    {
        this.MenuOptions = menuOptions;
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
        return strUserInput;
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





