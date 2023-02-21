using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (other.transform.GetComponent<Player_Active>().isHit == true)
            {
                //Do nothing

            }
            else
            {
                other.transform.GetComponent<Player_Active>().isHit = true;
                if (GameManager.instance.player_Stat.SoulHeart == 1f)
                {
                    GameManager.instance.player_Stat.SoulHeart -= 1f;
                }
                else if (GameManager.instance.player_Stat.SoulHeart >= 2f)
                {
                    GameManager.instance.player_Stat.SoulHeart -= 2f;
                }
                else
                {
                    GameManager.instance.player_Stat.NormalHeart -= 2f;
                }
                Debug.Log($"Hp : {GameManager.instance.player_Stat.NormalHeart}");

                StartCoroutine(GFunc.PlayerHit(other, 1));
            }


        }

        if (other.transform.tag == "Monster")
        {
            other.transform.parent.GetComponent<Monster_Active>().maxHp -= 40;
        }
        if (other.transform.tag == "Rock")
        {
            other.transform.gameObject.SetActive(false);
        }
    }
}
