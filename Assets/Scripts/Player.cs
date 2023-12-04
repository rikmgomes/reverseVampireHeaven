using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{   
    public bool isGameOver;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI vidaMaxima;
    [SerializeField] TextMeshProUGUI vidaAtual;

    
    void Start()
    {   
        isGameOver = false;
        currentHealth = maxHealth;
        vidaMaxima.text = "Vida Máxima: " + maxHealth.ToString();
        vidaAtual.text = "Vida Atual: " + currentHealth.ToString();
        healthBar.SetMaxHealth(maxHealth);
        int firstPass = 0;
        int secondPass = 0;
        for (int levelCycle = 1; levelCycle < 4; levelCycle++)
        {
            firstPass = (int)Math.Floor(levelCycle + (300 * Math.Pow(2, levelCycle / 7)));
            secondPass = firstPass / 4;
        }
    }

    public void GameOver() 
    {   
        Time.timeScale = 0f;
        panel.SetActive(true);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Inimigo"))
        {
            TakeDamage(40);
        }
        else if(collision.collider.gameObject.CompareTag("InimigoFoda"))
        {
            TakeDamage(100);
        }

        if (isGameOver)
        {
            GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        vidaAtual.text = "Vida Atual: " + currentHealth.ToString();
        if (currentHealth <= 0)
        {
            isGameOver = true;
        }    
    }
}