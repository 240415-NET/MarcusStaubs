using System.Collections;
using System.Net;

namespace HangMan;

class Program
{
    static void Main(string[] args)
    {
        bool stillPlaying = true;
        string[] hangBoard = {"-----|","|","|","|","|","----------"};
        string firstTest = "So long and thanks for all the fish";
        string guessesMade = "";
        string currentGuess = "";
        int wrongGuesses = 0;
        bool didYouWin = false;
        bool validInput = false;
        List<string> myPuzzles = new();

        Console.WriteLine("Welcome to hangman, let's start a new game!");
        LoadThePuzzleString(ref myPuzzles);
        string puzzleAnswer = GetANewPuzzle(ref myPuzzles);
        char[] charsInPuzzle = puzzleAnswer.ToCharArray();
        char[] puzzleDisplay = new char[charsInPuzzle.Count()];
        for(int i=0;i<charsInPuzzle.Count();i++)
        {
            if(Char.IsLetter(charsInPuzzle[i]))
            {
                puzzleDisplay[i] = '_';
            }
            else
            {
                puzzleDisplay[i] = charsInPuzzle[i];
            }
        }
        ShowHangmanStatus(ref hangBoard, ref puzzleDisplay,guessesMade);
        do
        {
            validInput = false;
            Console.WriteLine("Guess a letter!");
            do
            {
                currentGuess = Console.ReadLine();
                if(String.IsNullOrEmpty(currentGuess))
                {
                    Console.WriteLine("That wasn't anything. Enter a letter.");
                }
                else if(currentGuess.Count()>1)
                {
                    Console.WriteLine("No! Enter. A. Single. Letter.");
                }
                else if(guessesMade.ToLower().Contains(currentGuess))
                {
                    Console.WriteLine("You picked that already. Try a letter you haven't picked yet. That might be more productive...");
                }
                else if(Char.IsDigit(Convert.ToChar(currentGuess)))
                {
                    Console.WriteLine($"Yep, you caught me. The number {currentGuess} is absolutely in one of these words...");
                    Console.WriteLine("Give me a letter. Like from the alphabet. In English. Please.");
                }
                else
                {
                    validInput = true;
                }

            }while(!validInput);
            guessesMade = guessesMade + " " + currentGuess;
            if(!DidIGetOne(currentGuess,ref charsInPuzzle,ref puzzleDisplay,puzzleAnswer,wrongGuesses))
            {
                wrongGuesses++;
                ThatWasNotRight(ref hangBoard,wrongGuesses);
                if(wrongGuesses >= 6)
                {
                    stillPlaying = false;
                    didYouWin = false;
                }
            }
            else if(DidYouWin(ref puzzleDisplay))
            {
                stillPlaying = false;
                didYouWin = true;
            }
            Console.Clear();
            ShowHangmanStatus(ref hangBoard, ref puzzleDisplay,guessesMade);            
        }while(stillPlaying);
        if(didYouWin)
        {
            Console.WriteLine("Congratulations! You got it before being hanged!");
        }
        else
        {
            Console.WriteLine("Sorry, you lost. Good effort though.");
        }
        Console.ReadKey();

    }
    public static void LoadThePuzzleString(ref List<string> thePuzzles)
    {
        
        thePuzzles.Add("There are four lights");
        thePuzzles.Add("There are five lights");
        thePuzzles.Add("So long, and thanks for all the fish");
        thePuzzles.Add("I think you ought to know I'm feeling very depressed");
        thePuzzles.Add("Reality is frequently inaccurate");
        thePuzzles.Add("Here, for whatever reason, is the world. And here it stays. With me on it");
        thePuzzles.Add("Don't panic");
        thePuzzles.Add("Time is an illusion. Lunchtime doubly so");
        thePuzzles.Add("I'd far rather be happy than right any day");
        thePuzzles.Add("The ships hung in the sky in much the same way that bricks don't");
        thePuzzles.Add("We demand rigidly defined areas of doubt and uncertainty!");
        thePuzzles.Add("What's so unpleasant about being drunk? Ask a glass of water!");
        thePuzzles.Add("The best drink in existence is the Pan Galactic Gargle Blaster");
        thePuzzles.Add("Would it save you a lot of time if I just gave up and went mad now?");
        thePuzzles.Add("A towel is about the most massively useful thing an interstellar hitchhiker can have");
        thePuzzles.Add("Anyone who is capable of getting themselves made President should on no account be allowed to do the job");

    }

    public static string GetANewPuzzle(ref List<string> thePuzzles)
    {
        Random rnd = new Random();
        int myPick = rnd.Next(0,thePuzzles.Count()+1);
        string pickedPuzzle = thePuzzles[myPick];
        return pickedPuzzle;
    }
    public static bool DidYouWin(ref char[] puzzleDisplay)
    {
        bool isItOver = true;
        for(int i=0;i<puzzleDisplay.Count();i++)
        {
            if(puzzleDisplay[i]=='_')
            {
                isItOver = false;
            }
        }
        return isItOver;

    }
    public static void ShowHangmanStatus(ref string[] makeBoard,ref char[] displayPuzzle,string guessesSoFar)
    {
        foreach(string boardLine in makeBoard)
        {
            Console.WriteLine(boardLine);
        }
        Console.WriteLine(displayPuzzle);
        Console.WriteLine($"Guesses so far: {guessesSoFar}");        
    }

    public static bool DidIGetOne(string guess,ref char[] correctChars, ref char[] blankChars, string puzzleAnswer, int wrongAnswers)
    {
        char guessCharLower;
        char guessCharUpper;
        if(puzzleAnswer.ToLower().Contains(guess.ToLower()))
        {
            guessCharLower = Convert.ToChar(guess.ToLower());
            guessCharUpper = Convert.ToChar(guess.ToUpper());
            for(int i=0;i<puzzleAnswer.Count();i++)
            {
                if(puzzleAnswer[i] == guessCharLower || puzzleAnswer[i] == guessCharUpper)
                {
                    blankChars[i] = puzzleAnswer[i];
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void ThatWasNotRight(ref string[] board,int wrongAnswers)
    {
        switch(wrongAnswers)
        {
            case 1:
                board[1] = "|    O";
                break;
            case 2:
                board[2] = "|    | ";
                break;
            case 3:
                board[2] = "|   /| ";
                break;
            case 4:
                board[1] = "|    O/";
                break;
            case 5:
                board[3] = "|    / ";
                break;
            default:
                board[3] = "|    /| ";
                break;        
        }
    }
}

/*
     -----|    
     |    O/    
     |   /|   
     |    /|   
     |         
     ----------
*/

/*
     -----|
     |    
     |    
     |   
     |    
     ----------
*/
