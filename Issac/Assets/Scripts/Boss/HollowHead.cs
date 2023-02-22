using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowHead : Monster_Active
{
    public float MaxHp = default;
    private int totalLength;
    public GameObject HollowBody;
    public List<HollowBody> body;
    public bool[] isDie;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        totalLength = 6;

        body = new List<HollowBody>();
        for (int i = 0; i < totalLength; i++)
        {
            GameObject bodyObj = Instantiate(HollowBody);
            bodyObj.transform.SetParent(transform, false);
            bodyObj.GetComponent<HollowBody>().number = bodyObj.transform.GetSiblingIndex();
            bodyObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.6f * i, 0, 0);
            body.Add(bodyObj.GetComponent<HollowBody>());
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.bossHp <= 0)
        {
            gameObject.SetActive(false);
        }


    }
    void Cutting()
    {

        int count = 0;
        for (int i = 0; i < body.Count; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                count++;

            }

        }
        totalLength = count;
        for (int i = 0; i < totalLength; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.6f * i, 0, 0);
        }
    }
    void BodyNum()
    {
        for (int i = 0; i < body.Count; i++)
        {
            body[i] = transform.GetChiled(i).GetComponent<HollowBody>();
            if (body[i].maxHp <= 0)
            {
                body[i].die = true;
                isDie[i] = true;


            }
        }
        if (isDie[totalLength - 1])
        {
            body[totalLength - 1].gameObject.SetActive(false);
            body.RemoveAt(body.Count - 1);
        }
        else if (totalLength - 2 > 0 && isDie[totalLength - 2])
        {
            body[totalLength - 2].gameObject.SetActive(false);
            body.RemoveAt(body.Count - 2);
        }

    }

    public override void HitThisMonster(float damage)
    {
        for (int i = 0; i < totalLength; i++)
        {

        }
        base.HitThisMonster(damage);

        Cutting();
        transform.GetChild(totalLength - 1).GetComponent<HollowBody>().maxHp -= damage;

    }
}
