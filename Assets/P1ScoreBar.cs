using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class P1ScoreBar : MonoBehaviour
{
  
    public Slider P1slider;
    void Update()
    {
        
        P1slider.value = GameStateManager.player1Fame;
        
    //if (GameStateManager.player1Fame != 100)
    //  {
    //      GameStateManager.player1Fame += 1;
    //  }
        if (GameStateManager.player1Fame >= 100)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
