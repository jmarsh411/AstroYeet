using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    private Ship ship;

    void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            ship.TakeDamage(1);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {

    }
}
