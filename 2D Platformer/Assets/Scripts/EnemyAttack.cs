using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Health playerHealth;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        playerHealth.TakeDamage(damage);
        Debug.Log("Player Takes "+ damage + " points of damage.");
    }
}
