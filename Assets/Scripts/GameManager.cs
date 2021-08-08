using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Shopping;
    public GameObject Set;
    public GameObject SetInside;

    public Slider healthBar;
    public Slider manaBar;
    public Slider skillCool;

    public float MaxHp = 5;
    public float MaxMp = 5;
    public float skillMaxTime = 1f;
    public static float hp;
    public static int lvUp = 1;
    public static float mana;
    public static bool coinSound, coinUse, coinEnd = false;

    float skillTime, coinTime, nowSkill, hpPer, car, fs;
    bool skillUsable, coolStart, coolActive = false;

    int zero, stack = 0;

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
        skillUsable = true;
    }

    // Update is called once per frame
    void Update()
    {
        skillTime += Time.deltaTime;
        coinTime += Time.deltaTime;

        //Slider(Health/Mana Bar / SkillCool)
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
        if(hpPer >= healthBar.value * 100)
        {
            healthBar.value = hpPer / 100;
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

        //Coin Skill
        if (Input.GetKey(KeyCode.X) && skillUsable == true && mana > 1 && coolActive == false)
        {
            coinUse = true;
            if (zero == 0)
            {
                coinSound = true;
                coinTime = 0f;
            }
            zero++;
            if ((int)coinTime == 1f * stack && mana >= 1)
            {
                Debug.Log(mana);
                mana--;
                stack++;
                if (stack == 10)
                {
                    lvUp++;
                    coinEnd = true;
                }
            }
            else if((int)coinTime == 1f * stack && mana < 1)
            {
                coinEnd = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.X) && coinEnd == false && coolActive == false)
        {
            hp++;
            if (hp >= MaxHp)
            {
                hp = MaxHp;
            }
            coinUse = false;
            SkillCool();
            coolActive = true;
            zero = 0;
            stack = 0;
        }
        else if (coinEnd == true && coolActive == false)
        {
            coinUse = false;
            SkillCool();
            coolActive = true;
            zero = 0;
            stack = 0;
        }

        //CoolTime
        if(coolActive == true)
        {
            if (skillUsable == false)
            {
                nowSkill = (skillMaxTime - skillTime);
            }
            if (nowSkill <= 0)
            {
                skillUsable = true;
                coolActive = false;
            }
        }
    }

    //SceneManagement
    public void ShoppingEnd()
    {
        Shopping.gameObject.SetActive(false);
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
    
    //Skill CoolTime
    public void SkillCool()
    {
        nowSkill = skillMaxTime;
        skillTime = 0f;
        skillUsable = false;
        coolActive = true;
    }
}
