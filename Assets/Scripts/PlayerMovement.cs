using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    const float defaultSpeed = 5f;
    private float boostLen = 0.1f;
    private float boostSpeedMult = 6;
    private float speed = defaultSpeed;
    private float horizAxis;
    private Vector3 move;
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
            // normalize movement vector so joysticks don't have an advantage
            // in precision
            move.Normalize();
        }

        transform.position += move * speed * Time.deltaTime;
    }

    public void Boost()
    {
        speed = defaultSpeed * boostSpeedMult;
        boosting = true;
        Invoke("StopBoost", boostLen);
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

    public void SetHoriz(float axis)
    {
        horizAxis = axis;
    }
}
