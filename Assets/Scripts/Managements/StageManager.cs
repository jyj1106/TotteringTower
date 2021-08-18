using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject Tower, Player;
    [SerializeField] GameObject Shop, LoadingText;

    [SerializeField] GameObject[] MSpawnLand = new GameObject[2];
    [SerializeField] GameObject[] MSpawnSky = new GameObject[2];
    [SerializeField] GameObject[] BG = new GameObject[3];

    [SerializeField] GameObject[] BMon0 = new GameObject[10];
    [SerializeField] GameObject[] BMon1 = new GameObject[10];
    [SerializeField] GameObject[] BMon2 = new GameObject[10];
    [SerializeField] GameObject[] BMon3 = new GameObject[3];
    [SerializeField] GameObject[] BMon4 = new GameObject[3];

    [SerializeField] GameObject[] WMon0 = new GameObject[3];
    [SerializeField] GameObject[] WMon1 = new GameObject[3];
    [SerializeField] GameObject[] WMon2 = new GameObject[3];
    [SerializeField] GameObject[] WMon3 = new GameObject[3];
    [SerializeField] GameObject[] WMon4 = new GameObject[3];
    [SerializeField] GameObject[] WMon5 = new GameObject[3];
    [SerializeField] GameObject[] WMon6 = new GameObject[3];
    [SerializeField] GameObject[] WMon7 = new GameObject[10];
    [SerializeField] GameObject[] WMon8 = new GameObject[10];
    [SerializeField] GameObject[] WMon9 = new GameObject[3];

    [SerializeField] int maxKillCount;
    [SerializeField] float stageTime;

    public bool[] Stage = new bool[21];
    public bool rest = false;
    public int nowKillCount;
    public int stagenum = 0;
    public int THp;

    private GameObject BM0, BM1, BM2, BM3, BM4;
    private GameObject WM0, WM1, WM2, WM3, WM4, WM5, WM6, WM7, WM8, WM9;

    private bool[] bBM0 = new bool[10];
    private bool[] bBM1 = new bool[10];
    private bool[] bBM2 = new bool[10];
    private bool[] wWM7 = new bool[10];
    private bool[] wWM8 = new bool[10];
    private bool nowLoad, loadEnd, stageEnd = false;
    private int n, ran;
    private float endTime;
    private float loadColor, monAllDead = 0f;

    int a, tcheck = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Counting Time
        stageTime += Time.deltaTime;
        endTime += Time.deltaTime;
        loadColor += Time.deltaTime;

        //Random Spawn
        ran = (int)Random.Range(0f, 1.99999f);

        //Set Active
        if (BMon0[0].activeSelf == true)
        {
            if (BMon0[1].activeSelf == true)
            {
                if (BMon0[2].activeSelf == true)
                {
                    if (BMon0[3].activeSelf == true)
                    {
                        if (BMon0[4].activeSelf == true)
                        {
                            if (BMon0[5].activeSelf == true)
                            {
                                if (BMon0[6].activeSelf == true)
                                {
                                    if (BMon0[7].activeSelf == true)
                                    {
                                        if (BMon0[8].activeSelf == true)
                                        {
                                            BM0 = BMon0[9];
                                        }
                                        else
                                        {
                                            BM0 = BMon0[8];
                                        }
                                    }
                                    else
                                    {
                                        BM0 = BMon0[7];
                                    }
                                }
                                else
                                {
                                    BM0 = BMon0[6];
                                }
                            }
                            else
                            {
                                BM0 = BMon0[5];
                            }
                        }
                        else
                        {
                            BM0 = BMon0[4];
                        }
                    }
                    else
                    {
                        BM0 = BMon0[3];
                    }
                }
                else
                {
                    BM0 = BMon0[2];
                }
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
                if (BMon1[2].activeSelf == true)
                {
                    if (BMon1[3].activeSelf == true)
                    {
                        if (BMon1[4].activeSelf == true)
                        {
                            if (BMon1[5].activeSelf == true)
                            {
                                if (BMon1[6].activeSelf == true)
                                {
                                    if (BMon1[7].activeSelf == true)
                                    {
                                        if (BMon1[8].activeSelf == true)
                                        {
                                            BM1 = BMon1[9];
                                        }
                                        else
                                        {
                                            BM1 = BMon1[8];
                                        }
                                    }
                                    else
                                    {
                                        BM1 = BMon1[7];
                                    }
                                }
                                else
                                {
                                    BM1 = BMon1[6];
                                }
                            }
                            else
                            {
                                BM1 = BMon1[5];
                            }
                        }
                        else
                        {
                            BM1 = BMon1[4];
                        }
                    }
                    else
                    {
                        BM1 = BMon1[3];
                    }
                }
                else
                {
                    BM1 = BMon1[2];
                }
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
                if (BMon2[2].activeSelf == true)
                {
                    if (BMon2[3].activeSelf == true)
                    {
                        if (BMon2[4].activeSelf == true)
                        {
                            if (BMon2[5].activeSelf == true)
                            {
                                if (BMon2[6].activeSelf == true)
                                {
                                    if (BMon2[7].activeSelf == true)
                                    {
                                        if (BMon2[8].activeSelf == true)
                                        {
                                            BM2 = BMon2[9];
                                        }
                                        else
                                        {
                                            BM2 = BMon2[8];
                                        }
                                    }
                                    else
                                    {
                                        BM2 = BMon2[7];
                                    }
                                }
                                else
                                {
                                    BM2 = BMon2[6];
                                }
                            }
                            else
                            {
                                BM2 = BMon2[5];
                            }
                        }
                        else
                        {
                            BM2 = BMon2[4];
                        }
                    }
                    else
                    {
                        BM2 = BMon2[3];
                    }
                }
                else
                {
                    BM2 = BMon2[2];
                }
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
                if (WMon7[2].activeSelf == true)
                {
                    if (WMon7[3].activeSelf == true)
                    {
                        if (WMon7[4].activeSelf == true)
                        {
                            if (WMon7[5].activeSelf == true)
                            {
                                if (WMon7[6].activeSelf == true)
                                {
                                    if (WMon7[7].activeSelf == true)
                                    {
                                        if (WMon7[8].activeSelf == true)
                                        {
                                            WM7 = WMon7[9];
                                        }
                                        else
                                        {
                                            WM7 = WMon7[8];
                                        }
                                    }
                                    else
                                    {
                                        WM7 = WMon7[7];
                                    }
                                }
                                else
                                {
                                    WM7 = WMon7[6];
                                }
                            }
                            else
                            {
                                WM7 = WMon7[5];
                            }
                        }
                        else
                        {
                            WM7 = WMon7[4];
                        }
                    }
                    else
                    {
                        WM7 = WMon7[3];
                    }
                }
                else
                {
                    WM7 = WMon7[2];
                }
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
                if (WMon8[2].activeSelf == true)
                {
                    if (WMon8[3].activeSelf == true)
                    {
                        if (WMon8[4].activeSelf == true)
                        {
                            if (WMon8[5].activeSelf == true)
                            {
                                if (WMon8[6].activeSelf == true)
                                {
                                    if (WMon8[7].activeSelf == true)
                                    {
                                        if (WMon8[8].activeSelf == true)
                                        {
                                            WM8 = WMon8[9];
                                        }
                                        else
                                        {
                                            WM8 = WMon8[8];
                                        }
                                    }
                                    else
                                    {
                                        WM8 = WMon8[7];
                                    }
                                }
                                else
                                {
                                    WM8 = WMon8[6];
                                }
                            }
                            else
                            {
                                WM8 = WMon8[5];
                            }
                        }
                        else
                        {
                            WM8 = WMon8[4];
                        }
                    }
                    else
                    {
                        WM8 = WMon8[3];
                    }
                }
                else
                {
                    WM8 = WMon8[2];
                }
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
            rest = false;
            if(tcheck == 0)
            {
                a = 0;
                tcheck++;
                THp = Tower.GetComponent<Tower>().TowerHP;
            }
            if (stageTime >= 7f * n && stageTime < 36f)
            {
                n++;                
                BM0.transform.parent = null;
                BM0.transform.position = MSpawnLand[ran].transform.position;
                BM0.gameObject.SetActive(true);
            }
            else if(stageTime >= 7f * n && stageTime > 48f && !(nowKillCount >= maxKillCount))
            {
                n++;
                BM1.transform.parent = null;
                BM1.transform.position = MSpawnLand[ran].transform.position;
                BM1.gameObject.SetActive(true);
            }
            else if(nowKillCount >= maxKillCount && a == 0)
            {
                monAllDead = 0;
                for(int i = 0; i < BMon0.Length; i++)
                {
                    if(BMon0[i].activeSelf == true)
                    {
                        monAllDead++;
                    }
                    if (BMon1[i].activeSelf == true)
                    {
                        monAllDead++;
                    }
                }
                if(monAllDead == 0)
                {
                    if (a == 0)
                    {
                        a++;
                        NowLoading();
                        Invoke("StageClear", 1f);
                    }
                }
            }
        }
        else if (Stage[1] == true)
        {
            rest = false;
            if (tcheck == 0)
            {
                a = 0;
                tcheck++;
                THp = Tower.GetComponent<Tower>().TowerHP;
            }
            if (stageTime >= 5f * n && !(nowKillCount >= maxKillCount))
            {
                WM8.transform.parent = null;
                WM8.transform.position = MSpawnLand[ran].transform.position;
                WM8.gameObject.SetActive(true);
            }
            if (stageTime >= 10 * n && !(nowKillCount >= maxKillCount))
            {
                WM7.transform.parent = null;
                WM7.transform.position = MSpawnLand[ran].transform.position;
                WM7.gameObject.SetActive(true);
                n++;
            }
            else if (nowKillCount >= maxKillCount && a == 0)
            {
                monAllDead = 0;
                for (int i = 0; i < WMon8.Length; i++)
                {
                    if (WMon7[i].activeSelf == true)
                    {
                        monAllDead++;
                    }
                    if (WMon8[i].activeSelf == true)
                    {
                        monAllDead++;
                    }
                }
                if (monAllDead == 0)
                {
                    if (a == 0)
                    {
                        a++;
                        NowLoading();
                        Invoke("StageClear", 1f);
                    }
                }
            }
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
        else
        {
            rest = true;
        }
        
        //Rest
        if(rest == true)
        {
            Time.timeScale = 1f;
            Shop.transform.position = new Vector3(2.42f, -3.09f, 0f);
            Shop.gameObject.SetActive(true);
            if (stagenum % 3 == 0) //morning
            {
                BG[0].transform.position = new Vector3(0f, 0f, 0f);
                BG[0].gameObject.SetActive(true);
            }
            else if(stagenum % 3 == 1) //afternoon
            {
                BG[1].transform.position = new Vector3(0f, 0f, 0f);
                BG[1].gameObject.SetActive(true);
            }
            else if(stagenum % 3 == 2) //night
            {
                BG[2].transform.position = new Vector3(0f, 0f, 0f);
                BG[2].gameObject.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Find("Managements").transform.Find("SoundManager").GetComponent<SoundManager>().battleSnd = true;
                NowLoading();
            }
        }

        //Loading Effect
        if (nowLoad == true && loadEnd == false) //NowLoading()
        {
            Player.GetComponent<HeroKnight>().Inputtable = false;
            GameObject.Find("Canvas").transform.Find("Loading_Img").GetComponent<Image>().color = new Color(1f, 1f, 1f, loadColor);
            if (loadColor >= 1f)
            {
                loadColor = 1f;
                nowLoad = false;
                LoadingText.SetActive(true);
            }
        }
        if (LoadingText.activeSelf == true && nowLoad == false && loadEnd == false)
        {
            loadEnd = true;
            Invoke("LoadFinish", 1.5f);
            GameManager.hp = GameObject.Find("Managements").transform.Find("GameManager").GetComponent<GameManager>().MaxHp;
            GameManager.mana = GameObject.Find("Managements").transform.Find("GameManager").GetComponent<GameManager>().MaxMp;

            if (stageEnd == false)
            {
                if(Tower.GetComponent<Tower>().TCollapse == true)
                {
                    Tower.GetComponent<Tower>().TCollapse = false;
                    Tower.GetComponent<Tower>().TowerHP = THp;
                    Tower.transform.position = new Vector3(0f, -0.2091f, 0f);
                    if (!(THp <= 0) && THp > 14)
                    {
                        Tower.GetComponent<Animator>().SetTrigger("isIdle_100");
                    }
                    else if (!(THp <= 0) && THp <= 14 && THp > 7)
                    {
                        Tower.GetComponent<Animator>().SetTrigger("isIdle_60");
                    }
                    else if (!(THp <= 0) && THp <= 7 && THp > 0)
                    {
                        Tower.GetComponent<Animator>().SetTrigger("isIdle_30");
                    }

                    Player.GetComponent<HeroKnight>().m_dead = false;
                    Player.transform.position = new Vector3(0f, -2f, 0f);

                    for (int i = 0; i < BMon0.Length; i++)
                    {
                        BMon0[i].SetActive(false);
                        BMon1[i].SetActive(false);
                        BMon2[i].SetActive(false);
                        WMon7[i].SetActive(false);
                        WMon8[i].SetActive(false);
                    }

                    Stage[stagenum] = false;
                }
                else
                {
                    Stage[stagenum] = true;
                    rest = false;
                    StageSettings();
                }
            }
            else if(stageEnd == true)
            {
                stageEnd = false;
                GameObject.Find("Managements").transform.Find("SoundManager").GetComponent<SoundManager>().sndManager.Stop();
            }
        }
        if (loadEnd == true && nowLoad == false && LoadingText.activeSelf == false)
        {
            GameObject.Find("Canvas").transform.Find("Loading_Img").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1 - loadColor);
            if(loadColor >= 1f)
            {
                loadColor = 1f;
                loadEnd = false;
            }
        }
    }

    void StageSettings()
    {
        //Set default values
        Player.transform.position = new Vector3(0f, -2f, 0f);
        Tower.transform.position = new Vector3(0f, -0.2091f, 0f);
        Shop.transform.position = new Vector3(2.42f, -3.09f, 0f);
        Shop.gameObject.SetActive(true);
        n = 0;
        ran = 0;
        GameManager.lvUp = 1;
        GameManager.stack = 1;

        //Initializing Game Field
        if (Stage[0] == true)
        {
            //Set clear limit
            nowKillCount = 0;
            maxKillCount = 10;

            //Set position
            BG[0].transform.position = new Vector3(0f, 0f, 0f);
            BG[0].gameObject.SetActive(true);
        }
        else if (Stage[1] == true)
        {
            //Set clear limit
            nowKillCount = 0;
            maxKillCount = 20;

            //Set position
            BG[1].transform.position = new Vector3(0f, 0f, 0f);
            BG[1].gameObject.SetActive(true);
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

        stageTime = 0f; 
    }

    void StageClear()
    {
        stageEnd = true;
        Stage[stagenum] = false;
        if(stagenum % 3 == 0) //morning
        {
            BG[0].gameObject.SetActive(false);
        }
        else if(stagenum % 3 == 1) //afternoon
        {
            BG[1].gameObject.SetActive(false);
        }
        else if(stagenum % 3 == 2) //night
        {
            BG[2].gameObject.SetActive(false);
        }
        stagenum++;
    }

    public void NowLoading()
    {
        Time.timeScale = 1f;
        loadColor = 0f;
        nowLoad = true;
    }

    void LoadFinish()
    {
        LoadingText.SetActive(false);
        loadColor = 0f;
        ChangeBGM();
        tcheck = 0;
        Player.GetComponent<HeroKnight>().Inputtable = true;
    }

    void ChangeBGM()
    {
        GameObject.Find("Managements").transform.Find("SoundManager").GetComponent<SoundManager>().once = 0;
    }
}
