using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tears : MonoBehaviour
{
    private BoxCollider2D tearHitBox;
    private RectTransform tearSize;
    private Rigidbody2D tearRigid;

    private Player_Stat player_Stat;
    private Player_Active player_Active;
    private Rigidbody2D playerRigid;
    private RectTransform playerRect;
    private Vector2 startPosition;
    public float range = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        tearHitBox = gameObject.GetBoxCollider();
        tearSize =  gameObject.GetRect();
        tearRigid = gameObject.GetRigid();
    }

    // Update is called once per frame
    void Update()
    {
        tearRigid.velocity = transform.up*10f;
        if(range<Vector2.Distance(startPosition,tearSize.anchoredPosition)){
            gameObject.SetActive(false);
            Pooling.instance.playerTears.Push(gameObject);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag ==  "Player"){
            player_Stat = other.gameObject.GetComponent<Player_Stat>();
            player_Active = other.gameObject.GetComponent<Player_Active>();
            playerRigid = other.gameObject.GetRigid();
            
            playerRect = other.gameObject.GetComponent<RectTransform>();
            tearSize.transform.rotation = player_Active.playerHead.rotation;
            startPosition = playerRect.transform.position;

        }
        if(other.transform.tag=="wall" || other.transform.tag=="door"){
            gameObject.SetActive(false);
            Pooling.instance.playerTears.Push(gameObject);
        }
    }
    
}
