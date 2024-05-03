using Project1.Models;
using Project1.Data;

namespace Project1.Controllers;

public static class LocationController
{
    public static Dictionary<int,Location> InitializeLocations()
    {
        return LocationStorage.GetLocationsList();
    }

}