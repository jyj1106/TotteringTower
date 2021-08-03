using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform playerPos;
    public GameObject EAttack;
    public GameObject MSpawner;
    public float hp = 5f;
    public float spd = 2f;
    public float range = 2f;
    public float reAttackTime = 2f;
    public bool isFlying = false;

    private Animator anim;
    private float posy;
    private float pos1, pos2;
    private float atkTimer;
    private bool attackable;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Monster";
        anim = GetComponent<Animator>();
        posy = this.transform.position.y;
        //attackable is not same as reAttackTime. This makes monster stop
        attackable = true;
        //pos2 is not same as posy. pos2 is used in Flip
        pos2 = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //To calculating reAttackTime
        atkTimer += Time.deltaTime;

        //Dead
        if(hp <=0)
        {
            this.gameObject.tag = "Untagged";
            anim.SetTrigger("Dead");
        }

        //Tracking Player
        if(attackable == true)
        {
            float dis = Vector2.Distance(this.transform.position, playerPos.position);

            if (dis >= range && attackable == true)
            {
                Vector2 tracking = Vector2.MoveTowards(this.transform.position, playerPos.position, spd * Time.deltaTime);
                this.transform.position = tracking;
                pos1 = this.transform.position.x;
            }
            else
            {
                //Stop Tracking
            }
        }
        else
        {
            //Idle or Waiting reAttackTime
        }
 
        //Make non-Flying Monster
        if(isFlying == false)
        {
            this.transform.position = new Vector2(this.transform.position.x, posy);
        }

        //FlipX
        if(pos1 > pos2)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(pos1 == pos2)
        {
            //Do not Flip
        }
        else if(pos1 < pos2)
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        pos2 = this.transform.position.x;
    }

    //Attack Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && atkTimer >= reAttackTime)
        {
            atkTimer = 0f;
            anim.SetTrigger("Attack");
            EAttack.gameObject.SetActive(true);
        }
    }
    void EAttack_Active()
    {
        EAttack.gameObject.SetActive(true);
        attackable = false;
    }
    void EAttack_Hide()
    {
        EAttack.gameObject.SetActive(false);
    }

    void Attackable()
    {
        attackable = true;
    }

    void MonDead()
    {
        this.gameObject.SetActive(false);
    }
}
