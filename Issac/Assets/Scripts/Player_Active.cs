using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Active : MonoBehaviour
{

    // Start is called before the first frame update
    public Rigidbody2D playerRigid;
    public float maxVelocityX = 5;
    public float maxVelocityY = 5;
    private Tears tears;
    public RectTransform playerHead;
    public float speed;
    private bool keyDown;
    private bool isAttack = false;
    private bool[] isAttackKey;
    private Animator aniHead;
    private Animator aniBody;
    public void Awake()
    {
        isAttackKey = new bool[4];
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerHead = transform.GetChild(2).GetComponent<RectTransform>();
        aniHead = transform.GetChild(3).GetComponent<Animator>();
        aniBody = transform.GetChild(4).GetComponent<Animator>();
    }
    public void Start()
    {

    }

    void Update()
    {
        move();
        if (transform.GetChild(0).gameObject.activeSelf)
        {

        }
        else
        {
            Shooting();
        }

    }

    public void move()
    {

        if (Input.anyKey)
        {
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            aniBody.SetBool("FrontMove", true);
            playerRigid.AddForce(new Vector2(0, 2f));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {

            if (keyDown)
            {
                StartCoroutine(Moving(new Vector2(0, 0.05f)));
            }
            keyDown = false;
            aniBody.SetBool("FrontMove", false);

        }
        if (Input.GetKey(KeyCode.S))
        {
            aniBody.SetBool("FrontMove", true);
            playerRigid.AddForce(new Vector2(0, -2f));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {

            keyDown = false;
            aniBody.SetBool("FrontMove", false);

        }
        if (Input.GetKey(KeyCode.A))
        {
            aniBody.SetBool("SideMove", true);
            playerRigid.AddForce(new Vector2(-2f, 0));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            if (keyDown)
            {
                StartCoroutine(Moving(new Vector2(-0.05f, 0)));
            }
            keyDown = false;
            aniBody.SetBool("SideMove", false);

        }

        if (Input.GetKey(KeyCode.D))
        {
            aniBody.SetBool("SideMove", true);
            playerRigid.AddForce(new Vector2(2f, 0));
            LimitSpeed();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {



            if (keyDown)
            {
                StartCoroutine(Moving(new Vector2(0.05f, 0)));
            }
            keyDown = false;
            aniBody.SetBool("SideMove", false);

        }


    }
    void LimitSpeed()
    {
        if (playerRigid.velocity.x > maxVelocityX)
        {
            playerRigid.velocity = new Vector2(maxVelocityX, playerRigid.velocity.y);
        }
        if (playerRigid.velocity.x < (maxVelocityX * -1))
        {
            playerRigid.velocity = new Vector2(maxVelocityX * -1, playerRigid.velocity.y);
        }
        if (playerRigid.velocity.y > maxVelocityY)
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, maxVelocityY);
        }
        if (playerRigid.velocity.y < (maxVelocityY * -1))
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, (maxVelocityY * -1));
        }
    }

    public void Attack()
    {
        tears = Pooling.instance.playerTears.Pop().GetComponent<Tears>();
        tears.tearSize.rotation = playerHead.rotation;
        Debug.Log($"2번 플로우 눈물이 팝된다.{tears.tearSize.rotation.eulerAngles},  {playerHead.rotation.eulerAngles}");
        if (isAttackKey[0])
        {

            tears.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f, gameObject.transform.position.z);
            tears.tearImgSize.position =
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z);
            Debug.Log($"Right :{tears.transform.GetChild(0).gameObject.transform.position}");
            Debug.Log($"shadow :{tears.transform.position.y}");
            Debug.Log($"Tears : {tears.transform.position.y}");
            Debug.Log($"shadow rotation :{tears.tearSize.rotation.eulerAngles}");
            Debug.Log($"Tears rotation : {tears.tearImgSize.rotation.eulerAngles}");
        }
        if (isAttackKey[1])
        {

            tears.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f, gameObject.transform.position.z);
            tears.transform.GetChild(0).gameObject.transform.position =
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z);
            Debug.Log($"left :{tears.transform.GetChild(0).gameObject.transform.position}");
        }
        if (isAttackKey[2])
        {

            tears.transform.position = gameObject.transform.position;
            tears.transform.GetChild(0).gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (isAttackKey[3])
        {

            tears.transform.position = gameObject.transform.position;
            tears.transform.GetChild(0).gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        tears.gameObject.SetActive(true);
    }
    public void Shooting()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            aniHead.SetBool("RightAttack", false);
            isAttackKey[0] = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {

            aniHead.SetBool("LeftAttack", false);
            isAttackKey[1] = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            aniHead.SetBool("BackAttack", false);
            isAttackKey[2] = false;

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            aniHead.SetBool("frontAttack", false);
            isAttackKey[3] = false;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isAttackKey[0] = true;
            Debug.Log("Shot");
            aniHead.SetBool("RightAttack", true);
            playerHead.SetRotation(0, 0, 270f);
            Debug.Log($"1번 플로우 해드가 돌아간다.{playerHead.rotation.eulerAngles}");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isAttackKey[1] = true;
            aniHead.SetBool("LeftAttack", true);
            playerHead.SetRotation(0, 0, 90f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isAttackKey[2] = true;
            aniHead.SetBool("BackAttack", true);
            playerHead.SetRotation(0, 0, 0);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isAttackKey[3] = true;
            aniHead.SetBool("frontAttack", true);
            playerHead.SetRotation(0, 0, 180f);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {



            if (!isAttack)
            {


                isAttack = true;
                StartCoroutine(Attacking(tears));
            }

        }


    }
    IEnumerator Moving(Vector2 vector)
    {
        playerRigid.velocity = vector;
        yield return new WaitForSeconds(0.1f);
        playerRigid.velocity = Vector2.zero;
    }

    IEnumerator Attacking(Tears tears)
    {
        yield return null;
        Attack();
        Debug.Log("Shoting");
        yield return new WaitForSeconds(0.5f);
        isAttack = false;

    }
}
