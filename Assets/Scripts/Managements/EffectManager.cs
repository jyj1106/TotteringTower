using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void CoinSpin()
    {
        GameObject.Find("HeroKnight").transform.Find("Coin").GetComponent<Animator>().SetTrigger("Spinning");
    }
    void CoinHide()
    {
        GameObject.Find("HeroKnight").transform.Find("Coin").gameObject.SetActive(false);
    }
    void EffectEnd()
    {
        GameObject.Find("HeroKnight").GetComponent<HeroKnight>().attackable = true;
        Destroy(this.gameObject);
    }
    
    void LightOn()
    {
        transform.Find("Point Light 2D").gameObject.transform.Translate(0f, 0.517f, 0f);
        transform.Find("Point Light 2D").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().pointLightOuterRadius = 2;

    }
    void LightOff()
    {
        transform.Find("Point Light 2D").gameObject.transform.Translate(0f, -0.517f, 0f);
        transform.Find("Point Light 2D").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().pointLightOuterRadius = 1;
    }
}
