using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject TP1, TP2;
    public float spd = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-spd * Time.deltaTime, 0f, 0f);

        if(this.transform.position.x <= TP1.transform.position.x)
        {
            this.transform.position = new Vector2(TP2.transform.position.x, this.transform.position.y);
        }
    }
}
