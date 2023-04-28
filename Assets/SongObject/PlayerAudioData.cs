using UnityEngine;

[CreateAssetMenu(menuName = "SO/Audio/Player", fileName = "PlayerAudio")]
public class PlayerAudioData : ScriptableObject
{
    [Header("Movement")]
    public AK.Wwise.Event jump = null;

    [Header("Melody")]
    public AK.Wwise.Event melody = null;
}
