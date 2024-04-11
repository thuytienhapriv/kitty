using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class globalLight : MonoBehaviour
{
    public Light2D sun;
    public bool dayTime = true;

    private void Start()
    {
        sun.GetComponent<Light>();
        sun.color = new Color(0.4f, 0.3f, 0.2f);
        //sun.intensity = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E down");
            if(dayTime)
            {
                night();
            }
            else
            {
                day();
            }
        }
    }
    public void day()
    {
        sun.color = new Color(0f, 0.3f, 0.2f);
        dayTime = true;
    } 
    public void night()
    {
        sun.color = new Color(0.4f, 0f, 0.2f);
        dayTime = false;
    }
}

