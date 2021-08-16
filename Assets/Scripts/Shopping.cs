using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shop.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0.25f;
    }
}
