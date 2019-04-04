using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUIIcon : MonoBehaviour
{
    public GameObject ship;

    private GameObject parent;
    private RectTransform parentRTrans;
    private GameObject enemyShip;
    private Enemy enemy;
    private RectTransform rectT;
    private float totalDist;

    private void Awake()
    {
        rectT = GetComponent<RectTransform>();
        parentRTrans = transform.parent.GetComponent<RectTransform>();
        //enemyShip = GameObject.FindWithTag("EnemyShip");

    }

    // Start is called before the first frame update
    void Start()
    {
        //rectT.rect.size.y;
        totalDist = GameManager.goalDist + Enemy.startDist;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPos = new Vector3(rectT.anchoredPosition.x, ship.transform.position.y * parentRTrans.rect.size.y / GameManager.goalDist + Enemy.startDist);
        rectT.anchoredPosition = newPos;
    }
}
