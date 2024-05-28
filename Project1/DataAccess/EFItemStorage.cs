using Project1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Project1.Data;
public class EFItemStorage : IItemStorage
{
    private readonly GameContext _context = new GameContext();

    public void CreateInitialItemsList()
    {

        Item spiderSilk = new Item("silk", "Spider Silk", 4, 1);
        _context.Items.Add(spiderSilk);
        Item rattail = new Item("tail", "Rat Tail", 3, 1);
        _context.Items.Add(rattail);
        Item ratfur = new Item("fur", "Rat Fur", 4, 1);
        _context.Items.Add(ratfur);
        Item ratpaw = new Item("paw", "Rat Paw", 6, 1);
        _context.Items.Add(ratpaw);
        Item ratfang = new Item("rfang", "Rat Fang", 6, 1);
        _context.Items.Add(ratfang);
        Item spiderfang = new Item("fang", "Spider Fang", 6, 1);
        _context.Items.Add(spiderfang);
        Item leatherscrap = new Item("scraps", "Leather Scraps", 9, 1);
        _context.Items.Add(leatherscrap);
        Item purse = new Item("purse", "Crude Purse", 12, 1);
        _context.Items.Add(purse);
        Item brkbow = new Item("bow", "Broken Bow", 15, 1);
        _context.Items.Add(brkbow);
        Item arrows = new Item("arrows", "Warped Arrows", 9, 1);
        _context.Items.Add(arrows);
        Item brkshield = new Item("shield", "Broken Shield", 15, 1);
        _context.Items.Add(brkshield);
        Item sprhead = new Item("spearhead", "Spearhead", 21, 1);
        _context.Items.Add(sprhead);
        Item roughgem = new Item("gem", "Rough Gemstone", 30, 1);
        _context.Items.Add(roughgem);
        Item herbBundle = new Item("herbs", "Bundle of Herbs", 27, 1);
        _context.Items.Add(herbBundle);
        Item cpnecklace = new Item("necklace", "Copper Necklace", 30, 1);
        _context.Items.Add(cpnecklace);

        Potion mnrHealingPotion = new Potion("potion1", "Minor Healing Potion", 3, 1, 5, 1);
        _context.Potions.Add(mnrHealingPotion);
        Potion lssHealingPotion = new Potion("potion2", "Lesser Healing Potion", 5, 1, 10, 5);
        _context.Potions.Add(lssHealingPotion);
        Potion healingPotion = new Potion("potion3", "Healing Potion", 10, 1, 20, 10);
        _context.Potions.Add(healingPotion);
        Potion mjrHealingPotion = new Potion("potion4", "Major Healing Potion", 20, 1, 50, 15);
        _context.Potions.Add(mjrHealingPotion);

        Weapon crStick = new Weapon("weapon1", "Crooked Stick", 1, 1, 1, 0);
        _context.Weapons.Add(crStick);
        Weapon trBranch = new Weapon("weapon2", "Tree Branch", 1, 1, 2, 0);
        _context.Weapons.Add(trBranch);
        Weapon club = new Weapon("weapon3", "Club", 10, 1, 3, 3);
        _context.Weapons.Add(club);
        Weapon rstyDagger = new Weapon("weapon4", "Rusty Dagger", 10, 1, 3, 0);
        _context.Weapons.Add(rstyDagger);
        Weapon btnSpear = new Weapon("weapon5", "Bent Spear", 10, 1, 3, 0);
        _context.Weapons.Add(btnSpear);
        Weapon dllShortsword = new Weapon("weapon6", "Dull Shortsword", 20, 1, 4, 7);
        _context.Weapons.Add(dllShortsword);
        Weapon stdClub = new Weapon("weapon7", "Studded Club", 20, 1, 4, 0);
        _context.Weapons.Add(stdClub);
        Weapon shortsword = new Weapon("weapon10", "Shortsword", 40, 1, 5, 10);
        _context.Weapons.Add(shortsword);
        Weapon Longsword = new Weapon("weapon12", "Longsword", 60, 1, 6, 15);
        _context.Weapons.Add(Longsword);
        Weapon Battleaxe = new Weapon("weapon13", "Battleaxe", 60, 1, 6, 0);
        _context.Weapons.Add(Battleaxe);

        Armor rags = new Armor("armor1", "Dirty Rags", 1, 1, 0, 0);
        _context.Armors.Add(rags);
        Armor overalls = new Armor("armor2", "Overalls", 5, 1, 1, 1);
        _context.Armors.Add(overalls);
        Armor tatteredLeathers = new Armor("armor3", "Tattered Leathers", 10, 1, 2, 3);
        _context.Armors.Add(tatteredLeathers);
        Armor leatherArmor = new Armor("armor4", "Leather Armor", 20, 1, 3, 7);
        _context.Armors.Add(leatherArmor);
        Armor studdedLeather = new Armor("armor5", "Studded Leather", 40, 1, 4, 10);
        _context.Armors.Add(studdedLeather);
        Armor breastPlate = new Armor("armor6", "Breastplate", 60, 1, 5, 15);
        _context.Armors.Add(breastPlate);

        _context.SaveChanges();
    }

    public ItemDTO getAllMyItems()
    {
        List<string> nonItemIDs = _context.Weapons.Select(x => x.ItemID).AsNoTracking().ToList();
        nonItemIDs.AddRange(_context.Armors.Select(x => x.ItemID).AsNoTracking().ToList());
        nonItemIDs.AddRange(_context.Potions.Select(x => x.ItemID).AsNoTracking().ToList());
        List<Item> myItems = _context.Items.Where(x=> !nonItemIDs.Contains(x.ItemID))
        .AsNoTracking()
        .ToList();
        List<Weapon> myWeapons = _context.Weapons
        .AsNoTracking()
        .ToList();
        List<Armor> myArmors = _context.Armors
        .AsNoTracking()
        .ToList();
        List<Potion> myPotions = _context.Potions
        .AsNoTracking()
        .ToList();

        return new ItemDTO(myItems, myWeapons, myArmors, myPotions);
    }
}