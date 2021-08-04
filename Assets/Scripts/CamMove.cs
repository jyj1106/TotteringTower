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
