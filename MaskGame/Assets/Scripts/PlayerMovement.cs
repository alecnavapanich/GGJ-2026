using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 45f;
    [SerializeField] private float deceleration = 65f;

    [Header("SFX Settings")]
    [SerializeField] private AudioClip[] footstepClips; //array
    [SerializeField] private float stepRate = 0.5f; //step speed
    private float stepTimer;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFootsteps();
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = moveInput.normalized*moveSpeed;

        float currentRate = (moveInput.magnitude > 0) ? acceleration : deceleration;

        rb.linearVelocity = Vector2.MoveTowards(
            rb.linearVelocity,
            targetVelocity,
            currentRate*Time.fixedDeltaTime
        );
    }

    private void HandleFootsteps()
    {
        if(moveInput.sqrMagnitude > 0.01f)
        {
            stepTimer -= Time.deltaTime;

            if(stepTimer <= 0)
            {
                SFXManager.instance?.playRandomAudioClip(footstepClips, transform, 0.5f);
                stepTimer = stepRate;
            }
        }
        else
        {
            stepTimer = 0.1f;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
