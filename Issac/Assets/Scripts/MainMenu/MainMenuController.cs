using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public bool isAniPress;
    public bool isNewRun;
    public bool isNewRunChange;
    public bool isOption;
    public bool isOptionChange;
    public bool changeChk;
    public bool resetMove;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (!changeChk)
        {

            if (isAniPress)
            {

            }
            else
            {
                PressAny();

            }

            if (isNewRun)
            {
                NewRunOpen();
            }
            else
            {
                NewRunClose();
            }
            if (isOption)
            {
                OptionOpen();
            }
            else
            {
                OptionClose();
            }
        }



    }
    void PressAny()
    {

        if (Input.anyKeyDown)
        {
            changeChk = true;
            transform.GetChild(0).GetComponent<TitleMoving>().isActve = true;
            transform.GetChild(1).GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(0, -500f, 0), new Quaternion(0, 0, 0, 0));
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).GetComponent<ChoiceMenu>().direction = Vector2.up;
            transform.GetChild(1).GetComponent<ChoiceMenu>().speed = 500f;
            isAniPress = true;
            StartCoroutine(ActiveReset(transform.GetChild(0)));
        }


    }
    void NewRunOpen()
    {
        if (isNewRunChange)
        {
            changeChk = true;
            transform.GetChild(3).GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(1200f, 0, 0), new Quaternion(0, 0, 0, 0));
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(3).GetComponent<ChoiceCharator>().direction = Vector2.left;
            transform.GetChild(3).GetComponent<ChoiceCharator>().speed = 800f;
            transform.GetChild(1).GetComponent<ChoiceMenu>().direction = Vector2.left;
            transform.GetChild(1).GetComponent<ChoiceMenu>().speed = 800f;
            transform.GetChild(1).GetComponent<ChoiceMenu>().isExport = true;
            StartCoroutine(ActiveReset(transform.GetChild(1)));
            isNewRunChange = false;
            isNewRun = false;
        }
    }
    void NewRunClose()
    {

        if (isNewRunChange)
        {
            changeChk = true;
            transform.GetChild(1).GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(-1200f, 0, 0), new Quaternion(0, 0, 0, 0));
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(3).GetComponent<ChoiceCharator>().direction = Vector2.right;
            transform.GetChild(3).GetComponent<ChoiceCharator>().speed = 800f;
            transform.GetChild(1).GetComponent<ChoiceMenu>().direction = Vector2.right;
            transform.GetChild(1).GetComponent<ChoiceMenu>().speed = 800f;
            transform.GetChild(1).GetComponent<ChoiceMenu>().isExport = true;

            StartCoroutine(ActiveReset(transform.GetChild(3)));

            isNewRunChange = false;
            isNewRun = true;
        }
    }
    void OptionOpen()
    {
        if (isOptionChange)
        {
            changeChk = true;
            transform.GetChild(2).GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(-1250f, 0, 0), new Quaternion(0, 0, 0, 0));
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(2).GetComponent<Option>().direction = Vector2.right;
            transform.GetChild(2).GetComponent<Option>().speed = 800f;
            transform.GetChild(1).GetComponent<ChoiceMenu>().direction = Vector2.right;
            transform.GetChild(1).GetComponent<ChoiceMenu>().speed = 800f;
            StartCoroutine(ActiveReset(transform.GetChild(1)));
            isOptionChange = false;
            isOption = false;
        }

    }

    void OptionClose()
    {
        if (isOptionChange)
        {
            changeChk = true;
            transform.GetChild(1).GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(+1250f, 0, 0), new Quaternion(0, 0, 0, 0));
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).GetComponent<Option>().direction = Vector2.left;
            transform.GetChild(2).GetComponent<Option>().speed = 800f;
            transform.GetChild(1).GetComponent<ChoiceMenu>().direction = Vector2.left;
            transform.GetChild(1).GetComponent<ChoiceMenu>().speed = 800f;
            StartCoroutine(ActiveReset(transform.GetChild(2)));
            isOptionChange = false;
            isOption = true;
        }





    }
    IEnumerator ActiveReset(Transform tran)
    {
        yield return new WaitForSeconds(0.4f);
        changeChk = false;
        tran.gameObject.SetActive(false);
    }
    IEnumerator ResetMove()
    {
        resetMove = true;
        yield return new WaitForSeconds(0.1f);
        resetMove = false;
    }
}
