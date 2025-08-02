using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AsteroidProcess : MonoBehaviour
{
    float height;
    Rigidbody rb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        height = 10f;
    }

    void Update()
    {
        if (transform.position.y < -height - 1f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Shooting.PlusScore("Aster");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}