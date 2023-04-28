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
}
