using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private bool spawedPrompt = false;
    
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

    void SpawnSong()
    {
        // 1) get Song from server
        // 2) Spawn Song
        var offset = new Vector3(0f, 2f, 0);
        Instantiate(Song, transform.position + offset, transform.rotation);
    }

    void StopSongPrompt()
    {
        audioSource.Stop();
       // Destroy(songPromptInstance);
       // songPromptInstance = null;
    }
}
