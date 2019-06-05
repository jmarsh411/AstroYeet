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

    private void Awake()
    {
        rectT = GetComponent<RectTransform>();
        parentRTrans = transform.parent.GetComponent<RectTransform>();
    } 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPos = new Vector3(ship.transform.position.y * parentRTrans.rect.size.x / GameManager.goalY, rectT.anchoredPosition.y);
        rectT.anchoredPosition = newPos;
    }
}
