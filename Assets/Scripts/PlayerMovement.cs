using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float jumpingMultiplier; // 15
    [SerializeField] float speedMultiplier; // 2
    [SerializeField] float maxHorizontalSpeed; // 5
    [SerializeField] float gravityScale; // 3
    [SerializeField] float fallGravityScale; // 3.5
    
    [Header("Check Values")]
    public Vector2 myVelocity;
    public float myGravityScale;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-6,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // update my variables for debugging / checking
        myVelocity = rb.velocity;
        myGravityScale = rb.gravityScale;

        if (Input.GetKeyDown(KeyCode.W)) { PlayerJump(); }
        if (Input.GetKey(KeyCode.A)) { PlayerMove(Vector2.left); }
        if ( Input.GetKey(KeyCode.D)) { PlayerMove(Vector2.right); }

        // control horizonal speed
        if (rb.velocity.x < -maxHorizontalSpeed ) 
        { 
            rb.velocity = new Vector3 (-maxHorizontalSpeed, rb.velocity.y);
        } 
        else if (rb.velocity.x > maxHorizontalSpeed)
        {
            rb.velocity = new Vector3(maxHorizontalSpeed, rb.velocity.y);
        }

        // control jump curves
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravityScale;
        } 
        else
        {
            rb.gravityScale = fallGravityScale;
        }
    }

    private void PlayerJump()
    {
        // check if on ground
        if (rb.velocity.y != 0 ) { return; }

        rb.AddForce(Vector2.up * jumpingMultiplier, ForceMode2D.Impulse);
    }

    private void PlayerMove(Vector2 direction)
    {
        rb.AddForce(direction * speedMultiplier, ForceMode2D.Impulse);
    }
}
