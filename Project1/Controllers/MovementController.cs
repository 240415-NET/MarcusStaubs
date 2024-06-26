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
    public static bool CanIMoveThisWay(int direction, int locationOptions, int currentLocation, int currentPlayerLevel, string weaponID, List<Weapon> weaponInventory)
    {
        bool hasCoolSword = false;
        if (currentLocation == 112804 && currentPlayerLevel < 10 && direction == 4)
        {
            return false;
        }
        else if (currentLocation == 106801 && direction == 1 && weaponID == "weapon4")
        {
            foreach (Weapon weapon in weaponInventory)
            {
                if (weapon.ItemID == "weapon20")
                {
                    hasCoolSword = true;
                }
            }
            if (hasCoolSword)
            {
                return false;
            }
            else
            {
                return true;
            }
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