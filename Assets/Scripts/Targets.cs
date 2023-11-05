using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionPartical;

    //variables for Random functions
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 2;
    public int pointvalue;
    
    
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();// find component on scene and get script

        targetRb.AddForce( RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
       

    }

    
    void Update()
    {
      
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointvalue);
            Instantiate(explosionPartical, transform.position, transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
        

        if(!gameObject.CompareTag("Bad 1"))
        {
            gameManager.GameOver();
        }
        
    }
    Vector3 RandomForce()
    {

        return Vector3.up * Random.Range(minSpeed, maxSpeed);//Random range is for variable speed
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

}
