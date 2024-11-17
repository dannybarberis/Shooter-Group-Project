using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);

        if (transform.position.y < -8.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.CompareTag("Player"))
        {
            Player player = whatIHit.GetComponent<Player>();
            if(!player.isInvincible)
            {
                player.PlayerLives();
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
                player.AddPoints();
            }
        }
      
    }
}
