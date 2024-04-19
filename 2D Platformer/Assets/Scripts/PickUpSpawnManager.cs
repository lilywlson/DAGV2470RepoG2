using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawnManager : MonoBehaviour
{
    public GameObject[] pickupPrefabs;

    [SerializeField]
    private float spawnRangeX = 6.0f;

    private float startDelay = 2f;
    private float spawnInterval = 8f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPickUp", startDelay, spawnInterval);
    }

    void SpawnRandomPickUp()
    {
        // Generate a position to spawn at
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), -3);
        // Pick a random pickup from array
        int pickupIndex = Random.Range(0,pickupPrefabs.Length);
        // Spawn pickup indexed from the array
        Instantiate(pickupPrefabs[pickupIndex], spawnPos, pickupPrefabs[pickupIndex].transform.rotation);
    }
}
