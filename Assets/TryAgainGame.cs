using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgainGame : MonoBehaviour
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

        SceneManager.LoadScene("SampleScene");
        Shooting.score = 0;
        if (ChooseItem.isBought)
        {
            Shooting.money = ChooseItem.money;
        }
        Time.timeScale = 1f;
    }

    IEnumerator LoadSceneAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene("SampleScene");
    }
}
