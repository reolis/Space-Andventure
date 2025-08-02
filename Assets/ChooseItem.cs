using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ChooseItem : MonoBehaviour
{
    public static int money = 0;
    Rigidbody rb;
    Vector3 scale;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI textMoney;
    public AudioSource moneySound;
    public SpriteRenderer skin;
    public static Sprite newSkin;
    public static bool isBought = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = Shooting.money;
        rb = GetComponent<Rigidbody>();
        scale = rb.transform.localScale;
        textMoney.text = "Money: " + money.ToString();
        isBought = false;
    }

    void Update()
    {
        int itemCost = int.Parse(cost.text);
        if (Click())
        {
            if (money >= itemCost)
            {
                rb.transform.localScale = Vector3.Lerp(rb.transform.localScale, rb.transform.localScale * 1.5f, Time.deltaTime * 5f);

                money -= itemCost;
                moneySound.Play();
                newSkin = skin.sprite;
                PlayerProcess.skinName = newSkin.name;
                textMoney.text = "Money: " + money.ToString();
                isBought = true;
            }
            else
            {
                rb.transform.localScale = scale;
                textMoney.text = "Money: " + money.ToString();
            }
        }
    }


    bool Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.gameObject == gameObject && Mouse.current.leftButton.isPressed)
            {
                return true;
            }
        }
        return false;
    }
}
