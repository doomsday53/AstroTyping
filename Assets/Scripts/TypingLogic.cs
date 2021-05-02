using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingLogic : MonoBehaviour
{
    public List<string> enemyLines = null;
    public int currentLine = 0;
    public int currentCharacter = 0;
    public int damage;
    public int enemiesDefeated;
    public string displayString = "NOT SET";
    public UnityEngine.UI.Text txtEnemyDisplay;
    public Enemy1Logic enemyLogic;
    public ScoreLogic score;
    public PlayerLogic player;

    // Start is called before the first frame update
    void Start()
    {
        LoadLines("pangrams.txt");
        for (int i = 0; i < displayString.Length; i++)
        {
            score.totalCharacters += 1;
        }
        enemiesDefeated = 0;
    }
    public void LoadLines(string stringtxt)
    {

        string path = System.IO.Path.Combine(Application.streamingAssetsPath, stringtxt);
        System.IO.StreamReader streamReader = new System.IO.StreamReader(path);
        enemyLines = new List<string>();
        while (!streamReader.EndOfStream)
        {
            enemyLines.Add(streamReader.ReadLine());
        }
        streamReader.Close();

        displayString = enemyLines[0];
        txtEnemyDisplay.text = displayString;

        UnityEngine.InputSystem.Keyboard.current.onTextInput += DoKeyPress;
    }
    private void OnDestroy()
    {
        UnityEngine.InputSystem.Keyboard.current.onTextInput -= DoKeyPress;
    }
    private void DoKeyPress(char curKey)
    {
        if (curKey == enemyLines[currentLine][currentCharacter])
        {
            currentCharacter += 1;
            score.AddCorrectKeys();
            if (currentCharacter >= enemyLines[currentLine].Length)
            {
                score.totalCharacters += 1;
                currentCharacter = 0;
                currentLine += 1;
                enemyLogic.TakeDamage(damage);
                if (currentLine >= enemyLines.Count)
                {
                    score.GenerateResults();
                    //enemiesDefeated += 1;
                    //if(enemiesDefeated == 3)
                    //{
                    //    score.GenerateTotalGeneric();
                    //    score.GenerateWordsPerMin();
                    //}
                }
                currentLine = currentLine % enemyLines.Count;
                displayString = enemyLines[currentLine];
            }
            string leftSide = enemyLines[currentLine].Substring(0, currentCharacter);
            string rightSide = enemyLines[currentLine].Substring(currentCharacter, enemyLines[currentLine].Length - currentCharacter);
            displayString = string.Format("<color=green>{0}</color>{1}", leftSide, rightSide);
            txtEnemyDisplay.text = displayString;
        }
        else
        {
            player.TakeDamage(damage);
            score.AddMistake();
            score.ResetStreak();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(1);
    }

}
