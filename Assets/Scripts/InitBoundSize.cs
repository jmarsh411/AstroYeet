using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoundSize : MonoBehaviour
{
    private GameManager game;
    private BoxCollider2D box;

    private void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        box = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        box.offset = game.playArea.center;
        box.size = game.playArea.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
