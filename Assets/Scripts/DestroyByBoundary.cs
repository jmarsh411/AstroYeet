using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("PlayerShip");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject != player)
        {
            Destroy(other.gameObject);
        }
    }
}
