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

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -ship.vertSpeed, 0);
    }
}
