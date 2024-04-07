using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class main : MonoBehaviour
{
    [SerializeField] float Speed;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  // create a reference to our animator component
        spriteRenderer = GetComponent<SpriteRenderer>(); // create a reference to sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        //right arrow controls
        if (Input.GetKey(KeyCode.D))
        {

            animator.SetBool("right", true); //set the right perameters true
            transform.Translate(Time.deltaTime * Vector3.right * Speed);
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("left", true);
            transform.Translate(Time.deltaTime * Vector3.left * Speed);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
        }

        //up arrow controls
        else if (Input.GetKey(KeyCode.W))
        {

            animator.SetBool("up", true); //set the right perameters true
            transform.Translate(Time.deltaTime * Vector3.up * Speed);
            animator.SetBool("left", false);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
        }
        //down arrow controls
        else if (Input.GetKey(KeyCode.S))
        {

            animator.SetBool("down", true); //set the right perameters true
            transform.Translate(Time.deltaTime * Vector3.down * Speed);
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("right", false);
        }
    }
}