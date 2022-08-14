using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawn;
    public GameObject origin;
    Vector2 direction;
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blue")|| other.gameObject.CompareTag("Red") || other.gameObject.CompareTag("Green") || other.gameObject.CompareTag("Yellow") )
        {
            // 刷新玩家位置进入主游戏界面
            Vector3 playerPos = new Vector3(spawn.position.x,spawn.position.y,-8);
            other.transform.position = playerPos;
            other.gameObject.GetComponent<PinballPassCheck>().isControl = true;
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            direction =new Vector2( (other.gameObject.transform.position - origin.transform.position).x,other.gameObject.transform.position.y);
            if (gameObject.CompareTag("PlusTwo"))
            {
                giveSpeed(220,other);
            }else if (gameObject.CompareTag("PlusThree"))
            {
                giveSpeed(230, other);
            }
            else if (gameObject.CompareTag("PlusFive"))
            {
                giveSpeed(250, other);
            }
        }

    }

    public void giveSpeed(float speed, Collider2D someThing)
    {
        someThing.GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }
}
