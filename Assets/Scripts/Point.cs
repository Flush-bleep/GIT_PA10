using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private GameManager theGameManger;

    // Start is called before the first frame update
    void Start()
    {
        theGameManger = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        theGameManger.AddScore(10);

    }


}
