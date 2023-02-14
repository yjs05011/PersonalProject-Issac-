using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameUI : MonoBehaviour
{
    public TMP_Text[] status;
    // Start is called before the first frame update
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
    }
}
