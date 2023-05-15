using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AK.Wwise;
using UnityEngine.SceneManagement;

public class SongSpawner : MonoBehaviour
{
    public static SongSpawner Instance;
    public GameObject Song;
    public TMPro.TextMeshProUGUI textBox;
    public GameObject songPromptInstance;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject readyTextObject = GameObject.FindGameObjectWithTag("ReadyText");
        if (readyTextObject != null)
        {
            readyText = readyTextObject.GetComponent<TMPro.TextMeshProUGUI>();
            Debug.Log("Found ready text");
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        if (textBox != null)
        {
            textBox.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        debugTimer += Time.deltaTime;
        if (debugTimer >= 10f)
        {
            debugTimer = 0f;
        }
    }

    public void SpawnSong(int melodyNumber, Table table)
    {
        // 1) get Song from server
        // 2) Spawn Song
        var offset = new Vector3(0f, 2f, 0);
        Instantiate(Song, table.transform.position + offset, table.transform.rotation);

        // Start the challenge
        table.IsChallengeActive = true;
        table.ChallengeTimer = 60f; // Set the challenge duration
        table.PlayerPoints = 0;

        // Post the Wwise Event to play the challenge song
        AkSoundEngine.PostEvent("GameMusicControl", gameObject);
        Debug.Log("Song spawned. currentState: " + table.CurrentState);
    }

    public void StopSong(Table table)
    {
        // Post the Wwise Event to stop the challenge song
        AkSoundEngine.PostEvent("GameMusicControl", gameObject);

        table.IsChallengeActive = false;
        Debug.Log("Song stopped. currentState: " + table.CurrentState);
    }
}
