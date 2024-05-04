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
    public static bool CanIMoveThisWay(MoveDirection thisWay, Location currentLocation, int currentPlayerLevel)
    {
        //var testSouth = (MoveDirection)4;
        if (currentLocation.RoomHash == 112804 && currentPlayerLevel < 10 && thisWay == MoveDirection.South)
        {
            return false;
        }
        else
        {
            if (((MoveDirection)currentLocation.EnumMovementOptions & thisWay) == thisWay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public static bool MovePlayer(int currentRoomHash, int newRoomHash, Location newLocation)
    {
        return true;
    }
}