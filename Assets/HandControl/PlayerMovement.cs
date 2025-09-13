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

    private bool isMoving = false;
    public AudioSource moveSource; 
    public AudioSource stopSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // audioSource = GetComponent<AudioSource>();

        moveAction = InputSystem.actions.FindAction("Move");
        // moveAction.Enable();
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


        bool movingNow = movement.magnitude > 0.01f;

        if (movingNow && !isMoving)
        {
            isMoving = true;
            if (moveSource != null && !moveSource.isPlaying)
                moveSource.Play();
        }

        // Trigger sounds when movement stops
        if (!movingNow && isMoving)
        {
            isMoving = false;
            if (moveSource != null && moveSource.isPlaying)
                moveSource.Stop();

            if (stopSource != null)
                stopSource.Play();
        }
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

