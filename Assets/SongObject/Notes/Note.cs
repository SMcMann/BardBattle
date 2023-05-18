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
        StartCoroutine(CloseUp());
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void Input(InputAction.CallbackContext context)
    {
        if (ready && context.action.name.ToString() == noteName ) {

          if (!context.control.ToString().Contains("1") && expectedInput == 1 ) { //player 1 note
            Debug.Log("P1 scores!");
            AkSoundEngine.SetRTPCValue("TestPlayer1Inactive", 100, gameObject);
            StartCoroutine(resetP1Sound());
            Destroy(gameObject);
            GameStateManager.player1Fame += 1;            
          }
          if (context.control.ToString().Contains("1") && expectedInput == 2 ) { //player 2 note
            AkSoundEngine.SetRTPCValue("TestPlayer2Inactive", 100, gameObject);
            Debug.Log("P2 scores!");
            Destroy(gameObject);
            GameStateManager.player2Fame += 1;            
          }

        }

    }

    IEnumerator resetP1Sound() {
      yield return new WaitForSeconds(0.7f);
      AkSoundEngine.SetRTPCValue("TestPlayer1Inactive", 0, gameObject);
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

      IEnumerator CloseUp()
      {
          yield return new WaitForSeconds(2.3f);
          ready = false;
      }

    IEnumerator SelfDestruct()
      {
          yield return new WaitForSeconds(3f);
          Destroy(gameObject);
      }

    
}
