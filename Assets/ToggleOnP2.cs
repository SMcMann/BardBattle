using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOnP2 : MonoBehaviour
{
    
    public GameObject playergoblin;
    public GameObject playertiefling;

    private void Awake()
    {
        // Set default values
        playergoblin.SetActive(false);
            playertiefling.SetActive(true);
            MainMenus.p2goblin = false;
            MainMenus.p2tiefling = true;
            Debug.Log(MainMenus.p2goblin);
            Debug.Log(MainMenus.p2tiefling);
    }
    public void SwitchImages()
    {


        if (playergoblin.activeInHierarchy == true)
        {
            AkSoundEngine.SetSwitch("Player2Instrument", "P2_Lute", gameObject);
            playergoblin.SetActive(false);
            playertiefling.SetActive(true);
            MainMenus.p2goblin = false;
            MainMenus.p2tiefling = true;
            Debug.Log(MainMenus.p2goblin);
            Debug.Log(MainMenus.p2tiefling);
        }
        else if (playergoblin.activeInHierarchy == false)
        {
          
            AkSoundEngine.SetSwitch("Player2Instrument", "P2_Sax", gameObject);
            playergoblin.SetActive(true);
            playertiefling.SetActive(false);
            MainMenus.p2goblin = true;
            MainMenus.p2tiefling = false;
            Debug.Log(MainMenus.p2goblin);
            Debug.Log(MainMenus.p2tiefling);
        }
    }

}

