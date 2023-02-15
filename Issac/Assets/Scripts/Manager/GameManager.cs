using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player_Stat player_Stat;
    public bool itemgetChk;
    public string itemName;
    public List<int> totalItem = new List<int>();
    public List<Charator> player = new List<Charator>();
    public bool monsterClearChk = false;
    public int stageNum = 1;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
