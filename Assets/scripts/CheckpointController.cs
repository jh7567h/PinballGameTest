using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public float velocity = 1f;

    /*void Update() {
        Debug.Log(velocity);
    }*/

    // 判断速度加成区域，修改玩家初始速度值
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "MultiTwo") {
            velocity *= 2;
        }
        else if (other.tag == "MultiThree") {
            velocity *= 3;
        }
        else if (other.tag == "MultiFive") {
            velocity *= 5;
        }
        else if (other.tag == "PlusTwo") {
            velocity += 2;
        } 
        else if (other.tag == "PlusThree") {
            velocity += 3;
        }
        else if (other.tag == "PlusFive") {
            velocity += 5;
        }

    }
}
