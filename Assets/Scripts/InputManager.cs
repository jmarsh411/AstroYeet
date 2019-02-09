using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool canBoost;
    public float boostTimeout;
    public GameObject playerShip;
    PlayerMovement movement;
    Vector3 move;


    // Start is called before the first frame update
    void Start()
    {
        canBoost = true;
        movement = playerShip.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // send the horizontal axis to player for movement purposes
        movement.horizAxis = Input.GetAxis("Horizontal");

        // if boost button is pressed, boost if allowed and not already boosting
        if (Input.GetAxis("BoostJoy") > 0 || Input.GetAxis("BoostKey") > 0)
        {
            if (canBoost && !movement.IsBoosting())
            {
                Boost();
            }
        }
    }
    
    void Boost()
    {
        movement.Boost();
        canBoost = false;
        Invoke("ResetBoost", boostTimeout);
    }

    void ResetBoost()
    {
        canBoost = true;
    }
}
