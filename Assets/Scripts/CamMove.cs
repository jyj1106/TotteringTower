using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform playerPos;
    public float pLimitX, pLimitY, mLimitX, mLimitY;
    public float shakeAmount;

    private float posx, posy, Pposx, Pposy;
    private float shakeTimer;

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

        if(shakeTimer >= 0)
        {
            shakeTimer -= Time.deltaTime;

            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;

            this.transform.position = this.transform.position + new Vector3(shakePos.x, shakePos.y, -10);
        }
    }

    public void Shake(float shakePower, float shakeDuration)
    {
        shakeAmount = shakePower;
        shakeTimer = shakeDuration;
    }
}
