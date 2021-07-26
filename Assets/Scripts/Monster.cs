using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float spd;
    public Transform tf;
    public Transform[] movetf = new Transform[4];
    public int count = 0;
    public bool near = false;
    public float time = 0f;
    public int n = 1;
  
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().flipX = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = Vector3.Lerp(this.transform.position, tf.position, 0.1f * Time.deltaTime);
        /*
        Vector3 velo = Vector3.zero;
        Vector3 pos = Vector3.SmoothDamp(this.transform.position, tf.position, Vector3.zero);
        */
            
        if(count%4 == 2)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (count%4 == 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        float dis = Vector3.Distance(this.transform.position, movetf[0].position);
        if(dis > 5f && near == false)
        {
            return;
        }
        else
        {
            near = true;
        }
        if (near == true)
        {
            Attack();
            TimeAdd();
        }
        if(time >= 5f * n)
        {
            n++;
            spd++;
        }
        return;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        count++;
    }

    void Attack()
    {
        Vector3 pos = Vector3.MoveTowards(this.transform.position, movetf[0].position, spd * Time.deltaTime);
        this.transform.position = pos;
    }

    void TimeAdd()
    {
        time += Time.deltaTime;
    }
}
