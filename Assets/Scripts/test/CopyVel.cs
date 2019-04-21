using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyVel : MonoBehaviour
{
    public GameObject gameObj;
    Rigidbody2D rb;
    Rigidbody2D theirRB;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        theirRB = gameObj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = theirRB.velocity;
    }
}
