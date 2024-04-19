namespace FirstFridayGroupProject;

class Program
{
    static void Main()
    {
        bool exitProgram = false;
        int myAge = 0;
        string myAgeStr;
        do
        {
            //Console.Clear();
            Console.WriteLine("Please select what you would like to do");
            Console.WriteLine("1. First Option");
            Console.WriteLine("2. Exit Program");
            try
            {
                int menuSelection = Convert.ToInt32(Console.ReadLine());
                switch(menuSelection)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Congratulations on properly selecting a menu option!");
                        do
                        {
                            Console.WriteLine("How old are you?");
                             myAgeStr = Console.ReadLine();
                             if(Int32.TryParse(myAgeStr, out myAge))
                            {  
                                Console.WriteLine($"So noted.  You are {myAge} years old.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                            }else
                            {
                                Console.WriteLine($"{myAgeStr} wasn't a valid whole number. Try again");
                            }
                        }while(!Int32.TryParse(myAgeStr, out myAge));
                        break;
                    case 2:
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
}
