using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
            public void  PlayGame ()
    {
        SceneManager.LoadScene("Game");
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("Game2");
    }
}
