using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateShields : MonoBehaviour
{
    private Ship ship;
    private Text text;
    private RectTransform rect;
    private float initHeight;
    private float updRate;

    private void Awake()
    {
        ship = GameObject.FindWithTag("PlayerShip").GetComponent<Ship>();
        //text = GetComponent<Text>();
        rect= GetComponent<RectTransform>();
        // UI stuff doesn't need to update every frame
        updRate = 0.25f;
    }
    // Start is called before the first frame update
    void Start()
    {
        initHeight = rect.sizeDelta.y;
        //StartCoroutine(UpdateText());
        StartCoroutine(UpdateBar());
    }

    IEnumerator UpdateBar()
    {
        while (true)
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, ship.shield * (ship.maxShields / initHeight));

            yield return new WaitForSeconds(updRate);
        }
    }

    //IEnumerator UpdateText()
    //{
    //    while (true)
    //    {
    //        text.text = Mathf.FloorToInt(ship.shield).ToString();

    //        yield return new WaitForSeconds(updRate);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
