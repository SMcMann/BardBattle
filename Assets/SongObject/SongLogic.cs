using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongLogic : MonoBehaviour
{
    public Note nooote;
    private struct testNote {
        string expectedInput;
        int noteLength;
        string name;
    };

    private Note[] test;
    public GameObject gameTick;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SPAWNINGGGG");
        StartCoroutine(SelfDestruct());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testFunction(int x)
    {
        Debug.Log(x);
    }

    void OnCollisionEnter(Collision  collision) {
      Debug.Log("collision 0: " + collision.gameObject.tag);
    }

     IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
