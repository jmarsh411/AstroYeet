using UnityEngine;
using UnityAtoms;

public class ButtonToMainMenu : MonoBehaviour
{

    [SerializeField]
    private VoidEvent mainMenuEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            mainMenuEvent.Raise();
        }
    }
}
