using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {

	public GameObject destination;


	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.name == "Player") {
			GameObject.Find("FadeGM").GetComponent<Fading>(). BeginFade(-1);
			other.gameObject.transform.position = destination.transform.position;
		}
    }
}

