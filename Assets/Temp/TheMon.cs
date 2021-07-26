using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheMon : MonoBehaviour
{
    public float HP = 3f;
    public Animator anim;
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
        if (collision.CompareTag("Player"))
        {
            GameManager.hp--;
            HP -= HP;

            if (HP == 0)
            {
                GameObject.Find("StageManager").GetComponent<StageManager>().Score = 100;
                anim.Play("Dead");
                Destroy(this.gameObject, 2f);
            }
        }
    }
}
