using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;
    private Rigidbody rb;

    private InputAction moveAction;
    private InputAction dpadAction;
    public Vector3 movement;

    // private void Awake()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        dpadAction = InputSystem.actions.FindAction("DpadMove");
    }

    void Update()
    {
        // Vector2 move = dpadAction.ReadValue<Vector2>();
        // rb.linearVelocity = move * speed;

        Vector2 stickMove = moveAction.ReadValue<Vector2>();
        Vector2 dpadMove = dpadAction.ReadValue<Vector2>();
        Vector3 stickMovement = new Vector3(stickMove.x, stickMove.y, 0);
        Vector3 dpadMovement = new Vector3(0, 0, dpadMove.y);
        movement = (stickMovement + dpadMovement) * speed;
        rb.linearVelocity = movement;
    }

    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     moveInput = context.ReadValue<Vector2>();
    //     Debug.Log("moving!");
    // }
    // private void FixedUpdate()
    // {
    //     rb.linearVelocity = movement * speed * Time.fixedDeltaTime;
    // }
}

