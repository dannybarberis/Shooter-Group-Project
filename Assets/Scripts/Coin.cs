using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float timeToDisappear = 5f;  // time before the object disappears (in seconds)
    private bool isCollected = false;   // flag to track if the player has collected the object
    private float timer;                // timer to track time since spawn

    // Start is called before the first frame update
    void Start()
    {
        //start timer when coin spawns
        timer = timeToDisappear;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);

        if (!isCollected)
        {
            // decrease timer every frame
            timer -= Time.deltaTime;

            // if timer runs out (after 5 seconds)
            if (timer <= 0f)
            {
                // If not collected, destroy the object
                Destroy(this.gameObject);
            }
        }
    }

    // Method to handle when the player collects the object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // check if the player is the one that collided with the object
        {
            Debug.Log("Player collected the coin!");

            // Set the object as collected and destroy it immediately
            isCollected = true;
            Destroy(this.gameObject);
        }

    }
}