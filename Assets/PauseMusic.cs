using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class PauseMusic : MonoBehaviour, IGameEventListener<Void>
{

    [SerializeField]
    private VoidEvent pauseEvent;
    private AudioSource audioSource;

    private bool paused;

    void Awake()
    {
        paused = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseEvent.RegisterListener(this);
    }

    public void OnEventRaised(Void unused)
    {
        if (paused)
        {
            audioSource.Play();
            paused = false;
        }
        else
        {
            audioSource.Pause();
            paused = true;
        }
    }


    public void OnDisable()
    {
        pauseEvent.UnregisterListener(this);
    }
}
