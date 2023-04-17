using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SongNote
{
    public string name;
    public float noteLength;
    public string input;
}

[System.Serializable]
public class Song
{
    public string name;
    public List<SongNote> notes;
    public AudioClip audioClip;
}