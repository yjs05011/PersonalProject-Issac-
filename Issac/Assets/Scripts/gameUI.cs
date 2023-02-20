using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameUI : MonoBehaviour
{
    public GameObject minimap;
    public TMP_Text[] status;
    public Image[] rooms;
    private RectTransform imgrect;
    public GameObject ItemImg;
    private Rigidbody2D itemImgRigid;
    private RectTransform itemImgRect;
    bool move_Chk = false;
    private RectTransform TextBoxSize;
    private TMP_Text TextSize;
    private int miniMapSize;
    private GameObject[,] nowState;
    // Start is called before the first frame update
    private void OnEnable()
    {

        miniMapSize = 20 - GameManager.instance.stageNum * 2;
        minimap.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(miniMapSize * (GameManager.instance.stageNum + 7) * 2, miniMapSize * (GameManager.instance.stageNum + 7) * 2);
        minimap.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((-miniMapSize * (GameManager.instance.stageNum + 7)), (-(miniMapSize * (GameManager.instance.stageNum + 7))));
        itemImgRigid = ItemImg.GetComponent<Rigidbody2D>();
        itemImgRect = ItemImg.GetRect();
        TextBoxSize = status[4].GetComponent<RectTransform>();
        TextSize = status[4].GetComponent<TMP_Text>();


    }
    void Start()
    {


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
        if (GameManager.instance.roomChange)
        {
            MiniMap();
            GameManager.instance.roomChange = false;
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
        ItemImg.transform.SetLocalPositionAndRotation(new Vector2(-12.0f, ItemImg.transform.localPosition.y), new Quaternion(0f, 0f, 0f, 0f));
        itemImgRect.sizeDelta = new Vector2(300, 100);
        itemImgRigid.velocity = new Vector2(1500, 0);
        TextBoxSize.sizeDelta = new Vector2(300, 100);
        TextSize.fontSize = 40f;
        yield return new WaitForSeconds(0.5f);
        ItemImg.SetActive(false);



    }
    void MiniMap()
    {
        nowState = GameManager.instance.nowMapStat;
        for (int i = 0; i < GameManager.instance.stageNum + 6; i++)
        {
            for (int j = 0; j < GameManager.instance.stageNum + 6; j++)
            {

                switch (GameManager.instance.map[j, i])
                {
                    case 0:
                        Image makeImg = Instantiate(rooms[0]);
                        makeImg.transform.SetParent(minimap.transform, false);
                        imgrect = makeImg.GetComponent<RectTransform>();
                        imgrect.sizeDelta = new Vector2(miniMapSize, miniMapSize);
                        imgrect.transform.SetLocalPositionAndRotation(new Vector2(j * miniMapSize, i * miniMapSize), new Quaternion(0, 0, 0, 0));
                        break;
                    case 1:
                        makeImg = Instantiate(rooms[1]);
                        makeImg.transform.SetParent(minimap.transform, false);
                        imgrect = makeImg.GetComponent<RectTransform>();
                        imgrect.transform.SetLocalPositionAndRotation(new Vector2(j * miniMapSize, i * miniMapSize), new Quaternion(0, 0, 0, 0));
                        break;
                    case 2:
                        makeImg = Instantiate(rooms[2]);
                        makeImg.transform.SetParent(minimap.transform, false);
                        imgrect = makeImg.GetComponent<RectTransform>();
                        imgrect.transform.SetLocalPositionAndRotation(new Vector2(j * miniMapSize, i * miniMapSize), new Quaternion(0, 0, 0, 0));
                        break;
                    case 3:
                        makeImg = Instantiate(rooms[3]);
                        makeImg.transform.SetParent(minimap.transform, false);
                        imgrect = makeImg.GetComponent<RectTransform>();
                        imgrect.transform.SetLocalPositionAndRotation(new Vector2(j * miniMapSize, i * miniMapSize), new Quaternion(0, 0, 0, 0));
                        break;
                    case 4:
                        makeImg = Instantiate(rooms[4]);
                        makeImg.transform.SetParent(minimap.transform, false);
                        imgrect = makeImg.GetComponent<RectTransform>();
                        imgrect.transform.SetLocalPositionAndRotation(new Vector2(j * miniMapSize, i * miniMapSize), new Quaternion(0, 0, 0, 0));
                        break;
                    case 5:
                        makeImg = Instantiate(rooms[5]);
                        makeImg.transform.SetParent(minimap.transform, false);
                        imgrect = makeImg.GetComponent<RectTransform>();
                        imgrect.transform.SetLocalPositionAndRotation(new Vector2(j * miniMapSize, i * miniMapSize), new Quaternion(0, 0, 0, 0));
                        break;
                    case 6:
                        makeImg = Instantiate(rooms[6]);
                        makeImg.transform.SetParent(minimap.transform, false);
                        imgrect = makeImg.GetComponent<RectTransform>();
                        imgrect.transform.SetLocalPositionAndRotation(new Vector2(j * miniMapSize, i * miniMapSize), new Quaternion(0, 0, 0, 0));
                        break;

                }


            }
        }
    }
}
