namespace Project1.Models;

public interface ILevelStorage
{
    public Dictionary<int,LevelChange> GetLevelList();

    public void CreateLevelFile();
}