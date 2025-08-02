using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
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
        SceneManager.LoadScene("Shop");
    }
}
