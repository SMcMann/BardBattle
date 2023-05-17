using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AK.Wwise.Event MusicEvent;
    public Note aNote;
    public Note bNote;
    public Note yNote;
    public Note lNote;
    public Note rNote;
    int count = 1;
    UnityEngine.Vector3 spawnpoint;
    void Start()
    {
        uint CallbackType = (uint)(AkCallbackType.AK_MIDIEvent | AkCallbackType.AK_MusicSyncUserCue);
        MusicEvent.Post(gameObject, CallbackType, CallbackFunction);
        AkSoundEngine.SetSwitch("Player1Instrument", "P1_Lute", gameObject);
        AkSoundEngine.SetSwitch("Player2Instrument", "P2_Sax", gameObject);
        AkSoundEngine.SetRTPCValue("TestPlayer1Inactive", 100, gameObject);
        AkSoundEngine.SetRTPCValue("TestPlayer2Inactive", 100, gameObject);
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
        var offset = new Vector3(0f, 3f, 0);

        int num = Random.Range(1, 5);
        switch(num) {
          case 1:
            Instantiate(aNote, new Vector3(spawnpoint.x - 2f, spawnpoint.y + 12f, 3), transform.rotation);
            break;
          case 2:
            Instantiate(bNote, new Vector3(spawnpoint.x -1f, spawnpoint.y + 12f, 3), transform.rotation);
            break;
          case 3:
            Instantiate(lNote, new Vector3(spawnpoint.x, spawnpoint.y + 12f, 3), transform.rotation);
            break;
          case 4:
            Instantiate(rNote, new Vector3(spawnpoint.x +1f, spawnpoint.y + 12f, 3), transform.rotation);
            break;
          default:
            Instantiate(yNote, new Vector3(spawnpoint.x +2f, spawnpoint.y + 12f, 3), transform.rotation);
            break;
        }

        // obj.transform.localPosition = spawnpoint;
      }

      // allow input for a note
      if (eventinfo.byOnOffNote.Equals(37) && (count %2 == 1) ) {
        Debug.Log("Toggling ready status!");  
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

    public void playerOneMelody(UnityEngine.Vector3 table)
    {
      Debug.Log("Player 1 is playing a thing");
      spawnpoint = table;

      int num = Random.Range(0, p1map.Length);
      AkSoundEngine.SetSwitch("Player1Melodies", p1map[num], gameObject);
    }

    public void playerTwoMelody(UnityEngine.Vector3 table)
    {
      Debug.Log("Player 2 is playing a thing");
      spawnpoint = table;

      int num = Random.Range(0, p2map.Length);
      AkSoundEngine.SetSwitch("Player2Melodies", p2map[num], gameObject);
    }

    string[] p1map = new string[] {
      "P1_Melody01", 
      "P1_Melody02", 
      "P1_Melody03",
      "P1_Melody04",
      "P1_Melody05",
      "P1_Melody06",
      "P1_Melody07",
      "P1_Melody08",
      };

    string[] p2map = new string[] {
      "P2_Melody01", 
      "P2_Melody02", 
      "P2_Melody03",
      "P2_Melody04",
      "P2_Melody05",
      "P2_Melody06",
      "P2_Melody07",
      "P2_Melody08",
      };
}

