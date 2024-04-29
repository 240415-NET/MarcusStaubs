namespace FirstFridayGroupProject.HandleUserInputs;

public class HandleUserInput()
{
    public static bool ValidateUserInput(string userInput, string validationType, bool isSingleChar = false,int limiter =0, int lowerlimit = 0)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("I asked for something and you gave me... nothing. Try again.");
            return false;
        }
        if (isSingleChar && userInput.Count() > 1)
        {
            Console.WriteLine("This should be a single character and no more. Try again.");
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
                    Console.WriteLine("This option should be a whole number. Try again.");
                    return false;
                }
                //if(limiter>0 && Convert.ToInt32(userInput) > limiter)
                if (limiter > 0 && testInt > limiter)
                {
                    Console.WriteLine($"The maximum number acceptable is {limiter} and you gave me {userInput}. Think about that and try again.");
                    return false;
                }
                else if(testInt <= lowerlimit)
                {
                    Console.WriteLine("This should be a positive whole number. Not 0, not negative. Try again.");
                    return false;
                }
                return true;
            default:
                return true;
        }
        return true;
    }
    public static string ReturnUserInput(string validationType, bool valIsSingleChar = false, int limiter = 0, int lowerlimit = 0)
    {
        string strUserInput;
        bool isValid;
        //bool keepAsking = true;
        //do
        //{
            strUserInput = (Console.ReadLine()??"").Trim();
            Console.ForegroundColor = ConsoleColor.Red;
            isValid = ValidateUserInput(strUserInput, validationType, valIsSingleChar, limiter, lowerlimit);
            Console.ResetColor();
            if (!isValid)
            {
                strUserInput = "noCurrentValidInput";
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            // else
            // {
            //     keepAsking = false;
            // }
        //}while (keepAsking);
        return strUserInput;
    }
}