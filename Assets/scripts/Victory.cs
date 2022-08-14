using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public int B_hp, R_hp, G_hp, Y_hp;
    public GameObject target,FireWork;
    public GameObject Blue, Green, Red, Yellow;
    public GameObject P_B, P_G, P_R, P_Y;
    private int HP_Blue, HP_Green, HP_Red, HP_Yellow;
    public bool isOver = false;
    private void Update()
    {
        //record();
        VictorySide();
    }

    private void VictorySide()
    {
        if (B_hp>0&& G_hp <= 0 && R_hp <= 0 && Y_hp <= 0)
        {
            //Debug.Log("hhhh");
            target.GetComponent<CircleCollider2D>().isTrigger = false;
            FireWork.SetActive(true);
            P_B.SetActive(true);
            isOver = true;
        }
        else if (B_hp <= 0 && G_hp > 0 && R_hp <= 0 && Y_hp <= 0)
        {
            target.GetComponent<CircleCollider2D>().isTrigger = false;
            FireWork.SetActive(true);
            P_G.SetActive(true);
            isOver = true;
        }
        else if (B_hp <= 0 && G_hp <= 0 && R_hp > 0 && Y_hp <= 0)
        {
            target.GetComponent<CircleCollider2D>().isTrigger = false;
            FireWork.SetActive(true);
            P_R.SetActive(true);
            isOver = true;
        }
        else if (B_hp <= 0 && G_hp <= 0 && R_hp <= 0 && Y_hp > 0)
        {
            target.GetComponent<CircleCollider2D>().isTrigger = false;
            FireWork.SetActive(true);
            P_Y.SetActive(true);
            isOver = true;
        }
    }
    
    //private void record()
    //{
    //    HP_Blue = Blue.GetComponent<HealhBar>().health;
    //    HP_Green = Green.GetComponent<HealhBar>().health;
    //    HP_Red = Red.GetComponent<HealhBar>().health;
    //    HP_Yellow = Yellow.GetComponent<HealhBar>().health;
    //}
    
}
