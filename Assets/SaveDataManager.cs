using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataManager : MonoBehaviour
{
    public SaveData saveData;
    public bool firstGame;
    [SerializeField] private Scene activeScene;

    public static SaveDataManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        //saveData.saveOnDestroy = false;
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SaveData tempData = SaveData.LoadFile();
        //If the load failed, then create a new instance of SaveData
        if (tempData == null)
        {
            saveData = new SaveData();
        }
        //If the load suceeded, then use the loaded file
        else
        {
            saveData = tempData;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore()
    {
        float wordsPerMin = FindObjectOfType<ScoreLogic>().wordsPerMin;
        int maxStreak = FindObjectOfType<ScoreLogic>().maxStreak;
        //bool firstGame = FindObjectOfType<ScoreLogic>().firstGame;
        int mistakesMade = FindObjectOfType<ScoreLogic>().mistakesMade;
        int totalGeneric = FindObjectOfType<ScoreLogic>().totalGeneric;
        if (wordsPerMin > saveData.wpm)
        {
            saveData.wpm = wordsPerMin;
        }
        if (maxStreak > saveData.maxStreak)
        {
            saveData.maxStreak = maxStreak;
        }
        if (firstGame)
        {
            saveData.mistakes = mistakesMade;
        }
        else
        {
            if (mistakesMade < saveData.mistakes)
            {
                saveData.mistakes = mistakesMade;
            }
        }
        if (totalGeneric > saveData.totalGeneric)
        {
            saveData.totalGeneric = totalGeneric;
        }
        saveData.SaveToDisk();
    }

    public void ResetSaveData()
    {
        saveData.wpm = 0;
        saveData.maxStreak = 0;
        saveData.mistakes = 0;
        saveData.totalGeneric = 0;
        firstGame = true;
        saveData.SaveToDisk();
        SaveData tempData = SaveData.LoadFile();
        //If the load failed, then create a new instance of SaveData
        if (tempData == null)
        {
            saveData = new SaveData();
        }
        //If the load suceeded, then use the loaded file
        else
        {
            saveData = tempData;
        }

    }

    public void ResumeGame()
    {
        SaveData tempData = SaveData.LoadFile();
        //If the load failed, then create a new instance of SaveData
        if (tempData == null)
        {
            saveData = new SaveData();
        }
        //If the load suceeded, then use the loaded file
        else
        {
            saveData = tempData;
        }
        firstGame = false;
    }

    public void SaveBeforeQuit()
    {
        saveData.saveOnDestroy = true;
    }
}
