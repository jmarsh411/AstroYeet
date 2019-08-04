using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;
public class InputManager : MonoBehaviour
{
    public GameObject playerShip;
    private Ship ship;
    private float horizAxis;
    private float vertAxis;

    [SerializeField]
    private VoidEvent pauseEvent;

    // Start is called before the first frame update
    void Start()
    {
        ship = playerShip.GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        // send the horizontal axis to player ship for movement purposes
        horizAxis = Input.GetAxis("Horizontal");
        ship.SetHoriz(horizAxis);

        // send the vertical axis to player ship
        vertAxis = Input.GetAxis("Vertical");
        ship.SetVert(vertAxis);

        if (Input.GetButtonDown("Pause"))
            pauseEvent.Raise();
    }

}
