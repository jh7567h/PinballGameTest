using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public int health = 100;
    int maxHp = 100;
    public GameObject HealthUIPrefab;
    public bool isVisable;

    public Image healthSlider;
    //public Transform UIbar;
    //Transform cam;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthUIPrefab.SetActive(true);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Damage()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        HealthUIPrefab.SetActive(true);
        health -= 5;
        float sliderPercent = (float)health / maxHp;
        healthSlider.fillAmount = sliderPercent;
    }
}
