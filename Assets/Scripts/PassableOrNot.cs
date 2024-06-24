using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassableOrNot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject floor;
    public float playerHeight;
    public float myY;
    public float playerY;
    public bool belowPlayer = false;
    public bool ignoresCollision = false;
    public bool isTouching = false;
    public float allowedDistance;
    public float currentDistance;
    public bool isCoroutineRunning;
    public enum states { isIn, isOut};
    public states state;

    private void Awake()
    {
        myY = gameObject.GetComponent<Collider2D>().bounds.min.y;
        playerHeight = player.GetComponent<Collider2D>().bounds.max.y - player.GetComponent<Collider2D>().bounds.min.y;
        playerHeight /= 2;

        state = states.isOut;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*if (player.GetComponent<Collider2D>().bounds.max.y >= gameObject.GetComponent<Collider2D>().bounds.min.y+1)
        {
            belowPlayer = true;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            ignoresCollision = false;
            if (Physics2D.IsTouching(player.GetComponent<Collider2D>(), GetComponent<Collider2D>()) == true)
            {
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            }
        } */       
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player is below
        if (player.transform.position.y < gameObject.transform.position.y)
        {
            if (gameObject.CompareTag("MovableObject"))
            {
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            } else
            {
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (player.transform.position.y >= gameObject.GetComponent<Collider2D>().bounds.min.y)
        {
            if (gameObject.CompareTag("MovableObject"))
            {
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }
        }
    }*/

    private void Update()
    {
        currentDistance = Mathf.Abs(player.GetComponent<Collider2D>().bounds.max.y - gameObject.GetComponent<Collider2D>().bounds.min.y);

        // if distance btw top of player and bottom of platform is within allowed distance
        if (Mathf.Abs(player.GetComponent<Collider2D>().bounds.max.y - gameObject.GetComponent<Collider2D>().bounds.min.y) <= playerHeight + allowedDistance)
        {
            // find currentOWPlatform
            /*currentOWPlatform = gameObject;
            BoxCollider2D platformCollider = currentOWPlatform.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), platformCollider);*/
            StartCoroutine(DisableCollision());
        } else if (Mathf.Abs(player.GetComponent<Collider2D>().bounds.min.y - gameObject.GetComponent<Collider2D>().bounds.max.y) <= playerHeight + allowedDistance && Input.GetKey(KeyCode.S))
        {
            // find currentOWPlatform
            /*currentOWPlatform = gameObject;
            BoxCollider2D platformCollider = currentOWPlatform.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), platformCollider);*/
            StartCoroutine(DisableCollision());
        } else
        {
            /*currentOWPlatform = gameObject;
            BoxCollider2D platformCollider = currentOWPlatform.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), platformCollider, false);*/
        }

        if (state == states.isIn && isCoroutineRunning == false)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }

        // if hasnt exited but should time passed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state = states.isIn;
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.transform.position.y + allowedDistance <= gameObject.transform.position.y)
        {
            state = states.isIn;

            isTouching = false;
        }
    }

    IEnumerator DisableCollision()
    {
        isCoroutineRunning = true;

        BoxCollider2D platformCollider = gameObject.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), platformCollider);
        yield return new WaitForSeconds(0.3f);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), platformCollider,false);

        isCoroutineRunning = false;
    }

}
