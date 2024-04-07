using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class main : MonoBehaviour
{
    public string sceneName;
    public TextMeshProUGUI messageText; // Reference to the UI Text component
    [SerializeField] float Speed;
    [SerializeField] float MinX = 0f;
    [SerializeField] float MinY = 0f;
    [SerializeField] float MaxX = 0f;
    [SerializeField] float MaxY = 0f;
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

        animator.SetBool("left", false);
        animator.SetBool("up", false);
        animator.SetBool("right", false);
        animator.SetBool("down", false);

        if (transform.position.y > MaxY)
        {
            transform.position = new Vector3(transform.position.x, MaxY, 0f);
        }
        if (transform.position.y < MinY)
        {
            transform.position = new Vector3(transform.position.x, MinY, 0f);
        }
        if (transform.position.x > MaxX)
        {
            transform.position = new Vector3(MaxX, transform.position.y, 0f);
        }
        if (transform.position.x < MinX)
        {
            transform.position = new Vector3(MinX, transform.position.y, 0f);
        }
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

        if (transform.position.x >= 11.46f && transform.position.y >= 4.15)
        {
            SceneManager.LoadScene(sceneName);
        }
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Get the mouse position in the game world
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f; // Ensure the z-coordinate is appropriate for 2D games

                // Perform a collision check at the mouse position
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

                // If there's a collider at the mouse position, destroy the object and display a message
                if (hitCollider != null)
                {
                    Destroy(hitCollider.gameObject);
                    messageText.text = "You've collected an artifact!!";
            }
            StartCoroutine(HideMessageAfterDelay(1f));
        }
    }
}

// Coroutine to hide the message after a delay
private IEnumerator HideMessageAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    messageText.text = ""; // Empty the text to hide the message
}
     }
 