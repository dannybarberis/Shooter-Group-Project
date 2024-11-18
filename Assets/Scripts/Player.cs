using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private float speed;
    private int lives;
    private int score;
    private float horizontalInput;
    private float verticalInput;
    private float timer;

    public GameObject bullet;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI gameoverText;

    public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        lives = 3;
        score = 0;
        transform.position = new Vector3(0, -3, 0);
        
        livesText = GameObject.Find("Canvas/Lives").GetComponent<TextMeshProUGUI>();
        livesText.text = "Lives: " + lives.ToString();

        scoreText = GameObject.Find("Canvas/Score").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + score.ToString();

        powerText = GameObject.Find("Canvas/PowerUp").GetComponent<TextMeshProUGUI>();

        gameoverText = GameObject.Find("Canvas/GameOver").GetComponent<TextMeshProUGUI>();
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
            GameOver();
        }
    }

    public void AddPoints()
    {
      score += 5;
      scoreText.text = "Score: " + score.ToString();
    }
    public void Shield()
    {
        StartCoroutine(ShieldTimer());
    }
    private IEnumerator ShieldTimer()
    {
        float duration = 6f;
        float timer = 0f;
        isInvincible = true;
        powerText.text = "Shield Active";
        while(timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        powerText.text = "";
        isInvincible = false;

        // Play the PowerDown sound via the gameManager
        gameManager gm = FindObjectOfType<gameManager>();
        gm?.PlayPowerDown();
    }
    public void GameOver()
    {
        livesText.text = "";
        scoreText.text = "";
        powerText.text = "";
        gameoverText.text = "GAME OVER";
    }
}
