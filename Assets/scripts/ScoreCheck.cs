using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheck : MonoBehaviour
{
    public GameObject CubeBlue, CubeYellow, CubeGreen, CubeRed;
    public GameObject BloodBlue, BloodYellow, BloodGreen, BloodRed;
    public bool isClosed;
    private float CD = 5.0f;
    float currentTime = 0;
    //public Canvas ca;
    // Start is called before the first frame update
    private void Start()
    {
        isClosed = false;
    }

    private void Update()
    {
        
            MidIsClose();
            if (isClosed)
            {
                gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            }
            else
            {
                gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            }
        
            
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            takeDamage(BloodYellow, BloodRed, BloodGreen);
            isClosed = true;
        }
        else if (other.gameObject.CompareTag("Yellow"))
        {
            takeDamage(BloodBlue, BloodRed, BloodGreen);
            isClosed = true;
        }
        else if (other.gameObject.CompareTag("Red"))
        {
            takeDamage(BloodBlue, BloodYellow, BloodGreen);
            isClosed = true;
        }
        else if (other.gameObject.CompareTag("Green"))
        {
            takeDamage(BloodBlue, BloodRed, BloodYellow);
            isClosed = true;
        }
    }



    public void takeDamage(GameObject one, GameObject two, GameObject three)
    {
        one.GetComponent<HealhBar>().Damage();
        two.GetComponent<HealhBar>().Damage();
        three.GetComponent<HealhBar>().Damage();
    }

    private void MidIsClose()
    {
        if (isClosed)
        {
            currentTime += Time.deltaTime;
            if (currentTime > CD)
            {
                isClosed = false;
                currentTime = 0;
            }
        }
        
    }
}
