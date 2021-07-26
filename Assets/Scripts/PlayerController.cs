using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float spd = 5f;
    public bool auto = false;
    public float repeat = 0f;
    public float stop_count = 2f;
    public GameObject door;
    public GameObject bullet;
    public GameObject cherry;
    public GameObject ulbullet;
    public Transform FirePos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string aniname = "Player_Idle";
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            aniname = "Player_MoveRight";
            this.transform.Translate(-spd * Time.deltaTime, 0f, 0f, Space.World);
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            aniname = "Player_MoveRight";
            this.transform.Translate(spd * Time.deltaTime, 0f, 0f, Space.World);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            aniname = "Player_MoveUp";
            this.transform.Translate(0f, spd * Time.deltaTime, 0f, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            aniname = "Player_MoveDown";
            this.transform.Translate(0, -spd * Time.deltaTime, 0f, Space.World);
        }
        this.GetComponent<Animator>().Play(aniname);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            spd = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            spd = 5f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bull = Instantiate(bullet, FirePos);
            bull.transform.parent = null;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject cher = Instantiate(cherry, FirePos);
            cher.transform.parent = null;
        }

        if (Input.GetKey(KeyCode.E))
        {
            GameObject bull = Instantiate(bullet, FirePos);
            GameObject cher = Instantiate(cherry, FirePos);
            bull.transform.parent = null;
            cher.transform.parent = null;
            //GameObject ulbull = Instantiate(ulbullet, FirePos);
            //ulbull.transform.parent = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            door.SetActive(true);
            GameManager.keyGet = true;
        }

        if(collision.gameObject.tag == "Door")
        {
            GameObject.Find("Monster").GetComponent<Monster>().spd = 0f;

        }
    }*/
}
