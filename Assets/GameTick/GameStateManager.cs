using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public GameState CurrentGameState;

    // State change events
    public UnityEvent OnIdleEnter, OnIdleExit;
    public UnityEvent OnPlayingSongChallengeEnter, OnPlayingSongChallengeExit;
    public UnityEvent OnSongSpawningTimerEnter, OnSongSpawningTimerExit;
    public UnityEvent OnVictoryEnter;
    public static int player1Fame;
    public static int player2Fame;
    public static int victoryFame;
    public float challengeTimer;
    public float songSpawningTimer;
    [SerializeField] private SongSpawner songSpawner;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameStateManager GameObject persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Update timers and check for victory
        if (CurrentGameState == GameState.PlayingSongChallenge)
        {
            challengeTimer -= Time.deltaTime;
            if (challengeTimer <= 0)
            {
                ChangeState(GameState.SongSpawningTimer);
            }
        }
        else if (CurrentGameState == GameState.SongSpawningTimer)
        {
            songSpawningTimer -= Time.deltaTime;
            if (songSpawningTimer <= 0)
            {
                ChangeState(GameState.Idle);
            }
        }

        CheckForVictory();
    }

    public void ChangeState(GameState newState)
    {
        // Exit current state
        switch (CurrentGameState)
        {
            case GameState.Idle:
                OnIdleExit.Invoke();
                break;
            case GameState.PlayingSongChallenge:
                OnPlayingSongChallengeExit.Invoke();
                break;
            case GameState.SongSpawningTimer:
                OnSongSpawningTimerExit.Invoke();
                break;
            case GameState.Victory:
                OnVictoryEnter.Invoke();
                break;
        }

        // Enter new state
        CurrentGameState = newState;
        switch (newState)
        {
            case GameState.Idle:
                OnIdleEnter.Invoke();
                break;
            case GameState.PlayingSongChallenge:
                OnPlayingSongChallengeEnter.Invoke();
                break;
            case GameState.SongSpawningTimer:
                OnSongSpawningTimerEnter.Invoke();
                break;
            case GameState.Victory:
                OnVictoryEnter.Invoke();
                break;
        }
    }

    // private void OnEnterChallengeState()
    // {
    //     Debug.Log("Entering Challenge State");

    //     // Assume you have access to the variable `table` which is of type `Table`
    //     SongSpawner.Instance.SpawnSong(1, table);

    //     // Set the challenge duration and song clip to play for the challenge
    //     challengeTimer = 60f; // Change to your desired challenge duration

    //     // Change the game state to Challenge
    //     CurrentGameState = GameState.Challenge;
    // }


    // handle button presses during the song challenge player1Fame
    public void OnNoteButtonPressed(bool success)
    {
        if (CurrentGameState != GameState.PlayingSongChallenge) return;

        if (success)
        {
            player1Fame++;
            // Send good signal to Wwise
        }
        else
        {
            // Send bad signal to Wwise
        }
    }
    // handle button presses during the song challenge player2Fame
    public void OnNoteButtonPressedPlayer2(bool success)
    {
        if (CurrentGameState != GameState.PlayingSongChallenge) return;

        if (success)
        {
            player2Fame++;
            // Send good signal to Wwise
        }
        else
        {
            // Send bad signal to Wwise
        }
    }


    // Check for victory conditions
    private void CheckForVictory()
    {
        if (player1Fame >= victoryFame || player2Fame >= victoryFame)
        {
            ChangeState(GameState.Victory);
        }
    }

}