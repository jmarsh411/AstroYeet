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
    private const float fastVelMult = 1.2f;
    private const float minAccSpread = 0.5f;
    private float maxAccSpread;
    private Vector2 currSpeed;

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
        transform.position = Vector3.zero;
        maxAccSpread = game.playArea.extents.x;
        dist = player.transform.position.y - transform.position.y;

        // set the starting velocity of the enemies
        currSpeed = new Vector2(0, 10f);
        StartCoroutine(UpdateSpeed());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = player.transform.position.y - transform.position.y;
        enemyRB.velocity = currSpeed;
        //if (dist > 30)
        //{
        //    Vector2 newVel = new Vector2(0, Mathf.Max(10f, playerRB.velocity.y * fastVelMult));
        //    enemyRB.velocity = newVel;
        //}
        //else
        //{
        //    enemyRB.velocity = playerRB.velocity;
        //}

        //temporary testing key
        if (Input.GetKeyUp(KeyCode.L))
        {
            SpawnLaser();
        }
    }

    IEnumerator UpdateSpeed()
    {
        yield return new WaitUntil(() => ship.speedHist.Count > 0);
        while (true)
        {
            Vector2 speedEntry = ship.speedHist.Dequeue();
            float nextPos = speedEntry.x;
            float nextSpeed = speedEntry.y;
            yield return new WaitUntil(() => ReachedNextCheckpoint(nextPos));
            //enemyRB.velocity = new Vector2(0, nextSpeed);
            currSpeed = new Vector2(0, nextSpeed);
        }
    }

    bool ReachedNextCheckpoint(float checkpoint)
    {
        return (transform.position.y >= checkpoint);
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
