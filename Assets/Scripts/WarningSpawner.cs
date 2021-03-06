﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class WarningSpawner : MonoBehaviour, IGameEventListener<Vector3>
{
    public GameObject WarningPrefab;

    [SerializeField]
    private Vector3Event laserWarnEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        laserWarnEvent.RegisterListener(this);
    }

    void OnDisable()
    {
        laserWarnEvent.UnregisterListener(this);
    }

    public void OnEventRaised(Vector3 pos)
    {
        //Debug.Log("Laser Spawned: " + pos);
        GameObject laser = Instantiate(WarningPrefab, transform, false);
        laser.transform.localPosition = pos;
    }
}
