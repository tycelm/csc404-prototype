using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string message;
    public Outline outline;

    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {
        DisableOutline();
    }

    public virtual void Interact(GameObject player)
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
