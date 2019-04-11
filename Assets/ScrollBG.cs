using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float scrollSpeed;
    private GameObject player;
    private Vector3 startPos;
    private float tileSizeY = 20;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = player.transform.position + Vector3.down * newPosition;
        //transform.position = player.transform.position + Vector3.up * newPosition;
    }
}
