using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public bool playerIsInTheGround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsInTheGround = true;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
