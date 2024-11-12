using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject coin;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 2f);
        InvokeRepeating("CreateEnemy2", 1f, 3f);
        InvokeRepeating("CreateCoin", 1f, 4f);
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
}