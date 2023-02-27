using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUi : MonoBehaviour
{
    public Image backGroundImg;
    public Color backGroundImgDefaultColor = default;
    public Color backGroundImgFedeInColor = default;
    const float FADE_ALPHA_DELTA = 0.3f;
    bool fadinFinishCheck;
    Coroutine fadinCoroutine = default;
    // Start is called before the first frame update
    void Start()
    {
        fadinFinishCheck = false;
        backGroundImgDefaultColor = new Color(0f, 0f, 0f, 0f);
        backGroundImgFedeInColor = new Color(0f, 0f, 0f, 0.9f);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BlackFadeInAndOut()
    {

        backGroundImg.color = new Color(0f, 0f, 0f, 0f);
        if (fadinCoroutine != null)
        {
            StopCoroutine(fadinCoroutine);
        }
        else
        {
            //do nothing
        }

        fadinCoroutine = StartCoroutine(FadeIn(0.0725f));


    }
    IEnumerator FadeIn(float totalTime)
    {
        float delay = totalTime / 30;

        fadinFinishCheck = false;
        // alpha go 0 to 0.9
        float alpha = backGroundImgDefaultColor.a;
        while (alpha <= backGroundImgFedeInColor.a)
        {
            alpha += FADE_ALPHA_DELTA;
            backGroundImg.color =
             new Color(backGroundImgDefaultColor.r, backGroundImgDefaultColor.g, backGroundImgDefaultColor.b, alpha);
            yield return new WaitForSeconds(delay);
            // Debug.Log("FadeInroutineCheck");
        }
        fadinFinishCheck = true;
        if (fadinFinishCheck)
        {
            StartCoroutine(FadeOut(0.0725f));
        }
    }
    IEnumerator FadeOut(float totalTime)
    {
        float delay = totalTime / 30;

        // alpha go 0 to 0.9
        float alpha = backGroundImgFedeInColor.a;
        while (alpha >= backGroundImgDefaultColor.a)
        {
            alpha -= FADE_ALPHA_DELTA;
            backGroundImg.color =
             new Color(backGroundImgDefaultColor.r, backGroundImgDefaultColor.g, backGroundImgDefaultColor.b, alpha);
            yield return new WaitForSeconds(delay);
        }
        gameObject.SetActive(false);
        backGroundImg.color = new Color(0f, 0f, 0f, 0.9f);
    }
}
