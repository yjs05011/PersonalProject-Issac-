using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thorn1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
                Debug.Log($"Time");
                other.transform.GetComponent<Player_Active>().isHit = true;
                if (GameManager.instance.player_Stat.SoulHeart >= 1)
                {
                    GameManager.instance.player_Stat.SoulHeart -= 1;
                }
                else
                {
                    GameManager.instance.player_Stat.NormalHeart -= 1;
                }
                StartCoroutine(GFunc.PlayerHit(other, 1));

            }
        }
    }
}
