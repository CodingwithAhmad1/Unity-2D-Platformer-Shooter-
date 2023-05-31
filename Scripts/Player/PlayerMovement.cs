using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    // this script manages player movement

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    

    // left, right, jump
    float horizontal;
    float vertical;
    public float speed;
    public float jumpingPower;
    bool isFacingRight = true;
    bool jumping;



    // double jump
    private bool doubleJump;
    public float doublePower;


    // wall sliding
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;


    //Wall Jump System
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;

    public float wallJumpDuration;
    public Vector2 wallJumpForce;
    bool wallJumping;

    // platform movement
    bool onPlatform;

    // respawning
    Vector2 startPos;
    int deaths;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        startPos = transform.position;

        deaths = 0;
        
    }



    // Update is called once per frame
    void Update()
    {

        // if you want to change the facing direction

        
        /*  if (!isFacingRight && horizontal > 0f)
         {
            Flip();
         }
            else if (isFacingRight && horizontal < 0f)
        {
            Flip();

        }
        */
    }



    // left, right movement
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

    }



    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (onPlatform)
        {
            rb.interpolation = RigidbodyInterpolation2D.None; // to fix platform movement
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }

        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (wallJumping)
        {
            rb.velocity = new Vector2(-horizontal * wallJumpForce.x, wallJumpForce.y);
        }

        gameObject.GetComponent<TrailRenderer>().enabled=true; 


    }

    private GameObject currentTeleporter;



    public void Teleport(InputAction.CallbackContext context)
    {
        if (context.performed && currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Teleporting>().GetDestination().position;
            gameObject.GetComponent<TrailRenderer>().enabled=false; 
        }

    }



    // checking if on ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }



    // jumping
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isSliding)
        {
            wallJumping = true;
            Invoke("StopWallJump", wallJumpDuration);
        }
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump = true;
        }

        else if (context.performed && doubleJump == true) // double jumps
        {
            rb.velocity = new Vector2(rb.velocity.x, doublePower);
            doubleJump = false;
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
        }

        if (context.canceled && IsGrounded())
        {
            doubleJump = false;
        }

    }

    void StopWallJump()
    {
        wallJumping = false;
    }




    // facing right direction
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;

        transform.localScale = localScale;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Wall"))
        {
            isSliding = true;
        }

        if (collision.CompareTag("Platform"))
        {
            onPlatform = true;
        }  
        
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }      

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSliding = false;
        onPlatform = false;
        currentTeleporter = null;
    }


}
