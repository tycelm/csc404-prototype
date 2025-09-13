using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;
    private Rigidbody rb;

     private InputAction moveAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = move * speed;
    }

    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     moveInput = context.ReadValue<Vector2>();
    //     Debug.Log("moving!");
    // }
    // private void FixedUpdate()
    // {
    //     Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
    //     rb.linearVelocity = move * speed;
    // }
}

