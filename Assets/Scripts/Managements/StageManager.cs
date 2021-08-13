using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject Tower, Player;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject MSpawn1, MSpawn2, MSpawn3, MSpawn4;

    [SerializeField] GameObject[] BG = new GameObject[3];

    [SerializeField] GameObject[] BMon0 = new GameObject[3];
    [SerializeField] GameObject[] BMon1 = new GameObject[3];
    [SerializeField] GameObject[] BMon2 = new GameObject[3];
    [SerializeField] GameObject[] BMon3 = new GameObject[3];
    [SerializeField] GameObject[] BMon4 = new GameObject[3];

    [SerializeField] GameObject[] WMon0 = new GameObject[3];
    [SerializeField] GameObject[] WMon1 = new GameObject[3];
    [SerializeField] GameObject[] WMon2 = new GameObject[3];
    [SerializeField] GameObject[] WMon3 = new GameObject[3];
    [SerializeField] GameObject[] WMon4 = new GameObject[3];
    [SerializeField] GameObject[] WMon5 = new GameObject[3];
    [SerializeField] GameObject[] WMon6 = new GameObject[3];
    [SerializeField] GameObject[] WMon7 = new GameObject[3];
    [SerializeField] GameObject[] WMon8 = new GameObject[3];
    [SerializeField] GameObject[] WMon9 = new GameObject[3];

    [SerializeField] int nowKillCount, maxKillCount;
    [SerializeField] float stageTime;

    public bool[] Stage = new bool[21];

    private GameObject BM0, BM1, BM2, BM3, BM4;
    private GameObject WM0, WM1, WM2, WM3, WM4, WM5, WM6, WM7, WM8, WM9;
    private bool activation = true;
    private int n;

    // Start is called before the first frame update
    void Start()
    {
        //Set default values
        Player.transform.position = new Vector3(0f, -2f, 0f);
        Tower.transform.position = new Vector3(0f, -0.2091f, 0f);
        Shop.transform.position = new Vector3(2.42f, -3.09f, 0f);
        Shop.gameObject.SetActive(true);
        activation = true;
        n = 1;

        //Initializing Game Field
        if (Stage[0] == true)
        {
            //Set clear limit
            nowKillCount = 0;
            maxKillCount = 50;

            //Set position
            BG[0].transform.position = new Vector3(0f, 0f, 0f);
            BG[0].gameObject.SetActive(true);
        }
        else if (Stage[1] == true)
        {

        }
        else if (Stage[2] == true)
        {

        }
        else if (Stage[3] == true)
        {

        }
        else if (Stage[4] == true)
        {

        }
        else if (Stage[5] == true)
        {

        }
        else if (Stage[6] == true)
        {

        }
        else if (Stage[7] == true)
        {

        }
        else if (Stage[8] == true)
        {

        }
        else if (Stage[9] == true)
        {

        }
        else if (Stage[10] == true)
        {

        }
        else if (Stage[11] == true)
        {

        }
        else if (Stage[12] == true)
        {

        }
        else if (Stage[13] == true)
        {

        }
        else if (Stage[14] == true)
        {

        }
        else if (Stage[15] == true)
        {

        }
        else if (Stage[16] == true)
        {

        }
        else if (Stage[17] == true)
        {

        }
        else if (Stage[18] == true)
        {

        }
        else if (Stage[19] == true)
        {

        }
        else if (Stage[20] == true)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Counting Time
        stageTime += Time.deltaTime;

        //Set Active
        if (BMon0[0].activeSelf == true)
        {
            if (BMon0[1].activeSelf == true)
            {
                BM0 = BMon0[2];
            }
            else
            {
                BM0 = BMon0[1];
            }
        }
        else
        {
            BM0 = BMon0[0];
        }
        if (BMon1[0].activeSelf == true)
        {
            if (BMon1[1].activeSelf == true)
            {
                BM1 = BMon1[2];
            }
            else
            {
                BM1 = BMon1[1];
            }
        }
        else
        {
            BM1 = BMon1[0];
        }
        if (BMon2[0].activeSelf == true)
        {
            if (BMon2[1].activeSelf == true)
            {
                BM2 = BMon2[2];
            }
            else
            {
                BM2 = BMon2[1];
            }
        }
        else
        {
            BM2 = BMon2[0];
        }
        if (BMon3[0].activeSelf == true)
        {
            if (BMon3[1].activeSelf == true)
            {
                BM3 = BMon3[2];
            }
            else
            {
                BM3 = BMon3[1];
            }
        }
        else
        {
            BM3 = BMon3[0];
        }
        if (BMon4[0].activeSelf == true)
        {
            if (BMon4[1].activeSelf == true)
            {
                BM4 = BMon4[2];
            }
            else
            {
                BM4 = BMon4[1];
            }
        }
        else
        {
            BM4 = BMon4[0];
        }
        if (WMon0[0].activeSelf == true)
        {
            if (WMon0[1].activeSelf == true)
            {
                WM0 = WMon0[2];
            }
            else
            {
                WM0 = WMon0[1];
            }
        }
        else
        {
            WM0 = WMon0[0];
        }
        if (WMon1[0].activeSelf == true)
        {
            if (WMon1[1].activeSelf == true)
            {
                WM1 = WMon1[2];
            }
            else
            {
                WM1 = WMon1[1];
            }
        }
        else
        {
            WM1 = WMon1[0];
        }
        if (WMon2[0].activeSelf == true)
        {
            if (WMon2[1].activeSelf == true)
            {
                WM2 = WMon2[2];
            }
            else
            {
                WM2 = WMon2[1];
            }
        }
        else
        {
            WM2 = WMon2[0];
        }
        if (WMon3[0].activeSelf == true)
        {
            if (WMon3[1].activeSelf == true)
            {
                WM3 = WMon3[2];
            }
            else
            {
                WM3 = WMon3[1];
            }
        }
        else
        {
            WM3 = WMon3[0];
        }
        if (WMon4[0].activeSelf == true)
        {
            if (WMon4[1].activeSelf == true)
            {
                WM4 = WMon4[2];
            }
            else
            {
                WM4 = WMon4[1];
            }
        }
        else
        {
            WM4 = WMon4[0];
        }
        if (WMon5[0].activeSelf == true)
        {
            if (WMon5[1].activeSelf == true)
            {
                WM5 = WMon5[2];
            }
            else
            {
                WM5 = WMon5[1];
            }
        }
        else
        {
            WM5 = WMon5[0];
        }
        if (WMon6[0].activeSelf == true)
        {
            if (WMon6[1].activeSelf == true)
            {
                WM6 = WMon6[2];
            }
            else
            {
                WM6 = WMon6[1];
            }
        }
        else
        {
            WM6 = WMon6[0];
        }
        if (WMon7[0].activeSelf == true)
        {
            if (WMon7[1].activeSelf == true)
            {
                WM7 = WMon7[2];
            }
            else
            {
                WM7 = WMon7[1];
            }
        }
        else
        {
            WM7 = WMon7[0];
        }
        if (WMon8[0].activeSelf == true)
        {
            if (WMon8[1].activeSelf == true)
            {
                WM8 = WMon8[2];
            }
            else
            {
                WM8 = WMon8[1];
            }
        }
        else
        {
            WM8 = WMon8[0];
        }
        if (WMon9[0].activeSelf == true)
        {
            if (WMon9[1].activeSelf == true)
            {
                WM9 = WMon9[2];
            }
            else
            {
                WM9 = WMon9[1];
            }
        }
        else
        {
            WM9 = WMon9[0];
        }

        //Stage Settings. This is the Main Setting of Stages.
        if (Stage[0] == true)
        {
            if(stageTime >= 3f * n && )
            {
                n++;
                BM0.transform.position = MSpawn1.transform.position;
            }
        }
        else if (Stage[1] == true)
        {

        }
        else if (Stage[2] == true)
        {

        }
        else if (Stage[3] == true)
        {

        }
        else if (Stage[4] == true)
        {

        }
        else if (Stage[5] == true)
        {

        }
        else if (Stage[6] == true)
        {

        }
        else if (Stage[7] == true)
        {

        }
        else if (Stage[8] == true)
        {

        }
        else if (Stage[9] == true)
        {

        }
        else if (Stage[10] == true)
        {

        }
        else if (Stage[11] == true)
        {

        }
        else if (Stage[12] == true)
        {

        }
        else if (Stage[13] == true)
        {

        }
        else if (Stage[14] == true)
        {

        }
        else if (Stage[15] == true)
        {

        }
        else if (Stage[16] == true)
        {

        }
        else if (Stage[17] == true)
        {

        }
        else if (Stage[18] == true)
        {

        }
        else if (Stage[19] == true)
        {

        }
        else if (Stage[20] == true)
        {

        }
    }
}
