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
                AkSoundEngine.SetSwitch("silence", "Off", gameObject);
                Debug.Log("Test1 On");
                Debug.Log("Silence Off");
                isSilent = false;
            }
            AkSoundEngine.SetSwitch("test1", "On", gameObject);
        }
        else
        {
            // Player is not moving, switch to "silence" switch
            if (!isSilent)
            {
                // Stop the "test1" switch
                AkSoundEngine.SetSwitch("test1", "Off", gameObject);
                Debug.Log("Test1 Off");
                Debug.Log("Silence On");
                isSilent = true;
            }
            AkSoundEngine.SetSwitch("silence", "On", gameObject);
        }
    }
}
