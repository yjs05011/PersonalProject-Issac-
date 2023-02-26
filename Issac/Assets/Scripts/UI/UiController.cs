using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (!GameManager.instance.roomChange)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (transform.GetChild(0).gameObject.activeSelf)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    Time.timeScale = 1f;
                    GameManager.instance.MainUiActive = false;
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    GameManager.instance.MainUiActive = true;
                }

            }
        }

    }
}
