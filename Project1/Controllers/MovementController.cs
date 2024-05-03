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
        public static bool CanIMoveThisWay(MoveDirection thisWay, int moveOptions)
        {
            if(((MoveDirection)moveOptions & thisWay) == thisWay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }