using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private int extraJumps = 1; // Số lượng double jumps được phép
    private int remainingJumps; // Số lượng double jumps còn lại

    private enum MovementState { idle, running, jumping, falling, doubleJumping };

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        remainingJumps = extraJumps;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                Jump();
            }
            else if (remainingJumps > 0)
            {
                DoubleJump();
            }
        }
        UpdateAnimationUpdate();
    }

    private void Jump()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector3(0, jumpForce, 0);
        remainingJumps = extraJumps; // Reset số lượng double jumps khi nhảy từ mặt đất
    }

    private void DoubleJump()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector3(0, jumpForce, 0);
        remainingJumps--;
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
            if (remainingJumps < extraJumps)
            {
                state = MovementState.doubleJumping;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // Thêm trạng thái double jumping
        //if (remainingJumps < extraJumps)
        //{
        //    state = MovementState.doubleJumping;
        //}

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() => Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
}
