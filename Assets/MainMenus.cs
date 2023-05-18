using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenus : MonoBehaviour
{
    PlayerControls controlz;
    public static bool startcontrols = true;
    public static bool p1tiefling = false;
    public static bool p1goblin = false;
    public static bool p2tiefling = false;
    public static bool p2goblin = false;   
    void Awake()
    {
        startcontrols = true;
        VictoryRestart.VictoryControls = false;
        controlz = new PlayerControls();
        controlz.Gameplay.ButtonNorth.performed += ctx => PlayGame();
        controlz.Gameplay.ButtonWest.performed += ctx => PlayGame();
        controlz.Gameplay.ButtonSouth.performed += ctx => PlayGame();
        controlz.Gameplay.ButtonEast.performed += ctx => PlayGame();
        if (startcontrols == true)
        {
            controlz.Gameplay.Enable();
        }
        else
        {
            controlz.Gameplay.Disable();
        }

    }
    void OnEnable()
    {
        controlz.Gameplay.Enable();
    }
    public void  PlayGame ()
    {
        if (startcontrols == true)
        {
            controlz.Gameplay.Disable();
            SceneManager.LoadScene("CharacterSelect");
        }
    }
}
