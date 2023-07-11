using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //private BoxCollider2D coll;
    private SpriteRenderer sprite;
    //private Animator anim;

    //private Rigidbody playerRb;

    private float dirX = 0f;
    private float dirY = 0f;
    private string facing_angle = "D";
    private int index = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] float rollForce = 6.0f;
    private float addSpeedX = 0f;
    private float addSpeedY = 0f;
    private bool rolling = false;
    private bool stopMovement = false;
    private float timeSinceAction = 0.0f;
    private float rollDuration = 8.0f / 14.0f;
    private float attackDuration = 0.25f;

    public Animator animator; 

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
            if (dirX > 0f) // Right
            {
                addSpeedX += rollForce;
            }
            if (dirX < 0f) // Left
            {
                addSpeedX -= rollForce;
            }
            if (dirY > 0f) // Up
            {
                addSpeedY += rollForce;
            }
            if (dirY < 0f) // Down
            {
                addSpeedY -= rollForce;
            }
            
            Invoke("ResetMovement", rollDuration);
            // Reset timer
            timeSinceAction = 0.0f;
        }

        if (Input.GetMouseButtonDown(0) && timeSinceAction > attackDuration && !rolling) // Attack
        {
            if (facing_angle == "X" && sprite.flipX == false) // Right
            {
                index = 0;

                

            }
            if (facing_angle == "X" && sprite.flipX == true) // Left
            {
                index = 1;

                
            }
            if (facing_angle == "U") // Up
            {
                index = 2;

                
            }
            if (facing_angle == "D") // Down
            {
                index = 3;

                
            }

            transform.GetChild(index).gameObject.SetActive(true);
            stopMovement = true;
            Invoke("ResetMovement", attackDuration);

            // Reset timer
            timeSinceAction = 0.0f;
        }

        if (stopMovement)
        {
            dirX = 0f;
            dirY = 0f;
        }
        rb.velocity = new Vector2((dirX * moveSpeed) + addSpeedX, (dirY * moveSpeed) + addSpeedY);
        timeSinceAction += Time.deltaTime;

        UpdateAnimationState();

    }

    private void ResetMovement()
    {
        rolling = false;
        addSpeedX = 0f;
        addSpeedY = 0f;

        stopMovement = false;
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void UpdateAnimationState()
    {

        if (Input.GetMouseButtonDown(0) && timeSinceAction > attackDuration && !rolling) // Attack
        {
            // anim.Play("Player_Attack" + facing_angle);
        }

        else if (Input.GetMouseButtonDown(1) && timeSinceAction > rollDuration) // Roll
        {
            // anim.Play("Player_Roll" + facing_angle);
        }
        
        else if (dirX > 0f) // Right
        {
            facing_angle = "X";
            // anim.Play("Player_Walking" + facing_angle);
            animator.SetFloat("HorizontalSpeed", Mathf.Abs(dirX));

            sprite.flipX = false;
        }
        else if (dirX < 0f) // Left
        {
            facing_angle = "X";
            // anim.Play("Player_Walking" + facing_angle);
            animator.SetFloat("HorizontalSpeed", Mathf.Abs(dirX));

            sprite.flipX = true;
        }
        else if (dirY > 0f) // Up
        {
            
            facing_angle = "U";
            // anim.Play("Player_Walking" + facing_angle);
            animator.SetFloat("VerticalSpeed", Mathf.Abs(dirY));

            sprite.flipX = false;
        }
        else if (dirY < 0f) // Down
        {
            facing_angle = "D";
            // anim.Play("Player_Walking" + facing_angle);
            animator.SetFloat("VerticalSpeed", dirY);
            
            sprite.flipX = false;
        }

        else // Idle
        {
                animator.SetFloat("VerticalSpeed", dirY);
                animator.SetFloat("HorizontalSpeed", dirX);
            // anim.Play("Player_Idle" + facing_angle);
        }
    }
}
