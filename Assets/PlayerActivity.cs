using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class PlayerActivity : MonoBehaviour
{
    bool isMoving = false;
    bool isSilent = false;

    void Update()
    {
        // Determine if the player is moving
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Set the appropriate switch based on player activity
        if (isMoving)
        {
            // Player is moving, switch to "test1" switch
            if (isSilent)
            {
                // Stop the "silence" switch
                AkSoundEngine.SetSwitch("TestPlayer1Melodies", "Test1", gameObject);
                Debug.Log("Test1 On");
                isSilent = false;
                AkSoundEngine.PostEvent("GameMusicControl", gameObject);
            }
            AkSoundEngine.SetSwitch("TestPlayer1Melodies", "Silence", gameObject);
        }
        else
        {
            // Player is not moving, switch to "silence" switch
            if (!isSilent)
            {
                // Stop the "test1" switch
                AkSoundEngine.SetSwitch("TestPlayer1Melodies", "Silence", gameObject);
                Debug.Log("Silence On");
                isSilent = true;

            }
            AkSoundEngine.SetSwitch("TestPlayer1Melodies", "Test1", gameObject);
        }
    }
}


//AkSoundEngine.SetSwitch("TestPlayer1Melodies", "Silence", gameObject);
//AkSoundEngine.PostEvent("GameMusicControl", gameObject);