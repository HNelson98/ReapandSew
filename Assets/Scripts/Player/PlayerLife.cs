using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 5f;
    [SerializeField] float respawnTimer = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private PlayerMovement movement;
    private SpriteRenderer sprite;
    private Knockback kb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        sprite = GetComponent<SpriteRenderer>();
        kb = GetComponent<Knockback>();

        health = maxHealth;
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject sender = collision.gameObject;
        // if (sender.CompareTag("Lava"))
        // {
        //     TakeDamage(maxHealth);
        // }

        if (sender.CompareTag("Enemy"))
        {
            kb.PlayFeedback(sender);
            TakeDamage(1);
        }
    }

    private void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        this.movement.enabled = false;
        anim.SetTrigger("death");
        Invoke("Respawn", respawnTimer);
    }

    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
