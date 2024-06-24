using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayPlatform : MonoBehaviour
{
    public bool isOnPlatform;
    public bool isGoingDown;
    public GameObject kitty;
    public bool stopTime;

    void Update()
    {
        //Time.timeScale = 0.5f;
        if (Input.GetKeyDown(KeyCode.S))
        {
            isGoingDown = true;
        }
    }

    private void FixedUpdate()
    {
        if (stopTime == true)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 0.25f;
        }

        Physics2D.SyncTransforms();

        if (isGoingDown == true && isOnPlatform == true)
        {
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
            // Debug.Log("can fall through");
        }
        else
        {
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("is on");
            isOnPlatform = true;

            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Visualize the contact point
                Debug.DrawRay(contact.point, contact.normal, Color.red, 1);
            }

            //stopTime = true;

        }
    }


    // it goes sideways NOt because of col exit

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("is off");
            isOnPlatform = false;
            isGoingDown = false;
        }
    }
}
