using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    public GameObject shop;

    private bool shoppable = false;

    // Start is called before the first frame update
    void Start()
    {
        shoppable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && shoppable == true)
        {
            shop.gameObject.SetActive(true);
            Time.timeScale = 0.25f;
            GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0.25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shoppable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shoppable = false;
    }
}
