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

        Console.WriteLine("Welcome to hangman, let's start a new game!");
        string puzzleAnswer = GetThePuzzleString();
        char[] charsInPuzzle = firstTest.ToCharArray();
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
            Console.WriteLine("Guess a letter!");
            currentGuess = Console.ReadLine();
            guessesMade = guessesMade + " " + currentGuess;
            if(!DidIGetOne(currentGuess,ref charsInPuzzle,ref puzzleDisplay,firstTest,wrongGuesses))
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
    public static string GetThePuzzleString()
    {
        string puzzleString="";

        return puzzleString;
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
