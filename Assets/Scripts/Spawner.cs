using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int numberOfEnemies;
    public float spawnRadius;
    public GameObject objectToSpawn;
    private Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
        SpawnObject();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnObject ()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Vector3 adjustedtPosition = new Vector3(spawnPosition.x, 0, spawnPosition.z);
            Instantiate(objectToSpawn, adjustedtPosition, Quaternion.identity);
        }    
    }
}
