using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOn : MonoBehaviour
{
    public GameObject playergoblin;
    public GameObject playertiefling;
    public void SwitchImages()
    {
        if (playergoblin.activeInHierarchy == true)
        {
            playergoblin.SetActive(false);
            playertiefling.SetActive(true);
        }
        else if (playergoblin.activeInHierarchy == false)
        {
            playergoblin.SetActive(true);
            playertiefling.SetActive(false);
        }
    }
}

