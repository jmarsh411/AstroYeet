using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Ship ship;
    private const float startDist = 900;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position -= new Vector3(0, startDist, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
