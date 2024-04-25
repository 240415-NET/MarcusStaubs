using System.ComponentModel;

namespace FirstFridayGroupProject;

public class DinnerIdea
{
    public string MealName = "You didn't give me a name";
    public int PrepTime = 0;
    public int CookTime = 0;
    public List<string>? Ingredients;

    public DinnerIdea()
    {

    }
    public DinnerIdea(string MealName, int PrepTime, int CookTime)
    {
        SetMealName(MealName);
        SetPrepTime(PrepTime);
        SetCookTime(CookTime);
    }

    public DinnerIdea(string MealName, int PrepTime, int CookTime, List<string> Ingredients)
    {
        SetMealName(MealName);
        SetPrepTime(PrepTime);
        SetCookTime(CookTime);
        SetIngredients(Ingredients);
    }
    public void SetMealName(string MealName)
    {
        this.MealName = MealName.Trim();
    }
    public string GetMealName()
    {
        return this.MealName;
    }
    public void SetPrepTime(int PrepTime)
    {
        this.PrepTime = PrepTime;
    }
    public int GetPrepTime()
    {
        return this.PrepTime;
    }
    public void SetCookTime(int CookTime)
    {
        this.CookTime = CookTime;
    }
    public int GetCookTime()
    {
        return this.CookTime;
    }
    public void SetIngredients(List<string> Ingredients)
    {
        this.Ingredients = Ingredients;
    }
    public List<string> GetIngredients()
    {
        return this.Ingredients;
    }    
    public void AddIngredientToList(string Ingredient)
    {
        this.Ingredients.Add(Ingredient);
    }
    public void RemoveIngredientFromList(string Ingredient)
    {
        this.Ingredients.Remove(Ingredient);
    }

    public override string ToString()
    {
        string returnString = "";
        returnString = $"{MealName}\nPrep Time: {PrepTime} minutes\nCook Time: {CookTime} minutes\n\nIngredients:\n";
        for(int i=0; i<this.Ingredients.Count(); i++)
        {
            returnString += $"{this.Ingredients[i]}\n";
        }
        return returnString;
    }  
}
public class PreLoadMeals()
{
    public List<DinnerIdea> AvailableDinnerIdeas = new List<DinnerIdea>();
}
