using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Active : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Rigidbody2D playerRigid;

    public float speed ;

    public void Start()
    {
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        move();
        Debug.Log(playerRigid.velocity);
    }

    public void move()
    {
        switch (Input.inputString)
        {
            case "W":
                playerRigid.velocity = new Vector2(0,5);
                break;
            case "S":
                playerRigid.velocity =new Vector2(0,-5);
                break;
            case "A":
                playerRigid.velocity =new Vector2(-5,0);
                break;
            case "D":
                playerRigid.velocity =new Vector2(5,0);
                break;
        }
    }

    public virtual void Attack(){

    }
}
