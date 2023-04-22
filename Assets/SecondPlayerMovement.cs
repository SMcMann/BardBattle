using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerMovement : MonoBehaviour
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
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {


            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
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

            Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

            movement *= Time.deltaTime;

            transform.Translate(movement);
        }
    }
}
