using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHit : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PAttack") && transform.parent.GetComponent<Monster>().isAttack == false)
        {
            GameManager.hp--;
            anim.SetTrigger("Attack");
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().PAttack1.SetActive(false);
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().PAttack2.SetActive(false);

            if(GameManager.hp == 0)
            {
                GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_dead = true;
                GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_animator.SetTrigger("Death");
                GameObject.Find("HeroKnight").layer = 7;
            }
            else
            {
                if (!GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_blocking
                    && !GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_blockOn
                    && !GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_rolling)
                {
                    GameObject.Find("HeroKnight").GetComponent<HeroKnight>().m_animator.SetTrigger("Hurt");
                }
            }
        }
    }
}
