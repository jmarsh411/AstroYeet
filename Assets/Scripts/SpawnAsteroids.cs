using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour {
    private float uiOffset = -0.6f;

    [Header("Set in Inspector")]
    public GameObject player;
    public GameObject AsterPrefab;
    public float spawnPerSec = 1f;
    public float spawnPadding = 1.5f;
    public Vector3 spawnZone;
    private Ship ship;

    void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
        Invoke("SpawnAster", 1f / spawnPerSec);
    }

    void SpawnAster()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, spawnZone.y + player.transform.position.y, spawnZone.z);
        Instantiate(AsterPrefab, spawnPos, Quaternion.identity);
        Invoke("SpawnAster", 1f / spawnPerSec  * Random.Range(0.4f, 1.6f));
    }
}
