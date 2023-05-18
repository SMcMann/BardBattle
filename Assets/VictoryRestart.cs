using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryRestart : MonoBehaviour
{
    PlayerControls controls;
    public static bool VictoryControls = true;
    
    void Awake()
    {
        VictoryControls = true;
        MainMenus.startcontrols = false;
        controls = new PlayerControls();
        controls.Gameplay.ButtonNorth.performed += ctx => Restart();
        if (VictoryControls == true)
        {
            controls.Gameplay.Enable();
        }
        else
        {
            controls.Gameplay.Disable();
        }
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    public void Restart()
    {
        if (VictoryControls == true)
        {
            SceneManager.LoadScene("Main Menu");
        }

          
    

    }
}
