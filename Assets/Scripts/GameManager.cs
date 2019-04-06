using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public Score score;
    public float enemyDist;
    public float laserSpeed;
    public GameObject LaserPrefab;
    public Bounds playArea;
    private Camera cam;
    public float uiOffset;

    // how far player must travel to win
    public static float goalDist = 1000;
    public static float playerHeadStart = 250;
    public static float goalY = goalDist + playerHeadStart;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        float camHeight = cam.orthographicSize * 2;
        float camWidth = camHeight * cam.aspect;
        // camera width is 11.25
        // UI rect is 50 wide out of a total 450 width, or 1/9
        // 11.25 * 1/9 = 1.25
        // play area width = 11.25 - 1.25 = 10
        uiOffset = 1.25f;
        playArea = new Bounds(Vector3.zero, new Vector3(camWidth - uiOffset, camHeight, 0));
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
