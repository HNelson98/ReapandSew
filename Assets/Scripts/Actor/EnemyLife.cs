using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 1f;

    private Knockback kb;

    private void Start()
    {
        kb = GetComponent<Knockback>();

        health = maxHealth;
    }

    public void TakeDamage(float damageAmount, GameObject sender)
    {
        health -= damageAmount;

        kb.PlayFeedback(sender);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
