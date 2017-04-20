using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int numberOfEnemies;
    public float spawnRadius;
    public GameObject objectToSpawn;
	public Transform player;
	public float maxDistance;
	private Vector3 spawnPosition;
	private bool spawned = false;


	void Update () {
		if (!spawned) {
			if (calculateDistance () < maxDistance) {
				SpawnObject()
			}
		}
	}
	
	float calculateDistance(){
		return Vector3.Distance (transform.position, player.position);
	}
		
    void SpawnObject ()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Vector3 adjustedtPosition = new Vector3(spawnPosition.x, 0, spawnPosition.z);
            Instantiate(objectToSpawn, adjustedtPosition, Quaternion.identity);
        }  
		spawned = true;
    }
}
