using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysEOL : MonoBehaviour
{
    private ParticleSystem pSystem;

    void Awake()
    {
        pSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pSystem.IsAlive())
            Destroy(this.gameObject);
    }
}
