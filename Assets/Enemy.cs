using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject LaserPrefab;

    private GameObject player;
    private Ship ship;
    private Rigidbody2D playerRB;
    private Rigidbody2D enemyRB;
    private const float startDist = 900;
    private float fastVelMult;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
        enemyRB = GetComponent<Rigidbody2D>();
        playerRB = ship.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position -= new Vector3(0, startDist, 0);
        fastVelMult = 1.2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyRB.velocity = playerRB.velocity * fastVelMult;

        //temporary testing key
        if (Input.GetKeyUp(KeyCode.L))
        {
            ShootLaser(transform.position);
        }
    }

    public void ShootLaser(Vector3 position)
    {
        Instantiate(LaserPrefab, position, Quaternion.identity);
    }

}
