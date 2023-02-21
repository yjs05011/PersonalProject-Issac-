using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Hit : MonoBehaviour
{
    private BoxCollider2D hitBox;
    private Monster_Active monster;
    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<BoxCollider2D>();
        monster = transform.parent.GetComponent<Monster_Active>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (other.transform.GetComponent<Player_Active>().isHit == true)
            {

            }
            else
            {
                if (monster.monsterType == 1)
                {
                    other.transform.GetComponent<Player_Active>().isHit = true;
                    if (GameManager.instance.player_Stat.SoulHeart >= 2)
                    {
                        GameManager.instance.player_Stat.SoulHeart -= 2;
                    }
                    else if (GameManager.instance.player_Stat.SoulHeart == 1)
                    {
                        GameManager.instance.player_Stat.SoulHeart -= 1;
                    }
                    else
                    {
                        GameManager.instance.player_Stat.NormalHeart -= 2;
                    }
                }
                else
                {
                    other.transform.GetComponent<Player_Active>().isHit = true;
                    if (GameManager.instance.player_Stat.SoulHeart >= 1)
                    {
                        GameManager.instance.player_Stat.SoulHeart -= 1;
                    }
                    else
                    {
                        GameManager.instance.player_Stat.NormalHeart -= 1;
                    }
                }
                StartCoroutine(GFunc.PlayerHit(other, 1));
            }
        }
    }
}
