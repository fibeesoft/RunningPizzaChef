using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask layerGround;
    Rigidbody2D rb;
    Vector2 movePos;
    float speedX = 10f;
    Vector2 jumpForce;
    bool canJump = false;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0f, 2000f);
    }

    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        CheckIfGrounded();
        Move();
        Jump();
    }

    void Move()
    {
        rb.velocity = movePos;
    }

    void CheckInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movePos.x = x * speedX;
        if (Input.GetButtonDown("Jump"))
        {
            canJump = true;
        }

    }

    public void TurnJumpingOn()
    {
        canJump = true;
    }

    void Jump()
    {
        if (canJump && isGrounded)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    void CheckIfGrounded()
    {
        if(Physics2D.OverlapCircle(groundChecker.position,1f, layerGround.value))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
