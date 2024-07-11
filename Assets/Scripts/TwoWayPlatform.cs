using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayPlatform : MonoBehaviour
{
    public bool isOnPlatform;
    public bool isGoingDown;
    private float rotOffset;

    void Update()
    {
        // probably later should change to new input system instead of relying on Input Keycode
        if (Input.GetKeyDown(KeyCode.S))
        {
            isGoingDown = true;
        }
    }

    private void FixedUpdate()
    {
        Physics2D.SyncTransforms();
        rotOffset = gameObject.GetComponent<PlatformEffector2D>().rotationalOffset;

        

        if (isGoingDown && isOnPlatform)
        {
            if (rotOffset != 180)
            {
                gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
                return;
            }
        }

        
        if (isOnPlatform && isGoingDown == false)
        {
            if (rotOffset != 0)
            {
                gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
                return;
            }
        }

        //Debug.DrawRay(kitty.transform.position, Vector3.right, Color.blue, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            //Debug.Log("is on");
            isOnPlatform = true;

            /*foreach (ContactPoint2D contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.red, 1);
            }*/
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            //Debug.Log("is off");
            isOnPlatform = false;
            isGoingDown = false;
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;

        }
    }
}
