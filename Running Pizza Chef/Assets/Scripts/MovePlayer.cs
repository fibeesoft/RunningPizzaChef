using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask layerGround;
    [SerializeField] AudioClip[] audioclips;
    AudioSource audios;

    Animator anim;
    Rigidbody2D rb;
    Vector2 movePos;
    float speedX = 10f;
    Vector2 jumpForce;
    bool canJump = false;
    bool isGrounded;


    void Start()
    {
        audios = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0f, 2000f);
        anim = GetComponent<Animator>();
    }

    void PlayRunningAudio()
    {
        if (!audios.isPlaying)
        {
            audios.clip = audioclips[0];
            audios.Play();
        }
    }

    void PlayJumpAudio()
    {
        audios.Stop();
        audios.PlayOneShot(audioclips[1]);
    }


    void Update()
    {
        CheckInput();

        if(Mathf.Abs(rb.velocity.y) < 0.05f)
        {
            SwitchAnimation("Run");
            PlayRunningAudio();
        }
        else
        {
            SwitchAnimation("Jump");
        }
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

    void SwitchAnimation(string trigger)
    {
        anim.SetTrigger(trigger);
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
            PlayJumpAudio();
            canJump = false;
        }
        else
        {
            canJump = false;
        }
    }

    void CheckIfGrounded()
    {
        if(Physics2D.OverlapCircle(groundChecker.position, 0.6f, layerGround.value))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
