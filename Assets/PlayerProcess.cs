using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerProcess : MonoBehaviour
{
    public float playerSpeed = 10f;
    Rigidbody rb;
    public SpriteRenderer currentSkin;
    public static SpriteRenderer skin;
    public Sprite realCurrentSkin;
    string nameOfCurrentSave;
    public static string skinName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameOfCurrentSave = GameSession.SaveName;
        currentSkin.sprite = Resources.Load<Sprite>(skinName);

        rb = GetComponent<Rigidbody>();
        if (ChooseItem.newSkin != null)
        {
            currentSkin.sprite = ChooseItem.newSkin;
            skin.sprite = currentSkin.sprite;
            skinName = currentSkin.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) input.x -= 1;

        Vector3 movement = new Vector3(input.x, 0f, 0f) * playerSpeed;
        rb.linearVelocity = movement;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            Time.timeScale = 0f;

            SaveFile.Save(GameSession.SaveName);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Time.timeScale = 0f;

            SaveFile.Save(GameSession.SaveName);
            SceneManager.LoadScene("GameOver");
        }
    }
}
