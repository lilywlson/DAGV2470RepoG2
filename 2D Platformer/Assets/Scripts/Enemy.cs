using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damage)
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has been destroyed!");
        }

        health -= damage;
        Debug.Log(damage + "Damage Taken!");
    }
}
