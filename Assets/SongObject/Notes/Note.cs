using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int noteLength = 4;
    public float deadZone = -20;
    public GameObject song;
    public GameObject gameTick;

    public int expectedInput;
    public string noteName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * 3) * Time.deltaTime;
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
            SongLogic sn = song.GetComponent<SongLogic>();
            sn.testFunction(expectedInput);

            // Debug.Log(noteName);
        }
    }

    void OnCollisionEnter(Collision  collision) {
      Debug.Log("collision: " + collision.gameObject.tag);
      if(collision.gameObject.tag == "SongBar") {
        Destroy(gameObject);
      }
    }

      void OnTriggerEnter2D(Collider2D  collision) {
      Debug.Log("triiger: " + collision.gameObject.tag);
      if(collision.gameObject.tag == "SongBar") {
        Destroy(gameObject);
      }
    }
}
