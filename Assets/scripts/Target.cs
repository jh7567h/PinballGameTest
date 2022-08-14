using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject CubeBlue, CubeYellow, CubeGreen, CubeRed;

    private void Update()
    {
        Debug.Log("hhhhhsd");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            Debug.Log("hhh");
            takeDamage(CubeYellow, CubeRed, CubeGreen);
        }
        else if (other.gameObject.CompareTag("Yellow"))
        {
            takeDamage(CubeBlue, CubeRed, CubeGreen);
        }
        else if (other.gameObject.CompareTag("Red"))
        {
            takeDamage(CubeBlue, CubeYellow, CubeGreen);
        }
        else if (other.gameObject.CompareTag("Green"))
        {
            takeDamage(CubeBlue, CubeRed, CubeYellow);
        }
    }
   


    public void takeDamage(GameObject one, GameObject two, GameObject three)
    {
        one.GetComponent<HealthBarUI>().Damage();
        two.GetComponent<HealthBarUI>().Damage();
        three.GetComponent<HealthBarUI>().Damage();
    }


}
