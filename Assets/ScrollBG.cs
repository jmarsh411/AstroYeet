using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float scrollSpeed;

    private GameObject player;
    private float tileHeight;
    private float tileYOffset;
    private Vector3 camOffset;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
    }

    // Start is called before the first frame update
    void Start()
    {
        // the tile height has been set to be double the height of the screen
        // this gets the original tile height
        tileHeight = GetComponent<SpriteRenderer>().size.y / 2;
        camOffset = new Vector3(0, Camera.main.transform.position.y + tileHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        // since the player's position increases more rapidly when speed is higher,
        // tying the tile camOffset to position will directly tie the tile's relative speed
        // to player's speed. Mathf.repeat will reset the position of the tile when the
        // tile has fully scaled across the player
        tileYOffset = Mathf.Repeat(player.transform.position.y * scrollSpeed, tileHeight);
        Vector3 newPos = new Vector3(0, player.transform.position.y);
        transform.position = newPos + camOffset + Vector3.down * tileYOffset;
    }
}
