namespace Project1.Controllers;

using Project1.Models;

[Flags]
public enum MoveDirection
{
    North = 1,
    East = 2,
    South = 4,
    West = 8
}

public static class Movement
{
    public static bool CanIMoveThisWay(int direction, int locationOptions, int currentLocation, int currentPlayerLevel)  
    {
        if (currentLocation == 112804 && currentPlayerLevel < 10 && direction == 4)  
        {
            return false;
        }
        else
        {
            if (((MoveDirection)locationOptions & (MoveDirection)direction) == (MoveDirection)direction)  
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}