using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    [SerializeField] GameObject Slash1, Slash2;

    public static bool attackable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EHit") && collision.transform.parent.GetComponent<Monster>().isAttack == true)
        {
            collision.gameObject.transform.parent.GetComponent<Monster>().hp--;
            collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.3f);
            if(attackable == false)
            {
                Slash2.transform.position = collision.transform.position;
                Slash2.SetActive(true);
            }
            else if (attackable == true)
            {
                Slash1.transform.position = collision.transform.position;
                Slash1.SetActive(true);
                attackable = false;
            }
            Monster.colorChange = true;
        }
        else if (collision.gameObject.CompareTag("EHit") && collision.transform.parent.GetComponent<Monster>().isAttack == false)
        {
            if (attackable == false)
            {
                Slash2.transform.position = collision.transform.position;
                Slash2.SetActive(true);
            }
            else if (attackable == true)
            {
                Slash1.transform.position = collision.transform.position;
                Slash1.SetActive(true);
                attackable = false;
            }
        }
    }
}
