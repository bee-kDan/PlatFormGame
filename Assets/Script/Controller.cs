using System;
using UnityEngine;

public class Controller : MonoBehaviour 
{
    // Movement settings
    public float speed;
    public float jumpForce;
    public float maxFallSpeed = 15f;

    // variable jump settings
    public float jumpHoldDuration = 0.2f;
    public float jumpHoldForce = 20f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public bool onLadder;
    public float climpSpeed;
    private float climpVelocity;
    private float gravityStore;


    Rigidbody2D rb;
    Animator anim;


    // Double Jump
    int jumpCount = 0;
    int maxJump = 2;

    // Attack
    private bool isAttacking = false;
    private float comboCD = 1.2f;
    private float attackTime = 0.5f;
    private float lastAttackTime = 0f;
    private float defaultGravityScale;

    public Transform attackPoint;
    public GameObject banana;

    //Knock Back
    public float knockBack;
    public float knockBackCounter;
    public float knockBackLength;   
    public bool knockFromRight;

    bool isGrounded;
    bool wasGrounded;

    // variable jump state
    private bool isJumping = false;
    private float jumpHoldTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        defaultGravityScale = rb.gravityScale;
        gravityStore = rb.gravityScale;
    }

    void Update()
    {
        wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        // chỉ reset khi vừa chạm đất
        if (isGrounded && !wasGrounded)
        {
            jumpCount = 0;
        }

        // di chuyển 
        float move = Input.GetAxisRaw("Horizontal");

        if (knockBackCounter <= 0)
        {
            rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        }else
        {
            if (knockFromRight)
            {
                rb.linearVelocity = new Vector2(-knockBack, knockBack / 3);
            }else
            {
                rb.linearVelocity = new Vector2(knockBack, knockBack / 3);
            }
            knockBackCounter -= Time.deltaTime;
        }

        // xoay mặt nhân vật
        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // jump (start)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
            isJumping = true;
            jumpHoldTimer = 0f;
        }

        // variable jump: apply extra upward while holding space and within hold duration
        if (isJumping && Input.GetKey(KeyCode.Space) && jumpHoldTimer < jumpHoldDuration)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + jumpHoldForce * Time.deltaTime);
            jumpHoldTimer += Time.deltaTime;
        }

        // stop variable jump on release or when start falling
        if (Input.GetKeyUp(KeyCode.Space) || rb.linearVelocity.y <= 0f)
        {
            isJumping = false;
        }

        // tăng trọng lực khi rơi (set, don't multiply)
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = defaultGravityScale * 1.5f; // stronger fall gravity
        }
        else
        {
            rb.gravityScale = defaultGravityScale; // restore when not falling
        }

        // clamp maximum fall speed
        if (rb.linearVelocity.y < -maxFallSpeed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -maxFallSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isAttacking)
            {
                // attack lần 1
                lastAttackTime = Time.time;
                isAttacking = true;
                anim.SetBool("Sword", true);
                Invoke("ResetAttack", attackTime);
                Debug.Log("shoot");
            }
        }
        
        if (Mathf.Abs(move) > 0) 
        { 
            anim.Play("Player_run"); 
        }else if (!isAttacking && Mathf.Abs(move) <= 0)
        {
            anim.Play("Player_Idle");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(banana, attackPoint.position, attackPoint.rotation);
        }
        if (onLadder)
        {
            rb.gravityScale = 0f;

            climpVelocity = climpSpeed * Input.GetAxisRaw("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocityX, climpVelocity);
        }
        if (!onLadder)
        {
            rb.gravityScale = gravityStore;
        }
    }
    private void ResetAttack()
    {
        isAttacking = false;
        anim.SetBool("Sword", false);
    }
    public void eraseKnockBack()
    {
        knockBackCounter = 0;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatForm")
        {
            transform.parent = other.transform;
        }
    }
}