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
    public float baseThrust;
    public float addThrust;
    private float mass = 1f;
    private float drag = 0.15f;
    private float horizSpeed = defHorizSpeed;
    public float speed;
    public float accel;
    public float excessThrust;
    private float horizAxis;
    private float vertAxis;
    private Vector3 move;
    private bool boosting = false;

    // speed += thrust - drag

    void Awake()
    {
        speed = defVertSpeed;
        horizAxis = 0f;
        vertAxis = 0f;
        accel = 0;
        excessThrust = 0;
        drag = speed * speed;
        addThrust = 0f;
        StartCoroutine(UpdPhysics());
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
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

    IEnumerator UpdPhysics()
    {
        while (true)
        {
            drag = speed * speed;
            excessThrust = baseThrust + addThrust - drag;
            accel = excessThrust / mass;
            speed += accel * Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        
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
        StartCoroutine(SetThrust(0.3f, 2f));
    }

    private void BoostBack()
    {
        //addThrust -= 0.2f;
        //speed -= boostVertStr;
        StartCoroutine(SetThrust(-0.3f, 2f));

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
