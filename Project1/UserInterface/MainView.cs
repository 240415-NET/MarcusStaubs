using Project1.Models;
using Project1.Controllers;

namespace Project1.UserInterfaces;

public static class CurrentLocation
{
    public static void DisplayCurrentLocation(int roomHash)
    {
        //look up location info using roomhash from currentPlayer
        Console.WriteLine("Location Name:");
        Console.WriteLine("Location description which may be long or kinda short.  Multiple lines maybe but in one string so maybe a split in a loop or something?");
        Console.WriteLine();
        Console.WriteLine($"You can View your character, Rest, or move in the following direction(s): (MoveDirection)EnumMovementOptions");
        //Accept and validate User Input
        //If View Character - call PlayerView
        //If Rest, use method in Player Controller and pass in chance to spawn monster from room info (maybe pass the monster type list as well?)
        //If Move, send the direction to the move controller to see if it is an option
        //Valid options for input.ToLower(): v,view ; r,rest ; n, north, e,east, s,south, w, west
    }
}
