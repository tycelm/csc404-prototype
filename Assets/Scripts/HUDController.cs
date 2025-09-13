using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HUDController : MonoBehaviour
{
    [SerializeField] TMP_Text interactionText;

    public void EnableInteractionText(string content)
    {
        interactionText.text = content + " (E)";
        interactionText.gameObject.SetActive(true);
    }


    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
