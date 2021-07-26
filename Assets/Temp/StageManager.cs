using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject monster;
    public GameObject ground;
    public Transform[] Point = new Transform[5];
    public Text scoretext;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ground);
        int[] check = new int[5];
        int makecount = 0;

        while (true)
        {
            int temp = Random.Range(0, 5);

            if(check[temp] == 0)
            {
                GameObject mon = Instantiate(monster, Point[temp]);
                mon.transform.parent = null;
                mon.transform.name = "Monster";
                check[temp] = 1;
                makecount++;
                if(makecount == 3)
                {
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score : " + score;
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score += value;
        }
    }
}
