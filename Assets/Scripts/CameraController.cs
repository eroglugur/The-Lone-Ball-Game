using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public GameManager gameManager;

    Vector3 offset = new Vector3(5, 1, 0);

    private float rotateSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        RotateCamera();

    }

    // Rotate the camera horizontally according to user input
    void RotateCamera()
    {
        if (gameManager.isGameActive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
        }
    }
}
