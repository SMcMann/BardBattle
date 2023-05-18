using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryLoad : MonoBehaviour
{
    public GameObject P1Win;
    public GameObject P2Win;
    public GameObject Goblin;
    public GameObject Tiefling;

    public void Awake()
    {
        MainMenus.startcontrols = true;
        if (GameStateManager.player1Fame == 100)
        {
            if(MainMenus.p1goblin == true)
            {
                P1Win.SetActive(true);
                Goblin.SetActive(true);
            }
            else if(MainMenus.p1tiefling == true)
            {
                P1Win.SetActive(true);
                Tiefling.SetActive(true);
            }
        }
        else if(GameStateManager.player2Fame == 100)
        {
            if(MainMenus.p2goblin == true)
            {
                P2Win.SetActive(true);
                Goblin.SetActive(true);
              
            }
            else if (MainMenus.p2tiefling == true)
            {
                P2Win.SetActive(true);
                Tiefling.SetActive(true);
            }
        }
    }
}
