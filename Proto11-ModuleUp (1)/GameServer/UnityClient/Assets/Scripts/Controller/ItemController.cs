using Google.Protobuf.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;

public class ItemController : CreatureController
{
    protected GameObject item;
    protected override void Init()
    {
        State = CreatureState.Moving;
        base.Init();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveItem(other.gameObject);
        }
    }
    protected override void UpdateAnimation()
    { } // 아이템 획득 시 동작(서버로 패킷 전송)

    protected void ActiveItem(GameObject player)
    {
        MyPlayerController mc = player.GetComponent <MyPlayerController>();
        // 추후 기능 추가
        C_ItemGet cltemPacket = new C_ItemGet() { Iteminfo = new ItemInfo() }; Debug.Log($"Creature {Id} Item Get");
        cltemPacket.Iteminfo.ItemId = Id;
        cltemPacket.Iteminfo.Name = "Coin";
        cltemPacket.Iteminfo.PosInfo = PosInfo;
        cltemPacket.PlayerObjectId = mc.Id; Managers.Network.Send(cltemPacket); Debug.Log($"Creature {mc.Id} Item Get");
    }

}



