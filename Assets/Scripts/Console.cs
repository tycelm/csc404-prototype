using UnityEngine;

public class Console : Interactable
{
    private GameObject handRigTarget;

    void Start()
    {
        DisableOutline();
        handRigTarget = GameObject.Find("HandRig_target");
    }
    
    public override void Interact(GameObject player)
    {
        player.GetComponent<Player>().TurnOff();
        handRigTarget.GetComponent<PlayerMovement>().TurnOn(player);
    }
    
    
}
