using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

	public int numberOfEnemies;
	public float spawnRadius;
	public GameObject bossMinion;
	public GameObject Boss;
	public Transform player;
	public float maxDistance;
	private Vector3 spawnPosition;
	private bool spawned = false;
	private var timer;


	void Update () {
		if (!spawned) {
			if (calculateDistance () < maxDistance) {
				SpawnEnemy ();
			}
		}
		if(spawned){
			timer += Time.deltaTime;
			if(timer == 40){
				SpawnBoss();
			}
		}
	}

	float calculateDistance(){
		return Vector3.Distance (transform.position, player.position);
	}

	void SpawnEnemy ()
	{
		for(int i = 0; i < numberOfEnemies; i++)
		{
			spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
			Vector3 adjustedtPosition = new Vector3(spawnPosition.x, 0, spawnPosition.z);
			Instantiate(bossMinion, adjustedtPosition, Quaternion.identity);
		}  
		spawned = true;
	}

	void SpawnBoss(){
		var position = transform.position;
		Vector3 adjustedtPosition = new Vector3(position.x, 0, position.z);
		Instantiate(Boss, adjustedtPosition, Quaternion.identity);
	}

}
