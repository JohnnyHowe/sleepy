using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public Transform spawnPosition;
    public Vector2 startVelocity = Vector2.one;
    public float itemGravityScale = 0.5f;
    public float minRawSpawnTime = 0.5f;
    public float maxRawSpawnTime = 1f;
    float timeUntilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilSpawn = maxRawSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0) {
            timeUntilSpawn += Random.Range(minRawSpawnTime * 1000, maxRawSpawnTime * 1000) / 1000;
            Spawn();
        }
    }

    GameObject Spawn()
    {
        if (itemPrefabs.Length > 0)
        {
            GameObject newObject = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], transform);
            newObject.transform.position = spawnPosition.position;
            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
            rb.velocity = startVelocity;
            rb.gravityScale = itemGravityScale;
            return newObject;
        }
        else
        {
            return null;
        }
    }
}
