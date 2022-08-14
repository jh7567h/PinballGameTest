using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public void FireWorkEnable()
    {
        GameObject.Find("FireWork").SetActive(true);
    }
}
