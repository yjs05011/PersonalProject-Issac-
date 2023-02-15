using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tears : MonoBehaviour
{
    public BoxCollider2D tearHitBox;
    public RectTransform tearSize;
    public RectTransform tearImgSize;
    public Rigidbody2D tearRigid;
    public Rigidbody2D tearImgRigid;
    public Vector2 TearsstartPos;
    public Vector2 ShadowstartPos;

    public Player_Stat player_Stat;
    public Player_Active player_Active;
    public Rigidbody2D playerRigid;
    public RectTransform playerRect;
    public Vector2 startPosition;
    public float range = 0;


    public void OnEnable()
    {
        tearImgRigid = transform.GetChild(0).gameObject.GetRigid();
        tearImgSize = transform.GetChild(0).gameObject.GetRect();

        tearHitBox = gameObject.GetBoxCollider();
        tearSize = gameObject.GetRect();
        tearRigid = gameObject.GetRigid();

        TearsstartPos = tearImgRigid.position;
        ShadowstartPos = tearSize.position;


        Debug.Log($"3번 플로우 눈물이 발사된다. : {tearSize.rotation.eulerAngles}");

    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if (Vector2.Distance(TearsstartPos, tearSize.position) > GameManager.instance.player_Stat.Range / 2)
        {
            tearImgRigid.velocity = new Vector2(tearImgRigid.velocity.x, tearImgRigid.velocity.y - 0.1f);
            if (tearSize.position.y > tearImgSize.position.y || Vector2.Distance(TearsstartPos, tearSize.position) > (GameManager.instance.player_Stat.Range + 1) / 2)
            {
                gameObject.SetActive(false);
                gameObject.transform.position = ShadowstartPos;
                tearImgSize.position = TearsstartPos;
                Pooling.instance.playerTears.Push(gameObject);
            }

        }
        else
        {
            tearRigid.velocity = transform.up * 6f;
            tearImgRigid.velocity = transform.up * 6f;
            tearImgRigid.velocity = new Vector2(tearImgRigid.velocity.x, tearImgRigid.velocity.y - 0.2f);
        }



    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            player_Active = other.gameObject.GetComponent<Player_Active>();
            playerRigid = other.gameObject.GetRigid();

            playerRect = other.gameObject.GetComponent<RectTransform>();
            tearSize.transform.rotation = player_Active.playerHead.rotation;
            startPosition = playerRect.transform.position;

        }
        if (other.transform.tag == "wall" || other.transform.tag == "door")
        {
            gameObject.transform.position = ShadowstartPos;
            tearImgSize.position = TearsstartPos;
            gameObject.SetActive(false);

            Pooling.instance.playerTears.Push(gameObject);
        }
    }


}
