using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Set;
    public GameObject SetInside;

    public int MaxHp = 5;
    public int MaxMp = 2;
    public static int hp;
    public static float mana;
    public float manaTime = 0f;

    public float skillTime;
    public float nowSkill = 0f;
    public float skillMaxTime = 1f;
    bool skillUse = false;

    public Slider healthBar;
    public Slider manaBar;
    public Slider skillCool;

    public float hpPer;
    public float car;
    public float fs;


    void Awake()
    {
        mana = MaxMp;
        hp = MaxHp;
        hpPer = ((float)hp / MaxHp) * 100;
        fs = (1 / Time.deltaTime);
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
        //healthBar.value = (float)hp / MaxHp;
        manaBar.value = (float)mana / MaxMp;
        skillCool.value = (float)nowSkill / skillMaxTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Set.gameObject.SetActive(true);
        }

        //hp effect
        if ((float)hp / MaxHp * 100 < hpPer)
        {
            car = ((healthBar.value - ((float)hp / MaxHp)) / fs);
            hpPer = (float)hp / MaxHp * 100;
        }
        if (hpPer < healthBar.value * 100)
        {
            healthBar.value -= car;
        }


        //Mana
        if (!(mana >= MaxMp))
        {
            mana += (Time.deltaTime / 3);
        }
        else
        {
            mana = MaxMp;
        }

        //Skill CoolTime
        if(Input.GetKeyDown(KeyCode.X) && skillUse == true && mana > 1)
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
