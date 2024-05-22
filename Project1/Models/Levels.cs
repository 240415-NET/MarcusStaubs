using System.ComponentModel.DataAnnotations;

namespace Project1.Models;

public class LevelChange
{
    [Required]
    public int LevelNum {get; set;}
    public int XPRequiredForLevel {get; set;}
    public int MaxHitPointIncrease {get; set;}
    public int StrengthIncrease {get; set;}
    public int DexterityIncrease {get;set;}
    public int ConstitutionIncrease {get; set;}

    public LevelChange(int LevelNum, int XPRequiredForLevel, int MaxHitPointIncrease, int StrengthIncrease, int DexterityIncrease, int ConstitutionIncrease)
    {
        this.LevelNum = LevelNum;
        this.XPRequiredForLevel = XPRequiredForLevel;
        this.MaxHitPointIncrease = MaxHitPointIncrease;
        this.StrengthIncrease = StrengthIncrease;
        this.DexterityIncrease = DexterityIncrease;
        this.ConstitutionIncrease = ConstitutionIncrease;
    }
}

