using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour {

	private float time = 0.0f;
	private int count = 0;
	public GameObject BigTornado;
	public GameObject TornadoArea;

	void Update () {
		if (Mathf.Floor(time) == 30 && count == 0) {
			count++;
			spawn (TornadoArea);

		}
		if (Mathf.Floor(time) == 45 && count == 1) {
			count++;
			spawn (BigTornado);
		}
		time += Time.deltaTime;
	}

	void spawn(GameObject tornado) {
		Instantiate(tornado, transform.position, Quaternion.identity);
	}

}
	