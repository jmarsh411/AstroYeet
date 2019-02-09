using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool isBoosting;
    bool canBoost;
    public float boostTimeout;
    public GameObject playerShip;
    PlayerMovement movement;
    Vector3 move;


    // Start is called before the first frame update
    void Start()
    {
        isBoosting = false;
        canBoost = true;
        movement = playerShip.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        // If boost button pressed and not already boosting and I'm allowed to boost
        // then boost
        movement.horizAxis = Input.GetAxis("Horizontal");

        if (Input.GetAxis("BoostJoy") > 0 || Input.GetAxis("BoostKey") > 0)
        {
            if (!isBoosting && canBoost)
            {
                Boost();
            }
        }
    }


    void Boost()
    {
        Debug.Log("Boosting");
        movement.Boost();
        isBoosting = true;
        canBoost = false;
        Invoke("StopBoost", boostTimeout);
    }

    void StopBoost()
    {
        Debug.Log("Stopped Boosting");
        isBoosting = false;
        canBoost = true;
    }
}
