using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTestMap : MonoBehaviour
{
    public GameObject p1goblins;
    public GameObject p1goblins_thumbnail;
    public GameObject p1tieflings;
    public GameObject p1tieflings_thumbnail;
    public GameObject p2goblins;
    public GameObject p2goblins_thumbnail;
    public GameObject p2tieflings;
    public GameObject p2tieflings_thumbnail;
    void Start()
    {
        GameStateManager.player2Fame = 0;
        GameStateManager.player1Fame = 0;
        if (MainMenus.p1goblin == false)
        {
            p1goblins.SetActive(false);
            p1goblins_thumbnail.SetActive(false);
        }
       if (MainMenus.p1tiefling == false)
        {
            p1tieflings.SetActive(false);
            p1tieflings_thumbnail.SetActive(false);
        }
       if (MainMenus.p2goblin == false)
        {
            p2goblins.SetActive(false);
            p2goblins_thumbnail.SetActive(false);
        }
       if (MainMenus.p2tiefling == false)
        {
            p2tieflings.SetActive(false);
            p2tieflings_thumbnail.SetActive(false);
        }
    }


}
