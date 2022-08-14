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
        // ����һ����������
        req = await BiliBiliLive.Connect(RoomID);
        req.OnDanmuCallBack += GetDanmu;
        req.OnGiftCallBack += GetGift;
        req.OnSuperChatCallBack += GetSuperChat;
        bool flag = true;
        req.OnRoomViewer += number =>
        {
            // ���״���ʾ
            if (flag) Debug.Log($"��ǰ��������Ϊ: {number}");
        };
    }



    /// <summary>
    /// ���յ�����Ļص�
    /// </summary>
    public async void GetGift(BiliBiliLiveGiftData data)
    {
        Debug.Log($"<color=#FEA356>����</color> �û���: {data.username}, ������: {data.giftName}, ����: {data.num}, �ܼ�: {data.total_coin}");
        img.sprite = await BiliBiliLive.GetHeadSprite(data.userId);
    }

    /// <summary>
    /// ���յ���Ļ�Ļص�
    /// </summary>
    public async void GetDanmu(BiliBiliLiveDanmuData data)
    {
        Debug.Log($"<color=#60B8E0>��Ļ</color> �û���: {data.username}, ����: {data.content}, ���ӵȼ�: {data.guardLevel}");


        img.sprite = await BiliBiliLive.GetHeadSprite(data.userId);

    }

    /// <summary>
    /// ���յ�SC�Ļص�
    /// </summary>
    public async void GetSuperChat(BiliBiliLiveSuperChatData data)
    {
        Debug.Log($"<color=#FFD766>SC</color> �û���: {data.username}, ����: {data.content}, ���: {data.price}");
        img.sprite = await BiliBiliLive.GetHeadSprite(data.userId);
    }

    private void OnApplicationQuit()
    {
        req.DisConnect();
    }
}
