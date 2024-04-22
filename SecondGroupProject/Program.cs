using System.Text.RegularExpressions;

namespace FirstFridayGroupProject;

class Program
{
    static void Main()
    {
        bool exitProgram = false;
        string[] mealOptions = new string[7];
        bool mealsChosen = false;
        //prefill variables
        //string[] mealOptions = {"Steak","Eggs","Toast","Steak and Eggs","Steak and Toast","Eggs and Toast","Steak and Eggs and Toast"}; mealsChosen = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Please select what you would like to do");
            if(!mealsChosen)
            {
                Console.WriteLine("G: Gimme Meal Options");
            }
            if (mealsChosen)
            {
                Console.WriteLine("U: Update Meal Options");
                if(!HaveWeCookedEverything(mealOptions))
                {
                Console.WriteLine("W: What's for dinner?");
                Console.WriteLine("R: What is still on the menu?");
                }
                else
                {
                    Console.WriteLine("W: We used everything. Please update the list");
                }
            }
            Console.WriteLine("X: Exit Program");
            try
            {
                string strMenuSelection = Console.ReadLine().Trim().ToUpper();
                switch(strMenuSelection)
                {
                    case "G":
                        Console.Clear();
                        Console.WriteLine("Please enter your dinner ideas.  We're gonna need 7 of them.");
                        if(!mealsChosen)
                        {
                            string mealSelection;
                            bool exitCondition = false;
                            //int i;
                            for(int i=0;i<7;i++)
                            {
                                exitCondition = false;
                                do
                                {
                                    Console.WriteLine($"What is meal option {i+1}?");
                                    mealSelection = Console.ReadLine().Trim();
                                    if(!IsJustAlpha(mealSelection))
                                    {
                                        Console.WriteLine($"{mealSelection} doesn't look like a meal idea. Stick to letters.");
                                    }
                                    else
                                    {
                                        mealOptions[i] = mealSelection;
                                        exitCondition = true;
                                    }
                                }while(exitCondition==false);
                            }
                            mealsChosen = true;
                        }
                        break;
                    case "U":
                        if(mealsChosen)
                        {
                            Console.Clear();
                            UpdateDinnerOptions(ref mealOptions);
                        }    
                        break;
                    case "W":
                        if(mealsChosen && !HaveWeCookedEverything(mealOptions))
                        {
                            Console.Clear();
                            int cookedMeal = LetRNGDecideDinner(mealOptions);
                            mealOptions[cookedMeal] = mealOptions[cookedMeal] + " - used";
                        }
                        break;
                    case "R":
                        Console.Clear();
                        WhatsStillOnTheMenu(mealOptions);
                        break;
                    case "X":
                        exitProgram = true;
                        break;  
                    default:
                        Console.WriteLine("That wasn't an option. Try again.");
                        break;
                }
            }
            catch (Exception e)
            {
                bool didUserRespCorrectly = false;
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("Please enter a valid whole number.");
                do
                {
                    Console.WriteLine("Do you want to try again? (y/n)");
                    string userResp = Console.ReadLine();
                    if(String.IsNullOrEmpty(userResp) || (userResp.ToUpper() != "Y" && userResp.ToUpper() != "N"))
                    {
                        Console.WriteLine("You have to give me either a y or n response");
                    }else if (userResp.ToUpper() == "N")
                    {
                        exitProgram = true;
                        didUserRespCorrectly = true;
                    }else
                    {
                        Console.Clear();
                        didUserRespCorrectly = true;
                    }

                }while(didUserRespCorrectly == false);
                
            }
        }while(exitProgram==false);

    }
    public static void UpdateDinnerOptions(ref string[] mealArray)
    {
        int optionToUpdate;
        string strOption;
        bool iSaidSo = true;
        bool haveTheyAnsweredAboutReset = false;
        bool doneUpdating = false;
        do
        {
            if(HaveWeCookedEverything(mealArray) && !haveTheyAnsweredAboutReset)
            {
                Console.WriteLine("Do you want to just keep the current options again?");
                string strKeepOptions = Console.ReadLine();
                if(strKeepOptions.ToUpper() != "Y" && strKeepOptions.ToUpper() != "N")
                {
                    Console.WriteLine("That was a yes or no question and I'm expecting a y or n answer.");
                }
                else if(strKeepOptions.ToUpper() == "Y")
                {
                    for(int i=0;i<7;i++)
                    {
                        mealArray[i] = mealArray[i].Replace("- used","").Trim();
                    }
                    Console.WriteLine("All of your meal options have been used.");
                    iSaidSo = false;
                }
                else
                {
                    haveTheyAnsweredAboutReset = true;
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Current meal options:");
                for(int i=0;i<7;i++)
                    {
                        Console.WriteLine($"{i+1}: {mealArray[i]}");
                    }
                    do
                    {
                        Console.WriteLine("Which option do you want to change?");
                        strOption = Console.ReadLine().Trim();
                        try
                        {
                            
                            optionToUpdate = Convert.ToInt32(strOption)-1;
                            bool getItRight = false;
                            do
                            {
                                Console.WriteLine($"What would you like to put in place of {mealArray[optionToUpdate]}?");
                                string strUserInput = Console.ReadLine();
                                if(!IsJustAlpha(strUserInput))
                                {
                                    Console.WriteLine("Let's just stick to our words. Give me the name of a meal you might want to eat.");
                                }
                                else
                                {
                                    mealArray[optionToUpdate] = strUserInput;
                                    getItRight = true;
                                }
                            }while(!getItRight);
                        Console.WriteLine("Would you like to update another meal? (y/n)");
                        string strUpdateAnother = Console.ReadLine();
                        if(strUpdateAnother.ToUpper() != "N" && strUpdateAnother.ToUpper() != "NO")
                        {
                            Console.WriteLine("That wasn't a no, so let's keep going!");
                            doneUpdating = true;
                        }
                        else
                        {
                            doneUpdating = true; iSaidSo = false;
                        }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Enter a number. A whole number. Between 1 and 7...");
                        }
                    }while(!doneUpdating);
            }                
        }while(iSaidSo);
    }

    public static void WhatsStillOnTheMenu(string[] optionsLeft)
    {
        Console.WriteLine("The following options are still left:");
        foreach(string option in optionsLeft)
        {
            if(!option.Contains("- used"))
            {
                Console.WriteLine(option);
            }
        }
        Console.ReadKey();
    }
    public static int LetRNGDecideDinner(string[] dinnerOptions)
    {
        bool foundOne = false;
        Random rnd = new Random();
        int chosenMeal;
        do
        {
            chosenMeal = rnd.Next(0,7);
            if(!dinnerOptions[chosenMeal].Contains("used"))
            {
                foundOne = true;
            }
        }while(!foundOne);
        Console.WriteLine($"Tonight will be {dinnerOptions[chosenMeal]}!");
        Console.ReadKey();
        return chosenMeal;
    }

    public static bool HaveWeCookedEverything(string[] dinnerOptions)
    {
        bool allCooked = true;
        //int i = 0;
        foreach(string dinnerOption in dinnerOptions)
        {
            //Console.WriteLine($"Checked {dinnerOptions[i]}.");
            //i++;
            if (!dinnerOption.Contains("used"))
            {
                allCooked = false;
            }
        }
        return allCooked;
    }
    public static bool IsJustAlpha(string testMe)
    {
        string pattern;
        pattern = "^(?=.*[a-zA-Z ])[A-Za-z ]+$";
        //^ start of the string
        //(?=.*[a-zA-Z ]) alpha characters from a-z, A-Z, or a space
        //[A-Za-z ] everything is either alpha character or a space
        //+ one or more times
        //$ end of the string

        if (String.IsNullOrEmpty(testMe.Trim()))
        //trim to remove leading and trailing spaces and ensure there is something besides a space or spaces
        {
            return false;
        }else
        {
            Match m = Regex.Match(testMe,pattern);
            if (m.Success)
            {
                return true;
            }else
            {
                return false;
            }
        } 
    }
}


