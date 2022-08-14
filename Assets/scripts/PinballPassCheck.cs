using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liluo.BiliBiliLive;

public class PinballPassCheck : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 3;
    float verticalMove = 1;
    public bool isControl;
    private int RoomID = 25476715;
    IBiliBiliLiveRequest req;
    //更改为控制代码
    private async void Start()
    {
        req = await BiliBiliLive.Connect(RoomID);
        isControl = false;
        rb = GetComponent<Rigidbody2D>();
    }

     

    private void Update()
    {
        if(isControl) Movement();
    }

    private void Movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            gameObject.transform.Rotate(0, 0, horizontalMove * 3);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalMove * speed);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -verticalMove * speed);
        }
    }

    private void OnApplicationQuit()
    {
        req.DisConnect();
    }
}
