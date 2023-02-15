using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameUI : MonoBehaviour
{
    public TMP_Text[] status;

    public GameObject ItemImg;
    private Rigidbody2D itemImgRigid;
    private RectTransform itemImgRect;
    bool move_Chk = false;
    private RectTransform TextBoxSize;
    private TMP_Text TextSize;
    // Start is called before the first frame update
    void Start()
    {
        itemImgRigid = ItemImg.GetComponent<Rigidbody2D>();
        itemImgRect = ItemImg.GetRect();
        TextBoxSize = status[4].GetComponent<RectTransform>();
        TextSize = status[4].GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        status[0].text = $"{GameManager.instance.player_Stat.MaxHp}";
        status[1].text = $"{GameManager.instance.player_Stat.Str}";
        status[2].text = $"{GameManager.instance.player_Stat.Speed}";
        status[3].text = $"{GameManager.instance.player_Stat.RateSpeed}";
        status[4].text = $"{GameManager.instance.itemName}";
        if (itemImgRect.anchoredPosition.x > 0 && move_Chk)
        {
            Debug.Log(itemImgRect.anchoredPosition);
            itemImgRigid.velocity = new Vector2(0, 0);

            ItemImg.transform.SetLocalPositionAndRotation(new Vector2(0, ItemImg.transform.localPosition.y), new Quaternion(0f, 0f, 0f, 0f));
            itemImgRect.sizeDelta = new Vector2(500, 100);
            TextBoxSize.sizeDelta = new Vector2(500, 100);
            TextSize.fontSize = 78f;
        }


        if (GameManager.instance.itemgetChk)
        {
            GameManager.instance.itemgetChk = false;
            StartCoroutine(ItemText());
        }


    }
    IEnumerator ItemText()
    {
        ItemImg.SetActive(true);
        move_Chk = true;
        itemImgRect.sizeDelta = new Vector2(200, 100);
        TextBoxSize.sizeDelta = new Vector2(200, 100);
        TextSize.fontSize = 40f;
        ItemImg.transform.SetLocalPositionAndRotation(new Vector2(-800, ItemImg.transform.localPosition.y), new Quaternion(0f, 0f, 0f, 0f));
        itemImgRigid.velocity = new Vector2(1500, 0);

        yield return new WaitForSeconds(1.5f);
        move_Chk = false;
        ItemImg.transform.SetLocalPositionAndRotation(new Vector2(-120, ItemImg.transform.localPosition.y), new Quaternion(0f, 0f, 0f, 0f));
        itemImgRect.sizeDelta = new Vector2(300, 100);
        itemImgRigid.velocity = new Vector2(1500, 0);
        TextBoxSize.sizeDelta = new Vector2(300, 100);
        TextSize.fontSize = 40f;
        yield return new WaitForSeconds(0.5f);
        ItemImg.SetActive(false);



    }
}
