using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrapDoor : MonoBehaviour
{
    public GameObject trapDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.bossCheck)
        {
            trapDoor.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }
        else
        {
            trapDoor.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("why");
            GameManager.instance.stageNum++;

            StartCoroutine(Delay(other.gameObject));



        }

    }
    IEnumerator Delay(GameObject objs)
    {

        objs.transform.GetChild(1).gameObject.SetActive(true);
        objs.transform.GetChild(4).gameObject.SetActive(false);
        objs.transform.GetChild(3).gameObject.SetActive(false);
        objs.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = objs.transform.GetComponent<Player_Active>().PlayerActSprite[2];
        objs.transform.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3f;
        yield return new WaitForSeconds(0.4f);
        objs.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = objs.transform.GetComponent<Player_Active>().PlayerActSprite[3];
        objs.transform.GetComponent<Rigidbody2D>().velocity = Vector2.down * 3f;
        yield return new WaitForSeconds(0.4f);
        objs.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        objs.transform.gameObject.SetActive(false);
        SceneManager.LoadScene($"Stage{GameManager.instance.stageNum}");

    }
}
