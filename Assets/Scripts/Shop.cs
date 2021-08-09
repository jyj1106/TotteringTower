using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int EP = 5;

    public static int num1 = 0;
    public static int num2 = 0;
    public static int num3 = 0;
    public static int num4 = 0;


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

    public static bool shopBtn_snd = false;

    private int upgrade1, upgrade2;

    // Start is called before the first frame update
    void Start()
    {
        num1 = 0;
        num2 = 0;
        num3 = 0;
        num4 = 0;
        upgrade1 = 0;
        upgrade2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        point.text = "강화포인트: " + EP;
        if(EP <=0)
        {
            pbtn1.gameObject.SetActive(false);
            pbtn2.gameObject.SetActive(false);
            pbtn3.gameObject.SetActive(false);
            pbtn4.gameObject.SetActive(false);
        }
        else
        {
            if (num1 == 20)
            {
                pbtn1.gameObject.SetActive(false);
            }
            else
            {
                pbtn1.gameObject.SetActive(true);
            }
            if (num2 == 20)
            {
                pbtn2.gameObject.SetActive(false);
            }
            else
            {
                pbtn2.gameObject.SetActive(true);
            }
            if (num3 == 20)
            {
                pbtn3.gameObject.SetActive(false);
            }
            else
            {
                pbtn3.gameObject.SetActive(true);
            }
            if (num4 == 20)
            {
                pbtn4.gameObject.SetActive(false);
            }
            else if (!(EP == 0))
            {
                pbtn4.gameObject.SetActive(true);
            }
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
        shopBtn_snd = true;
        num1++;
        shop1.text = "사과\n\n\nHP MP\n\n\nLV : " + num1;
        EP--;
        GameObject.Find("GameManager").GetComponent<GameManager>().MaxHp += 0.5f;
        if(num1 == 5 || num1 == 10 || num1 == 15 || num1 == 20)
        {
            upgrade1++;
            if( 5 * upgrade1 == num1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().MaxMp += 1f;
            }
        }
    }
    public void ShopMinus1()
    {
        shopBtn_snd = true;
        num1--;
        shop1.text = "사과\n\n\nHP MP\n\n\nLV : " + num1;
        EP++;
        GameObject.Find("GameManager").GetComponent<GameManager>().MaxHp -= 0.5f;
        if (num1 == 4 || num1 == 9 || num1 == 14 || num1 == 19)
        {
            if(5 * upgrade1 > num1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().MaxMp -= 1f;
                upgrade1--;
            }
        }
    }

    public void ShopPlus2()
    {
        shopBtn_snd = true;
        num2++;
        shop2.text = "황금코인\n\n\n쿨타임\n\n\nLV : " + num2;
        EP--;
        GameObject.Find("GameManager").GetComponent<GameManager>().skillMaxTime -= 0.1f;
        if(num2 == 5 || num2 == 10 || num2 == 15 || num2 == 20)
        {
            upgrade2++;
            if (upgrade2 == 1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().skillMaxTime -= 0.5f;
            }
            if (upgrade2 == 2)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().skillMaxTime -= 0.5f;
                //"회복 이 외의 코인 효과 추가"로 생각중. 예로 3단점프, 2단구르기, 추가타, 강화반격 등
            }
            if (upgrade2 == 3)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().skillMaxTime -= 1f;
            }
            if (upgrade2 == 4)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().skillMaxTime -= 1f;
                GameObject.Find("GameManager").GetComponent<GameManager>().maxStack = 5;
            }
        }
    }
    public void ShopMinus2()
    {
        shopBtn_snd = true;
        num2--;
        shop2.text = "황금코인\n\n\n쿨타임\n\n\nLV : " + num2;
        EP++;
        GameObject.Find("GameManager").GetComponent<GameManager>().skillMaxTime += 0.1f;
        if(num2 == 4 || num2 == 9 || num2 == 14 || num2 == 19)
        {
            if(upgrade2 == 1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().skillMaxTime += 0.5f;
            }
            if(upgrade2 == 2)
            {

            }
            if(upgrade2 == 3)
            {

            }
            if(upgrade2 == 4)
            {

            }
            upgrade2--;
        }
    }

    public void ShopPlus3()
    {
        shopBtn_snd = true;
        num3++;
        shop3.text = "방패\n\n\n반격기\n\n\nLV : " + num3;
        EP--;
    }
    public void ShopMinus3()
    {
        shopBtn_snd = true;
        num3--;
        shop3.text = "방패\n\n\n반격기\n\n\nLV : " + num3;
        EP++;
    }

    public void ShopPlus4()
    {
        shopBtn_snd = true;
        num4++;
        shop4.text = "마력석\n\n\n타워\n\n\nLV : " + num4;
        EP--;
    }
    public void ShopMinus4()
    {
        shopBtn_snd = true;
        num4--;
        shop4.text = "마력석\n\n\n타워\n\n\nLV : " + num4;
        EP++;
    }
}
