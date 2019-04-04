using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject LaserPrefab;

    private GameManager game;
    private GameObject player;
    private Ship ship;
    private Rigidbody2D playerRB;
    private Rigidbody2D enemyRB;
    //private const float startDist = 900;
    public static float startDist = 400;
    private const float fastVelMult = 1.2f;
    private const float minAccSpread = 0.5f;
    private float maxAccSpread;

    public float dist;
    float acc;

    private void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
        enemyRB = GetComponent<Rigidbody2D>();
        playerRB = ship.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position -= new Vector3(0, startDist, 0);
        maxAccSpread = game.playArea.extents.x;
        dist = player.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = player.transform.position.y - transform.position.y;
        enemyRB.velocity = playerRB.velocity * fastVelMult;

        //temporary testing key
        if (Input.GetKeyUp(KeyCode.L))
        {
            SpawnLaser();
        }
    }


    public void SpawnLaser()
    {
        float spread = Mathf.Clamp(dist / 200, minAccSpread, maxAccSpread);
        Vector3 spawnPos = new Vector3(Random.Range(-spread, spread), transform.position.y, 0);
        ShootLaser(spawnPos);
    }

    public void ShootLaser(Vector3 position)
    {
        Instantiate(LaserPrefab, position, Quaternion.identity);
    }

}
