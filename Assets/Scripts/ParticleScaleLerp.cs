using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScaleLerp : MonoBehaviour
{
    public Vector3 targetScale;

    private Vector3 origScale;
    private ParticleSystem partSys;
    private ParticleSystem.MainModule main;
    private ParticleSystem.ShapeModule shape;
    private Vector3 newScale;

    private void Awake()
    {
        partSys = GetComponent<ParticleSystem>();
        main = partSys.main;
        shape = partSys.shape;
    }
    // Start is called before the first frame update
    void Start()
    {
        origScale = shape.scale;
    }

    // Update is called once per frame
    void Update()
    {
        newScale = Vector3.Lerp(origScale, targetScale, partSys.time / main.duration);
        shape.scale = newScale;
    }
}
