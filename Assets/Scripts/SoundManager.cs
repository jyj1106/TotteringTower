using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource sndManager;
    private AudioSource sndManager2;

    public AudioClip bgm1;
    public AudioClip slash_snd, slashHit_snd;
    public AudioClip block1_snd, block2_snd, block3_snd, block4_snd;
    public AudioClip coin_snd;
    public AudioClip shop_btn;
    public AudioClip ShieldHit_snd;
    public AudioClip playerHit_snd;


    // Start is called before the first frame update
    void Start()
    {
        sndManager = this.GetComponent<AudioSource>();
        sndManager2 = transform.Find("Audio0.5x").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Shop.shopBtn_snd == true)
        {
            sndManager.PlayOneShot(shop_btn);
            Shop.shopBtn_snd = false;
        }
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
        if (GameManager.coinSound == true)
        {
            sndManager.PlayOneShot(coin_snd);
            GameManager.coinSound = false;
        }
        if(GameObject.Find("HeroKnight").GetComponent<HeroKnight>().hurt_snd == true)
        {
            GameObject.Find("HeroKnight").GetComponent<HeroKnight>().hurt_snd = false;
            sndManager.PlayOneShot(playerHit_snd);
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
