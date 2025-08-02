using UnityEngine;
using UnityEngine.InputSystem;

public class BulletFromPlayer : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    float speed = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.position = player.transform.position;

        rb.linearVelocity = Vector3.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
