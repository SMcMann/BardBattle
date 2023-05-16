using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Table : MonoBehaviour
{
    public GameObject Song;
    public float cooldownTime = 5f;
    private float cooldownTimer = 0f;
    public enum State { Ready, Playing, Cooldown }
    private State currentState = State.Ready;
    private bool isChallengeActive;
    private float challengeTimer;
    private int playerPoints;
    private GameObject player1;
    private GameObject player2;
    private float debugTimer = 0f;
    private SongSpawner songSpawner;
    public TMPro.TextMeshProUGUI uiText;
    // public UnityEngine.UI.Image uiImage;
    public Image tableImage;



    public State CurrentState { get { return currentState; } set { currentState = value; } }
    public bool IsChallengeActive { get { return isChallengeActive; } set { isChallengeActive = value; } }
    public float ChallengeTimer { get { return challengeTimer; } set { challengeTimer = value; } }
    public int PlayerPoints { get { return playerPoints; } set { playerPoints = value; } }



    private void Start()
    {
        songSpawner = SongSpawner.Instance;

        if (songSpawner == null)
        {
            Debug.LogError("SongSpawner instance is null.");
        }
    }



    private void Awake()
    {
        // songSpawner = SongSpawner.Instance;
        // Debug.Log("SongSpawner instance: " + (songSpawner != null ? "Not null" : "Null"));

        currentState = State.Cooldown;
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        tableImage = GetComponentInChildren<Image>();
    }

    void Update()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        debugTimer += Time.deltaTime;

        // if (debugTimer >= 5f)
        // {
        //     Debug.Log("currentState (Update): " + currentState);
        //     debugTimer = 0f;
        // }

        if (currentState == State.Cooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownTime)
            {
                Debug.Log("Cooldown finished");
                currentState = State.Ready;
                cooldownTimer = 0f;
            }
            else
            {
                Debug.Log("Cooldown in progress: " + cooldownTimer);
            }
        }

        if (currentState == State.Ready)
        {
            // uiText.text = "Press 'X' to start challenge";
             tableImage.enabled = true;
             uiText.text = "";
        }
        else if (currentState == State.Playing)
        {
            uiText.text = "Challenge in progress...";
            tableImage.enabled = false;
        }
        else if (currentState == State.Cooldown)
        {
            // uiText.text = $"Cooldown: {Mathf.Ceil(cooldownTime - cooldownTimer)}";
            uiText.text = $"Cooldown: {Mathf.Ceil(cooldownTime - cooldownTimer)}";
            tableImage.enabled = false;
        }

        bool player1CloseEnough = Vector2.Distance(new Vector2(player1.transform.position.x, player1.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 2;
        bool player2CloseEnough = Vector2.Distance(new Vector2(player2.transform.position.x, player2.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 2;

        // Debug.Log("Player1 Distance: " + Vector2.Distance(new Vector2(player1.transform.position.x, player1.transform.position.y), new Vector2(transform.position.x, transform.position.y)));
        // Debug.Log("Player2 Distance: " + Vector2.Distance(new Vector2(player2.transform.position.x, player2.transform.position.y), new Vector2(transform.position.x, transform.position.y)));
        // Debug.Log("Jump Button Pressed: " + Input.GetButtonDown("Jump"));
        
        // Debug.Log("Player1 Position: " + player1.transform.position);
        // Debug.Log("Player2 Position: " + player2.transform.position);
        // Debug.Log("Table Position: " + transform.position);

        if (player1CloseEnough && Input.GetButtonDown("Jump"))
        {
            Debug.Log("player1 is close enough and the Jump button was pressed.");
            HandleChallengeStart();
        }

        if (player2CloseEnough && Input.GetButtonDown("Jump"))
        {
            Debug.Log("player2 is close enough and the Jump button was pressed.");
            HandleChallengeStart();
        }

        if (isChallengeActive)
        {
            challengeTimer -= Time.deltaTime;
            if (challengeTimer <= 0)
            {
                isChallengeActive = false;
                EndChallenge();
            }
        }
    }

    private void HandleChallengeStart()
    {
        if (currentState == State.Ready)
        {
            songSpawner.SpawnSong(1, this);
            currentState = State.Playing;
        }
        else if (currentState == State.Playing)
        {
            songSpawner.StopSong(this);
            currentState = State.Cooldown;
        }
        else if (currentState == State.Cooldown)
        {
            currentState = State.Ready;
        }
    }

    void EndChallenge()
    {
        // Add the player's points from this challenge to their total score
        // Use the 'playerPoints' variable to update the player's score or fame points
        currentState = State.Cooldown;
    }
}

