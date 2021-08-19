using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sndManager;
    private AudioSource sndManager1;
    private AudioSource sndManager2;
    private AudioSource sndManager3;

    public AudioClip[] bgm = new AudioClip[2];
    public AudioClip slash_snd, slashHit1_snd, slashHit2_snd;
    public AudioClip block0_snd, block1_snd, block2_snd, block3_snd, block4_snd, blockEffect_snd;
    public AudioClip walk1_snd, walk2_snd, jump_snd, roll_snd;
    public AudioClip coin_snd;
    public AudioClip shop_btn, shopOpen_snd;
    public AudioClip monsterHit_snd, playerHit_snd, playerDead_snd, towerHit_snd;
    public AudioClip battleStart_snd;

    public int once = 0;
    public bool battleSnd = false;

    // Start is called before the first frame update
    void Start()
    {
        sndManager = this.GetComponent<AudioSource>();
        sndManager1 = transform.Find("Audio_1x").GetComponent<AudioSource>();
        sndManager2 = transform.Find("Audio_0.75x").GetComponent<AudioSource>();
        sndManager3 = transform.Find("Audio_0.5x").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shop Sounds
        if (Shop.shopBtn_snd == true)
        {
            sndManager.PlayOneShot(shop_btn);
            Shop.shopBtn_snd = false;
        }
        if(GameObject.Find("Managements").transform.Find("Objects").Find("ETCSpot").Find("Chest1").GetComponent<Shopping>().shopOpen == true)
        {
            GameObject.Find("Managements").transform.Find("Objects").Find("ETCSpot").Find("Chest1").GetComponent<Shopping>().shopOpen = false;
            sndManager1.PlayOneShot(shopOpen_snd);
        }

        //GameManager Coin Use Sound
        if (GameManager.coinSound == true)
        {
            sndManager.PlayOneShot(coin_snd);
            GameManager.coinSound = false;
        }

        //HeroKnight Walk Sound

        //HeroKnight Jump Sound
        if (GameObject.Find("HeroKnight").GetComponent<HeroKnight>().jumpSound == true)
        {
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().jumpSound = false;
            sndManager.PlayOneShot(jump_snd);
        }

        //HeroKinght Rolling Sound
        if (GameObject.Find("HeroKnight").GetComponent<HeroKnight>().rollSound == true)
        {
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().rollSound = false;
            sndManager.PlayOneShot(roll_snd);
        }

        //HeroKnight Blocking Sound
        if (HeroKnight.isblock == true)
        {
            if(Shop.num3 < 5)
            {
                sndManager.PlayOneShot(block0_snd);
            }
            else if(Shop.num3 >= 5 && Shop.num3 < 10)
            {
                sndManager.PlayOneShot(block1_snd);
            }
            else if(Shop.num3 < 15)
            {
                sndManager.PlayOneShot(block2_snd);
            }
            else if(Shop.num3 < 20)
            {
                sndManager.PlayOneShot(block3_snd);
            }
            else if(Shop.num3 == 20)
            {
                sndManager3.PlayOneShot(block4_snd);
            }
            sndManager.PlayOneShot(monsterHit_snd);
            HeroKnight.isblock = false;
        }

        //HeroKnight Hit Sound
        if(GameObject.Find("HeroKnight").GetComponent<HeroKnight>().hurt_snd == true)
        {
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().hurt_snd = false;
            sndManager.PlayOneShot(playerHit_snd);
        }
        else if(GameObject.Find("HeroKnight").GetComponent<HeroKnight>().dead_snd == true)
        {
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().dead_snd = false;
            sndManager2.PlayOneShot(playerDead_snd);
        }
              
        //Tower Hit Sound
        if(GameObject.Find("Tower").GetComponent<Tower>().towerSound == true)
        {
            GameObject.Find("Tower").GetComponent<Tower>().towerSound = false;
            sndManager3.PlayOneShot(towerHit_snd);
        }

        //Monster Hit by Shield Blocking Sound
        if(GameObject.Find("HeroKnight").GetComponent<HeroKnight>().monHitSound == true)
        {
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().monHitSound = false;
            sndManager.PlayOneShot(monsterHit_snd);
            sndManager3.PlayOneShot(blockEffect_snd);
        }

        //Setting BGM
        if(GameObject.Find("Managements").transform.Find("StageManager").GetComponent<StageManager>().rest == true)
        {
            if(once == 0)
            {
                sndManager.Stop();
                sndManager.clip = bgm[0];
                sndManager.loop = true;
                sndManager.Play();
                once++;
            }
        }
        else
        {
            if(once == 0)
            {
                sndManager.Stop();
                sndManager.clip = bgm[1];
                sndManager.loop = true;
                sndManager.Play();
                once++;
            }
        }

        //Battle Start Snd
        if(battleSnd == true)
        {
            battleSnd = false;
            sndManager.Stop();
            sndManager.PlayOneShot(battleStart_snd);
        }
    }

    public void SlashSnd()
    {
        if (HeroKnight.isSlash == true && HeroKnight.isHit == true)
        {
            if(GameManager.lvUp == 1)
            {
                sndManager.PlayOneShot(slashHit1_snd);
            }
            else if(GameManager.lvUp == 2)
            {
                sndManager.PlayOneShot(slashHit2_snd);
            }
            sndManager.PlayOneShot(monsterHit_snd);
        }
        else if (HeroKnight.isSlash == true && HeroKnight.isHit == false)
        {
            sndManager.PlayOneShot(slash_snd);
        }
        HeroKnight.isSlash = false;
        HeroKnight.isHit = false;
    }
}
