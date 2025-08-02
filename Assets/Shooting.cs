using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
    public static int score = 0;
    public static int money = 0;
    public AudioSource shotSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        moneyText.text = "Money: " + money.ToString();
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            shotSound.Play();
        }
        if (transform.position.y < -10f - 1f)
        {
            Destroy(gameObject);
        }
    }

    public static void PlusScore(string type)
    {
        score++;
        if (type == "Enemy")
        {
            money += score * 10;
        }
        else
        {
            money += score;
        }
    }
}
