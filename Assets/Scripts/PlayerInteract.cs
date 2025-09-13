using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // [SerializeField] private GameObject hudPrefab;
    public float reach = 1f;
    public GameObject fpsCam;
    Interactable currentItem;
    HUDController hUDController;

    void Start()
    {
        hUDController = GetComponentInChildren<HUDController>(true);
    }


    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            currentItem.Interact();
        }

    }

    void CheckInteraction()
    {
        RaycastHit hit;

        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        if (Physics.Raycast(ray, out hit, reach))
        {

            if (hit.collider.tag == "Interactable")
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
