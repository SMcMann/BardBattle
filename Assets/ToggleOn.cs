using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOn : MonoBehaviour
{
    PlayerControls controls;
    public GameObject playergoblin;
    public GameObject playertiefling;
    public static bool CharSelectControls = true;

    private void Awake()
    {
        // Set default values
        MainMenus.startcontrols = false;
        controls = new PlayerControls();
        CharSelectControls = true;
        controls.Gameplay.MoveRight.performed += ctx => SwitchImages();
        controls.Gameplay.MoveLeft.performed += ctx => SwitchImages();
        playergoblin.SetActive(true);
        playertiefling.SetActive(false);
        MainMenus.p1goblin = true;
        MainMenus.p1tiefling = false;
        if (ToggleOn.CharSelectControls == true)
        {
                controls.Gameplay.Enable();
        }
        else
        {
            controls.Gameplay.Disable();
        }
    }
 
    public void SwitchImages()
    {
        if (ToggleOn.CharSelectControls == true)
        {
            if (playergoblin.activeInHierarchy == true)
            {
                playergoblin.SetActive(false);
                playertiefling.SetActive(true);
                MainMenus.p1goblin = false;
                MainMenus.p1tiefling = true;
            }
            else if (playergoblin.activeInHierarchy == false)
            {
                playergoblin.SetActive(true);
                playertiefling.SetActive(false);
                MainMenus.p1goblin = true;
                MainMenus.p1tiefling = false;
            }
        }
    }

}

