using System;
using System.IO;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    public static string savePath, nameOfSave;

    static public void CreateSaveFile(string name)
    {
        string folderPath = Path.Combine(Application.persistentDataPath);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var file = File.Create(Path.Combine(folderPath, "progress_" + name + ".txt"));
        savePath = file.Name;
        file.Close();
    }

    public static void Save(string name)
    {
        nameOfSave = name;
        SaveProgress.Save(nameOfSave);
    }

    public static void Load(string name)
    {
        SaveProgress.Load(name);
    }
}