using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSpawner : MonoBehaviour
{
    private GameObject player;
    public GameObject Song;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        if (Vector3.Distance(player.transform.position, transform.position) <= 1 && Input.GetButtonDown("Jump"))
        {
          spawnSong();
        }
    }

    void spawnSong()
    {
      var offset = new Vector3(0.5f, 0.5f, 0);
      Instantiate(Song, transform.position + offset, transform.rotation);
    }
}
