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
    private GameObject songPromptInstance;
    
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

        if (playerCloseEnough)
    {
        Debug.Log("Text box should be active now");
        textBox.gameObject.SetActive(true);
    }
    else
    {
        Debug.Log("Text box should be inactive now");
        textBox.gameObject.SetActive(false);
    }

        if (playerCloseEnough && Input.GetButtonDown("Jump"))
        {
            if (currentState == State.Ready)
            {
                SpawnSongPrompt();
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

    void SpawnSongPrompt()
    {
        if (songPromptInstance == null)
        {
            var offset = new Vector3(0.5f, 0.5f, 0);
            songPromptInstance = Instantiate(Song, transform.position + offset, transform.rotation);
            AudioClip songClip = Song.GetComponent<AudioSource>().clip;
            audioSource.PlayOneShot(songClip);
        }
    }

    void StopSongPrompt()
    {
        audioSource.Stop();
        Destroy(songPromptInstance);
        songPromptInstance = null;
    }
}
