using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class PauseListener : MonoBehaviour, IGameEventListener<Void>
{

    public GameObject PausePanel;
    [SerializeField]
    private VoidEvent pauseEvent;

    private bool paused;

    void Awake()
    {
        paused = false;
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
            Time.timeScale = 1;
            paused = false;
            PausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            PausePanel.SetActive(true);
        }
    }


    public void OnDisable()
    {
        pauseEvent.UnregisterListener(this);
    }
}
