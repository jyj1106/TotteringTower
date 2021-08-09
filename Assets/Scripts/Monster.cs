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
    public float rangeP = 2f;
    public float reAttackTime = 2f;
    public bool isFlying, isAttack = false;
    public bool[] B_Mon = new bool[5];
    public bool[] W_Mon = new bool[10];
    public static bool colorChange = false;

    private Animator anim;
    private float posy;
    private float pos1, pos2;
    private float atkTimer, deathTimer, dTime;
    private bool trackP, attackable = true;
    private bool trackC = false;

    // Start is called before the first frame update
    void Start()
    {
        //This is Initializing process of Monster's ability and status. Set value in Inspector View
        //You must set true only one element. If you set true as multiple, it makes error!
        //The List of Monster's ability is In Àû ´É·Â memo sheet.
        //Default value is same as B_Mon[0];
        if (B_Mon[0] == true)
        {
            trackP = true; trackC = false;
            hp = 5f;
            spd = 2f;
            rangeP = 2f;
            reAttackTime = 2f;
            isFlying = false;
            isAttack = true;
        }
        else if (B_Mon[1] == true)
        {
            trackP = true; trackC = false;
            hp = 3f;
            spd = 5f;
            rangeP = 2f;
            reAttackTime = 2f;
            isFlying = false;
            isAttack = true;
        }
        else if (B_Mon[2] == true)
        {
            trackP = true; trackC = false;
            hp = 3f;
            spd = 1f;
            rangeP = 2f;
            reAttackTime = 2f;
            isFlying = false;
            isAttack = true;
        }
        else if (B_Mon[3] == true)
        {

        }
        else if (B_Mon[4] == true)
        {

        }
        //Now It's White Monsters!         Now It's White Monsters!
        else if (W_Mon[0] == true)
        {
            trackP = true; trackC = false;
            hp = 3f;
            spd = 2f;
            rangeP = 2f;
            reAttackTime = 2f;
            isFlying = true;
            isAttack = true;
        }
        else if (W_Mon[1] == true)
        {

        }
        else if (W_Mon[2] == true)
        {

        }
        else if (W_Mon[3] == true)
        {

        }
        else if (W_Mon[4] == true)
        {

        }
        else if (W_Mon[5] == true)
        {

        }
        else if (W_Mon[6] == true)
        {

        }
        else if (W_Mon[7] == true)
        {

        }
        else if (W_Mon[8] == true)
        {
            //Dabe
            trackP = true; trackC = false;
            hp = 10f;
            spd = 2f;
            rangeP = 2f;
            reAttackTime = 0f;
            isFlying = true;
            isAttack = false;
        }
        else if (W_Mon[9] == true)
        {

        }


        this.gameObject.layer = 3;
        anim = GetComponent<Animator>();
        posy = this.transform.position.y;
        atkTimer = 0f;
        deathTimer = 0f;
        dTime = 1f;
        //attackable is not same as reAttackTime. This makes monster stop
        attackable = true;
        //pos2 is not same as posy. pos2 is used in Flip
        pos2 = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //To calculating reAttackTime and deadTime
        atkTimer += Time.deltaTime;
        deathTimer += Time.deltaTime;

        //Tracking Player
        if(attackable == true && trackP == true)
        {
            float dis = Vector2.Distance(this.transform.position, playerPos.position);

            if (dis >= rangeP && attackable == true)
            {
                Vector2 tracking = Vector2.MoveTowards(this.transform.position, playerPos.position, spd * Time.deltaTime);
                this.transform.position = tracking;
                pos1 = this.transform.position.x;
            }
            else if (dis < rangeP && attackable == true && atkTimer >= reAttackTime && isAttack == true)
            {
                atkTimer = 0f;
                anim.SetTrigger("Attack");
                EAttack.gameObject.SetActive(true);
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
 
        //Make non-Flying Monsters
        if(isFlying == false)
        {
            this.transform.position = new Vector2(this.transform.position.x, posy);
        }

        //Make non-Attack Monsters get dmg
        if(isAttack == false)
        {
            if(deathTimer >= 2 * dTime)
            {
                hp--;
                dTime++;
                this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.3f);
                colorChange = true;
            }
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

        //ColorChange(Transparent)
        if(colorChange == true)
        {
            Invoke("Color", 0.1f);
        }

        //Dead
        if (hp <= 0)
        {
            attackable = false;
            this.gameObject.layer = 7;
            this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            anim.SetTrigger("Dead");
        }
    }

    //Attack Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && atkTimer >= reAttackTime && isAttack == true)
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

    void Color()
    {
        this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        colorChange = false;
    }
}
