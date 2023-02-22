using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowBody : Monster_Active
{

    public bool die;
    public float hp;
    public int number;

    // Start is called before the first frame update
    void Start()
    {

        maxHp = stat.maxHp;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > maxHp)
        {
            if (maxHp <= 0)
            {
                maxHp = 0;
                GameManager.instance.bossHp -= hp - maxHp;
                hp = maxHp;
            }
            else
            {
                GameManager.instance.bossHp -= hp - maxHp;
                hp = maxHp;
            }


        }
        if (maxHp <= 0)
        {
            die = true;
            transform.SetAsLastSibling();
            gameObject.SetActive(false);
        }
    }

    public override void HitThisMonster(float damage)
    {
        base.HitThisMonster(damage);
        maxHp -= damage;
    }
}
