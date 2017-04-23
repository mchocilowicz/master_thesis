using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {

	public Transform destination;
    public Transform cameraRig;

	void OnTriggerEnter(Collider other)
    {
		Debug.Log (other.gameObject.name);
		if(other.gameObject.name == "Player") {
			GameObject.Find("FadeGM").GetComponent<Fading>(). BeginFade(-1);
			cameraRig.position = destination.position;
		}


    }

}

