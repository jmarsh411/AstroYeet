using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityAtoms;

public class RadHealthBar : MonoBehaviour
{
    public FloatReference hp;
    public FloatReference maxHP;

    private Image image;
    private float fill;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = hp.Value / maxHP.Value;
    }
}
