using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUp : MonoBehaviour
{
    private float timeToDisappear = 5f;
    private bool isCollected = false;
    private float timer;

    void Start()
    {
        timer = timeToDisappear;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);

        if (!isCollected)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameManager gm = FindObjectOfType<gameManager>();
            gm?.PlayPowerUp();

            isCollected = true;
            Destroy(this.gameObject);
            other.GetComponent<Player>().Shield();
        }

    }
}