using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class WarningToLaser : MonoBehaviour
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
            laserEvent.Raise(transform.localPosition);
            Destroy(this.gameObject);
        }
    }
}
