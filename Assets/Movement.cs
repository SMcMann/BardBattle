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

    void Update()
    {
        float inputX = 0f;
        float inputY = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputX = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            inputX = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputY = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
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
