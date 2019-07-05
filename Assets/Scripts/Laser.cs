using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject player;
    private Ship ship;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            ship.TakeHit(1);
            Destroy(this.gameObject);
        }
    }
}
