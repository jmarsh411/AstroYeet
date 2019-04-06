using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FollowPlayer: MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame, after all other updates
    void LateUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y) + offset;
    }
}
