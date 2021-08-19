using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sndManager;
    private AudioSource sndManager2;
    private AudioSource sndManager3;

    public AudioClip[] bgm = new AudioClip[2];
    public AudioClip slash_snd, slashHit1_snd, slashHit2_snd;
    public AudioClip block0_snd, block1_snd, block2_snd, block3_snd, block4_snd, blockEffect_snd;
    public AudioClip coin_snd;
    public AudioClip shop_btn;
    public AudioClip monsterHit_snd, playerHit_snd, towerHit_snd;
    public AudioClip battleStart_snd;

    public int once = 0;
    public bool battleSnd = false;

    // Start is called before the first frame update
    void Start()
    {
        sndManager = this.GetComponent<AudioSource>();
        sndManager2 = transform.Find("Audio0.5x").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shop Button Sound
        if (Shop.shopBtn_snd == true)
        {
            sndManager.PlayOneShot(shop_btn);
            Shop.shopBtn_snd = false;
        }

        //HeroKnight Block Sound
        if(HeroKnight.isblock == true)
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
                sndManager2.PlayOneShot(block4_snd);
            }
            sndManager.PlayOneShot(monsterHit_snd);
            HeroKnight.isblock = false;
        }

        //GameManager Coin Use Sound
        if (GameManager.coinSound == true)
        {
            sndManager.PlayOneShot(coin_snd);
            GameManager.coinSound = false;
        }

        //HeroKnight Hit Sound
        if(GameObject.Find("HeroKnight").GetComponent<HeroKnight>().hurt_snd == true)
        {
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().hurt_snd = false;
            sndManager.PlayOneShot(playerHit_snd);
        }

        //Tower Hit Sound
        if(GameObject.Find("Tower").GetComponent<Tower>().towerSound == true)
        {
            GameObject.Find("Tower").GetComponent<Tower>().towerSound = false;
            sndManager.PlayOneShot(towerHit_snd);
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
            //GameObject.Find("Managements").transform.Find("StageManager").GetComponent<StageManager>().stagenum
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
