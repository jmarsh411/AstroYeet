using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAtoms;

public class StartGameListener : MonoBehaviour, IGameEventListener<Void>
{

    [SerializeField]
    private VoidEvent startGameEvent;

    // Start is called before the first frame update
    void Start()
    {
        startGameEvent.RegisterListener(this);
    }

    public void OnEventRaised(Void unused)
    {
        SceneManager.LoadScene("Game");
    }

    public void OnDisable()
    {
        startGameEvent.UnregisterListener(this);
    }
}
