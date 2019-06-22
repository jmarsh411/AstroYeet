using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityAtoms;

public class UpdateShields : MonoBehaviour
{
    public FloatReference shield;
    public FloatReference maxShields;
    private RectTransform rect;
    private float initHeight;
    private float updRate;

    private void Awake()
    {
        rect= GetComponent<RectTransform>();
        // UI stuff doesn't need to update every frame
        updRate = 0.25f;
    }
    // Start is called before the first frame update
    void Start()
    {
        initHeight = rect.sizeDelta.y;
        StartCoroutine(UpdateBar());
    }

    IEnumerator UpdateBar()
    {
        while (true)
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, shield * (initHeight / maxShields));

            yield return new WaitForSeconds(updRate);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
