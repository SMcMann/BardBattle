using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2ScoreBar : MonoBehaviour
{

    public Slider P2slider;
    void Update()
    {

        P2slider.value = GameStateManager.player2Fame;
        
     //   if (GameStateManager.player2Fame != 100)
    //    {
    //        GameStateManager.player2Fame += 1;
   //     }

    }
}
