using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    // [SerializeField] private GameObject hudPrefab;
    public float reach = 1f;
    public GameObject fpsCam;
    Interactable currentItem;
    [SerializeField] private HUDController hUDController;

    private InputAction _interactAction;

    void Start()
    {
        _interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if (_interactAction.WasPressedThisFrame())
        {
            Debug.Log("touch");
        }

        CheckInteraction();

        if (_interactAction.WasPressedThisFrame() && currentItem != null)
        {
            currentItem.Interact(gameObject);
        }

    }

    void CheckInteraction()
    {
        RaycastHit hit;

        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        if (Physics.Raycast(ray, out hit, reach))
        {

            if (hit.collider.tag == "interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentItem && newInteractable != currentItem)
                {
                    currentItem.DisableOutline();
                }

                if (newInteractable.enabled)
                {
                    SetNewCurrInteractable(newInteractable);
                }
                else
                {
                    DisableCurrInteractable();
                }
            }
            else
            {
                DisableCurrInteractable();
            }
        }
        else
        {
            DisableCurrInteractable();
        }
    }

    void SetNewCurrInteractable(Interactable newInteractable)
    {
        currentItem = newInteractable;
        currentItem.EnableOutline();
        hUDController.EnableInteractionText(currentItem.message);
    }

    void DisableCurrInteractable()
    {
        hUDController.DisableInteractionText();
        if (currentItem)
        {
            currentItem.DisableOutline();
            currentItem = null;
        }
    }
}
