namespace Project1.Models;

public interface IMonsterStorage
{
    public Dictionary<int, MonsterData> GetMonsterList();

    public void FirstEverMonsterFileCreation();
}