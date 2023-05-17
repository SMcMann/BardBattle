using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOn : MonoBehaviour
{
    
    public GameObject playergoblin;
    public GameObject playertiefling;

    private void Awake()
    {
        // Set default values
        playergoblin.SetActive(true);
            playertiefling.SetActive(false);
            MainMenus.p1goblin = true;
            MainMenus.p1tiefling = false;
    }
    
    public void SwitchImages()
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

