using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AK.Wwise;
using UnityEngine.SceneManagement;

public class SongSpawner : MonoBehaviour
{
    public static SongSpawner Instance;
    private GameObject player1;
    private GameObject player2;
    public GameObject Song;
    public TMPro.TextMeshProUGUI textBox;
    public float cooldownTime = 5f; // Time in seconds for the cooldown
    private float cooldownTimer = 0f;
    private enum State { Ready, Playing, Cooldown }
    private State currentState = State.Ready;
    public GameObject songPromptInstance;
    private bool isChallengeActive;
    private float challengeTimer;
    private int playerPoints;
    public GameObject buttonsContainer;
    private TMPro.TextMeshProUGUI readyText;
    private float debugTimer = 0f;

    private bool spawedPrompt = false;
    
     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //  call when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentState = State.Cooldown;
        AssignPlayerObjects();
        GameObject readyTextObject = GameObject.FindGameObjectWithTag("ReadyText");
        if (readyTextObject != null)
        {
            readyText = readyTextObject.GetComponent<TMPro.TextMeshProUGUI>();
            Debug.Log("Found ready text");
        }
    }


    //  Avoiding potential memory leaks, unsubscribe 
    // from the SceneManager.sceneLoaded event when the object is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    // Start is called before the first frame update
    void Start()
    {
        if (textBox != null)
        {
            textBox.gameObject.SetActive(false);
        }
    }


    private void AssignPlayerObjects()
    {
        if (player1 == null)
        {
            player1 = GameObject.FindWithTag("Player1");
        }
    
        if (player2 == null)
        {
            player2 = GameObject.FindWithTag("Player2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        AssignPlayerObjects();

        debugTimer += Time.deltaTime;
        if (debugTimer >= 10f)
        {
            Debug.Log("currentState (Update): " + currentState);
            debugTimer = 0f;
        }

         if (player1 != null)
        {
            // Debug.Log("Player 1 is not null");
            bool player1CloseEnough = Vector2.Distance(new Vector2(player1.transform.position.x, player1.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 2;
        
            if (player1CloseEnough && !spawedPrompt)
            {
                var offset = new Vector3(0f, 2f, 0);
                // Instantiate(songPromptInstance, transform.position + offset, transform.rotation);
                // spawedPrompt = true;
                // textBox.gameObject.SetActive(true);
            }
            else if (!player1CloseEnough && spawedPrompt)
            {
                spawedPrompt = false;
            }

            if (player1CloseEnough && Input.GetButtonDown("Jump"))
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
        }

        if (player2 != null)
        {
            // Debug.Log("Player 2 is not null");
            bool player2CloseEnough = Vector2.Distance(new Vector2(player2.transform.position.x, player2.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 2;
            if (player2CloseEnough && !spawedPrompt)
            {
                var offset = new Vector3(0f, 2f, 0);
                // Instantiate(songPromptInstance, transform.position + offset, transform.rotation);
                // spawedPrompt = true;
                // textBox.gameObject.SetActive(true);
            }
            else if (!player2CloseEnough && spawedPrompt)
            {
                spawedPrompt = false;
            }

            if (player2CloseEnough && Input.GetButtonDown("Jump"))
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
        }

        if (currentState == State.Cooldown)
        {
            cooldownTimer += Time.deltaTime;
            Debug.Log("Cooldown timer: " + cooldownTimer);
            if (cooldownTimer >= cooldownTime)
            {
                Debug.Log("Cooldown timer is greater than cooldown time");
                currentState = State.Ready;
                cooldownTimer = 0f;
                Debug.Log("currentState set to State.Ready");
            }
        }
        
        if (readyText != null)
        {
            // Debug.Log("Ready text is not null");
            readyText.gameObject.SetActive(currentState == State.Ready);
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

        // Post the Wwise Event to play the challenge song
        AkSoundEngine.PostEvent("GameMusicControl", gameObject);

        currentState = State.Playing;
        Debug.Log("Song spawned. currentState: " + currentState);
    }

    void EndChallenge()
    {
        // Disable and hide buttons for the song challenge
        // buttonsContainer.SetActive(false);

        // Stop the challenge song
        // Collect the points
        CollectPoints();
        // Set currentState to Cooldown
        currentState = State.Cooldown;
    }

    void CollectPoints()
    {
        // Add the player's points from this challenge to their total score
        // Use the 'playerPoints' variable to update the player's score or fame points
    }


    void StopSongPrompt()
    {
        // Post the Wwise Event to stop the challenge song
        AkSoundEngine.PostEvent("GameMusicControl", gameObject);

       // Destroy(songPromptInstance);
       // songPromptInstance = null;

       currentState = State.Cooldown;
        Debug.Log("Song stopped. currentState: " + currentState);
    }
}