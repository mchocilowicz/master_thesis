using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {

    public Vector3 teleportTo;
    public Transform cameraRig;

	IEnumerator OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name == "Player") {
			Fade fade = GameObject.FindGameObjectWithTag ("Fade").GetComponent<Fade> ();
			yield return StartCoroutine (fade.FadeToBlack ());
			cameraRig.position = teleportTo;
			yield return StartCoroutine(fade.FadeToClear());
		}
    }

}

