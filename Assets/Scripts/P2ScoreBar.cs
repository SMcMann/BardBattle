using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class P2ScoreBar : MonoBehaviour
{

    public Slider P2slider;
    void Update()
    {

        P2slider.value = GameStateManager.player2Fame;
        if (GameStateManager.player2Fame != 100)
        {
     //       GameStateManager.player2Fame += 1;
        }
        if (GameStateManager.player2Fame == 100)
        {
            SceneManager.LoadScene("VictoryScene");
        }

    }
}
