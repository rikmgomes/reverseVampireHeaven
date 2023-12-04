using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    void Update()
    {
        if(Time.timeScale != 0f)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(panel.activeInHierarchy == false)
                {
                    OpenMenu();
                }
                else{
                    CloseMenu();
                }
            }
        }
        else{
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(panel.activeInHierarchy == false)
                {
                    
                }
                else{
                    CloseMenu();
                }
            }
        }
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }
}
