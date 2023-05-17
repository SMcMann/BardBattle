using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Note : MonoBehaviour
{
    public GameObject song;

    public int expectedInput;
    public string noteName;
    PlayerControls controls;
    public bool ready = false;

    // Start is called before the first frame update
    void Awake()
    {

        controls = new PlayerControls();
        controls.Gameplay.ButtonNorth.performed += ctx => Input(ctx);
        controls.Gameplay.ButtonEast.performed += ctx => Input(ctx);
        controls.Gameplay.ButtonSouth.performed += ctx => Input(ctx);
        controls.Gameplay.ButtonWest.performed += ctx => Input(ctx);
        controls.Gameplay.LeftTrigger.performed += ctx => Input(ctx);
        controls.Gameplay.RightTrigger.performed += ctx => Input(ctx);
        StartCoroutine(SelfDestruct());
        StartCoroutine(ReadyUp());
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void Input(InputAction.CallbackContext context)
    {
        if (ready && context.action.name.ToString() == noteName ) {
          Destroy(gameObject);
          GameStateManager.player1Fame += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * 5) * Time.deltaTime;
    }
    IEnumerator ReadyUp()
      {
          yield return new WaitForSeconds(1.7f);
          ready = true;
      }
    IEnumerator SelfDestruct()
      {
          yield return new WaitForSeconds(3f);
          Destroy(gameObject);
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
