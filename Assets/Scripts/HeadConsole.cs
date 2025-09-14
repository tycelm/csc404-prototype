using UnityEngine;
using UnityEngine.InputSystem;

public class HeadConsole : Interactable
{
    [SerializeField] private Vector3 camPosition;
    [SerializeField] private Quaternion camAngle;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public override void Interact(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        // save old rotation
        Camera playerCam = playerInput.camera;
        originalPosition = playerCam.transform.position;
        originalRotation = playerCam.transform.rotation;

        playerCam.transform.position = camPosition;
        playerCam.transform.rotation = camAngle;
    }
}
