using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform target;
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
}
