using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    readonly float defaultSpeed = 5f;
    public float speed = 5.0f;
    public float horizAxis;
    Vector3 move;
    private bool boosting;

    // Use this for initialization
    void Start () {
        boosting = false;
	}
	
	// Update is called once per frame
	void Update () {
        // can only change direction while not boosting
        if (!IsBoosting())
        {
            move = new Vector3(horizAxis, 0, 0);
        }

        transform.position += move * speed * Time.deltaTime;
    }

    public void Boost()
    {
        speed = defaultSpeed * 6;
        boosting = true;
        Invoke("StopBoost", 0.1f);
    }

    public void StopBoost()
    {
        speed = defaultSpeed;
        boosting = false;
    }

    public bool IsBoosting()
    {
        return boosting;
    }
}
