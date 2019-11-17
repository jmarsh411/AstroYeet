using UnityEngine;
using UnityAtoms;

public class InstructionsListener : MonoBehaviour, IGameEventListener<Void>
{

    [SerializeField]
    private VoidEvent instructionsEvent;
    [SerializeField]
    private GameObject instructionsWrap;
    [SerializeField]
    private GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        instructionsEvent.RegisterListener(this);
    }

    public void OnEventRaised(Void unused)
    {
        instructionsWrap.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnDisable()
    {
        instructionsEvent.UnregisterListener(this);
    }
}
