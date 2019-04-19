using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLasers : MonoBehaviour {
    private float uiOffset = -0.6f;

    [Header("Set in Inspector")]
    public GameObject LaserPrefab;
    public GameObject LaserWarnPrefab;
    private GameManager game;
    public float spawnPerSec = 1f;
    public float spawnPadding = 1.5f;
    public Vector3 spawnZone;
    private const float minAccSpread = 0.5f;
    private float maxAccSpread;
    private float accFalloff;
    float acc;

    private GameObject player;
    private GameObject enemyShip;
    private Enemy enemy;
    private float playerOffset = -1.2f;

    void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        player = GameObject.FindWithTag("PlayerShip");
        enemyShip = GameObject.FindWithTag("EnemyShip");
        enemy = enemyShip.GetComponent<Enemy>();
        Invoke("SpawnWarning", (enemy.dist + 50) / 75);
    }

    private void Start()
    {
        maxAccSpread = game.playArea.extents.x;
        accFalloff = GameManager.playerHeadStart / 5f;
    }


    //void SpawnLaserOLDER()
    //{
    //    Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, spawnZone.y, spawnZone.z);
    //    //Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
    //    Instantiate(LaserPrefab, spawnPos, Quaternion.identity);
    //    Invoke("SpawnLaserOLDER", 1f / spawnPerSec);
    //}

    //void SpawnWarningOLD()
    //{
    //    Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, spawnZone.y, spawnZone.z);
    //    Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
    //    Invoke("SpawnWarningOLD", 1f / spawnPerSec);
    //}

    //void SpawnWarning3()
    //{
    //    Vector3 spawnPos = new Vector3(Random.Range(-spawnZone.x, spawnZone.x) + uiOffset, player.transform.position.y + playerOffset, spawnZone.z);
    //    Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
    //    // minimum of 1.5 seconds for 0 distance
    //    // want about 10 seconds for distance 400
    //    Invoke("SpawnWarning3", (enemy.dist + 75) / 50);
    //}

    void SpawnWarning()
    {
        float spread = Mathf.Clamp(enemy.dist / accFalloff, minAccSpread, maxAccSpread);
        Vector3 spawnPos = new Vector3(
            player.transform.position.x + Random.Range(-spread, spread),
            player.transform.position.y + playerOffset,
            0);
        Instantiate(LaserWarnPrefab, spawnPos, Quaternion.identity);
        // minimum of 1.5 seconds for 0 distance
        // want about 10 seconds for distance 400
        Invoke("SpawnWarning", (enemy.dist + 50) / 75);
    }

    public void SpawnLaser(Vector3 position)
    {
        Instantiate(LaserPrefab, position, Quaternion.identity);
    }
}
