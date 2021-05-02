using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public TypingLogic typingLogic;
    public Text healthText;
    public Text maxHealthText;
    public GameObject explosion;
    public ScoreLogic score;
    // Start is called before the first frame update
    void Start()
    {
        //health = typingLogic.enemyLines.Count;
       // maxHealth = health;
        healthText.text = health.ToString();
        maxHealthText.text = maxHealth.ToString();
        //healthBar.SetMaxHealth(maxHealth);
        typingLogic = FindObjectOfType<TypingLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //print(Time.timeSinceLevelLoad.ToString());
            gameObject.SetActive(false);
            ObjectPool.Spawn(explosion, transform.position, transform.rotation);
            //StartCoroutine(WaitForRespawn());

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = health.ToString();
    }
}
