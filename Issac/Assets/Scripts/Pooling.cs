using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public Stack<GameObject> playerTears;
    public Stack<GameObject> enemyTears;
    public GameObject Tear;
    public GameObject playerTearPooling;
    public GameObject enemyTearPooling;
    public static Pooling instance = null;
    void Awake(){
        if( null == instance){
            instance = this;
        }
        else{
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerTears = new Stack<GameObject>();
        enemyTears = new Stack<GameObject>();
       
        for(int i = 0; i< 300; i++){
            GameObject poolingObjs = Instantiate(Tear);
            poolingObjs.SetActive(false);
            poolingObjs.transform.SetParent(playerTearPooling.transform,false);
            playerTears.Push(poolingObjs);
        }

        for(int i = 0; i< 300; i++){
            GameObject poolingObjs = Instantiate(Tear);
            poolingObjs.SetActive(false);
            poolingObjs.transform.SetParent(playerTearPooling.transform,false);
            enemyTears.Push(poolingObjs);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
