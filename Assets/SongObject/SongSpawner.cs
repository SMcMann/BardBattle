using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AK.Wwise;

public class SongSpawner : MonoBehaviour
{
    public static SongSpawner Instance;
    private GameObject player;
    public GameObject Song;
    public TMPro.TextMeshProUGUI textBox;
    public float cooldownTime = 5f; // Time in seconds for the cooldown
    private float cooldownTimer = 0f;
    private enum State { Ready, Playing, Cooldown }
    private State currentState = State.Ready;
    private AudioSource audioSource;
    public GameObject songPromptInstance;
    private bool isChallengeActive;
    private float challengeTimer;
    private int playerPoints;
    public GameObject buttonsContainer;
    public Switch MelodySwitch;

    private bool spawedPrompt = false;
    
     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        textBox.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
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
            if (currentState == State.Ready)
            {
                SpawnSong(1); // Temporary placeholder value for the melodyNumber 
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

        if (isChallengeActive)
        {
            challengeTimer -= Time.deltaTime;

            // Check for player input here and update playerPoints accordingly

            if (challengeTimer <= 0)
            {
                isChallengeActive = false;
                EndChallenge();
            }
        }
    }

    public void SpawnSong(int melodyNumber)
    {
        // 1) get Song from server
        // 2) Spawn Song
        var offset = new Vector3(0f, 2f, 0);
        Instantiate(Song, transform.position + offset, transform.rotation);

         // Set the Wwise Switch for the melody to play
        // MelodySwitch.SetValue(gameObject, melodyNumber);

        // Start the challenge
        isChallengeActive = true;
        challengeTimer = 60f; // Set the challenge duration
        playerPoints = 0;
        // buttonsContainer.SetActive(true);

        // Post the Wwise Event to play the challenge song
        AkSoundEngine.PostEvent("Play_Challenge_Song", gameObject);
    }

    void EndChallenge()
    {
        // Disable and hide buttons for the song challenge
        // buttonsContainer.SetActive(false);

        // Stop the challenge song
        audioSource.Stop();

        // Collect the points
        CollectPoints();
    }

void CollectPoints()
{
    // Add the player's points from this challenge to their total score
    // Use the 'playerPoints' variable to update the player's score or fame points
}


    void StopSongPrompt()
    {
        audioSource.Stop();
        // Post the Wwise Event to stop the challenge song
        AkSoundEngine.PostEvent("Stop_Challenge_Song", gameObject);

       // Destroy(songPromptInstance);
       // songPromptInstance = null;
    }
}