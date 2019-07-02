using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class ParticleSysEOL : MonoBehaviour
{
    public Vector3Event laserEvent;
    private ParticleSystem pSystem;

    void Awake()
    {
        pSystem = GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        if (!pSystem.IsAlive())
        {
            laserEvent.Raise(transform.position);
            Destroy(this.gameObject);
        }
    }
}
