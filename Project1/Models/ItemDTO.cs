namespace Project1.Models;

public class ItemDTO
{
    public List<Item> Items {get;set;}
    public List<Weapon> Weapons {get; set;}
    public List<Armor> Armors {get;set;}
    public List<Potion> Potions {get;set;}

    public ItemDTO()
    {
        Items = new List<Item>();
        Weapons = new List<Weapon>();
        Armors = new List<Armor>();
        Potions = new List<Potion>();
    }
    public ItemDTO(List<Item> allItems, List<Weapon> allWeapons, List<Armor> allArmors, List<Potion> allPotions)
    {
        this.Items = allItems;
        this.Weapons = allWeapons;
        this.Armors = allArmors;
        this.Potions = allPotions;
    }
}