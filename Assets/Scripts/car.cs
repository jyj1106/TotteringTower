using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float spd = 0.01f;
    public bool auto = false;
    public float repeat = 0f;
    public float stop_count = 2f;
    float posx;
    bool direction = false;
    bool bombable = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //이동 관련
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            direction = true;
            this.transform.Translate(-spd * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            direction = false;
            this.transform.Translate(spd * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0f, spd * Time.deltaTime * 0.5f , 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, -spd * Time.deltaTime * 0.5f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            spd = 50f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            spd = 5f;
        }

        //오토 관련
        posx = this.transform.position.x;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            auto = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            auto = false;
        }

        if (auto == true)
        {
            if(direction == false)
            {
                this.transform.Translate(spd * Time.deltaTime, 0f, 0f);

                if(posx >= 8f)
                {
                    this.GetComponent<SpriteRenderer>().flipX = true;
                    direction = true;
                    this.transform.Translate(-spd * Time.deltaTime, 0f, 0f);
                    repeat += 0.5f;
                }
            }
            if (direction == true)
            {
                this.transform.Translate(-spd * Time.deltaTime, 0f, 0f);

                if (posx <= -8)
                {
                    this.GetComponent<SpriteRenderer>().flipX = false;
                    direction = false;
                    this.transform.Translate(spd * Time.deltaTime, 0f, 0f);
                    repeat += 0.5f;
                }
            }
            if (repeat == stop_count)
            {
                this.gameObject.SetActive(false);
            }
        }
        //애니메이션 관련
        if (Input.GetKey(KeyCode.Backspace))
        {
            if(bombable == true)
            {
                bombable = false;
                spd = 0f;
                anim.SetTrigger("BOOM");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("BOOM");
            bombable = false;
            spd = 0f;
            Destroy(this.gameObject, 1);
        }
    }
}
