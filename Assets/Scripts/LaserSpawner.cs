using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class LaserSpawner : MonoBehaviour, IGameEventListener<Vector3>
{
    public GameObject LaserPrefab;

    [SerializeField]
    private Vector3Event laserSpawnEvent;

    // Start is called before the first frame update
    void Start()
    {
        laserSpawnEvent.RegisterListener(this);
    }

    void OnDisable()
    {
        laserSpawnEvent.UnregisterListener(this);
    }

    public void OnEventRaised(Vector3 pos)
    {
        //Debug.Log("Laser Spawned: " + pos);
        GameObject laser = Instantiate(LaserPrefab, transform, false);
        laser.transform.localPosition = pos;
    }
}
