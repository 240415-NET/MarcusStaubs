namespace Project1.Models;

public interface ILocationStorage
{
    public  Dictionary<int, Location> GetLocationsList();

    public void CreateLocationFile();
}