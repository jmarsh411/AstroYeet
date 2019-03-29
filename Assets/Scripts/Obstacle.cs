using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Ship ship;

    void Awake()
    {
        ship = GameObject.FindWithTag("PlayerShip").GetComponent<Ship>();
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(0, -ship.speed, 0);
    }
}
