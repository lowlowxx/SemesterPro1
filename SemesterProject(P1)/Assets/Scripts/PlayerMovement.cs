using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbod;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anime;

    [SerializeField] private LayerMask jumpableGround;
    private float directionX = 0f;

    public float moveSpeed = 7f;
    public float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rigidbod = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
    }

   private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rigidbod.velocity = new Vector2(directionX * moveSpeed, rigidbod.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            PlayerJumping();
        }

        // Check for left arrow key press
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        // Check for right arrow key press
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }




        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rigidbod.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rigidbod.velocity.y < -.01f)
        {
            state = MovementState.falling;
        }

        anime.SetInteger("state", (int)state);
    }

    public void PlayerJumping()
    {
        rigidbod.velocity = new Vector3(rigidbod.velocity.x, jumpForce);
    }


    public void MoveLeft()
    {
        // Move the player to the left based on the moveSpeed
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        // Move the player to the right based on the moveSpeed
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
