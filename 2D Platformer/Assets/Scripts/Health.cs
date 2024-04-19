using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public int numberOfhearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject gameoverRedScreen;
    public GameObject gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentHealth = maxHealth;
        gameoverRedScreen.SetActive(false);
        gameoverText.SetActive(false);
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Debug.Log("Player Health = "+ currentHealth);

        if(currentHealth <=0)
        {
            Debug.Log("GAME OVER!");
            Time.timeScale = 0;
            gameoverRedScreen.SetActive(true);
            gameoverText.SetActive(true);
        }
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Update()
    {
        if(currentHealth > numberOfhearts)
        {
            currentHealth = numberOfhearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numberOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
