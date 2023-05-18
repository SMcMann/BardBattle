using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenus : MonoBehaviour
{
    PlayerControls controls;
    public static bool p1tiefling = false;
    public static bool p1goblin = false;
    public static bool p2tiefling = false;
    public static bool p2goblin = false;

    void Awake()
    {
        controls = new PlayerControls();
        // controls.Gameplay.ButtonNorth.performed += ctx => PlayGame();
        // controls.Gameplay.ButtonWest.performed += ctx => PlayGame();
        // controls.Gameplay.ButtonSouth.performed += ctx => PlayGame();
        // controls.Gameplay.ButtonEast.performed += ctx => PlayGame();
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    public void  PlayGame ()
    {
        p1goblin = true;
        p2tiefling = true;
        Debug.Log(p2goblin);
        Debug.Log(p2tiefling);
        SceneManager.LoadScene("CharacterSelect");
        
    }
    public void PlayGame2()
    {
        
        
        SceneManager.LoadScene("Testmap");

    }
}
