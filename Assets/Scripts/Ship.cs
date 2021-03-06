﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAtoms;

public class Ship : MonoBehaviour
{
    private GameManager game;
    private CircleCollider2D coll;
    private Rigidbody2D rBody;
    private AudioSource aSource;
    SpriteRenderer shieldSprite;

    public FloatReference shield;
    public FloatReference maxShields;
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
    private bool invulnerable;
    //private bool boosting;

    // This is a queue of Vector2, which is in this case a substitute for Tuples since
    // Unity doesn't support them. It contains y-position, y-speed pairs for the enemy
    // to keep track of
    public Queue<Vector2> speedHist;
    private float historyInterval;

    private float shieldRegen;
    float shieldDuration = 1.75f;

    void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        coll = GetComponent<CircleCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        speedHist = new Queue<Vector2>();
        aSource = GetComponent<AudioSource>();
        shieldSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        // The starting speed of enemies until they catch up to the player start position
        //speedHist.Enqueue(new Vector2(-1, 10));
        StartCoroutine(UpdateHistory());
        transform.position = new Vector3(0, GameManager.playerHeadStart, 0);
    }

    // Use this for initialization
    void Start()
    {
        //transform.position = new Vector3(0, GameManager.playerHeadStart, 0);
        shield.Variable.Value = maxShields.Value;
        invulnerable = false;
        // recover 2 shield every 60 seconds (FixedUpdate procs every 1/50 seconds)
        shieldRegen = 2f / (50 * 60);
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

        if (Input.GetAxis("Boost") > 0)
        {
            Accel();
        }

        if (Input.GetAxis("Brake") > 0)
        {
            Decel();
        }

        if (transform.position.y > GameManager.goalY)
        {
            YouWin();
        }

        shield.Variable.Value = Mathf.Min(shield.Value + shieldRegen, maxShields.Value);
        if (shield.Value <= 0)
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
        rBody.AddForce(thrust * 2.8f);
    }

    public void Decel()
    {
        rBody.AddForce(-thrust);
    }

    public void TakeHit(int damage)
    {
        aSource.Play();
        if (!invulnerable)
        {
            TakeDamage(damage);
            StartCoroutine(ShieldInvuln());
        }
    }

    public void TakeDamage(int amount)
    {
        shield.Variable.Value -= amount;
    }

    IEnumerator ShieldInvuln()
    {
        invulnerable = true;
        shieldSprite.enabled = true;
        yield return new WaitForSeconds(shieldDuration);
        invulnerable = false;
        shieldSprite.enabled = false;
    }

    public void SetHoriz(float axis)
    {
        horizAxis = axis;
    }

    public void SetVert(float axis)
    {
        //vertAxis = axis;
    }
}
