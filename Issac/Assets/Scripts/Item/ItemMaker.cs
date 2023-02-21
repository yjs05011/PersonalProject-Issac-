using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaker : MonoBehaviour
{
    public Sprite[] itemImg;

    public Item[] Items;

    private SpriteRenderer itemSprite;
    private int randomNum;
    private int itemFindCount = 0;
    private bool player_Get_Item_Chk = false;
    public AudioSource PickItem;
    // Start is called before the first frame update
    void Start()
    {
        PickItem = GetComponent<AudioSource>();
        player_Get_Item_Chk = false;



        while (true)
        {

            randomNum = Random.Range(0, 4);
            if (GameManager.instance.totalItem.Contains(randomNum))
            {
                break;
            }

        }
        GameManager.instance.totalItem.Remove(randomNum);



        itemSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        itemSprite.sprite = itemImg[randomNum];
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                GetItem();
                transform.GetChild(0).gameObject.SetActive(false);

                if (!player_Get_Item_Chk)
                {
                    player_Get_Item_Chk = true;
                    GameManager.instance.itemgetChk = true;
                    other.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = itemImg[randomNum];
                    StartCoroutine(ItemAnima(other));
                }

            }
        }

    }
    void GetItem()
    {
        GameManager.instance.player_Stat.item.Push(randomNum);
        GameManager.instance.player_Stat.MaxHp += Items[randomNum].maxHp;
        GameManager.instance.player_Stat.NormalHeart += Items[randomNum].normalHeart;
        GameManager.instance.player_Stat.SoulHeart += Items[randomNum].soulHeart;
        GameManager.instance.player_Stat.Str += Items[randomNum].str;
        GameManager.instance.player_Stat.ShotSpeed += Items[randomNum].shotSpeed;
        GameManager.instance.player_Stat.RateSpeed += Items[randomNum].rateSpeed;
        GameManager.instance.player_Stat.Speed += Items[randomNum].speed;
        GameManager.instance.player_Stat.Luck += Items[randomNum].luck;
        GameManager.instance.player_Stat.Range += Items[randomNum].range;
        GameManager.instance.itemName = Items[randomNum].name;
    }
    IEnumerator ItemAnima(Collider2D other)
    {
        PickItem.Play();
        other.transform.GetComponent<Player_Active>().playerAct.sprite = other.transform.GetComponent<Player_Active>().PlayerActSprite[0];
        other.transform.GetChild(0).gameObject.SetActive(true);
        other.transform.GetChild(1).gameObject.SetActive(true);
        other.transform.GetChild(4).gameObject.SetActive(false);
        other.transform.GetChild(3).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        other.transform.GetChild(0).gameObject.SetActive(false);
        other.transform.GetChild(1).gameObject.SetActive(false);
        other.transform.GetChild(4).gameObject.SetActive(true);
        other.transform.GetChild(3).gameObject.SetActive(true);

    }
}
