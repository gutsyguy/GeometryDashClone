using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private float horizontal;
    private bool isJumpPressed = false;
    private bool isJumping = false;
    public float speed = 9.0f;
    private Rigidbody2D rb;
    public float jumpSpeed = 7.0f;
    private bool isGrounded = false;
    private Animator animator;
    private bool isFacingRight = true;
    private bool Coin;
    public Transform attackCheck;
    private bool isAttacking = false;

    private int score = 0;
    private int health = 100;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //if ((rb.velocity.x < 0 && isFacingRight) || (rb.velocity.x > 0 && !isFacingRight))
        //{
        //    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        //    isFacingRight = !isFacingRight;
        //}

    }
    private void FixedUpdate()
    {
        var horizontalForce = Vector2.right * horizontal * speed;
        rb.AddForce(horizontalForce);

        if (isJumpPressed && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin Exit!");

        }
        else
        {
            Debug.Log("Not Grounded");

            isGrounded = false;
        }
    }
}