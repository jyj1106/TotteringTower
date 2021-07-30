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

    private float posy;
    private Animator anim;
    private float atkTimer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        posy = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //To calculating reAttackTime
        atkTimer += Time.deltaTime;

        //Dead
        if(hp <=0)
        {
            Destroy(this.gameObject);
        }

        //Tracking Player
        float dis = Vector2.Distance(this.transform.position, playerPos.position);

        if(dis >= range)
        {
            Vector2 tracking = Vector2.MoveTowards(this.transform.position, playerPos.position, spd * Time.deltaTime);
            this.transform.position = tracking;
        }
        else
        {
            //Stop Tracking
        }
 
        //Make non-Flying Monster
        if(isFlying == false)
        {
            this.transform.position = new Vector2(this.transform.position.x, posy);
        }
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
    }
    void EAttack_Hide()
    {
        EAttack.gameObject.SetActive(false);
    }
}
