using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBehaviour : MonoBehaviour
{
    public GameObject player;
    public enum Ownership { player, environment };
    public Ownership ownerName;

    [Serializable]
    public class Owner
    {
        public Ownership name;
        public GameObject ownerObject;
    }

    public List<Owner> ownersList;

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeOwner (Ownership.player);
            Debug.Log("player owner");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeOwner (Ownership.environment);
            Debug.Log("envi owner");

        }*/

        /*if (Vector3.Distance(player.transform.position, transform.position) < 10 && Input.GetKey(KeyCode.P))
        {
            ChangeOwner(Ownership.player);
            Debug.Log("player owner");
        }else
        {
            ChangeOwner(Ownership.environment);
            
            Debug.Log("envi owner");

        }*/
    }

    public void ChangeOwner (Ownership myOwner)
    {
        for (int i = 0; i < ownersList.Count; i++)
        {
            if (ownersList[i].name == myOwner)
            {
                //gameObject.transform.SetParent(ownersList[i].ownerObject.transform, true);
                gameObject.transform.parent = ownersList[i].ownerObject.transform;

                return;
            }
        }
    }
}
