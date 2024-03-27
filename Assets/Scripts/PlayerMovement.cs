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
        myVelocity = rb.velocity;
        myGravityScale = rb.gravityScale;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("jump");
            rb.AddForce(Vector2.up * jumpingMultiplier, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speedMultiplier, ForceMode2D.Impulse);

            //rb.velocity = new Vector2(-1,0) * speedMultiplier;
        }

        if ( Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speedMultiplier, ForceMode2D.Impulse);

            //rb.velocity = new Vector2(1, 0) * speedMultiplier;
        }

        if (rb.velocity.x < -maxHorizontalSpeed ) 
        { 
            rb.velocity = new Vector3 (-maxHorizontalSpeed, rb.velocity.y);
        } else if (rb.velocity.x > maxHorizontalSpeed)
        {
            rb.velocity = new Vector3(maxHorizontalSpeed, rb.velocity.y);
        }

        if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravityScale;
        } else
        {
            rb.gravityScale = fallGravityScale;
        }
    }
}
