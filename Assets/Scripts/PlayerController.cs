using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 50.0f;
	public Image healthBar;
	public Text healthText;
	public Text score;
	public float PlayerScore = 0;
	private float HealthPoints = 200;
	private float maxHealthPoints = 200;


	void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "Teleporter") {
			TakeDamage (20);
			IncreaseScore (5);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Walk ();
	}

	void Walk(){
		Vector3 pos = transform.position;
		pos.x += moveSpeed * Input.GetAxis("Horizontal")
			* Time.deltaTime;
		pos.z += moveSpeed * Input.GetAxis("Vertical")
			* Time.deltaTime;
		transform.position = pos;
	}

	void UpdateHealth(){
		float ratio = HealthPoints / maxHealthPoints;
		healthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		healthText.text = (ratio * 100).ToString () + "%";
	}

	void TakeDamage(float damage){
		HealthPoints -= damage;
		if (HealthPoints < 0) {
			HealthPoints = 0;
			Debug.Log ("DEAD");
		}
		UpdateHealth ();
	}

	void IncreaseScore(float points){
		PlayerScore += points;
		score.text = PlayerScore.ToString ();
	}
}
