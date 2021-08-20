using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject set;
    public GameObject Load;

    private AudioSource titleAudio;
    private float loadTime;
    private bool loadStart;

    // Start is called before the first frame update
    void Start()
    {
        loadStart = false;
        Load.SetActive(false);
        titleAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        loadTime += Time.deltaTime;

        if(loadStart == true)
        {
            if(loadTime >= 1f)
            {
                loadTime = 1f;
            }
            Load.GetComponent<Image>().color = new Color(1f, 1f, 1f, loadTime);
            titleAudio.volume = 1 - loadTime;
        }
    }

    public void StartOn()
    {
        loadTime = 0f;
        loadStart = true;
        Invoke("GoPlay", 1.1f);
        Load.SetActive(true);
    }

    public void GoPlay()
    {
        SceneManager.LoadScene("Play");
    }

    public void SettingOn()
    {
        set.gameObject.SetActive(true);
    }
    public void SettingOff()
    {
        set.gameObject.SetActive(false);
    }

    public void GameOff()
    {
        Application.Quit();
    }
}
