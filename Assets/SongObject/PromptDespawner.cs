using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptDespawner : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject songPromptInstance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        bool playerCloseEnough = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 4;
        if (!playerCloseEnough)
        {
            Destroy(songPromptInstance);
        }
    }
}
