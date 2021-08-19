using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHit : MonoBehaviour
{
    Animator anim;
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit == true && this.transform.parent.GetComponent<Monster>().isAttack == false)
        {
            this.transform.parent.GetComponent<Monster>().hp++;
            GameManager.hp--;
            anim.SetTrigger("Attack");

            if(GameManager.hp == 0)
            {
                GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_dead = true;
                GameObject.Find("HeroKnight").GetComponent<HeroKnight>().dead_snd = true;
                GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_animator.SetTrigger("Death");
                GameObject.Find("HeroKnight").layer = 7;
            }
            else
            {
                if (!GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_blocking
                    && !GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_blockOn
                    && !GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_rolling
                    && !GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_attack
                    && !GameObject.Find("HeroKnight").GetComponent<HeroKnight>().isAttack)
                {
                    GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_animator.SetTrigger("Hurt");
                    GameObject.Find("HeroKnight").GetComponent<HeroKnight>().hurt_snd = true;
                }
            }
            isHit = false;
        }
    }
}
