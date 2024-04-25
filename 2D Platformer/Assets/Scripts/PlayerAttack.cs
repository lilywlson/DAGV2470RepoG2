using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private float attackDelay;
    public float startDelay;
    public Transform attackPos;

    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    public Transform firePoint;
    public GameObject projectile;
    public bool canAttack;

    // public Button attackButton; // Reference to the attack button

    // Start is called before the first frame update
    void Start()
    {
        // attackButton.onClick.AddListener(Attack); // Listen for button click
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(canAttack)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.position.y > (2 * (Screen.height / 3)))
                {
                    if (touch.position.x > (2 * (Screen.width / 3)))
                    {
                        canAttack = false;
                        Attack();
                        Shoot();
                    }
                }
            }
        }
        else
        {
            canAttack = true;
        }
    }

    // Function to perform the attack
    void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

