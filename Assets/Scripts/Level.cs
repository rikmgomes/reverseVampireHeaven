using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    private GameObject vampiro;
    private GameObject arma;
    [SerializeField] GameObject panel;
    [SerializeField] Button botaoUpgradeUm;
    [SerializeField] Button botaoUpgradeDois;
    [SerializeField] Button botaoUpgradeTres;
    [SerializeField] TextMeshProUGUI textBotaoUm;
    [SerializeField] TextMeshProUGUI textBotaoDois;
    [SerializeField] TextMeshProUGUI textBotaoTres;
    private float proximo = 1.0f;
    [SerializeField] TextMeshProUGUI tamanhoAtual;
    [SerializeField] TextMeshProUGUI velocidadeVampiro;
    [SerializeField] TextMeshProUGUI velocidadeBala;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        vampiro = GameObject.Find("Slime");
        arma = GameObject.Find("Gun");
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        tamanhoAtual.text = "Tamanho Vampiro: " + proximo.ToString();
        velocidadeVampiro.text = "Velocidade Vampiro: " + vampiro.GetComponent<PlayerController>().speed.ToString();
        velocidadeBala.text = "Velocidade Bala: " + arma.GetComponent<Gun>().bulletSpeed.ToString();
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);

        string[] listaUpgrades = {"Aumentar Tamanho Vampiro (+1)", "Diminuir Velocidade Vampiro (-2)", "Diminuir Vida Atual Vampiro (-100)", "Diminuir Velocidade Bala (-2)"};
        Button[] listaBotoes = {botaoUpgradeUm, botaoUpgradeDois, botaoUpgradeTres};
        TextMeshProUGUI[] listaTextosBotoes = {textBotaoUm, textBotaoDois, textBotaoTres};
        
        for(int i = 0; i < 3 ; i++)
        {
            int upgrade = Random.Range(0, 4);
            listaTextosBotoes[i].text = listaUpgrades[upgrade];
            listaBotoes[i].onClick.RemoveAllListeners();
            if(upgrade == 0)
            {
                listaBotoes[i].onClick.AddListener(AumentarTamanho);
            }
            else if(upgrade == 1)
            {
                listaBotoes[i].onClick.AddListener(DiminuirVelocidade);
            }
            else if(upgrade == 2)
            {
                listaBotoes[i].onClick.AddListener(DiminuirMaxHealth);
            }
            else if(upgrade == 3)
            {
                listaBotoes[i].onClick.AddListener(DimnuirVelBala);
            }
        }
        OpenMenu();
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void AumentarTamanho()
    {
        vampiro.transform.localScale = new Vector3(proximo, proximo, proximo);
        proximo += 1.0f;
        tamanhoAtual.text = "Tamanho Vampiro: " + proximo.ToString();
        CloseMenu();
    }

    public void DiminuirVelocidade()
    {
        vampiro.GetComponent<PlayerController>().speed -= 2;
        velocidadeVampiro.text = "Velocidade Vampiro: " + vampiro.GetComponent<PlayerController>().speed.ToString();
        CloseMenu();
    }

    public void DiminuirMaxHealth()
    {
        int vidaAtual = vampiro.GetComponent<Player>().currentHealth;
        if(vidaAtual <= 100)
        {
            vampiro.GetComponent<Player>().TakeDamage(vidaAtual-1);
        }
        else
        {
            vampiro.GetComponent<Player>().TakeDamage(100);
        }
        CloseMenu();
    }

    public void DimnuirVelBala()
    {
        arma.GetComponent<Gun>().bulletSpeed -= 2;
        velocidadeBala.text = "Velocidade Bala: " + arma.GetComponent<Gun>().bulletSpeed.ToString();
        CloseMenu();
    }
}