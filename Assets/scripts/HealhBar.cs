using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealhBar : MonoBehaviour
{

    public int health = 100;
    int maxHp = 100;
    public GameObject HealthUIPrefab,Victory;
    public bool isVisable;

    public Image healthSlider;
    //public Transform UIbar;
    //Transform cam;

    private void Start()
    {
        Victory.GetComponent<Victory>().B_hp = health;
        Victory.GetComponent<Victory>().G_hp = health;
        Victory.GetComponent<Victory>().R_hp = health;
        Victory.GetComponent<Victory>().Y_hp = health;
    }
    private void Update()
    {
        if (health <= 0)
        {
            if (gameObject.CompareTag("BloodBlue"))
            {
                Victory.GetComponent<Victory>().B_hp = health;
            }else if (gameObject.CompareTag("BloodGreen"))
            {
                Victory.GetComponent<Victory>().G_hp = health;
            }else if (gameObject.CompareTag("BloodRed"))
            {
                Victory.GetComponent<Victory>().R_hp = health;
            }else if (gameObject.CompareTag("BloodYellow"))
            {
                Victory.GetComponent<Victory>().Y_hp = health;
            }
            Destroy(gameObject);
        }



    }
    public void Damage()
    {
        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //}
        HealthUIPrefab.SetActive(true);
        health -= 10;
        float sliderPercent = (float)health / maxHp;
        healthSlider.fillAmount = sliderPercent;
    }
}
