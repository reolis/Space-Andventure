using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyProcess : MonoBehaviour
{
    float height;
    Rigidbody rb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        height = 10f;

        ChangeCostume();
    }

    void Update()
    {
        if (transform.position.y < -height - 1f)
        {
            Destroy(gameObject);
        }
    }

    void ChangeCostume()
    {
        int num = Random.Range(0, 2);
        Sprite newSprite = null;

        switch (num)
        {
            case 0:
                newSprite = Resources.Load<Sprite>("Resources/Enemy");
                break;
            case 1:
                newSprite = Resources.Load<Sprite>("Resources/Enemy2");
                break;
        }

        if (newSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Shooting.PlusScore("Enemy");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}