using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TestMapStart : MonoBehaviour
{
    PlayerControls controls;
    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.ButtonNorth.performed += ctx => PlayGame2();
        controls.Gameplay.ButtonWest.performed += ctx => PlayGame2();
        controls.Gameplay.ButtonSouth.performed += ctx => PlayGame2();
        controls.Gameplay.ButtonEast.performed += ctx => PlayGame2();
        if (ToggleOn.CharSelectControls == true)
        {
            controls.Gameplay.Enable();
        }
        else
        {
            controls.Gameplay.Disable();
        }
    }
    public void PlayGame2()
    {
        if (ToggleOn.CharSelectControls == true)
        {
            SceneManager.LoadScene("Testmap");
        }
    }
}
