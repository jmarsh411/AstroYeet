using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class GameManager : MonoBehaviour
{
    // Global TODO
    // - decouple ship from shield

    //public Score score;
    public float enemyDist;
    public float laserSpeed;
    public GameObject LaserPrefab;
    public Bounds playArea;
    private Camera cam;


    // how far player must travel to win
    public static float goalDist = 1000;
    public static float playerHeadStart = 250;
    public static float goalY = goalDist + playerHeadStart;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        float camHeight = cam.orthographicSize * 2;
        float camWidth = camHeight * cam.aspect;
        playArea = new Bounds(Vector3.zero, new Vector3(camWidth, camHeight, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
