using Project1.Models;
using System.Text.Json;

namespace Project1.Data;

public class ItemStorage
{
    public static readonly string itemPath = "./TempDataStorage/ItemInfo.json";
    public static void CreateInitialItemsList()
    {
        List<Item> items = new();
        Item spiderSilk = new Item("silk", "Spider Silk", 4, 1);
        items.Add(spiderSilk);
        Item rattail = new Item("tail", "Rat Tail", 3, 1);
        items.Add(rattail);
        Item ratfur = new Item("fur", "Rat Fur", 4, 1);
        items.Add(ratfur);
        Item ratpaw = new Item("paw", "Rat Paw", 6, 1);
        items.Add(ratpaw);
        Item ratfang = new Item("rfang", "Rat Fang", 6, 1);
        items.Add(ratfang);
        Item spiderfang = new Item("fang", "Spider Fang", 6, 1);
        items.Add(spiderfang);
        Item leatherscrap = new Item("scraps", "Leather Scraps", 9, 1);
        items.Add(leatherscrap);
        Item purse = new Item("purse", "Crude Purse", 12, 1);
        items.Add(purse);
        Item brkbow = new Item("bow", "Broken Bow", 15, 1);
        items.Add(brkbow);
        Item arrows = new Item("arrows", "Warped Arrows", 9, 1);
        items.Add(arrows);
        Item brkshield = new Item("shield", "Broken Shield", 15, 1);
        items.Add(brkshield);
        Item sprhead = new Item("spearhead", "Spearhead", 21, 1);
        items.Add(sprhead);
        Item roughgem = new Item("gem", "Rough Gemstone", 30, 1);
        items.Add(roughgem);
        Item herbBundle = new Item("herbs", "Bundle of Herbs", 27, 1);
        items.Add(herbBundle);
        Item cpnecklace = new Item("necklace", "Copper Necklace", 30, 1);
        items.Add(cpnecklace);


        List<Potion> potions = new();
        Potion mnrHealingPotion = new Potion("potion1", "Minor Healing Potion", 3, 1, 5, 1);
        potions.Add(mnrHealingPotion);
        Potion lssHealingPotion = new Potion("potion2", "Lesser Healing Potion", 5, 1, 10, 5);
        potions.Add(lssHealingPotion);
        Potion healingPotion = new Potion("potion3", "Healing Potion", 10, 1, 20, 10);
        potions.Add(healingPotion);
        Potion mjrHealingPotion = new Potion("potion4", "Major Healing Potion", 20, 1, 50, 15);
        potions.Add(mjrHealingPotion);

        List<Weapon> weapons = new();
        Weapon crStick = new Weapon("weapon1", "Crooked Stick", 1, 1, 1, 0);
        weapons.Add(crStick);
        Weapon trBranch = new Weapon("weapon2", "Tree Branch", 1, 1, 2, 0);
        weapons.Add(trBranch);
        Weapon club = new Weapon("weapon3", "Club", 10, 1, 3, 3);
        weapons.Add(club);
        Weapon rstyDagger = new Weapon("weapon4", "Rusty Dagger", 10, 1, 3, 0);
        weapons.Add(rstyDagger);
        Weapon btnSpear = new Weapon("weapon5", "Bent Spear", 10, 1, 3, 0);
        weapons.Add(btnSpear);
        Weapon dllShortsword = new Weapon("weapon6", "Dull Shortsword", 20, 1, 4, 7);
        weapons.Add(dllShortsword);
        Weapon stdClub = new Weapon("weapon7", "Studded Club", 20, 1, 4, 0);
        weapons.Add(stdClub);
        Weapon shortsword = new Weapon("weapon10", "Shortsword", 40, 1, 5, 10);
        weapons.Add(shortsword);
        Weapon Longsword = new Weapon("weapon12", "Longsword", 60, 1, 6, 15);
        weapons.Add(Longsword);
        Weapon Battleaxe = new Weapon("weapon13", "Battleaxe", 60, 1, 6, 0);
        weapons.Add(Battleaxe);

        List<Armor> armors = new();
        Armor rags = new Armor("armor1", "Dirty Rags", 1, 1, 0, 0);
        armors.Add(rags);
        Armor overalls = new Armor("armor2", "Overalls", 5, 1, 1, 1);
        armors.Add(overalls);
        Armor tatteredLeathers = new Armor("armor3", "Tattered Leathers", 10, 1, 2, 3);
        armors.Add(tatteredLeathers);
        Armor leatherArmor = new Armor("armor4", "Leather Armor", 20, 1, 3, 7);
        armors.Add(leatherArmor);
        Armor studdedLeather = new Armor("armor5", "Studded Leather", 40, 1, 4, 10);
        armors.Add(studdedLeather);
        Armor breastPlate = new Armor("armor6", "Breastplate", 60, 1, 5, 15);
        armors.Add(breastPlate);

        ItemDTO allMyItems = new ItemDTO();
        allMyItems.Items = items;
        allMyItems.Weapons = weapons;
        allMyItems.Armors = armors;
        allMyItems.Potions = potions;


        string itemsString = JsonSerializer.Serialize(allMyItems);
        File.WriteAllText(itemPath, itemsString);
    }
    public static ItemDTO getAllMyItems()
    {
        ItemDTO allMyItems = JsonSerializer.Deserialize<ItemDTO>(File.ReadAllText(itemPath));
        return allMyItems;
    }
}