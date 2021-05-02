using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject credits_Screen;
    public GameObject options_Menu;
    public GameObject results_Screen;
    public AudioSource menuAudio;
    public SaveDataManager saveDataObj;

    public Text genScore;
    public Text curMistakes;
    public Text curStreak;
    public Text wpmScore;
    // Start is called before the first frame update
    void Awake()
    {
        CloseCredits();
        CloseOptions();
        SetResults();
        CloseResults();

        saveDataObj = FindObjectOfType<SaveDataManager>();
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
    
    public void NewGame()
    {
        //SaveData.DeleteSaveData();
        //Destroy(saveDataObj);
        saveDataObj.ResetSaveData();
        SceneManager.LoadScene("Level 1 test");
    }

    public void ResumeGame()
    {
        saveDataObj.ResumeGame();
        SceneManager.LoadScene("Level 1 test");
    }

    public void QuitGame()
    {
        saveDataObj.GetComponent<SaveDataManager>().SaveBeforeQuit();
        Application.Quit();
    }
    
    public void ShowResults()
    {
        results_Screen.SetActive(true);
    }

    public void CloseResults()
    {
        results_Screen.SetActive(false);
    }

    public void SetResults()
    {
        genScore.text = saveDataObj.saveData.totalGeneric.ToString();
        wpmScore.text = saveDataObj.saveData.wpm.ToString("0.##");
        curStreak.text = saveDataObj.saveData.maxStreak.ToString();
        curMistakes.text = saveDataObj.saveData.mistakes.ToString();
    }
}
