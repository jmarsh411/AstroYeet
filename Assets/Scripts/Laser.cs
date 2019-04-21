using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laserWarningPrefab;
    private GameObject player;
    private Ship ship;
    private GameObject laserWarning;
    private LaserWarn warn;

    //private bool warning;
    public float warnDist;
    private float distance;
    //private Vector3 warnOffset = new Vector3(0, -1.2f, 0);

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //warning = false;
        warnDist = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            ship.TakeHit(1);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    distance = player.transform.position.y - transform.position.y;
    //    if (!warning && distance < warnDist)
    //    {
    //        warning = true;
    //        Vector3 warnPos = new Vector3(transform.position.x, player.transform.position.y, 0) + warnOffset;
    //        laserWarning = Instantiate(laserWarningPrefab, warnPos, Quaternion.identity);
    //        warn = laserWarning.GetComponentInChildren<LaserWarn>();
    //    }

    //    if (warning && distance >= 0)
    //    {
    //        //warn.UpdState(distance);
    //    }
    //}

    //IEnumerator SpawnWarning()
    //{
    //    yield return null;
    //}
}
