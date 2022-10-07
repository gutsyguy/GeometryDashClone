using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 6.2f;
    private Rigidbody2D rb;
    private bool isGrounded;

    private float flightSpeed = 7.0f;
    private bool isFlying = false;
    private bool isWalking = true;
    private int FlyDirection = -1;
    private float flightForce = 6.0f;
    private Vector2 Flight;

    public SpriteRenderer spriteRender;
    public Sprite newSprite;
    public Sprite oldSprite;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {
        if (isWalking == true)
        {
            rb.gravityScale = 3;
        }
        else if (isFlying == true)
        {
            rb.gravityScale = 1;
        }
    }
    private void Update()
    {
        //if (isWalking == true){
        //    Walk();
        //}
        //else if (isFlying == true){
        //    Fly();
        //}
        Walk();
        rb.velocity = new Vector2(speed, rb.velocity.y);
        StartCoroutine(Example());
    }


    //Checks for collisions with objects
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Debug.Log("JUMPABLE");
            isGrounded = true;
        }

    }

    //Checks for if you pass through portals
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("WORK");
        if (col.gameObject.tag == "FlyPortal")
        {
            isFlying = true;
            isWalking = false;
            ChangeSprite(newSprite);
        }
        else if (col.gameObject.tag == "WalkPortal")
        {
            isFlying = false;
            isWalking = true;
            ChangeSprite(oldSprite);
        }
        else if (col.gameObject.tag == "obstacle")
        {
            //Death
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName: "SampleScene");
        }
        else if (col.gameObject.tag == "Finish")
        {

        }
        Debug.Log(isFlying);
    }

    //Allows you to jump
    private void Walk()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isWalking == true && isGrounded == true)
        {
            rb.velocity = new Vector2(speed, jumpForce);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isWalking == false)
        {
            Flight = new Vector2(flightSpeed, flightForce);
            rb.AddForce(Vector2.up * flightForce, ForceMode2D.Impulse);
        }
    }

    //Allows Flight
    private void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isWalking == false)
        {
            Flight = new Vector2(speed, jumpForce);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //isGrounded = false;

            ////if (FlyDirection == -1)
            ////{
            ////    FlyDirection = 1;
            ////}
            ////else {
            ////    FlyDirection = -1;
            ////}
        }

        rb.velocity = new Vector2(speed, flightSpeed * FlyDirection);

    }
    IEnumerator Example()
    {
        float origin_pos = rb.position.x;
        yield return new WaitForSeconds(0.05f);
        float new_pos = rb.position.x;
        if (origin_pos - new_pos == 0)
        {
            //PLACEHOLDER
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName: "SampleScene");
        }
    }
    private void ChangeSprite(Sprite newSprite)
    {
        spriteRender.sprite = newSprite;
    }

}
