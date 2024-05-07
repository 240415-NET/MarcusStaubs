namespace Project1.Models;

public interface IMapStorage
{
    public List<string> GetGameMap();

    public void InitializeGameMap();
}