using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float scrollSpeed;
    private GameObject player;
    private Rigidbody2D playerRB;
    private float tileSizeY = 20;
    private Vector3 offset = new Vector3(0, 10 + 8, 0);
    private float playerY;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float tileY = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        playerY = player.transform.position.y;
        Vector3 newPos = new Vector3(0, playerY);
        //float tileY = Mathf.Repeat(Time.time * scrollSpeed * playerRB.velocity.y, tileSizeY);

        transform.position = newPos + offset + Vector3.down * tileY;
        //transform.position = player.transform.position + Vector3.up * tileY;
    }
}
