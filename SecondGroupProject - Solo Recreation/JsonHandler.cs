using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using FirstFridayGroupProject.Dinner;

namespace FirstFridayGroupProject.JsonHandle;

public class JsonHandler
{
    // Declares file path and sets it equal to root directory of project
    private string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

    private string GetFilePath(string path)
    {
        // Navigates backwards to the correct directory in the project
        string newFilePath = Directory.GetParent(filePath).FullName;
        newFilePath = Directory.GetParent(Directory.GetParent(newFilePath).FullName).FullName;
        newFilePath += path; // Then adds the actual file name
        return newFilePath;
    }

    public PreLoadMeals LoadMealsFromFile()
    {
        string filePath = GetFilePath(@"\DefaultMeals.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PreLoadMeals preLoadMeals = JsonConvert.DeserializeObject<PreLoadMeals>(json);
            return preLoadMeals;
        }
        return new PreLoadMeals();
    }
}