/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] float jumpingMultiplier; // 15
    [SerializeField] float speedMultiplier; // 2
    [SerializeField] float maxHorizontalSpeed; // 5
    [SerializeField] float gravityScale; // 3
    [SerializeField] float fallGravityScale; // 3.5
    [SerializeField] float climbingSpeed;
    //[SerializeField] GameObject[] platforms;

    [Header("Check Values", order = 0 )]
    public Vector2 myVelocity;
    public float myGravityScale;
    public string currentState;

    [Header("Variables", order = 1)]
    public bool isClimbing;
    public bool isHolding;
    public bool isJumping;
    public bool isGrounded;
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
    public CharacterController controller;

    void Start()
    {
        isClimbing = false;
        isTouchingClimbable = false;
        isHolding = false;
        states = playerStates.defaultState;
    }

    void Update()
    {
        // update my variables for debugging / checking
        myVelocity = controller.velocity;
        currentState = states.ToString();

        // control horizonal speed
        if (controller.velocity.x < -maxHorizontalSpeed ) 
        {
            controller.velocity = new Vector3 (-maxHorizontalSpeed, rb.velocity.y);
        } 
        else if (controller.velocity.x > maxHorizontalSpeed)
        {
            rb.velocity = new Vector3(maxHorizontalSpeed, rb.velocity.y);
        }

        GravityController();

        IsGrounded();
        MoveAndJump(); // on ground and platforms
        Climb(); // when touching ladders
    }

    private void PlayerJump()
    {
        // check if on ground
        if (isGrounded == false ) { Debug.Log("not on ground"); return; } // will have to change
        isGrounded = false;
        //isJumping = true;
        rb.AddForce(Vector2.up * jumpingMultiplier, ForceMode2D.Impulse);
    }

    private void PlayerMove(Vector2 direction)
    {
        rb.AddForce(direction * speedMultiplier, ForceMode2D.Impulse);
    }

    private void MoveAndJump()
    {
        //isJumping = false;
        states = playerStates.defaultState;

        if (Input.GetKeyDown(KeyCode.Space)) { PlayerJump(); }
        if (Input.GetKey(KeyCode.A)) { PlayerMove(Vector2.left); }
        if (Input.GetKey(KeyCode.D)) { PlayerMove(Vector2.right); }
    }

    public void IsGrounded()
    {
        states = playerStates.defaultState;
        foreach (var plat in GameObject.FindGameObjectsWithTag("GroundAndPlatforms"))
        {
            bool grounded = Physics2D.IsTouching(col, plat.GetComponent<Collider2D>());
            if (isGrounded == false && grounded == true)
            {
                //AudioManager.instance.Play("Landing");
            }
            
            isGrounded = grounded;
            if (grounded == true)
            {
                break;
            }
        }
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

    *//*public void StateManager()
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
    }*//*

}
*/