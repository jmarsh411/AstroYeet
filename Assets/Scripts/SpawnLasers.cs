using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLasers : MonoBehaviour {
    private float uiOffset = -0.6f;

    [Header("Set in Inspector")]
    public GameObject LaserPrefab;
    public GameObject LaserWarnPrefab;
    public float spawnPerSec = 1f;
    public float spawnPadding = 1.5f;
    public Vector3 spawnZone;

    void Awake()
    {
        Invoke("SpawnWarning", 1f / spawnPerSec);
    }

    void SpawnLaserOLD()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, spawnZone.y, spawnZone.z);
        //Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
        Instantiate(LaserPrefab, spawnPos, Quaternion.identity);
        Invoke("SpawnLaserOLD", 1f / spawnPerSec);
    }

    void SpawnWarning()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, spawnZone.y, spawnZone.z);
        Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
        Invoke("SpawnWarning", 1f / spawnPerSec);
    }

    public void SpawnLaser(Vector3 position)
    {
        Instantiate(LaserPrefab, position, Quaternion.identity);
    }
}
