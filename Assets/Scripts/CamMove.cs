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

        /*
        //Setting Cam Move Distance Limit
        if (Pposx >= pLimitX)
        {
            if(Pposy <= pLimitY && Pposy >= mLimitY)
            {
                this.transform.position = new Vector3(pLimitX, playerPos.position.y, -10f);
            }
            else if (Pposy <= pLimitY && Pposy <= mLimitY)
            {
                this.transform.position = new Vector3(pLimitX, mLimitY, -10f);
            }
            else
            {
                this.transform.position = new Vector3(pLimitX, pLimitY, -10f);
            }
        }
        else if (Pposx <= mLimitX)
        {
            if (Pposy <= mLimitY)
            {
                this.transform.position = new Vector3(mLimitX, mLimitY, -10f);
            }
            else
            {
                this.transform.position = new Vector3(mLimitX, playerPos.position.y, -10f);
            }
        }
        else if (Pposy <= mLimitY)
        {
            this.transform.position = new Vector3(playerPos.position.x, mLimitY, -10f);
        }
        else
        {
            this.transform.position = playerPos.position;
        }*/
        float px = playerPos.position.x;
        float py = playerPos.position.y;


        if (Pposx >= pLimitX)
        {
            px = pLimitX;
        }
        if (Pposx <= mLimitX)
        {
            px = mLimitX;
        }
        if (Pposy >= pLimitY)
        {
            py = pLimitY;
        }
        if (Pposy <= mLimitY)
        {
            py = mLimitY;
        }
        this.transform.position = new Vector3(px, py, -10f);
    }
}
