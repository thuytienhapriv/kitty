using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassableOrNot : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= transform.position.y)
        {
            GetComponent<Collider2D>().isTrigger = false;
        } else
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
