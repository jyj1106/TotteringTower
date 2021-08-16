using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTitle : MonoBehaviour
{
    private float a, amount;
    private bool available = false;

    public GameObject Title, start, setting, quit;
    public float spd = 1f;
    public float plus = 0.003f;

    // Start is called before the first frame update
    void Start()
    {
        amount = 0f;
        a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime * spd;
        if(amount > 1f)
        {
            amount = 1f;
        }
        if (available == true && a < 2f && amount <= 1f)
        {
            amount += plus;
            Title.GetComponent<Image>().color = new Color(1f, 1f, 1f, amount);
            start.GetComponent<Text>().color = new Color(0.19f, 0.19f, 0.19f, amount);
            setting.GetComponent<Text>().color = new Color(0.19f, 0.19f, 0.19f, amount);
            quit.GetComponent<Text>().color = new Color(0.19f, 0.19f, 0.19f, amount);
        }
    }

    void TitleStart()
    {
        a = 0;
        available = true;
    }
}
