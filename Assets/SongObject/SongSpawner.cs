using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;


public class SongSpawner : MonoBehaviour
{
    private GameObject player;
    public GameObject Song;
    public TMPro.TextMeshProUGUI textBox;
    public float cooldownTime = 5f; // Time in seconds for the cooldown
    private float cooldownTimer = 0f;
    private enum State { Ready, Playing, Cooldown }
    private State currentState = State.Ready;
    private AudioSource audioSource;
    public GameObject songPromptInstance;
    public string switchGroup = "SwitchGroupName";
    public string switchState = "SwitchStateName";

    private bool spawedPrompt = false;
    
    // Start is called before the first frame update
    void Start()
    {
        textBox.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        // Log in to PlayFab
        LoginToPlayFab();
    }

     void LoginToPlayFab()
    {
        string customId = SystemInfo.deviceUniqueIdentifier;
        Debug.Log("Custom ID: " + customId);

        var request = new LoginWithCustomIDRequest { CustomId = customId, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }


    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Logged in successfully to PlayFab!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"Error logging in to PlayFab: {error.GenerateErrorReport()}");
    }


    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        bool playerCloseEnough = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 2;

        if (playerCloseEnough && !spawedPrompt)
        {
            var offset = new Vector3(0f, 2f, 0);
            // Instantiate(songPromptInstance, transform.position + offset, transform.rotation);
            // spawedPrompt = true;
            // textBox.gameObject.SetActive(true);
        }
        else if (!playerCloseEnough && spawedPrompt)
        {
            spawedPrompt = false;
        }

        if (playerCloseEnough && Input.GetButtonDown("Jump"))
        {
            // Set the Wwise Switch
            AkSoundEngine.SetSwitch(switchGroup, switchState, this.gameObject);

            if (currentState == State.Ready)
            {
                SpawnSong();
                currentState = State.Playing;
            }
            else if (currentState == State.Playing)
            {
                StopSongPrompt();
                currentState = State.Cooldown;
            }
        }

        if (currentState == State.Cooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownTime)
            {
                currentState = State.Ready;
                cooldownTimer = 0f;
            }
        }
    }

    void GetSongData(string songKey, Action<Song> onSuccess, Action<PlayFabError> onError)
    {
        var request = new GetTitleDataRequest { Keys = new List<string>() { songKey } };

        PlayFabClientAPI.GetTitleData(request, result =>
        {
            // Deserialize the song data from the result
            string songJson = result.Data[songKey];
            Song song = JsonUtility.FromJson<Song>(songJson);

            // Log the song data to the console
            Debug.Log("Song Name: " + song.name);
            foreach (var note in song.notes)
            {
                Debug.Log("Note Name: " + note.name);
                Debug.Log("Note Length: " + note.noteLength); // change "length" to "noteLength"
                Debug.Log("Note Input: " + note.input);
            }


            // Invoke the success callback with the song object
            onSuccess.Invoke(song);

        }, error =>
        {
            Debug.LogError(error);
            onError.Invoke(error);
        });
    }


    

    void SpawnSong()
    {
        // 1) Get Song from server
        string songKey = "Song1";
        GetSongData(songKey, song =>
        {
            // Spawn the Song instance with the fetched song data
            SpawnSongInstance(song);
        },
        error =>
        {
            Debug.LogError(error);
        });
    }

    void SpawnSongInstance(Song fetchedSong)
    {
        // Check if the fetchedSong is null
        if (fetchedSong == null)
        {
            Debug.LogError("Cannot spawn null song!");
            return;
        }

        // Spawn Song
        var offset = new Vector3(0f, 2f, 0);
        var songInstance = Instantiate(Song, transform.position + offset, transform.rotation);
        // var songController = songInstance.GetComponent<SongController>();

        // // Check if the songController is null
        // if (songController == null)
        // {
        //     Debug.LogError("SongController is not found in the Song prefab!");
        //     return;
        // }

        // songController.song = fetchedSong;
        Debug.Log("Spawned song: " + fetchedSong.name);
    }



    void StopSongPrompt()
    {
        audioSource.Stop();
       // Destroy(songPromptInstance);
       // songPromptInstance = null;
    }
}
