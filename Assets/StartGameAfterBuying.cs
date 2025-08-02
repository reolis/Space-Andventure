using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameAfterBuying : MonoBehaviour
{
    public Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (button == null)
            button = GetComponent<Button>();

        button.onClick.AddListener(OnSubmit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSubmit()
    {
        SceneManager.LoadScene("SampleScene");

        Time.timeScale = 1f;
        Shooting.score = 0;
        Shooting.money = 0;
    }
}
