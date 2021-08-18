using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject[] MEffects = new GameObject[10];

    private Animator anim;
    private bool collapse;

    public int TowerHP = 20;
    public bool TCollapse, towerSound = false;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.layer = 8;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EAttack" && collapse == false)
        {
            TowerHP--;
            towerSound = true;
            if(!(TowerHP <= 0) && TowerHP > 14)
            {
                GameObject Mefc0 = Instantiate(MEffects[0]);
                Mefc0.transform.parent = null;
                Mefc0.transform.position = new Vector2(Random.Range(-1.3f, 1.3f), Random.Range(-3.45f, 2.6f));
                anim.SetTrigger("isHit_100");
            }
            else if(!(TowerHP <= 0) && TowerHP <= 14 && TowerHP > 7)
            {
                GameObject Mefc0 = Instantiate(MEffects[0]);
                Mefc0.transform.parent = null;
                Mefc0.transform.position = new Vector2(Random.Range(-1.3f, 1.3f), Random.Range(-3.45f, 2.6f));
                anim.SetTrigger("isHit_60");
            }
            else if (!(TowerHP <= 0) && TowerHP <= 7 && TowerHP > 0)
            {
                GameObject Mefc0 = Instantiate(MEffects[0]);
                Mefc0.transform.parent = null;
                Mefc0.transform.position = new Vector2(Random.Range(-1.3f, 1.3f), Random.Range(-3.45f, 2.6f));
                anim.SetTrigger("isHit_30");
            }
            else if(TowerHP <= 0)
            {
                GameObject.Find("HeroKnight").GetComponent<HeroKnight>().enabled = false;
                collapse = true;
                this.gameObject.layer = 7;
                anim.SetTrigger("isCollapse");
            }
        }
    }

    void GoIdle()
    {
        if (!(TowerHP <= 0) && TowerHP > 14)
        {
            anim.SetTrigger("isIdle_100");
        }
        else if (!(TowerHP <= 0) && TowerHP <= 14 && TowerHP > 7)
        {
            anim.SetTrigger("isIdle_60");
        }
        else if (!(TowerHP <= 0) && TowerHP <= 7 && TowerHP > 0)
        {
            anim.SetTrigger("isIdle_30");
        }
    }

    void TowerDead()
    {
        TCollapse = true;
        GameObject.Find("Managements").transform.Find("StageManager").GetComponent<StageManager>().NowLoading();
    }
}
