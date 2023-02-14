using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Active : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Rigidbody2D playerRigid;
    public float maxVelocityX = 5;
    public float maxVelocityY = 5;
    private GameObject tears;
    public RectTransform playerHead;
    public float speed ;
    private bool keyDown;
    private bool isAttack = false;
    private Animator aniHead;
    public void Start()
    {
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerHead = transform.GetChild(0).GetComponent<RectTransform>();
        aniHead = transform.GetChild(1).GetComponent<Animator>();
    }

    void Update(){
        move();
        Shooting();
        if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Debug.Log("Down");
                aniHead.SetBool("RightAttack",false);


            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Debug.Log("Down");
                aniHead.SetBool("LeftAttack",false);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("Up");
                aniHead.SetBool("BackAttack",false);

            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Debug.Log("Down");
                aniHead.SetBool("frontAttack",false);

            }
    }

    public void move()
    {

        if(Input.anyKey){
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.W))
        {

            playerRigid.AddForce(new Vector2(0, 2f));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if(keyDown){
                StartCoroutine(Moving(new Vector2(0,0.05f)));
            }
            keyDown = false;
            
        }
        if (Input.GetKey(KeyCode.S))
        {

            playerRigid.AddForce(new Vector2(0, -2f));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            
            keyDown = false;

        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigid.AddForce(new Vector2(-2f, 0));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {   
            
            if(keyDown){
             StartCoroutine(Moving(new Vector2(-0.05f,0)));
            }
            keyDown = false;

        }

        if (Input.GetKey(KeyCode.D))
        {

            playerRigid.AddForce(new Vector2(2f, 0));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            
            if(keyDown){
             StartCoroutine(Moving(new Vector2(0.05f,0)));
            }
            keyDown = false;

        }
           
           
    }
    void LimitSpeed(){
        if(playerRigid.velocity.x> maxVelocityX){
            playerRigid.velocity = new Vector2(maxVelocityX, playerRigid.velocity.y);
        }
        if(playerRigid.velocity.x< (maxVelocityX*-1)){
            playerRigid.velocity = new Vector2(maxVelocityX*-1, playerRigid.velocity.y);
        }
        if(playerRigid.velocity.y> maxVelocityY){
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, maxVelocityY );
        }
        if(playerRigid.velocity.y< (maxVelocityY*-1)){
            playerRigid.velocity = new Vector2(playerRigid.velocity.x,  (maxVelocityY*-1));
        }
    }

    public void Attack(){
        tears = Pooling.instance.playerTears.Pop(); 
        tears.transform.position = gameObject.transform.position;
        tears.SetActive(true);     
    }
    public void Shooting(){
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) )
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                aniHead.SetBool("RightAttack",true);
                playerHead.SetRotation(0, 0, 270f);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                aniHead.SetBool("LeftAttack",true);
                playerHead.SetRotation(0, 0, 90f);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                aniHead.SetBool("BackAttack",true);
                playerHead.SetRotation(0, 0, 0);

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                aniHead.SetBool("frontAttack",true);
                playerHead.SetRotation(0, 0, 180f);

            } 
            
            if(!isAttack){
                isAttack = true;
                StartCoroutine("Attacking");
            }
            
        }
    }
    IEnumerator Moving(Vector2 vector){
        playerRigid.velocity = vector;
        yield return new WaitForSeconds(0.1f);
        playerRigid.velocity = Vector2.zero;
    }

    IEnumerator Attacking(){

        Attack();
        yield return new WaitForSeconds(0.5f);
        isAttack =false;

    }
}
