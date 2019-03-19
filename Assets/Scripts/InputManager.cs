using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject playerShip;
    private Ship ship;
    private Vector3 move;
    private bool canBoost = true;
    private float boostTimeout = 1.5f;
    // deadzone to pad against broken/miscalibrated controllers
    private float horizDeadzone = 0.1f;
    private float horizAxis = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ship = playerShip.GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        // send the horizontal axis to player for ship purposes
        horizAxis = Input.GetAxis("Horizontal");
        if (horizAxis > horizDeadzone || horizAxis < -horizDeadzone)
            ship.SetHoriz(horizAxis);
        else
            ship.SetHoriz(0);

        // if boost button is pressed, boost if allowed and not already boosting
        if (Input.GetAxis("BoostJoy") > 0 || Input.GetAxis("BoostKey") > 0)
        {
            if (canBoost && !ship.IsBoosting())
            {
                Boost();
            }
        }
    }

    void Boost()
    {
        ship.Boost();
        canBoost = false;
        Invoke("ResetBoost", boostTimeout);
    }

    void ResetBoost()
    {
        canBoost = true;
    }
}
