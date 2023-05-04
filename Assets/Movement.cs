using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forwardForce = 100f;
    public float sidewaysForce = 500f;
    // Start is called before the first frame update
    public Vector2 speed = new Vector2(1, 1);
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
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
        } else if (inputY != 0)
        {
            animator.SetFloat("Speedy", 1);
        }
        else
        {
            animator.SetFloat("Speedy", -3);

        }

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
        }
    }
}
