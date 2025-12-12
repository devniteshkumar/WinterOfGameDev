using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.5f;

    private bool isDashing = false;
    private float dashTimer = 0f;
    private Vector2 dashDirection;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnDash(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.Log("shift pressed");
            Dash();
        }
    }

    void Dash()
    {
        if (isDashing)
            return;
        if (dashTimer > 0f)
            return;

        if(moveInput.sqrMagnitude > 0.0001f)
        {
            isDashing = true;
            dashTimer = dashCooldown;
            dashDirection = moveInput.normalized;
        }
    }

    void Update()
    {
        if (!isDashing)
        {
            rb.linearVelocity = moveInput * moveSpeed;


            bool isMoving = moveInput.sqrMagnitude > 0.01f;
            anim.SetBool("IsMoving", isMoving);


            if (isMoving)
            {
                anim.SetFloat("X", moveInput.x);
                anim.SetFloat("Y", moveInput.y);
            }
        }
    }

    void FixedUpdate()
    {
        if(isDashing)
        {
            rb.linearVelocity = dashDirection * dashSpeed;
            dashTimer -= Time.fixedDeltaTime;
            if(dashTimer < 0f)
            {
                isDashing= false;
                dashTimer = dashCooldown;
            }
            else
            {
                if(dashTimer > 0f)
                {
                    dashTimer -= Time.fixedDeltaTime;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "square")
            Debug.Log("works");
    }
}
