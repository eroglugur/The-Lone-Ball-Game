using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1000;
    private float jumpForce = 30000;

    public bool playerJumped = false;
    public bool hasGrounded = false;

    private GameObject focalPoint;
    private Rigidbody rb;
    private GameManager gameManager;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        hasGrounded = true;
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        focalPoint.transform.position = transform.position;

        MovePlayer();
        JumpPlayer();

    }

    // Move the player according to user input
    void MovePlayer()
    {
        if (gameManager.isGameActive)
        {
            float verticalInput = Input.GetAxis("Vertical");
            rb.AddForce(focalPoint.transform.right * -1 * verticalInput * speed * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    // Make player jump if it's on ground
    void JumpPlayer()
    {
        if (gameManager.isGameActive && hasGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            hasGrounded = false;
        }
    }

    // Check if the player is on ground or platform
    private void OnCollisionEnter(Collision collision)
    {
        // Player can use platform just one time
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb.AddForce(Vector3.up * (jumpForce / 1.5f) * Time.deltaTime, ForceMode.Impulse);
            jumpSound.Play();
            playerJumped = true;
            hasGrounded = false;
        }
    }
}
