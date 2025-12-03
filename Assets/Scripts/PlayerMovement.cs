using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        transform.position += (Vector3)moveInput * moveSpeed * Time.deltaTime;

        bool isMoving = moveInput.sqrMagnitude > 0.01f;
        anim.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            anim.SetFloat("X",moveInput.x);
            anim.SetFloat("Y",moveInput.y);
        }
    }
}
