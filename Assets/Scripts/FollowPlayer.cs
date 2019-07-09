using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

    public class FollowPlayer: MonoBehaviour
{
    private GameObject player;
    public Vector3Reference offset;
    public Vector3Constant defaultOffset;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        offset.Variable.Value = defaultOffset.Value;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // LateUpdate is called once per frame, after all other updates
    void LateUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y) + offset.Value;
    }
}
