using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Monster_Active
{
    // Start is called before the first frame update

    protected Rigidbody2D EnemyRigd;
    private Animator bodyAni;
    private bool die;
    public override void Start()
    {

        base.Start();
        EnemyRigd = gameObject.GetComponent<Rigidbody2D>();
        bodyAni = transform.GetChild(0).GetComponent<Animator>();
        Debug.Log(maxHp);
        if (gameObject.activeSelf)
        {
            GameManager.instance.monsterCount++;
        }
        maxHp = stat.maxHp + GameManager.instance.stageNum * 0.8f;
        monsterType = 2;


    }

    // Update is called once per frame
    void Update()
    {

        if (maxHp < 0)
        {
            die = true;
            transform.gameObject.SetActive(false);
            GameManager.instance.monsterCount--;
            bodyAni.SetBool("isDie", true);
        }





    }


    public virtual void OnTriggerStay2D(Collider2D other)
    {

        if (other.transform.tag == "Player")
        {
            EnemyRigd.velocity = (other.transform.position - transform.position).normalized * stat.speed * 3f;

        }
    }



}
