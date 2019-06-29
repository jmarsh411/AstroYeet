using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class Enemy : MonoBehaviour
{
    public GameObject LaserPrefab;

    [SerializeField]
    private Vector3Event enemyShootEvent;

    private GameManager game;
    private GameObject player;
    private Ship ship;
    private Rigidbody2D enemyRB;
    private const float fastVelMult = 1.2f;
    private const float minAccSpread = 0.5f;
    private const float minSpeed = 5f;
    private float maxAccSpread;
    private Vector2 currSpeed;

    enum RelSpeed { VerySlow, Slow, Match, Fast, VeryFast };

    // thresholds for enemy relative speed
    private float verySlowThresh;
    private float slowThresh;
    private float matchThresh;
    private float fastThresh;
    private float veryFastThresh;

    // multipliers for enemy relative speed
    private float verySlowMult;
    private float slowMult;
    private float matchSpeedMult;
    private float fastMult;
    private float veryFastMult;

    private Dictionary<RelSpeed, float> speedMult;
    private Dictionary<RelSpeed, float> speedThresh;

    public float dist;

    private void Awake()
    {
        game = Camera.main.GetComponent<GameManager>();
        player = GameObject.FindWithTag("PlayerShip");
        ship = player.GetComponent<Ship>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        maxAccSpread = game.playArea.extents.x;
        dist = player.transform.position.y - transform.position.y;

        // In the beginning the enemies are far behind
        // so set their overall speed to aggressive
        SetAggroBehav();

        // set enemy relative speed multipliers
        speedMult = new Dictionary<RelSpeed, float>();
        speedMult[RelSpeed.VerySlow] = 0.5f;
        speedMult[RelSpeed.Slow] = 0.75f;
        speedMult[RelSpeed.Match] = 1f;
        speedMult[RelSpeed.Fast] = 1.25f;
        speedMult[RelSpeed.VeryFast] = 1.5f;

        // set the starting velocity of the enemies
        currSpeed = new Vector2(0, 12f);
        StartCoroutine(UpdateSpeed());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = player.transform.position.y - transform.position.y;
        enemyRB.velocity = currSpeed;
        //if (dist > 30)
        //{
        //    Vector2 newVel = new Vector2(0, Mathf.Max(10f, playerRB.velocity.y * fastVelMult));
        //    enemyRB.velocity = newVel;
        //}
        //else
        //{
        //    enemyRB.velocity = playerRB.velocity;
        //}

        //temporary testing key
        if (Input.GetKeyUp(KeyCode.L))
        {
            SpawnLaser();
        }
    }

    IEnumerator UpdateSpeed()
    {
        float roll;
        float behavSpeed;
        float trueSpeed;
        RelSpeed relSpeed = RelSpeed.Match;
        yield return new WaitUntil(() => ship.speedHist.Count > 0);
        while (true)
        {
            Vector2 speedEntry = ship.speedHist.Dequeue();
            float nextPos = speedEntry.x;
            float nextSpeed = speedEntry.y;
            yield return new WaitUntil(() => ReachedNextCheckpoint(nextPos));

            // determine how fast the enemy should be going
            roll = Random.Range(0f, 1f);
            if (roll < verySlowThresh)
                relSpeed = RelSpeed.VerySlow;
            else if (roll < slowThresh)
                relSpeed = RelSpeed.Slow;
            else if (roll < matchThresh)
                relSpeed = RelSpeed.Match;
            else if (roll < fastThresh)
                relSpeed = RelSpeed.Fast;
            else if (roll < veryFastThresh)
                relSpeed = RelSpeed.VeryFast;

            // update beahvior based on how close the player is
            if (dist <= 50)
                SetKiteBehav();
            else if (dist <= 150)
                SetModerateBehav();
            else
                SetAggroBehav();

            // set new current speed
            behavSpeed = nextSpeed * speedMult[relSpeed];
            trueSpeed = Mathf.Max(behavSpeed, minSpeed);
            currSpeed = new Vector2(0, trueSpeed);
        }
    }

    void SetKiteBehav()
    {
        verySlowThresh = 0.2f;
        slowThresh = 0.4f;
        matchThresh = 1f;
        // going faster than the player is disabled
        fastThresh = -100f;
        veryFastThresh = -100f;
    }
    
    void SetModerateBehav()
    {
        verySlowThresh = 0.1f;
        slowThresh = 0.2f;
        matchThresh = 0.3f;
        fastThresh = 0.7f;
        veryFastThresh = 1f;
    }

    void SetAggroBehav()
    {
        verySlowThresh = 0.05f;
        slowThresh = 0.15f;
        matchThresh = 0.3f;
        fastThresh = 0.5f;
        veryFastThresh = 1f;
    }

    bool ReachedNextCheckpoint(float checkpoint)
    {
        return (transform.position.y >= checkpoint);
    }

    public void SpawnLaser()
    {
        float spread = Mathf.Clamp(dist / 200, minAccSpread, maxAccSpread);
        //Vector3 spawnPos = new Vector3(Random.Range(-spread, spread), transform.position.y, 0);
        Vector3 spawnPos = new Vector3(Random.Range(-spread, spread), 0, 0);
        ShootLaser(spawnPos);
    }

    public void ShootLaser(Vector3 position)
    {
        enemyShootEvent.Raise(position);
    }

}
