using UnityEngine;

public static class GameSession
{
    public static string SaveName
    {
        get => PlayerPrefs.GetString("LastSaveName", "default");
        set
        {
            PlayerPrefs.SetString("LastSaveName", value);
            PlayerPrefs.Save();
        }
    }
}
