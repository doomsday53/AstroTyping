using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreLogic : MonoBehaviour
{
    public int mistakesMade;
    public int correctKeys;
    public int keyStreak;
    public int maxStreak;
    public int totalGeneric;
    public float totalCharacters;
    public float wordsPerMin;
    //public bool firstGame;

    public Text newGeneric;
    public Text newMistakes;
    public Text newStreak;
    public Text newWordsPerMinute;
    public Text savedGeneric;
    public Text savedMistakes;
    public Text savedStreak;
    public Text savedWordsPerMinute;
    public Canvas results;
    public Canvas gameOver;
    [SerializeField] private SaveDataManager saveDataObj;
    // Start is called before the first frame update
    void Awake()
    {
        //results.enabled = false;
        //mistakesMade = 0;
        //correctKeys = 0;
        //totalGeneric = 0;
        //genScore.text = totalGeneric.ToString();
        //wordsPerMin = 0;
        //wpmScore.text = wordsPerMin.ToString();
        //totalCharacters = 0;
        //keyStreak = 0;
        //SaveData tempData = SaveData.LoadFile();
        ////If the load failed, then create a new instance of SaveData
        //if (tempData == null)
        //{
        //    saveData = new SaveData();
        //    firstGame = true;
        //}
        ////If the load suceeded, then use the loaded file
        //else
        //{
        //    saveData = tempData;
        //    firstGame = false;
        //}
        results.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        //saveDataObj = FindObjectOfType<SaveDataManager>().gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        //curMistakes.text = mistakesMade.ToString();
        //curStreak.text = keyStreak.ToString();
        if(saveDataObj == null)
        {
            saveDataObj = FindObjectOfType<SaveDataManager>();
        }
        
    }

    public void AddMistake()
    {
        mistakesMade += 1;
    }

    public void AddCorrectKeys()
    {
        correctKeys += 1;
        keyStreak += 1;
    }

    public void ResetStreak()
    {
        if(keyStreak > maxStreak)
        {
            maxStreak = keyStreak;
            keyStreak = 0;
        }
        else
        {
            keyStreak = 0;
        }
    }

    public void ShowGameOver()
    {
        gameOver.gameObject.SetActive(true);
    }

    public void GenerateResults()
    {
        //Load Old Scores
        savedGeneric.text = saveDataObj.saveData.totalGeneric.ToString();
        savedMistakes.text = saveDataObj.saveData.mistakes.ToString();
        savedStreak.text = saveDataObj.saveData.maxStreak.ToString();
        savedWordsPerMinute.text = saveDataObj.saveData.wpm.ToString("0.##");
        //Generate Total Generic Score
        if (mistakesMade <= 0)
        {
            totalGeneric = correctKeys * 100;
        }
        else
        {
            totalGeneric = (correctKeys / mistakesMade) * 100;
        }
        newGeneric.text = totalGeneric.ToString();

        //Generate Words Per Minute
        wordsPerMin = 0.2f * totalCharacters / (Time.timeSinceLevelLoad / 60);
        newWordsPerMinute.text = wordsPerMin.ToString("0.##");

        //Generate Max Streak
        newStreak.text = maxStreak.ToString();

        //Generate Mistakes
        newMistakes.text = mistakesMade.ToString();

        //Enable Results Canvas
        results.gameObject.SetActive(true);
    }
    //private void OnDestroy()
    //{
    //    //If the saveOnDestroy flag is set, data will automatically be saved.  This can be
    //    //triggered by scene changes, application ending, or manual deletion of the GameObject
    //    if (saveData.saveOnDestroy)
    //    {
    //        if(wordsPerMin > saveData.wpm)
    //        {
    //            saveData.wpm = wordsPerMin;
    //        }
    //        if(maxStreak > saveData.maxStreak)
    //        {
    //            saveData.maxStreak = maxStreak;
    //        }
    //        if(firstGame)
    //        {
    //            saveData.mistakes = mistakesMade;
    //        }
    //        else
    //        {
    //            if(mistakesMade < saveData.mistakes)
    //            {
    //                saveData.mistakes = mistakesMade;
    //            }
    //        }
    //        if(totalGeneric > saveData.totalGeneric)
    //        {
    //            saveData.totalGeneric = totalGeneric;
    //        }
    //        saveData.SaveToDisk();
    //    }
    //    //Again, not limited to calling SaveToDisk here.  It can be called any time you want to
    //    //save data.  Remember that the Project window will have to refresh before you see your
    //    //save file.  This happens automatically when recompiling or importing assets, or you can
    //    //right click in the Project window and select refresh.
    //}

    public void SaveAndRestart()
    {
        //saveData.SaveToDisk();
        saveDataObj.GetComponent<SaveDataManager>().SaveScore();
        saveDataObj.GetComponent<SaveDataManager>().firstGame = false;
        SceneManager.LoadScene("Level 1 Test");
    }

    public void GoToMenu()
    {
        saveDataObj.GetComponent<SaveDataManager>().SaveScore();
        saveDataObj.GetComponent<SaveDataManager>().firstGame = false;
        SceneManager.LoadScene("Main Menu");
    }
    //public void OnApplicationQuit()
    //{
    //    if (saveData.saveOnDestroy)
    //    {
    //        saveData.SaveToDisk();
    //    }
    //}
    public void GameOverRestart()
    {
        SceneManager.LoadScene("Level 1 Test");
    }

    public void GameOverMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
