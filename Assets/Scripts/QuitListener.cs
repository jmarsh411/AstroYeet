using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class QuitListener : MonoBehaviour, IGameEventListener<Void>
{

    [SerializeField]
    private VoidEvent quitEvent;

    // Start is called before the first frame update
    void Start()
    {
        quitEvent.RegisterListener(this);
    }

    public void OnEventRaised(Void unused)
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnDisable()
    {
        quitEvent.UnregisterListener(this);
    }
}
