using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
    public float angle = 0f;
    public int status = 0; //0: ����, 1: �����̵�, 2: �������̵�
    public float count = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Space.World�� �۷ι���ǥ(�� ������ ��ǥ��), Space.Self�� �� ������Ʈ�� ��ǥ��
    void Update()
    {
        count += Time.deltaTime;
        if (count > 2)
        {
            this.transform.Rotate(0, 0, angle);
        }
        if(status == 1)
        {
            this.transform.Translate(-0.01f, 0, 0, Space.World);
        }
        else if(status == 2)
        {
            this.transform.Translate(0.01f, 0, 0, Space.World);
        }
    }
}
