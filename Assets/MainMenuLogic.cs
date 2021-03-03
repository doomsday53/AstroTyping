using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject credits_Screen;
    public GameObject options_Menu;
    public AudioSource menuAudio;
    // Start is called before the first frame update
    void Start()
    {
        CloseCredits();
        CloseOptions();
        menuAudio = GameObject.FindObjectOfType<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCredits()
    {
        credits_Screen.SetActive(true);
    }

    public void CloseCredits()
    {
        credits_Screen.SetActive(false);
    }
    public void CloseOptions()
    {
        options_Menu.SetActive(false);
    }

    public void OpenOptions()
    {
        options_Menu.SetActive(true);
    }
}
