using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform playerPos;
    public GameObject EAttack;
    public float hp = 5f;
    public float spd = 2f;

    private Animator anim;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dead
        if(hp <=0)
        {
            Destroy(this.gameObject);
        }

        //Tracking Player
        Vector2 tracking = Vector2.MoveTowards(this.transform.position, playerPos.position, spd * Time.deltaTime);
        this.transform.position = tracking;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active == false)
        {
            anim.SetTrigger("Attack");
            EAttack.gameObject.SetActive(true);
            active = true;
        }
        Vector2 difference = (transform.position - collision.transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
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
