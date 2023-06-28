using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackPower = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyLife>(out EnemyLife enemyComponent))
        {
            enemyComponent.TakeDamage(attackPower, gameObject);
        }
    }
}
