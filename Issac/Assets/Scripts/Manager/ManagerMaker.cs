using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GFunc.SceneChanger("Stage1");
        ItemDuplication(4);
        PlayerStatReset(1);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayerStatReset(int Id)
    {

        GameManager.instance.player_Stat.ID = GameManager.instance.player[Id].id;
        GameManager.instance.player_Stat.Name = GameManager.instance.player[Id].name;
        GameManager.instance.player_Stat.MaxHp = GameManager.instance.player[Id].maxHp;
        GameManager.instance.player_Stat.NormalHeart = GameManager.instance.player[Id].normalHeart;
        GameManager.instance.player_Stat.SoulHeart = GameManager.instance.player[Id].soulHeart;
        GameManager.instance.player_Stat.Str = GameManager.instance.player[Id].str;
        GameManager.instance.player_Stat.ShotSpeed = GameManager.instance.player[Id].shotSpeed;
        GameManager.instance.player_Stat.RateSpeed = GameManager.instance.player[Id].rateSpeed;
        GameManager.instance.player_Stat.Speed = GameManager.instance.player[Id].speed;
        GameManager.instance.player_Stat.Luck = GameManager.instance.player[Id].luck;
        GameManager.instance.player_Stat.Range = GameManager.instance.player[Id].range;
        GameManager.instance.player_Stat.Die = GameManager.instance.player[Id].die;
        GameManager.instance.player_Stat.KeyCount = GameManager.instance.player[Id].keyCount;
        GameManager.instance.player_Stat.BoomCount = GameManager.instance.player[Id].boomCount;
        GameManager.instance.player_Stat.CoinCount = GameManager.instance.player[Id].coinCount;
    }
    void ItemDuplication(int totalItem)
    {
        for (int i = 0; i < totalItem; i++)
            GameManager.instance.totalItem.Add(i);
    }
}
