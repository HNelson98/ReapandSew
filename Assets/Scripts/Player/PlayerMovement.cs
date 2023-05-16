using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //private BoxCollider2D coll;
    private SpriteRenderer sprite;
    //private Animator anim;

    private float dirX = 0f;
    private float dirY = 0f;
    private string facing_angle = "D"; 
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] float rollForce = 6.0f;
    private float addSpeedX = 0f;
    private float addSpeedY = 0f;
    private bool rolling = false;
    private float timeSinceAction = 0.0f;
    private float rollDuration = 8.0f / 14.0f;
    //private float rollCurrentTime;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(1) && timeSinceAction > rollDuration) // Roll
        {
            rolling = true;
            if (dirX > 0)
            {
                addSpeedX += rollForce;
            }
            if (dirX < 0)
            {
                addSpeedX -= rollForce;
            }
            if (dirY > 0)
            {
                addSpeedY += rollForce;
            }
            if (dirY < 0)
            {
                addSpeedY -= rollForce;
            }
            
            Invoke("ResetMovement", rollDuration);

            // Reset timer
            timeSinceAction = 0.0f;
        }

        rb.velocity = new Vector2((dirX * moveSpeed) + addSpeedX, (dirY * moveSpeed) + addSpeedY);
        timeSinceAction += Time.deltaTime;

        // UpdateAnimationState();

    }

    private void ResetMovement()
    {
        rolling = false;
        addSpeedX = 0f;
        addSpeedY = 0f;
    }

    private void UpdateAnimationState()
    {

        if (Input.GetMouseButtonDown(0) && timeSinceAction > 0.25f && !rolling) // Attack
        {
            // anim.Play("Player_Attack" + facing_angle);

            // Reset timer
            timeSinceAction = 0.0f;
        }

        else if (Input.GetMouseButtonDown(1) && timeSinceAction > rollDuration) // Roll
        {
            // anim.Play("Player_Roll" + facing_angle);
        }
        
        else if (dirX > 0f) // Right
        {
            facing_angle = "X";
            // anim.Play("Player_Walking" + facing_angle);
            sprite.flipX = false;
        }
        else if (dirX < 0f) // Left
        {
            facing_angle = "X";
            // anim.Play("Player_Walking" + facing_angle);
            sprite.flipX = true;
        }
        else if (dirY > 0f) // Up
        {
            
            facing_angle = "U";
            // anim.Play("Player_Walking" + facing_angle);
            sprite.flipX = false;
        }
        else if (dirY < 0f) // Down
        {
            facing_angle = "D";
            // anim.Play("Player_Walking" + facing_angle);
            sprite.flipX = false;
        }

        else // Idle
        {
            // anim.Play("Player_Idle" + facing_angle);
        }
    }
}
