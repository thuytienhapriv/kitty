using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Environments", order = 0)]
    public GameObject permEnvi;
    public GameObject dayEnvi;
    public GameObject nightEnvi;

    [Header("Variables", order = 1)]
    public bool itsDay;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        itsDay = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itsDay == true) { itsDay = false; } 
            else if (itsDay == false) {  itsDay = true; }
        }

        if (itsDay == true)
        {
            dayEnvi.SetActive(true);
            nightEnvi.SetActive(false);
        } else
        {
            dayEnvi.SetActive(false);
            nightEnvi.SetActive(true);
        }

    }
}