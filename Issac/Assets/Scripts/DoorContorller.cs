using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorContorller : MonoBehaviour
{


    private SpriteRenderer[] Doors;
    public int monsterNumber;
    public BoxCollider2D[] DoorExit;

    // Start is called before the first frame update
    void Start()
    {
        Doors = new SpriteRenderer[4];
        Doors[0] = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Doors[1] = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Doors[2] = transform.GetChild(2).GetComponent<SpriteRenderer>();
        Doors[3] = transform.GetChild(3).GetComponent<SpriteRenderer>();
        DoorChk();


    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.monsterClearChk = false;
        if (monsterNumber == 0)
        {
            GameManager.instance.monsterClearChk = true;
            OpenDoor();
        }
        /*  if(GameManager.Instance.ClearChk){

          }*/
    }
    void DoorChk()
    {
        if (true)
        {

        }
        else
        {
            for (int i = 0; i < Doors.Length; i++)
            {
                Doors[i].gameObject.SetActive(false);
            }
        }
    }


    void OpenDoor()
    {
        if (GameManager.instance.monsterClearChk)
        {

            for (int i = 0; i < Doors.Length; i++)
            {
                Doors[i].transform.GetChild(0).gameObject.SetActive(true);
                Doors[i].transform.GetChild(1).gameObject.SetActive(false);
                Doors[i].transform.GetChild(2).gameObject.SetActive(false);
                DoorExit[i].isTrigger = true;
            }
        }
    }


}