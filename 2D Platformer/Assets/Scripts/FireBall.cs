using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 30.0f;
    public int damage = 1;
    private Rigidbody2D rb;
    private PlayerController2D playCon;
    private float playSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playCon = GameObject.Find("Player").GetComponent<PlayerController2D>();
        if(playCon.isFacingRight)
        {
            playSpeed = speed;
        }
        else
        {
            playSpeed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * playSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
