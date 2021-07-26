using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float spd = 20f;
    float posx;
    float posy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posx = this.transform.position.x;
        posy = this.transform.position.y;
        this.transform.Translate(0f, spd * Time.deltaTime, 0f);

        if (posx > 10 || posx < -10 || posy > 5 || posy < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
