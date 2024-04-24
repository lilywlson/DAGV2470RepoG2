using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Player Stats
    [Header("Player Stats")]
    public float speed;
    public float jumpForce;
    private float moveInput;

    // Player RigidBody
    [Header("RigidBody Component")]
    private Rigidbody2D rb;
    public bool isFacingRight = true;

    // Player Jump
    [Header("Player Jump Settings")]
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool doubleJumpAvailable = false;

    [Header("Animations")]
    private Animator playerAnim;

    private PickUpScoreManager incScore;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        incScore = GetComponent<PickUpScoreManager>();
    }

    // Fixed Update is called a fixed or set number of frames. This works best with physics based movement
    void FixedUpdate()
    {
        if (moveInput != 0)
        {
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // If player is moving right but facing left, flip player right
        if (!isFacingRight && moveInput > 0)
        {
            FlipPlayer();
        }
        // If the player is moving left but facing right, flip player left
        else if (isFacingRight && moveInput < 0)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    // Update is called once per frame.
    void Update()
    {
        if (isGrounded)
        {
            doubleJumpAvailable = true;
        }

        // Touch input for movement
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.position.y < (2 * (Screen.height / 3)))
            {
                if (touch.position.x < Screen.width / 3)
                {
                    moveInput = -1;
                }
                else if (touch.position.x > Screen.width-(Screen.width / 3))
                {
                    moveInput = 1;
                }
            }
        }
        else
        {
            moveInput = 0;
        }

        // Touch input for jumping
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 3)
            {
                if (touch.position.x < Screen.width-(Screen.width / 3))
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (isGrounded)
                        {
                            Jump();
                        }
                        else if (doubleJumpAvailable)
                        {
                            Jump();
                            doubleJumpAvailable = false;
                        }
                    }
                }
            }

        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        playerAnim.SetTrigger("Jump_Trig");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            string itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
            Debug.Log("You have collected a: " + itemType);
            Destroy(collision.gameObject);
            incScore.IncreaseScore(1);
        }
    }
}

