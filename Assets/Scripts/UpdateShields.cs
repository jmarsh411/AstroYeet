using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateShields : MonoBehaviour
{
    private Ship ship;
    private Text text;
    private float updRate;

    private void Awake()
    {
        ship = GameObject.FindWithTag("PlayerShip").GetComponent<Ship>();
        text = GetComponent<Text>();
        updRate = 0.25f;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateText());
    }

    // UI stuff doesn't need to update every frame
    IEnumerator UpdateText()
    {
        while (true)
        {
            //text.text = ship.shield.ToString();
            text.text = Mathf.FloorToInt(ship.shield).ToString();

            yield return new WaitForSeconds(updRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
