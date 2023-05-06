using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStatic : MonoBehaviour
{
    public GameObject p1goblins;
    public GameObject p1tieflings;
    public GameObject p2goblins;
    public GameObject p2tieflings;
    void Start()
    {
       if (MainMenus.p1goblin == false)
        {
            p1goblins.SetActive(false);
        }
       if (MainMenus.p1tiefling == false)
        {
            p1tieflings.SetActive(false);
        }
       if (MainMenus.p2goblin == false)
        {
            p2goblins.SetActive(false);
        }
       if (MainMenus.p2tiefling == false)
        {
            p2tieflings.SetActive(false);
        }
    }


}
