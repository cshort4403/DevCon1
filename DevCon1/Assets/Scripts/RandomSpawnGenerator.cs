using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnGenerator : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn
    public Vector3 spawnPosition; // The base position to spawn from
    public Vector3 spawnOffset; // Range of the random offset
    public float spawnInterval = 2f; // Time interval between spawns

    void Start()
    {
        StartCoroutine(SpawnPrefabRoutine());
    }

    private IEnumerator SpawnPrefabRoutine()
    {
        while (true) // Infinite loop for continuous spawning
        {
            SpawnPrefab();
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }

    private void SpawnPrefab()
    {
        // Generate a random offset within the specified range
        Vector3 randomOffset = new Vector3(Random.Range(-spawnOffset.x, spawnOffset.x), Random.Range(-spawnOffset.y, spawnOffset.y), Random.Range(-spawnOffset.z, spawnOffset.z));

        // Calculate the final spawn position
        Vector3 finalSpawnPosition = spawnPosition + randomOffset;

        // Instantiate the prefab at the newly calculated position
        Instantiate(prefabToSpawn, finalSpawnPosition, Quaternion.identity);
    }

}
