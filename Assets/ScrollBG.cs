using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float scrollSpeed;
    private GameObject player;
    private float tileSizeY;
    private Vector3 offset = new Vector3(0, 10 + 8, 0);
    private float playerY;
    private float tileYOffset;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
    }

    // Start is called before the first frame update
    void Start()
    {
        tileSizeY = GetComponent<SpriteRenderer>().size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // since the player's position increases more rapidly when speed is higher,
        // tying the tile offset to position will directly tie the tile's relative speed
        // to player's speed. Mathf.repeat will reset the position of the tile when the
        // tile has fully scaled across the player
        tileYOffset = Mathf.Repeat(player.transform.position.y * scrollSpeed, tileSizeY);
        playerY = player.transform.position.y;
        Vector3 newPos = new Vector3(0, playerY);

        transform.position = newPos + offset + Vector3.down * tileYOffset;
    }
}
