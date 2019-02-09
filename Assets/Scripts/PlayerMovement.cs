using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    readonly float defaultSpeed = 5f;
    public float speed = 5.0f;
    public float horizAxis;
    Vector3 move;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        move = new Vector3(horizAxis, 0, 0);
        transform.position += move * speed * Time.deltaTime;
    }

    public void Boost()
    {
        speed = defaultSpeed * 6;
        Invoke("StopBoost", 0.08f);
    }

    public void StopBoost()
    {
        speed = defaultSpeed;
    }
}
