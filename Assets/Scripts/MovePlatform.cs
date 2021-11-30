using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlatform : MonoBehaviour
{
    private float zMoveRange = 40;
    private float speed = 10;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    // Moves the from light to left continually in limited range
    void MoveObject()
    {
        if (gameManager.isGameActive && SceneManager.GetActiveScene().buildIndex > 1)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (transform.position.z > zMoveRange || transform.position.z < -zMoveRange)
            {
                speed *= -1;
            }
        }
    }
}
