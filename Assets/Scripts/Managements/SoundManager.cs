using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource sndManager;
    private AudioSource sndManager2;

    public AudioClip[] bgm = new AudioClip[2];
    public AudioClip slash_snd, slashHit_snd;
    public AudioClip block1_snd, block2_snd, block3_snd, block4_snd;
    public AudioClip coin_snd;
    public AudioClip shop_btn;
    public AudioClip ShieldHit_snd;
    public AudioClip playerHit_snd;

    public int once = 0;

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
            if(Shop.num3 >= 5 && Shop.num3 < 10)
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
                sndManager.PlayOneShot(block4_snd);
            }
            sndManager2.PlayOneShot(ShieldHit_snd);
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
    }

    public void SlashSnd()
    {
        if (HeroKnight.isSlash == true && HeroKnight.isHit == true)
        {
            sndManager.PlayOneShot(slashHit_snd);
        }
        else if (HeroKnight.isSlash == true && HeroKnight.isHit == false)
        {
            sndManager.PlayOneShot(slash_snd);
        }
        HeroKnight.isSlash = false;
        HeroKnight.isHit = false;
    }
}
