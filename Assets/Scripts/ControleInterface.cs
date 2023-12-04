using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleInterface : MonoBehaviour
{
    public void clicarBotaoIniciar()
    {
        SceneManager.LoadScene("run");
        Time.timeScale = 1f;
    }

    public void clicarBotaoSair()
    {
        Debug.Log("sair");
        Application.Quit();
    }

    public void clicarBotaoMenu()
    {
        SceneManager.LoadScene("menuInicial");
        Time.timeScale = 1f;
    }

    public void clicarBotaoTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void clicarBotaoCreditos()
    {
        SceneManager.LoadScene("credits");
    }
}
