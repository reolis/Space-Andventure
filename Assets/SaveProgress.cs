using System;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    public static void Save(string saveName)
    {
        string folderPath = Application.persistentDataPath;
        Directory.CreateDirectory(folderPath);

        string filePath = Path.Combine(folderPath, "progress_" + saveName + ".txt");

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(saveName);
        stringBuilder.AppendLine("Money: " + Shooting.money);
        stringBuilder.AppendLine("Skin: " + PlayerProcess.skinName);

        File.WriteAllText(filePath, stringBuilder.ToString());
        Debug.Log("Saved to: " + filePath);
    }


    public static void Load(string saveName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, "progress_" + saveName + ".txt");

        if (!File.Exists(filePath))
        {
            Debug.LogWarning("Save file not found: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            if (line.StartsWith("Money: "))
            {
                string moneyStr = line.Substring("Money: ".Length);
                if (int.TryParse(moneyStr, out int moneyValue))
                {
                    Shooting.money = moneyValue;
                }
            }
            else if (line.StartsWith("Skin: "))
            {
                string skinName = line.Substring("Skin: ".Length);
                PlayerProcess.skinName = skinName;
            }

        }

        Debug.Log("Loaded from: " + filePath);
    }
}
