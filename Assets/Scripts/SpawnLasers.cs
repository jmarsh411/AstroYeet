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

    private GameObject player;
    private GameObject enemyShip;
    private Enemy enemy;
    private float playerOffset = -1.2f;

    void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        enemyShip = GameObject.FindWithTag("EnemyShip");
        enemy = enemyShip.GetComponent<Enemy>();
        Invoke("SpawnWarning", (enemy.dist + 75) / 50);
    }

    void SpawnLaserOLDER()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, spawnZone.y, spawnZone.z);
        //Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
        Instantiate(LaserPrefab, spawnPos, Quaternion.identity);
        Invoke("SpawnLaserOLD", 1f / spawnPerSec);
    }

    void SpawnWarningOLD()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, spawnZone.y, spawnZone.z);
        Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
        Invoke("SpawnWarning", 1f / spawnPerSec);
    }

    void SpawnWarning()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, player.transform.position.y + playerOffset, spawnZone.z);
        Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
        // minimum of 1.5 seconds for 0 distance
        // want about 10 seconds for distance 400
        Invoke("SpawnWarning", (enemy.dist  + 75) / 50);
    }

    public void SpawnLaser(Vector3 position)
    {
        Instantiate(LaserPrefab, position, Quaternion.identity);
    }
}
