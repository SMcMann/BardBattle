using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryLoad : MonoBehaviour
{
    public GameObject P1TextWin;
    public GameObject P2TextWin;
    public GameObject Goblin;
    public GameObject Tiefling;



    public void Awake()
    {
        if (GameStateManager.player2Fame == 100)
        {
           if (MainMenus.p2goblin == true)
            {
                P2TextWin.SetActive(true);
                Goblin.SetActive(true);
            }
           else if (MainMenus.p2tiefling == true)
            {
                P2TextWin.SetActive(true);
                Tiefling.SetActive(true);
            }
        }
        else if (GameStateManager.player1Fame == 100)
        {
            if (MainMenus.p1goblin == true)
            {
                P1TextWin.SetActive(true);
                Goblin.SetActive(true);
            }
            else if (MainMenus.p1tiefling == true)
            {
                P1TextWin.SetActive(true);
                Tiefling.SetActive(true);
            }
        }
    }




}
