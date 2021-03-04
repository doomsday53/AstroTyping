using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    public int mistakesMade;
    public int correctKeys;
    public int keyStreak;
    public int totalGeneric;
    public float totalWords;
    public float wordsPerMin;

    public UnityEngine.UI.Text genScore;
    public UnityEngine.UI.Text curMistakes;
    public UnityEngine.UI.Text curStreak;

    // Start is called before the first frame update
    void Start()
    {
        if( mistakesMade <= 0)
        {
            mistakesMade = 0;
        }
        if(correctKeys <= 0)
        {
            correctKeys = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        curMistakes.text = mistakesMade.ToString();
        curStreak.text = keyStreak.ToString();
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
        keyStreak = 0;
    }

    public void GenerateTotalGeneric()
    {
        if(mistakesMade <= 0)
        {
            totalGeneric = correctKeys * 100;
        }
        else
        {
            totalGeneric = (correctKeys / mistakesMade) * 100;
        }
        
        genScore.text = totalGeneric.ToString();
    }

    public void GenerateWordsPerMin()
    {
        wordsPerMin = totalWords / Time.timeSinceLevelLoad;
    }
}
