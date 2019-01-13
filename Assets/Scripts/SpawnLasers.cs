using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLasers : MonoBehaviour {

    [Header("Set in Inspector")]
    public GameObject AsterPrefab;
    public float spawnPerSec = 1f;
    public float spawnPadding = 1.5f;
    public Vector3 spawnZone;

    void Awake()
    {
        Invoke("SpawnLaser", 1f / spawnPerSec);
    }

    void SpawnLaser()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x), spawnZone.y, spawnZone.z);
        Instantiate(AsterPrefab, spawnPos, Quaternion.identity);
        Invoke("SpawnLaser", 1f / spawnPerSec);
    }
}
