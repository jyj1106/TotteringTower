using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform playerPos;
    public float pLimitX, pLimitY, mLimitX, mLimitY;

    private float posx, posy, Pposx, Pposy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posx = this.transform.position.x;
        posy = this.transform.position.y;
        Pposx = playerPos.position.x;
        Pposy = playerPos.position.y;
        
        //Setting Cam Move Distance Limit
        if(posx >= pLimitX)
        {
            if(posy < pLimitY)
            {
                this.transform.position = new Vector3(this.transform.position.x, playerPos.position.y, -10f);
            }
        }
        else if (playerPos.position.x > mLimitX && playerPos.position.x < pLimitX && playerPos.position.y > mLimitY && playerPos.position.y < pLimitX)
        {
            this.transform.position = playerPos.position;
        }
        else
        {
            //Following Player
            this.transform.position = playerPos.position;
        }
    }
}
