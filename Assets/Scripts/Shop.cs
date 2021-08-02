using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int EP = 5;

    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;


    public Text point;
    public Text shop1;
    public Text shop2;
    public Text shop3;
    public Text shop4;

    public GameObject pbtn1;
    public GameObject pbtn2;
    public GameObject pbtn3;
    public GameObject pbtn4;
    public GameObject mbtn1;
    public GameObject mbtn2;
    public GameObject mbtn3;
    public GameObject mbtn4;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        point.text = "사용가능 EP : " + EP;
        if(EP <=0)
        {
            pbtn1.gameObject.SetActive(false);
            pbtn2.gameObject.SetActive(false);
            pbtn3.gameObject.SetActive(false);
            pbtn4.gameObject.SetActive(false);
        }
        else
        {
            pbtn1.gameObject.SetActive(true);
            pbtn2.gameObject.SetActive(true);
            pbtn3.gameObject.SetActive(true);
            pbtn4.gameObject.SetActive(true);
        }

        if (num1 == 0)
        {
            mbtn1.gameObject.SetActive(false);
        }
        else
        {
            mbtn1.gameObject.SetActive(true);
        }
        if (num2 == 0)
        {
            mbtn2.gameObject.SetActive(false);
        }
        else
        {
            mbtn2.gameObject.SetActive(true);
        }
        if (num3 == 0)
        {
            mbtn3.gameObject.SetActive(false);
        }
        else
        {
            mbtn3.gameObject.SetActive(true);
        }
        if (num4 == 0)
        {
            mbtn4.gameObject.SetActive(false);
        }
        else
        {
            mbtn4.gameObject.SetActive(true);
        }

    }

    public void ShopPlus1()
    {
        num1++;
        shop1.text = "사과\n\n\nHP MP\n\n\nLV : " + num1;
        EP--;
    }
    public void ShopMinus1()
    {
        num1--;
        shop1.text = "사과\n\n\nHP MP\n\n\nLV : " + num1;
        EP++;
    }

    public void ShopPlus2()
    {
        num2++;
        shop2.text = "황금코인\n\n\n쿨타임\n\n\nLV : " + num2;
        EP--;
    }
    public void ShopMinus2()
    {
        num2--;
        shop2.text = "황금코인\n\n\n쿨타임\n\n\nLV : " + num2;
        EP++;
    }

    public void ShopPlus3()
    {
        num3++;
        shop3.text = "방패\n\n\n반격기\n\n\nLV : " + num3;
        EP--;
    }
    public void ShopMinus3()
    {
        num3--;
        shop3.text = "방패\n\n\n반격기\n\n\nLV : " + num3;
        EP++;
    }

    public void ShopPlus4()
    {
        num4++;
        shop4.text = "마력석\n\n\n타워\n\n\nLV : " + num4;
        EP--;
    }
    public void ShopMinus4()
    {
        num4--;
        shop4.text = "마력석\n\n\n타워\n\n\nLV : " + num4;
        EP++;
    }
}
