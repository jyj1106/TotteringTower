using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform playerPos;
    public GameObject EAttack;
    private Animator anim;
    private bool active = false;

    float posx;
    float posy;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        posx = this.gameObject.transform.position.x;
        posy = this.gameObject.transform.position.y;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active == false)
        {
            anim.SetTrigger("Attack");
            EAttack.gameObject.SetActive(true);
            active = true;
        }
    }
    void EAttack_Active()
    {
        EAttack.gameObject.SetActive(true);
    }
    void EAttack_Hide()
    {
        EAttack.gameObject.SetActive(false);
        active = false;
    }
}
