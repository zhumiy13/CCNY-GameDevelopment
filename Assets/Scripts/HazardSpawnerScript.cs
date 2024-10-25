using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class HazardSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject hazardPrefab;
    [SerializeField] float sizeX = 1f;
    [SerializeField] float sizeY = 1f;
    [SerializeField] float spawnCooldown = 1f;

    private float spawnTime;

    void Start()
    {
        spawnTime = spawnCooldown;
    }

    void Update()
    {
        if (spawnTime > 0) spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime = spawnCooldown;
        }
    }

    void Spawn()
    {
        // Get the spawner's position
        Vector3 spawnerPosition = transform.position;

        // Generate random positions within the specified ranges
        float xPos = spawnerPosition.x + (Random.value - 0.5f) * 2 * sizeX;
        float yPos = spawnerPosition.y + (Random.value - 0.5f) * 2 * sizeY;

        // Instantiate the hazard prefab at the random position
        var spawn = Instantiate(hazardPrefab);
        spawn.transform.position = new Vector3(xPos, yPos, 0);
    }
}

