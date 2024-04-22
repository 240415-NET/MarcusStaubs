using System;
using System.Text.RegularExpressions;

namespace FirstFridayGroupProject;

class Program
{
    static void Main()
    {
        bool exitProgram = false;  //Flag to exit the program
        bool iKnowYou = false;  //Flag to indicate if user info has already been provided
        int menuLoop = 0;  //How many times has the user tried to enter a value since the last correct entry
        int correctChoice = 0;  //How many times has the user correctly entered a menu option
        int wrongChoice = 0;  //How many times has the user incorrectly entered a menu option
        //default user if the program get frustrated otherwise repopulated with the user input
        Person whoDis = new Person("Linus", "Torvalds", "Software Developer, Scientist, and Software Engineer", 54, 150000.00);  

        do
        {
            if(iKnowYou)
            {
                Console.WriteLine($"Hello, {whoDis.FullName()}! How can I help you today?");
            }else
            {
                Console.WriteLine("Please select what you would like to do");
            }
            Console.WriteLine("1. Tell me about yourself");
            Console.WriteLine("2. Have some Fizzbuzz");
            Console.WriteLine("3. Money talk");
            Console.WriteLine("4. Exit Program");
            //attempt to get user input
            try
            {
                int menuSelection = Convert.ToInt32(Console.ReadLine());
                switch(menuSelection)
                {
                    case 1:
                        iKnowYou = LearnAboutTheUser(iKnowYou,ref whoDis);
                        Console.ReadKey();
                        Console.Clear();
                        correctChoice++; menuLoop = 0;
                        break;
                    case 2:
                        if(iKnowYou)
                        {
                            FizzBuzz(whoDis.GetAge());
                        }else
                        {
                            FizzBuzz();
                        }
                        correctChoice++; menuLoop = 0;
                        break;
                    case 3:
                        if(iKnowYou)
                        {
                            LetsTalkMoney(ref whoDis);
                        }else
                        {
                            Console.WriteLine("We should get to know each other before we start talking money.");
                            Console.WriteLine("I mean, I don't even know your mother's maiden name or your SSN yet.");
                            Console.WriteLine("Not that I'm going to ask for either of those. Probably. You can totally trust me.");
                            Console.WriteLine("Maybe.");
                            Console.ReadKey();
                            Console.WriteLine("No, you can. You can absolutely trust me.");
                            Console.WriteLine("But seriously, you should take a minute and tell me a little about yourself. Use option 1 from the menu.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        correctChoice++; menuLoop = 0;
                        break;
                    case 4:
                        exitProgram = true;
                        break;  
                    default:
                        if (menuLoop <=1)
                        {
                            Console.Clear();
                            Console.WriteLine("That wasn't an option. Try again.");
                        }else if(menuLoop <=4)
                        {
                            Console.Clear();
                            Console.WriteLine($"Do you see {menuSelection} as an option there?  Try 1, 2, 3, or 4.");
                        }else
                        {
                            Console.Clear();
                            Console.WriteLine($"Ok, you have failed this {wrongChoice} times. {menuLoop} in a row.  I quit. Go away.");
                            exitProgram = true;
                        }
                        wrongChoice++; menuLoop++;
                        break;

                }
            }
            catch (Exception e)
            {
                wrongChoice++; menuLoop++;
                Console.Clear();
                Console.WriteLine($"{e.Message}");
                if (menuLoop <=1)
                {
                    Console.WriteLine("Please enter a valid whole number.");
                }else if(menuLoop <=4)
                {
                    Console.WriteLine($"That isn't even a number. Your options are 1, 2, 3, or 4. It's right there on the screen. I don't know how to be clearer about this.");
                }else
                {
                    Console.WriteLine($"{wrongChoice} times. I give up. You should not be trying to use this application. Bye!");
                    exitProgram = true;
                }
                
            }
        }while(exitProgram==false);
    }

    static void FizzBuzz(int givenAge = 0)
    {
        string userRespStr = "";
        int maxFizzToBuzz;
        bool firstExitCondition = false;
        int loopCounter = 0;
        bool forceNumber = false;

        Console.Clear();
        do
        {
            if(forceNumber==false)
            {
                Console.WriteLine("How high do you want me to go with this?");
                userRespStr = Console.ReadLine();
            }    
            if((String.IsNullOrEmpty(userRespStr) || !Int32.TryParse(userRespStr, out maxFizzToBuzz)) && forceNumber == false)
            {
                if (loopCounter <= 2)
                {
                    Console.WriteLine("I'm asking for a number, you have to give me something to work with here. Try again");
                }else if (loopCounter > 2 && loopCounter < 5)
                {
                    Console.WriteLine("Do you know what a whole number is? Something like 1 or 2 or 412,874... Try again (but don't pick 412,874)");
                }else
                {
                    if(givenAge==0)
                    {
                        Console.WriteLine("I guess you really don't know how to enter a number. I'm picking for you. 42 it is.");
                        userRespStr = "42";
                        forceNumber=true;
                    }else
                    {
                        Console.WriteLine($"I guess you really don't know how to enter a number. You said, or I made up, that you are {givenAge} years old so let's go with {givenAge}.");
                        Console.ReadKey();
                        userRespStr = givenAge.ToString();
                        forceNumber=true;
                    }
                }    
                loopCounter++;
            }else
            {
                 Int32.TryParse(userRespStr,out maxFizzToBuzz);
                if(maxFizzToBuzz <=0)
                {
                    Console.WriteLine("I probably should have been clearer. Enter a positive whole number.  No negatives and no 0.");
                }else if (maxFizzToBuzz == 412874 && loopCounter > 2)
                {
                    Console.WriteLine("I specifically said not to pick 412,874...");
                }else if(maxFizzToBuzz > 200)
                {
                    Console.WriteLine("Let's not go over 200.  That's a lot of lines.  You don't want to read that many and I don't want to generate that many.");
                }else
                {
                    firstExitCondition = true;
                    for(int i=1; i<=maxFizzToBuzz;i++)
                    {
                        if (i%5==0 && i%3==0)
                        {
                            Console.WriteLine("FizzBuzz");
                        }else if (i%3==0)
                        {
                            Console.WriteLine("Fizz");
                        }else if (i%5==0)
                        {
                            Console.WriteLine("Buzz");
                        }else
                        {
                            Console.WriteLine(i);
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }while(firstExitCondition==false);
    }
    public static bool LearnAboutTheUser(bool iAlreadyKnowYou, ref Person passedPerson)
    {
        string strFirstName = "";
        string strLastName = "";
        int intAge = 0;
        string strAge = "";
        string strJob = "";
        double dblInvestMent = 0;
        string strInvestment = "";
        bool exitLoop = false;
        int loopCounter = 0;
        bool tiredOfMistakes = false;
        

        if(iAlreadyKnowYou)
        {
            Console.WriteLine("You already told me about yourself. You only get to be one person at a time.");
            Console.ReadKey();
            return true;
        }else
        {
            Console.Clear();
            while(exitLoop == false && tiredOfMistakes == false)
            {
                Console.WriteLine("What is your first name?");
                strFirstName = Console.ReadLine();
                if(!IsJustAlpha(strFirstName))
                {
                    loopCounter++;
                    if (loopCounter <=3)
                    {
                        Console.WriteLine("Your name has to have some letters and can't include any numbers or special characters...");
                    }else if(loopCounter <= 6)
                    {
                        tiredOfMistakes = true;
                    }
                }else
                {
                    exitLoop = true;
                }
            };
            exitLoop = false;
            while(exitLoop == false && tiredOfMistakes == false)
            {
                Console.WriteLine("What is your last name?");
                strLastName = Console.ReadLine();
                if(!IsJustAlpha(strLastName))
                {
                    loopCounter++;
                    if (loopCounter <=3)
                    {
                        Console.WriteLine("Your name has to have some letters and can't include any numbers or special characters...");
                    }else if(loopCounter <= 6)
                    {
                        tiredOfMistakes = true;
                    }                    
                }else
                {
                    exitLoop = true;
                }
            };
            exitLoop = false;
            while(exitLoop == false && tiredOfMistakes == false)
            {
                Console.WriteLine("How old are you?");
                strAge = Console.ReadLine();
                if(!CanConvertToNumber(strAge,"int"))
                {
                    loopCounter++;
                    if (loopCounter <=3)
                    {
                        Console.WriteLine("Age is nothing but a number, give me a whole number...");
                    }else if(loopCounter <= 6)
                    {
                        tiredOfMistakes = true;
                    }                        
                }else
                {
                    intAge = Convert.ToInt32(strAge);
                    exitLoop = true;
                }
            };
            exitLoop = false;
            while(exitLoop == false && tiredOfMistakes == false)
            {
                Console.WriteLine("What is your job title?");
                strJob = Console.ReadLine();
                if(String.IsNullOrEmpty(strJob))
                {
                    loopCounter++;
                    if (loopCounter <=3)
                    {
                        Console.WriteLine("You have to put something here... Just make something up if you're embrassed to tell me the truth.");
                    }else if(loopCounter <= 6)
                    {
                        tiredOfMistakes = true;
                    }                        
                }
                //else if(!IsJustAlpha(strJob,false))
                //{
                //    Console.WriteLine("You shouldn't need anything other than letters, numbers, or spaces.  Try again.");
                //}
                else
                {
                    exitLoop = true;
                }
            };
            exitLoop = false;
            while(exitLoop == false && tiredOfMistakes == false)
            {
                Console.WriteLine("I found a way to make some money. How much do you want to invest?");
                strInvestment = Console.ReadLine();
                if(!CanConvertToNumber(strInvestment,"double"))
                {
                    loopCounter++;
                    if (loopCounter <=3)
                    {
                        Console.WriteLine("That... that isn't a number. I need a number and no dollar sign, I've got that part taken care of.");
                    }else if(loopCounter <= 6)
                    {
                        tiredOfMistakes = true;
                    }                        
                }else
                {
                    dblInvestMent = Convert.ToDouble(strInvestment);
                    if(dblInvestMent <=0)
                    {
                        Console.WriteLine($"C'mon, {dblInvestMent.ToString("C")}? This is a super safe investment probably so you should pick something.");
                    }else if(dblInvestMent < 100)
                    {
                        Console.WriteLine($"{dblInvestMent.ToString("C")}? You can't even do $100.00? You can trust me, I promise!");
                    }else
                    {
                        exitLoop = true;
                    }
                }
            };
            if(tiredOfMistakes)
            {
                Console.Clear();
                Console.WriteLine("You really aren't getting the concept of entering information are you?");
                Console.WriteLine("I'm just going to make some stuff up.");
                Console.WriteLine($"Your name is now {passedPerson.FullName()}.");
                Console.WriteLine($"You are a {passedPerson.GetAge()} year old {passedPerson.GetJob()}.");
                Console.WriteLine($"And you've decided to let me invest {passedPerson.GetInvestment().ToString("C")}. Thank you!");
                Console.ReadKey();
            }else
            {      
                passedPerson.SetFirstName(strFirstName);
                passedPerson.SetLastName(strLastName);
                passedPerson.SetJob(strJob);
                passedPerson.SetAge(intAge);
                passedPerson.SetInvestment(dblInvestMent);
            }
            Console.WriteLine($"Great to meet you, {passedPerson.FullName()}!");
            return true;
        }
    }
    public static void LetsTalkMoney(ref Person passedPerson)
    {
        Console.Clear();
        if(passedPerson.GetInvestment()>0)
        {
            Console.WriteLine("Ok, so I know of an investment opportunity where we can get you 4% interest compounded monthly.");
            Console.WriteLine("I know that might not sound like much, but it is totally risk free and check out these numbers!");
            Console.WriteLine($"If we take your {passedPerson.GetInvestment().ToString("C")} and invest it for 1 year, you'll get: {passedPerson.CalculateCompoudInterest(1,.04).ToString("C")}");
            Console.WriteLine($"If you leave it there for 5 years, you'll have: {passedPerson.CalculateCompoudInterest(5,.04).ToString("C")}");
            Console.WriteLine($"And in just 10 short years, you'll have: {passedPerson.CalculateCompoudInterest(10,.04).ToString("C")}");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You're right, that's too slow and we want some money now. Let's risk it all on a coin toss.  Double or nothing!");
            while(passedPerson.GetInvestment()>0)
            {
                Console.WriteLine("Flip it!");
                Console.ReadKey();
                passedPerson.GambleWithMyMoney();
            }
        }else
        {
            Console.WriteLine("Sorry, you don't have any money left to talk about.");
            Console.ReadKey();
        }
    }
    public class Person
    {
        //class properties
        private string firstName {get; set;}
        private string lastName {get; set;}
        private string jobTitle {get; set;}
        private int age {get; set;}
        private double investmentCapital {get; set;}

        //class constructor which requires all fields to be provided
        public Person(string myFirstName, string myLastName, string job, int myAge, double myInvestment)
        {
            firstName = myFirstName;
            lastName = myLastName;
            jobTitle = job;
            age = myAge;
            investmentCapital = myInvestment;
        }

        //methods to get or set the properties of the class after it has been intantiated or to perform some functions using those properties
        public string FullName()
        {
            return firstName + " " + lastName;
        }
        public void SetFirstName(string name)
        {
            firstName = name;
        }
        public void SetLastName(string name)
        {
            lastName = name;
        }        
        public string GetJob()
        {
            return jobTitle;
        }
        public void SetJob(string job)
        {
            jobTitle = job;
        }
        public int GetAge()
        {
            return age;
        }
        public void SetAge(int myAge)
        {
            age = myAge;
        }
        public double GetInvestment()
        {
            return investmentCapital;
        }
        public void SetInvestment(double investmentAmount)
        {
            investmentCapital = investmentAmount;
        }
        public double CalculateCompoudInterest(int numYears, double interestRate)
        {
            double resultAfterInterest;
            resultAfterInterest = investmentCapital * (Math.Pow(((1+(interestRate/12))),(12*numYears)));
            return resultAfterInterest;
        }
        public void GambleWithMyMoney()
        {
            Random rnd = new Random();
            int resultNum = rnd.Next(0,100);
            if(resultNum<50)
            {
                SetInvestment(investmentCapital*2);
                Console.WriteLine($"Wooo!! You won! You now have {investmentCapital.ToString("C")}");
                SetInvestment(investmentCapital*.9);
                Console.WriteLine($"I'm only going to take 10% since I helped so now you have {investmentCapital.ToString("C")}");
            }else
            {
                SetInvestment(0);
                Console.WriteLine("Sorry, you lost that one and the house (totally not me) wins and takes all of your money. You have no money left.");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }

    public static bool IsJustAlpha(string testMe, bool justAlpha = true)
    {
        string pattern;
        if(justAlpha)
        {
            pattern = "^(?=.*[a-zA-Z ])[A-Za-z ]+$";
            //^ start of the string
            //(?=.*[a-zA-Z ]) alpha characters from a-z, A-Z, or a space
            //[A-Za-z ] everything is either alpha character or a space
            //+ one or more times
            //$ end of the string
        }else
        {
            pattern = "^(?=.*[a-zA-Z ])(?=.*[0-9])[0-9A-Za-z ]+$";
        }
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

    public static bool CanConvertToNumber(string testMe, string convertType)
    {
        int testerInt;
        bool validToConvert;
        double testerDouble;
        if(convertType == "int")
        {
            try
            {
                testerInt = Convert.ToInt32(testMe);
                validToConvert = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                validToConvert = false;
            }
        }else
        {
            try
            {
                testerDouble = Convert.ToDouble(testMe);
                validToConvert = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                validToConvert = false;
            }
        }
        return validToConvert;

    }
}
