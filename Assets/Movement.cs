using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forwardForce = 100f;
    public float sidewaysForce = 500f;
    public Vector2 speed = new Vector2(1, 1);
    public Animator animator;
    private Bounds bounds;

    private SpriteRenderer backgroundRenderer;
    private SpriteRenderer spriteRenderer;
    private Vector2 backgroundSize;
    private Vector2 minLimit;
    private Vector2 maxLimit;

    private SpriteRenderer playerSpriteRenderer;
    PlayerControls controls;
    public bool MoveUp;
    public bool MoveDown;
    public bool MoveRight;
    public bool MoveLeft;

    void Awake() {
        controls = new PlayerControls();
        controls.Gameplay.MoveUp.started += ctx => { if (!ctx.control.ToString().Contains("1")) MoveUp = true; };
        controls.Gameplay.MoveUp.canceled += ctx => { if (!ctx.control.ToString().Contains("1")) MoveUp = false; };
        controls.Gameplay.MoveDown.started += ctx => {if (!ctx.control.ToString().Contains("1")) MoveDown = true;};
        controls.Gameplay.MoveDown.canceled += ctx => {if (!ctx.control.ToString().Contains("1")) MoveDown = false;};
        controls.Gameplay.MoveRight.started += ctx => {if (!ctx.control.ToString().Contains("1")) MoveRight = true;};
        controls.Gameplay.MoveRight.canceled += ctx => {if (!ctx.control.ToString().Contains("1")) MoveRight = false;};
        controls.Gameplay.MoveLeft.started += ctx => {if (!ctx.control.ToString().Contains("1")) MoveLeft = true;};
        controls.Gameplay.MoveLeft.canceled += ctx => {if (!ctx.control.ToString().Contains("1")) MoveLeft = false;};      
    }
    void Start()
    {
        // Get the background object and its bounds
        GameObject background = GameObject.Find("BackGround");
        backgroundRenderer = background.GetComponent<SpriteRenderer>();
        backgroundSize = backgroundRenderer.bounds.size;

        spriteRenderer = GetComponent<SpriteRenderer>();
        bounds = spriteRenderer.bounds;

        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        // Calculate the limits of the background object
        Vector2 backgroundPosition = background.transform.position;
        minLimit = new Vector2(backgroundPosition.x - backgroundSize.x / 2, backgroundPosition.y - backgroundSize.y / 2);
        maxLimit = new Vector2(backgroundPosition.x + backgroundSize.x / 2, backgroundPosition.y + backgroundSize.y / 2);


    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }



    void Update()
    {
        float inputX = 0f;
        float inputY = 0f;

        if (Input.GetKey(KeyCode.LeftArrow) || MoveLeft == true)
        {
            inputX = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || MoveRight == true)
        {
            inputX = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow) || MoveUp == true)
        {
            inputY = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || MoveDown == true)
        {
            inputY = -1f;
        }

        animator.SetFloat("Horizontal", inputX);

        if (inputX != 0)
        {
            animator.SetFloat("Speedy", inputX);
            animator.SetFloat("isFace", inputX);
        }
        else if (inputY != 0)
        {
            animator.SetFloat("Speedy", 1);
        }
        else
        {
            animator.SetFloat("Speedy", -3);
        }

        // Calculate the new position of the player
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

         float playerWidth = playerSpriteRenderer.bounds.size.x;
            float playerHeight = playerSpriteRenderer.bounds.size.y;

        // Clamp the position to the limits of the background object
       
        newPosition.x = Mathf.Clamp(newPosition.x, minLimit.x + playerWidth / 2, maxLimit.x - playerWidth / 2);
        newPosition.y = Mathf.Clamp(newPosition.y, minLimit.y + playerWidth / 2, maxLimit.y - playerWidth / 2);
 
        // Move the player to the new position
        transform.position = newPosition;
    }
}
