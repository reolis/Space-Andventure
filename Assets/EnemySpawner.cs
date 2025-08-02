using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject asterPrefab;
    public Transform spawn;
    public float spawnInterval = 5f;
    public float speed = 5f;

    float timer;
    float width, height;

    void Start()
    {
        height = 10f;
        width = 10f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            SpawnAster();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawn.position.x - width, spawn.position.x + width), height, 0f);

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 movement = new Vector3(0f, -1f, 0f) * speed;
            rb.linearVelocity = movement;
        }
    }

    void SpawnAster()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawn.position.x - width, spawn.position.x + width), height, 0f);

        GameObject aster = Instantiate(asterPrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = aster.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 movement = new Vector3(0f, -1f, 0f) * Random.Range(1f, 10f);
            rb.linearVelocity = movement;
        }
    }
}
