using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HUDController : MonoBehaviour
{
    [SerializeField] List<TMP_Text> interactionText;

    public void EnableInteractionText(int player, string content)
    {
        interactionText[player - 1].text = content;
        interactionText[player - 1].gameObject.SetActive(true);
    }


    public void DisableInteractionText(int player)
    {
        interactionText[player - 1].gameObject.SetActive(false);
    }
}
