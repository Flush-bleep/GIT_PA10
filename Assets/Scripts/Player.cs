using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager theGameManger;

    private Rigidbody thisRigidboy = null;

    public float Force = 100;

    Animator FLAPPING;

    private void OnParticleTrigger()
    {
        ParticleSystem explo = GetComponent<ParticleSystem>();  
    }



    // Start is called before the first frame update
    void Start()
    {
        thisRigidboy = GetComponent<Rigidbody>();
        FLAPPING = gameObject.GetComponent<Animator>();
        theGameManger = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            thisRigidboy.AddForce(Vector3.up * Force);
            FLAPPING.SetTrigger("Flap");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            OnParticleTrigger();
            theGameManger.GamePause();
            
        }
    }
}
