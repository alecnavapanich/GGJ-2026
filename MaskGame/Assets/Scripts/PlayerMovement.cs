using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

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
        rb.linearVelocity = moveInput*moveSpeed;
        if(moveInput.magnitude > 0)
        {
            //Debug.Log("Moving: Input = " + moveInput);
        }

        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        if(moveInput.magnitude > 0.1f)
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
            stepTimer = 0;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
