using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class Laser : MonoBehaviour
{
    private GameObject player;
    private Ship ship;
    private Collider2D laserCollider;

    [SerializeField]
    private FloatConstant laserLifespan;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
        laserCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        StartCoroutine(LaserDestruct());
    }

    IEnumerator LaserDestruct()
    {
        yield return new WaitForSeconds(laserLifespan.Value);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            ship.TakeHit(1);
            laserCollider.enabled = false;
        }
    }
}
