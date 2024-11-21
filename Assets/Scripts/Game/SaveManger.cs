using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string saveFilePath = "save.json";
    private SaveData saveData;

    private void Start()
    {
        LoadSaveFile();
    }

    public void UpdateScore(int level, int score)
    {
        saveData.levels[level - 1].score = score;
        saveData.sumScore += score;

        if (level > saveData.highestLevel)
        {
            saveData.highestLevel = level;
            saveData.currentLevel = level;
        }
        else
        {
            saveData.currentLevel = level + 1;
        }

        SaveToFile();
    }

    private void LoadSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            saveData = JsonUtility.FromJson<SaveData>(jsonData);
        }
        else
        {
            saveData = new SaveData();
            SaveToFile();
        }
    }

    private void SaveToFile()
    {
        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, jsonData);
    }
}

[System.Serializable]
public class SaveData
{
    public int currentLevel;
    public int highestLevel;
    public int sumScore;
    public LevelData[] levels;
}

[System.Serializable]
public class LevelData
{
    public int level;
    public int score;
}