using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject coin;
    public GameObject powerup;

    public AudioClip powerUp;
    public AudioClip powerDown;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 2f);
        InvokeRepeating("CreateEnemy2", 1f, 3f);
        InvokeRepeating("CreateCoin", 1f, 4f);
        InvokeRepeating("CreatePowerUp", 6f, 8f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 9f, 0),
        Quaternion.identity);
    }
    void CreateEnemy2()
    {
        Instantiate(enemy2, new Vector3(10f, Random.Range(2f, 6f), 0),
        Quaternion.identity);
    }
    void CreateCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-9f, 9f), 9f, 0),
        Quaternion.identity);
    }
    void CreatePowerUp()
    {
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), 9f, 0),
        Quaternion.identity);
    }
    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }
    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }
}