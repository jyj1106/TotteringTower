using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    public GameObject chest;
    public GameObject shop;
    public static GameObject chestmake;

    // Start is called before the first frame update
    void Start()
    {
        chestmake = chest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shop.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
