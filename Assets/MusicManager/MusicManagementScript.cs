using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AK.Wwise.Event MusicEvent;
    public Note nooote;
    int count = 1;
    void Start()
    {
        uint CallbackType = (uint)(AkCallbackType.AK_MIDIEvent | AkCallbackType.AK_MusicSyncUserCue);
        MusicEvent.Post(gameObject, CallbackType, CallbackFunction);
        AkSoundEngine.SetSwitch("Player1Instrument", "P1_Lute", gameObject);
        AkSoundEngine.SetRTPCValue("TestPlayer1Inactive", 100, gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void CallbackFunction(object COOKIE, AkCallbackType TYPE, object INFO)
    {
    if (TYPE == AkCallbackType.AK_MIDIEvent) {
      AkMIDIEventCallbackInfo eventinfo = (AkMIDIEventCallbackInfo) INFO;

      // spawwn a note
      if (eventinfo.byOnOffNote.Equals(36) && (count %2 == 1) ) {
        var offset = new Vector3(0f, 2f, 0);
        Instantiate(nooote, transform.position + offset, transform.rotation);
      }

      // allow input for a note
      if (eventinfo.byOnOffNote.Equals(37) && (count %2 == 1) ) {
        Debug.Log("Toggling not ready status!");  
      }

      count++;
      Debug.Log(count);
      Debug.Log("==============");

    }
    else if (TYPE == AkCallbackType.AK_MIDIEvent) {
      // give player back control cause song is done
      count = 1;
    }
    else {
      Debug.Log("=``````````=");
      Debug.Log(TYPE);
    }

    // if (TYPE == AkCallbackType.Ak_MusicSyncUserCue)
    //   {    
    //     AkUserCueEventCallbackInfo otherinfo = (AkUserCueEventCallbackInfo) OTHERINFO;
    //       if (otherinfo.pszUserCueName == "Cool")
    //         OpenInput();
    //   }
    }

    public void playerOneMelody(int songNum)
    {
      Debug.Log("Player 1 is playing a thing");
      AkSoundEngine.SetSwitch("Player1Melodies", "P1_Melody01", gameObject);
    }
}
