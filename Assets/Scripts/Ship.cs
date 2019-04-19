using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private GameManager game;
    private CircleCollider2D coll;
    private Rigidbody2D rBody;

    public float shield;
    private Vector2 thrust;
    private Vector3 temp;
    float tempx;
    private float colliderPadding;
    private float leftBound;
    private float rightBound;
    private float horizSpeed = 5f;
    private float horizAxis;
    //private float vertAxis;
    private Vector3 move;
    //private bool boosting;

    // This is a queue of Vector2, which is in this case a substitute for Tuples since
    // Unity doesn't support them. It contains y-position, y-speed pairs for the enemy
    // to keep track of
    public Queue<Vector2> speedHist;
    private float historyInterval;

    private float shieldRegen;

    void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        coll = GetComponent<CircleCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        speedHist = new Queue<Vector2>();
        // The starting speed of enemies until they catch up to the player start position
        //speedHist.Enqueue(new Vector2(-1, 10));
        StartCoroutine(UpdateHistory());
    }

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, GameManager.playerHeadStart, 0);
        shield = 5;
        // recover 1 shield every 60 seconds (FixedUpdate procs every 1/50 seconds)
        shieldRegen = 1f / (50 * 60);
        thrust = new Vector2(0, 20f);
        horizAxis = 0f;
        historyInterval = 1f;
        //vertAxis = 0f;
        colliderPadding = coll.bounds.extents.x;
        leftBound = game.playArea.min.x + colliderPadding;
        rightBound = game.playArea.max.x - colliderPadding;
        //boosting = false;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        move = new Vector3(horizAxis, 0, 0);
        move.Normalize();
        temp = transform.position + move * horizSpeed * Time.deltaTime;
        // keep x within the game's playable boundaries
        tempx = Mathf.Clamp(temp.x, leftBound, rightBound);
        rBody.AddForce(thrust);
        transform.position = new Vector3(tempx, temp.y, temp.z);

        if (Input.GetAxis("BoostJoy") > 0 || Input.GetAxis("BoostKey") > 0)
        {
            Accel();
        }

        if (Input.GetAxis("BrakeJoy") > 0 || Input.GetAxis("BrakeKey") > 0)
        //if (Input.GetAxis("BrakeKey") > 0)
        {
            Decel();
        }

        if (transform.position.y > GameManager.goalY)
        {
            YouWin();
        }

        shield = Mathf.Min(shield + shieldRegen, 5f);
        if (shield < 1)
        {
            GameOver();
        }
    }



    IEnumerator UpdateHistory()
    {
        yield return new WaitUntil(()=> transform.position.y > GameManager.playerHeadStart + 20);
        while (true)
        {
            speedHist.Enqueue(new Vector2(transform.position.y, rBody.velocity.y));
            yield return new WaitForSeconds(historyInterval);
        }
    }

    private void YouWin()
    {
        SceneManager.LoadScene("Yeet");
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void Accel()
    {
        rBody.AddForce(thrust * 3);
    }

    public void Decel()
    {
        rBody.AddForce(-thrust);
    }

    public void TakeDamage(int amount)
    {
        shield -= amount;
    }

    //public void Boost()
    //{
    //    // Horizontal boost takes priority if axis are equal
    //    if (horizAxis != 0 && Mathf.Abs(horizAxis) >= Mathf.Abs(vertAxis))
    //    {
    //        BoostHoriz();
    //    }
    //    else
    //    {
    //        if (vertAxis < 0)
    //            BoostBack();
    //        else
    //            BoostForw();
    //    }

    //    boosting = true;
    //    Invoke("StopBoost", boostLen);
    //}

    //IEnumerator SetThrust(float thrust, float duration)
    //{
    //    addThrust = thrust;
    //    yield return new WaitForSeconds(duration);
    //    addThrust = 0;
    //}

    //private void BoostForw()
    //{
    //    //speed += boostVertStr;
    //    //addThrust += 0.2f;
    //    StartCoroutine(SetThrust(boostVertStr, boostLen * 2));
    //}

    //private void BoostBack()
    //{
    //    //addThrust -= 0.2f;
    //    //speed -= boostVertStr;
    //    StartCoroutine(SetThrust(-boostVertStr * 0.2f, boostLen));

    //}

    //private void BoostHoriz()
    //{
    //    horizSpeed = defHorizSpeed * boostHorizSpeedMult;
    //}

    //public void StopBoost()
    //{
    //    horizSpeed = defHorizSpeed;
    //    boosting = false;
    //}

    //public bool IsBoosting()
    //{
    //    return boosting;
    //}

    public void SetHoriz(float axis)
    {
        horizAxis = axis;
    }

    public void SetVert(float axis)
    {
        //vertAxis = axis;
    }
}
