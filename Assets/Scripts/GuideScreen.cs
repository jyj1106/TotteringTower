using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScreen : MonoBehaviour
{
    [SerializeField] GameObject guide;

    private bool enter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && enter == true)
        {
            guide.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enter = false;
    }
}
