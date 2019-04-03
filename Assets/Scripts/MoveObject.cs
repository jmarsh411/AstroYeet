using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
	}
}
