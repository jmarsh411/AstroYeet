using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    const float defHorizSpeed = 5f;
    private float defVertSpeed = 0.15f;
    private float boostLen = 0.1f;
    private float boostHorizSpeedMult = 6f;
    private float boostVertStr = 0.05f;
    private float horizSpeed = defHorizSpeed;
    public float vertSpeed;
    private float horizAxis;
    private Vector3 move;
    private bool boosting = false;

    void Awake()
    {
        vertSpeed = defVertSpeed;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // can only change direction while not boosting
        if (!IsBoosting())
        {
            move = new Vector3(horizAxis, 0, 0);
            // normalize movement vector so joysticks don't have an advantage
            // in precision
            move.Normalize();
        }

        transform.position += move * horizSpeed * Time.deltaTime;
    }

    public void Boost()
    {
        if (horizAxis == 0f)
            vertSpeed += boostVertStr;

        horizSpeed = defHorizSpeed * boostHorizSpeedMult;
        
        boosting = true;
        Invoke("StopBoost", boostLen);
    }

    public void StopBoost()
    {
        horizSpeed = defHorizSpeed;
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
