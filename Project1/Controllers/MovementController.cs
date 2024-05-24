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
    public static bool CanIMoveThisWay(int direction)
    {
        bool hasCoolSword = false;
        if (GameSession.currentPlayer.CurrentLocation == 112804 && GameSession.currentPlayer.PlayerLevel < 10 && direction == 4)
        {
            return false;
        }
        else if (GameSession.currentPlayer.CurrentLocation == 106801 && direction == 1 && GameSession.currentPlayer.EquippedWeaponID == "weapon4")
        {
            foreach (PlayerInventoryWeapon weapon in GameSession.currentPlayer.InventoryWeapons)
            {
                if (weapon.WeaponID == "weapon20")
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
            if (((MoveDirection)GameSession.locationReference[GameSession.currentPlayer.CurrentLocation].EnumMovementOptions & (MoveDirection)direction) == (MoveDirection)direction)
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