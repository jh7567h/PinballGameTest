using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Liluo.BiliBiliLive;

public class Danmutest : MonoBehaviour
{
    public Image img;
    public int RoomID;
    IBiliBiliLiveRequest req;

    async void Start()
    {
        // 创建一个监听对象
        req = await BiliBiliLive.Connect(RoomID);
        req.OnDanmuCallBack += GetDanmu;
        req.OnGiftCallBack += GetGift;
        req.OnSuperChatCallBack += GetSuperChat;
        bool flag = true;
        req.OnRoomViewer += number =>
        {
            // 仅首次显示
            if (flag) Debug.Log($"当前房间人数为: {number}");
        };
    }



    /// <summary>
    /// 接收到礼物的回调
    /// </summary>
    public async void GetGift(BiliBiliLiveGiftData data)
    {
        Debug.Log($"<color=#FEA356>礼物</color> 用户名: {data.username}, 礼物名: {data.giftName}, 数量: {data.num}, 总价: {data.total_coin}");
        img.sprite = await BiliBiliLive.GetHeadSprite(data.userId);
    }

    /// <summary>
    /// 接收到弹幕的回调
    /// </summary>
    public async void GetDanmu(BiliBiliLiveDanmuData data)
    {
        Debug.Log($"<color=#60B8E0>弹幕</color> 用户名: {data.username}, 内容: {data.content}, 舰队等级: {data.guardLevel}");


        img.sprite = await BiliBiliLive.GetHeadSprite(data.userId);

    }

    /// <summary>
    /// 接收到SC的回调
    /// </summary>
    public async void GetSuperChat(BiliBiliLiveSuperChatData data)
    {
        Debug.Log($"<color=#FFD766>SC</color> 用户名: {data.username}, 内容: {data.content}, 金额: {data.price}");
        img.sprite = await BiliBiliLive.GetHeadSprite(data.userId);
    }

    private void OnApplicationQuit()
    {
        req.DisConnect();
    }
}
