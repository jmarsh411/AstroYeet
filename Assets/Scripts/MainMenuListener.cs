using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAtoms;

public class MainMenuListener : MonoBehaviour, IGameEventListener<Void>
{

    [SerializeField]
    private VoidEvent mainMenuEvent;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuEvent.RegisterListener(this);
    }

    public void OnEventRaised(Void unused)
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnDisable()
    {
        mainMenuEvent.UnregisterListener(this);
    }
}
