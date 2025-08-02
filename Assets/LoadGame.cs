using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;

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
        audioSource.Play();
        StartCoroutine(LoadSceneAfterSound());
    }

    IEnumerator LoadSceneAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene("SampleScene");
    }

}
