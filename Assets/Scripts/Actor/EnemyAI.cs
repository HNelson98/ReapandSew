using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float checkRadius;

    [SerializeField] bool shouldRotate;

    [SerializeField] LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    //private Animator anim;
    private Vector2 movement;
    private Knockback kb;
    [SerializeField] Vector3 dir;

    private bool isInChaseRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        kb = GetComponent<Knockback>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        //anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            //anim.SetFloat("X", dir.x);
            //anim.SetFloat("Y", dir.y);
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange)
        {
            MoveCharacter(movement);
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
