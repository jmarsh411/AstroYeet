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

    private GameManager game;
    private Rigidbody2D playerRB;
    private float colliderPadding;
    private float leftBound;
    private float rightBound;


    void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        player = GameObject.FindWithTag("PlayerShip");
        playerRB = player.GetComponent<Rigidbody2D>();
        //spawn an asteroid off screen to get the size of its collider
        GameObject temp = Instantiate(AsterPrefab, new Vector3(-100, -100), Quaternion.identity);
        CapsuleCollider2D coll = temp.GetComponent<CapsuleCollider2D>();
        colliderPadding = coll.bounds.extents.x;
        Destroy(temp);
    }

    private void Start()
    {
        leftBound = game.playArea.min.x + colliderPadding;
        rightBound = game.playArea.max.x - colliderPadding;
        Invoke("SpawnAster", 1f / spawnPerSec);
    }

    void SpawnAster()
    {
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), spawnZone.y + player.transform.position.y, 0);
        Instantiate(AsterPrefab, spawnPos, Quaternion.identity);
        float speedmult = playerRB.velocity.y / 4;
        Invoke("SpawnAster", 1f / spawnPerSec / speedmult  * Random.Range(0.4f, 1.6f));
    }
}
