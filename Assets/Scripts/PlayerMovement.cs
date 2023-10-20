using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float directionx = 0f;

    [SerializeField] private LayerMask JumpGround;

    private enum MovementState {idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSoundEffect;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionx * 7f, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        UpdateAnimation();


    }

    private void UpdateAnimation()
    {
        MovementState movstate;
        
        if (directionx > 0f)
        {
            movstate = MovementState.running;
            sprite.flipX = false;
        }

        else if (directionx < 0f)
        {
            movstate = MovementState.running;
            sprite.flipX = true;
        }

        else
        {
            movstate = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            movstate = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            movstate = MovementState.falling;
        }

        anim.SetInteger("movstate", (int)movstate);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpGround);
    }
}
