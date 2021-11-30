using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int count = 0;

    public AudioSource score;

    private void Start()
    {
        count = 0;

    }

    private void Update()   
    {
        CheckIfScored();
    }

    // Add a score and count when the ball hits the trigger on the basket
    private void OnTriggerEnter(Collider other)
    {
        count++;
        score.Play();
    }

    // If player scores, reset the counter
    public bool CheckIfScored()
    {
        if (count > 0)
        {
            return true;
            count = 0;

        }
        else
        {
            return false;
        }
    }

}