using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AK.Wwise.Event MusicEvent;
    void Start()
    {
        MusicEvent.Post(gameObject, (uint)AkCallbackType.AK_MusicSyncAll, CallbackFunction);
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
      Debug.Log("TYPE");
    }
    // if (TYPE == AkCallbackType.Ak_MIDIEvent)
    // {    AkMIDIEventCallbackInfo eventinfo = (AkMIDIEventCallbackInfo) INFO;
    //             if (eventinfo.byType. == 24)
    //                 // SpawnNote();
    //                 Debug.Log("Spanw song now plz");
    //             if (eventinfo.tNoteOnOff.byNote == 25)
    //                 // SpawnNote();
    //                 Debug.Log("Accpet input");
    // }
    }

    public void playerOneMelody(int songNum)
    {
      Debug.Log("Player 1 is playing a thing");
      AkSoundEngine.SetSwitch("Player1Melodies", "P1_Melody01", gameObject);
    }
}
