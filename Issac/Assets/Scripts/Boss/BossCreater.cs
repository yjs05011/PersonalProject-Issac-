using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCreater : MonoBehaviour
{
    public GameObject[] bossList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateBoss()
    {
        GameObject newBoss = Instantiate(bossList[Random.Range(0, 2)]);
        newBoss.SetActive(true);
        GameManager.instance.monsterCount++;
    }
}
