using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    public GameObject key;
    public float playTime = 0f;
    public bool fiveSecAfterHide = false;
    public float keyTime = 0f;
    public float hideKey = 0f;
    public bool hide = true;
    int n = 1;
    public static bool keyGet = false;
    */
    public GameObject Shop;
    public GameObject Set;
    public GameObject SetInside;

    public int MaxHp = 5;
    public int MaxMp = 2;
    public static int hp;
    public static int mana;
    public float manaTime = 0f;
    bool manaHeal = false;
    bool healing = false;

    public float skillTime;
    public float nowSkill = 0f;
    public float skillMaxTime = 1f;
    bool skillUse = false;

    public Slider healthBar;
    public Slider manaBar;
    public Slider skillCool;


    void Awake()
    {
        mana = MaxMp;
        hp = MaxHp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manaTime += Time.deltaTime;
        skillTime += Time.deltaTime;

        //Slider(Health/Mana Bar / SkillCool)
        healthBar.value = (float)hp / MaxHp;
        manaBar.value = (float)mana / MaxMp;
        skillCool.value = (float)nowSkill / skillMaxTime;

        /*
        playTime += Time.deltaTime;
        keyTime += Time.deltaTime;

        //Ver. keyTime
        if (keyTime >= 5f * n && key.activeSelf == false && fiveSecAfterHide == true && keyGet == false)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-2f, 2f);
            key.transform.position = new Vector3(x, y);
            key.SetActive(true);
            hide = false;
        }

        if(hide == false)
        {
            hideKey += Time.deltaTime;
        }

        if(hideKey >= 2f)
        {
            key.SetActive(false);
            hideKey = 0f;
            hide = true;
            keyTime = 0f;
        }

        //Ver.playTime
        if(playTime >= 5f * n && key.activeSelf == false && fiveSecAfterHide == false && keyGet == false)
        {
            n++;
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-2f, 2f);
            key.transform.position = new Vector3(x, y);
            key.SetActive(true);
            hide = false;
        }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Set.gameObject.SetActive(true);
        }

        //Mana
        if (!(MaxMp == mana))
        {
            manaHeal = true;
        }
        if (manaHeal == true && healing == false)
        {
            manaTime = 0f;
            healing = true;
        }
        if (healing == true && manaTime >= 3f && !(mana == MaxMp))
        {
            mana++;
            healing = false;
        }
        if (mana == MaxMp)
        {
            healing = false;
            manaHeal = false;
        }

        //Skill CoolTime
        if(Input.GetKeyDown(KeyCode.X) && skillUse == true)
        {
            nowSkill = skillMaxTime;
            skillTime = 0f;
            skillUse = false;
            mana--;
        }

        if (skillUse == false)
        {
            nowSkill = (skillMaxTime - skillTime);
        }
        if (nowSkill <= 0)
        {
            skillUse = true;
        }
    }

    //SceneManagement
    public void ShoppingEnd()
    {
        Shop.gameObject.SetActive(false);
    }

    public void SettingEnd()
    {
        Set.gameObject.SetActive(false);
    }

    public void SetInsideStart()
    {
        SetInside.gameObject.SetActive(true);
    }
    public void SetInsideEnd()
    {
        SetInside.gameObject.SetActive(false);
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
