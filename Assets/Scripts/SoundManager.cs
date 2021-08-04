using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource sndManager;

    public AudioClip bgm1;
    public AudioClip slash_snd, slashHit_snd;


    // Start is called before the first frame update
    void Start()
    {
        sndManager = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SlashSnd()
    {
        if (HeroKnight.isSlash == true && PAttack.isHit == true)
        {
            sndManager.PlayOneShot(slashHit_snd);
            PAttack.isHit = false;
        }
        else if (HeroKnight.isSlash == true && PAttack.isHit == false)
        {
            sndManager.PlayOneShot(slash_snd);
            PAttack.isHit = false;
        }
        HeroKnight.isSlash = false;
    }
}
