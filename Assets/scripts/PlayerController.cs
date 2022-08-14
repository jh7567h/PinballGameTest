using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liluo.BiliBiliLive;

public class PlayerController : MonoBehaviour
{
    public Transform creationPoint;
    public GameObject player;
    public bool IsStart = false;
    private int RoomID = 25476715;
    public int[] players = new int[20];
    public int[] greenID = new int[5];
    public int[] blueID = new int[5];
    public int[] yellowID = new int[5];
    private int playerNum = 0;

    IBiliBiliLiveRequest req;
    async void Start()
    {
        req = await BiliBiliLive.Connect(RoomID);
        req.OnDanmuCallBack += GameStart;
    }
    public async void GameStart(BiliBiliLiveDanmuData data)
    {
        if (playerNum < 20)
        {

            if ((data.content == "red") && (transform.tag == "MachineRed") && (!isExist(players, data.userId)))
            {
                IsStart = true;
                GameObject newPlayer = Instantiate(player, creationPoint.position, Quaternion.identity);
                players[playerNum] = data.userId;// 找到对应的sprite路径然后展示
                Debug.Log(players[playerNum]);
                Debug.Log(playerNum);
                playerNum++;
                newPlayer.GetComponent<SpriteRenderer>().sprite = await BiliBiliLive.GetHeadSprite(data.userId);
                IsStart = false;
            }
            else if ((data.content == "green") && (transform.tag == "MachineGreen") && (!isExist(players, data.userId)))
            {
                IsStart = true;
                GameObject newPlayer = Instantiate(player, creationPoint.position, Quaternion.identity);
                players[playerNum] = data.userId;
                Debug.Log(players[playerNum]);
                Debug.Log(playerNum);
                playerNum++;
                newPlayer.GetComponent<SpriteRenderer>().sprite = await BiliBiliLive.GetHeadSprite(data.userId);
                IsStart = false;
            }
            else if ((data.content == "blue") && (transform.tag == "MachineBlue") && (!isExist(players, data.userId)))
            {
                IsStart = true;
                GameObject newPlayer = Instantiate(player, creationPoint.position, Quaternion.identity);
                players[playerNum] = data.userId;
                playerNum++;
                newPlayer.GetComponent<SpriteRenderer>().sprite = await BiliBiliLive.GetHeadSprite(data.userId);
                IsStart = false;
            }
            else if ((data.content == "Yellow") && (transform.tag == "MachineYellow") && (!isExist(players, data.userId)))
            {
                IsStart = true;
                GameObject newPlayer = Instantiate(player, creationPoint.position, Quaternion.identity);
                players[playerNum] = data.userId;
                playerNum++;
                newPlayer.GetComponent<SpriteRenderer>().sprite = await BiliBiliLive.GetHeadSprite(data.userId);
                IsStart = false;
            }
        }
    }

    private bool isExist(int[] players, int id)
    {
        int i;
        bool is_exist = false;
        for (i = 0; i < 20; i++)
        {
            if ((id == players[i]))
            {
                is_exist = true;
            }
        }
        return is_exist;
    }
    private void OnApplicationQuit()
    {
        req.DisConnect();
    }
}
