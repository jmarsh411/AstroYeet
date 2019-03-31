﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private CircleCollider2D collider;
    private GameManager game;
    private Vector3 temp;
    float tempx;
    private float colliderPadding;
    private float leftBound;
    private float rightBound;
    const float defHorizSpeed = 5f;
    private float defVertSpeed = 0.15f;
    private float boostLen = 0.07f;
    private float boostHorizSpeedMult = 6f;
    private float boostVertStr;
    public float dragMult;
    public float baseThrust;
    public float addThrust;
    public float mass;
    private float drag;
    private float horizSpeed = defHorizSpeed;
    public float speed;
    public float accel;
    public float excessThrust;
    private float horizAxis;
    private float vertAxis;
    private Vector3 move;
    private bool boosting = false;
    private float baseSpeed = 0.2f;
    public float speedMult;

    // speed += thrust - drag

    void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Use this for initialization
    void Start()
    {
        speed = defVertSpeed;
        horizAxis = 0f;
        vertAxis = 0f;
        accel = 0;
        excessThrust = 0;
        drag = speed * speed;
        addThrust = 0f;
        speedMult = 1f;
        boostVertStr = baseThrust * 40;
        colliderPadding = collider.bounds.extents.x;
        leftBound = game.playArea.min.x + colliderPadding;
        rightBound = game.playArea.max.x - colliderPadding;
        //StartCoroutine(UpdPhysics());
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        //UpdPhysics();
        //speed += accel * Time.deltaTime;
        //speedMult = speed / baseSpeed;

        // can only change direction while not boosting
        if (!IsBoosting())
        {
            move = new Vector3(horizAxis, 0, 0);
            // normalize movement vector so joysticks don't have an advantage
            // in precision
            move.Normalize();
        }

        temp = transform.position + move * horizSpeed * Time.deltaTime;
        // keep x within the game's playable boundaries
        tempx = Mathf.Clamp(temp.x, leftBound, rightBound);
        transform.position = new Vector3(tempx, temp.y, temp.z);
    }

    public void Boost()
    {
        // Horizontal boost takes priority if axis are equal
        if (horizAxis != 0 && Mathf.Abs(horizAxis) >= Mathf.Abs(vertAxis))
        {
            BoostHoriz();
        }
        else
        {
            if (vertAxis < 0)
                BoostBack();
            else
                BoostForw();
        }
        
        boosting = true;
        Invoke("StopBoost", boostLen);
    }

    void UpdPhysics()
    {
            // https://www.grc.nasa.gov/www/k-12/airplane/exthrst.html
            drag = dragMult * speed * speed;
            excessThrust = baseThrust + addThrust - drag;
            accel = excessThrust / mass;

    }

    IEnumerator SetThrust(float thrust, float duration)
    {
        addThrust = thrust;
        yield return new WaitForSeconds(duration);
        addThrust = 0;
    }

    private void BoostForw()
    {
        //speed += boostVertStr;
        //addThrust += 0.2f;
        StartCoroutine(SetThrust(boostVertStr, boostLen * 2));
    }

    private void BoostBack()
    {
        //addThrust -= 0.2f;
        //speed -= boostVertStr;
        StartCoroutine(SetThrust(-boostVertStr * 0.2f, boostLen));

    }

    private void BoostHoriz()
    {
        horizSpeed = defHorizSpeed * boostHorizSpeedMult;
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

    public void SetVert(float axis)
    {
        vertAxis = axis;
    }
}
