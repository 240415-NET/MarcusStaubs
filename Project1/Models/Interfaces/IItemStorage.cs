namespace Project1.Models;

public interface IItemStorage
{
    public ItemDTO getAllMyItems();

    public void CreateInitialItemsList();
}