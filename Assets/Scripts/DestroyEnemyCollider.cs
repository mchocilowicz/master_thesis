using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyCollider : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Colliding with: " + col.gameObject.name);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
