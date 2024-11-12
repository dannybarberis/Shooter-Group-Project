using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    // its access level: public or private
    // its type: int (5, 8, 36, etc.), float (2.5f, 3.7f, etc.)
    // its name: speed, playerSpeed --- Speed, PlayerSpeed
    // optional: give it an initial value
    private float speed;
    public int lives;
    public int score;
    private float horizontalInput;
    private float verticalInput;

    public GameObject bullet;

    public TextMeshProUGUI livesText;
    // public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        lives = 3;
       // score = 0;
        transform.position = new Vector3(0, -3, 0);

        livesText = FindObjectOfType<TextMeshProUGUI>();
        livesText.text = "Lives: " + lives.ToString();

      //  scoreText = FindObjectOfType<TextMeshProUGUI>();
      //  scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        // Makes player teleport to other side of screen if off left or right side of screen
        if (transform.position.x > 11.5f || transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        // Makes player unable to move above half of screen
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        // Makes player unable to move below bottom of screen
        if (transform.position.y < -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }
    }

    void Shooting()
    {
        //if I press SPACE
        //Create a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Create a bullet
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    
    public void PlayerLives()
    {
        lives -= 1;
        livesText.text = "Lives: " + lives.ToString();
        if(lives < 1)
        {
            livesText.text = "Lives: " + lives.ToString();
            Destroy(this.gameObject);
        }
    }

    //public void CoinGrab()
    //{
      //score += 1;
      //Debug.Log("Score: "+ score);
    //}
}
