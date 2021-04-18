using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Logic : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    public TypingLogic typingLogic;
    public List<Sprite> sprites;
    private int i = 0;
    private Color[] colors;
    private Color randColor;

    // Start is called before the first frame update
    void Start()
    {
        health = typingLogic.enemyLines.Count;
        healthBar.SetMaxHealth(maxHealth);
        typingLogic = FindObjectOfType<TypingLogic>();
        GetComponentInChildren<SpriteRenderer>().sprite = sprites[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //print(Time.timeSinceLevelLoad.ToString());
            gameObject.SetActive(false);
            //StartCoroutine(WaitForRespawn());
            
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (typingLogic.currentLine % 2 == 0)
        {
            i += 1;
            //float colorR = Random.Range(1, 255);
            //float colorGn = Random.Range(1, 255);
            //float colorB = Random.Range(1, 255);


            
            if (i > 3)
            {
                i = 0;
                gameObject.SetActive(false);
                GetComponentInChildren<SpriteRenderer>().sprite = sprites[i];
                RandomColor();
                GetComponentInChildren<SpriteRenderer>().color = randColor;
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
                GetComponentInChildren<SpriteRenderer>().sprite = sprites[i];
                RandomColor();
                GetComponentInChildren<SpriteRenderer>().color = randColor;
                gameObject.SetActive(true);
            }
            
        }

    }

    void RandomColor()
    {
        colors = new[]
        {
            Color.blue,
            Color.magenta,
            Color.red,
            Color.green,
            Color.yellow,
            Color.cyan,
            Color.grey,
            Color.white,
            Color.magenta, 
            Color.black
        };

        int rand = Random.Range(0, colors.Length);
        randColor = colors[rand];


    }

    //public IEnumerator WaitForRespawn()
    //{
    //    gameObject.SetActive(false);
    //    yield return new WaitForSeconds(.5f);
    //    health = typingLogic.enemyLines.Count;
    //    healthBar.SetHealth(health);
    //    maxHealth = typingLogic.enemyLines.Count;
    //    healthBar.SetMaxHealth(maxHealth);
    //    typingLogic.currentLine = 0;
    //    typingLogic.currentCharacter = 0;
    //    if (typingLogic.enemiesDefeated == 1)
    //    {
    //        typingLogic.LoadLines("attack1.txt");
    //    }
    //    if (typingLogic.enemiesDefeated == 2)
    //    {
    //        typingLogic.LoadLines("attack2.txt");
    //    }
    //    gameObject.SetActive(true);
    //}
}
