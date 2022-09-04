using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    //public GameObject[] fallingObjects;
    public List<GameObject> fallingObjects;
    public GameObject fallingObject;

    private List<GameObject> _objectsFalling;
    void Start()
    {
        InvokeRepeating("DropMeteorites", 1.0f, 0.1f);
    }

    void DropMeteorites()
    {
        Vector3 randomSpawn = new Vector3(
            Random.Range(-50, 50),
            200,
            Random.Range(-50, 50)
        );
        
        Instantiate(fallingObject, randomSpawn, Quaternion.identity);
    }
    
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.G))
        {
            int randomIndex = Random.Range(0, fallingObjects.Count);
            Vector3 randomSpawn = new Vector3(
                Random.Range(-10, 20), // random x coord
                100,
                Random.Range(-10, 20)
            );
            Instantiate(fallingObjects[0], randomSpawn, Quaternion.identity);

        }
        */
    }
}
