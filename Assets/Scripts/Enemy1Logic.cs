using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Logic : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            print(Time.timeSinceLevelLoad.ToString());
            gameObject.SetActive(false);
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

    }
}
