using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car2 : MonoBehaviour
{
    public float spd = 0.01f;
    public bool auto = false;
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
            if (direction == false)
            {
                this.transform.Translate(spd * Time.deltaTime, 0f, 0f);

                if (posx >= 8f)
                {
                    this.GetComponent<SpriteRenderer>().flipX = true;
                    direction = true;
                    this.transform.Translate(-spd * Time.deltaTime, 0f, 0f);
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
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (bombable == true)
            {
                bombable = false;
                spd = 0f;
                anim.SetTrigger("BOOM");
            }
        }
    }
}
