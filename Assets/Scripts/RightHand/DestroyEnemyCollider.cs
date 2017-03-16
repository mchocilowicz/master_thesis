using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyCollider : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Sphere")
        {
            Debug.Log("Destory");
            Destroy(other.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
