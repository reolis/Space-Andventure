using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Load : MonoBehaviour
{
    public TMP_InputField field;
    public UnityEngine.UI.Button buttonStart;
    public UnityEngine.UI.Button buttonSave1, buttonSave2, buttonSave3, buttonSave4;
    public static string nameOfSave;
    UnityEngine.UI.Button clickedButton;
    int numOfSaves = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        field.onDeselect.AddListener(CancelCreatingNewSave);

        int fileCount = Directory.GetFiles(Application.persistentDataPath).Length;
        if (fileCount >= numOfSaves)
        {
            field.text = "There is no space for your new saves. Please, enter name of save, that you want to delete.";
        }

        field.onSubmit.AddListener(HandleInput);
        field.gameObject.SetActive(false);
        buttonStart.interactable = false;

        if (buttonSave1 == null && buttonSave2 == null && buttonSave3 == null && buttonSave4 == null)
        {
            buttonSave1 = GetComponent<UnityEngine.UI.Button>();
            buttonSave2 = GetComponent<UnityEngine.UI.Button>();
            buttonSave3 = GetComponent<UnityEngine.UI.Button>();
            buttonSave4 = GetComponent<UnityEngine.UI.Button>();
        }

        buttonSave1.onClick.AddListener(() => OnSubmit(buttonSave1));
        buttonSave2.onClick.AddListener(() => OnSubmit(buttonSave2));
        buttonSave3.onClick.AddListener(() => OnSubmit(buttonSave3));
        buttonSave4.onClick.AddListener(() => OnSubmit(buttonSave4));

        LoadSavesToButtons();
    }

    void OnSubmit(UnityEngine.UI.Button btn)
    {
        TextMeshProUGUI text = btn.GetComponentInChildren<TextMeshProUGUI>();

        if (text.text == "No Save")
        {
            clickedButton = btn;
            field.gameObject.SetActive(true);

            buttonSave1.gameObject.SetActive(false);
            buttonSave2.gameObject.SetActive(false);
            buttonSave3.gameObject.SetActive(false);
            buttonSave4.gameObject.SetActive(false);
        }
        else
        {
            string name = btn.GetComponentInChildren<TextMeshProUGUI>().text;
            string fullPath = Path.Combine(Application.persistentDataPath, "progress_" + name + ".txt");

            if (File.Exists(fullPath))
            {
                SaveFile.Load(name);
                PlayerPrefs.SetString("LastSaveName", name);
                PlayerPrefs.Save();
                buttonStart.interactable = true;
            }
            else
            {
                Debug.LogWarning("File not found: " + fullPath);
            }
        }

    }


    // Update is called once per frame
    void Update()
    {

    }

    void HandleInput(string userInput)
    {
        nameOfSave = userInput;
        GameSession.SaveName = userInput;

        TextMeshProUGUI text = clickedButton.GetComponentInChildren<TextMeshProUGUI>();

        if (text.text == "No Save")
        {
            SaveFile.CreateSaveFile(nameOfSave);
        }

        if (clickedButton != null)
        {
            text.text = nameOfSave;
        }

        buttonSave1.gameObject.SetActive(true);
        buttonSave2.gameObject.SetActive(true);
        buttonSave3.gameObject.SetActive(true);
        buttonSave4.gameObject.SetActive(true);

        field.gameObject.SetActive(false);

        SaveFile.Save(nameOfSave);
    }

    void LoadSavesToButtons()
    {
        string folderPath = Path.Combine(Application.persistentDataPath);
        string[] saveFiles = Directory.GetFiles(folderPath, "progress_*.txt");

        UnityEngine.UI.Button[] buttons = new[] { buttonSave1, buttonSave2, buttonSave3, buttonSave4 };

        for (int i = 0; i < buttons.Length; i++)
        {
            TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();

            if (i < saveFiles.Length)
            {
                string[] lines = File.ReadAllLines(saveFiles[i]);
                if (lines.Length > 0)
                    text.text = lines[0];
                else
                    text.text = "No Save";
            }
            else
            {
                text.text = "No Save";
            }
        }
    }

    void CancelCreatingNewSave(string input)
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            field.gameObject.SetActive(false);
        }
    }
}
