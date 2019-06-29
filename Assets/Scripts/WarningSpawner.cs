using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class WarningSpawner : MonoBehaviour, IGameEventListener<Vector3>
{
    public GameObject WarningPrefab;

    [SerializeField]
    private Vector3Event enemyShootEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyShootEvent.RegisterListener(this);
    }

    public void OnEventRaised(Vector3 pos)
    {
        //Debug.Log("Laser Spawned: " + pos);
        GameObject laser = Instantiate(WarningPrefab, transform, false);
        laser.transform.localPosition = pos;
    }
}
