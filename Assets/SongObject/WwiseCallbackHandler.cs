// using UnityEngine;
// using AK.Wwise;

// public class WwiseCallbackHandler : MonoBehaviour
// {
//     public SongSpawner songSpawner;
//     public AK.Wwise.Event melodyEvent;

//     void Start()
//     {
//         uint playingID = melodyEvent.Post(gameObject);
//         ulong gameObjectID = GetComponent<AkGameObj>().GetID();
//         if (playingID != AkSoundEngine.AK_INVALID_PLAYING_ID)
//         {
//             AkSoundEngine.RegisterGameObj(gameObject);
//             AkSoundEngine.SetGameObjectOutputBusVolume(playingID, gameObjectID, 1.0f);
//             AkSoundEngine.PostEvent(melodyEvent.Id, gameObject, (uint)AkCallbackType.AK_MusicSyncUserCue, Callback, null);
//         }
//     }

//     private void Callback(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
//     {
//         if (in_type == AkCallbackType.AK_MusicSyncUserCue)
//         {
//             AkMusicSyncCallbackInfo callbackInfo = (AkMusicSyncCallbackInfo)in_info;
//             songSpawner.SpawnNoteAndCheckInput(callbackInfo.userCueName);
//         }
//     }
// }
