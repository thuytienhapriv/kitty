using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] float jumpingMultiplier; // 15
    [SerializeField] float speedMultiplier; // 2
    [SerializeField] float maxHorizontalSpeed; // 5
    [SerializeField] float gravityScale; // 3
    [SerializeField] float fallGravityScale; // 3.5
    [SerializeField] float climbingSpeed;
    
    [Header("Check Values", order = 0 )]
    public Vector2 myVelocity;
    public float myGravityScale;
    public string currentState;

    [Header("Variables", order = 1)]
    public bool isClimbing;
    public bool isHolding;
    public bool isJumping;
    public bool isTouchingClimbable;
    public float climbDirection;
    private float onLadderX;

    public enum playerStates
    {
        defaultState,
        climb,
        holdingItem
    }
    public playerStates states;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        isClimbing = false;
        isTouchingClimbable = false;
        isHolding = false;
        states = playerStates.defaultState;
    }

    void Update()
    {
        // update my variables for debugging / checking
        myVelocity = rb.velocity;
        myGravityScale = rb.gravityScale;
        currentState = states.ToString();

        // control horizonal speed
        if (rb.velocity.x < -maxHorizontalSpeed ) 
        { 
            rb.velocity = new Vector3 (-maxHorizontalSpeed, rb.velocity.y);
        } 
        else if (rb.velocity.x > maxHorizontalSpeed)
        {
            rb.velocity = new Vector3(maxHorizontalSpeed, rb.velocity.y);
        }

        GravityController();

        MoveAndJump(); // on ground and platforms
        Climb(); // when touching ladders
    }

    private void PlayerJump()
    {
        // check if on ground
        if (rb.velocity.y != 0 ) { Debug.Log("not on ground"); return; } // will have to change
        isJumping = true;
        rb.AddForce(Vector2.up * jumpingMultiplier, ForceMode2D.Impulse);
    }

    private void PlayerMove(Vector2 direction)
    {
        rb.AddForce(direction * speedMultiplier, ForceMode2D.Impulse);
    }

    private void MoveAndJump()
    {
        isJumping = false;
        states = playerStates.defaultState;

        if (Input.GetKey(KeyCode.Space)) { PlayerJump(); }
        if (Input.GetKey(KeyCode.A)) { PlayerMove(Vector2.left); }
        if (Input.GetKey(KeyCode.D)) { PlayerMove(Vector2.right); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isTouchingClimbable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isTouchingClimbable = false;
            isClimbing = false;
            states = playerStates.defaultState;
            Debug.Log("turn of my trigg");
        }
        
    }

    private void GravityController()
    {
        rb.gravityScale = fallGravityScale;

        // controls jump curves
        if (states == playerStates.defaultState)
        {
            if (rb.velocity.y > 0)
            {
                rb.gravityScale = gravityScale;
            }
            else
            {
                rb.gravityScale = fallGravityScale;
            }
            return;
        } 

        if (states == playerStates.climb)
        {
            rb.gravityScale = 0f;
        }
    }

    public void Climb() 
    {
        if (isHolding == true) { return; }
        if (isTouchingClimbable == false) { return; }

        // is touching climbable and not holding anything ->

        if (Input.GetKey(KeyCode.W)) // go up
        {
            isClimbing = true;
            climbDirection = 1;
        } else if (Input.GetKey(KeyCode.S))
        {
            climbDirection = -1;
        } else { climbDirection = 0; }

        if (isClimbing == true)
        {
            //onLadderX 

            //col.isTrigger = true;
            states = playerStates.climb;

            if (rb.velocity.y == 0)
            {
                //AudioManager.instance.Play("Climbing"); 
            }
            else if (rb.velocity.y != 0)
            {
                //AudioManager.instance.Stop("Climbing");
            }

            
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, climbDirection * climbingSpeed);
        }
    }

    /*public void StateManager()
    {
        switch (states)
        {
            case playerStates.defaultState:
                MoveAndJump();
                break;
            case playerStates.climb:
                Climb();
                break;
            case playerStates.holdingItem:
                break;
        }
    }*/

}
