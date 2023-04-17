using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SongController : MonoBehaviour
{
    public Song song;
    public AudioSource audioSource;
    private int currentNoteIndex = 0;

    void Start()
    {
        if (song != null)
        {
            // Start playing the song
            StartCoroutine(PlaySong());
        }
    }

    IEnumerator PlaySong()
    {
        // Play the audio
        audioSource.clip = song.audioClip;
        audioSource.Play();

        // Wait for the song to finish
        yield return new WaitForSeconds(audioSource.clip.length);

        // Handle the end of the song
        EndSong();
    }

    void Update()
    {
        // Check for user input and compare it to the current note
        if (currentNoteIndex < song.notes.Count)
        {
            SongNote note = song.notes[currentNoteIndex];
            if (Input.GetKeyDown(note.input))
            {
                // User input matches the current note
                Debug.Log("Correct note");
                currentNoteIndex++;
            }
        }
    }

    void EndSong()
    {
        // Handle the end of the song
    }
}
