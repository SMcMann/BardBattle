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
        TickSystem ticker = gameTick.GetComponent<TickSystem>();
        test = new Note[] { nooote, nooote, nooote, };
        var offset = new Vector3(0f, 2f, 0);
        for (int i=0; i < 3; i++)
        {
            // Debug.Log(test[i]);
            // test[i].noteName = "";
            var n = Instantiate(nooote, transform.position + offset, transform.rotation);
            n.noteName = "aaaa";

            offset += new Vector3(0, 2, 0);
        }
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
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
