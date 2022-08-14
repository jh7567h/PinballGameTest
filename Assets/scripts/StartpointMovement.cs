using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartpointMovement : MonoBehaviour
{
    public Transform pos1, pos2;
    public Transform startPos;
    public Transform spawn;

    private float speed = 2f;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos1.position;
        nextPos = startPos.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position) {
            nextPos = pos2.position;
        } 
        if (transform.position == pos2.position) {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ( other.gameObject.CompareTag("PlusThree") )
        {
            // 刷新玩家位置进入主游戏界面
            transform.position = spawn.position;
        }

    }

}
