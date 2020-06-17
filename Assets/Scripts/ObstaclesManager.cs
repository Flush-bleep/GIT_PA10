using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesManager : MonoBehaviour
{
    public GameObject Obstacles = null;
    public GameObject Obstacles1 = null;
    public GameObject Obstacles2 = null;

    public GameObject SpeedUp = null;
    public GameObject SpeedUp2 = null;
    public GameObject SpeedUp3 = null;


    private float NextTime = 0;
    public float SpawnTime = 1.7f;

    public float CurrentSpawnGen = 0;


    private GameManager theGameManger;


    // Start is called before the first frame update
    void Start()
    {
        theGameManger = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        CurrentSpawnGen = (Random.Range(0,3));

        if (Time.time >= NextTime && CurrentSpawnGen == 0)
        {
            NextTime = Time.time + SpawnTime;
            Vector3 spawnPos = new Vector3(15, Random.Range(2.5f, 5.4f), -2.5f);
            Instantiate(Obstacles, spawnPos, Quaternion.identity);
        }

        if (Time.time >= NextTime && CurrentSpawnGen == 1)
        {
            NextTime = Time.time + SpawnTime;
            Vector3 spawnPos = new Vector3(15, Random.Range(0.35f, 3.2f), -8.85f);
            Instantiate(Obstacles1, spawnPos, Quaternion.identity);
        }

        if (Time.time >= NextTime && CurrentSpawnGen == 2)
        {
            NextTime = Time.time + SpawnTime;
            Vector3 spawnPos = new Vector3(15, Random.Range(-1.02f, 1.83f), -4f);
            Instantiate(Obstacles2, spawnPos, Quaternion.identity);
        }

    }

}
