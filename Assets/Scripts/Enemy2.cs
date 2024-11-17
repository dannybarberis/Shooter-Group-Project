using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 6f);
        if (transform.position.x < -13f || transform.position.x > 13f)
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