using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0f;
    Vector3 move;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("BoostJoy") > 0 || Input.GetAxis("BoostKey") > 0)
        {
            speed = 30.0f;
        }
        else
            speed = 5.0f;

        move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		transform.position += move * speed * Time.deltaTime;
    }
}
