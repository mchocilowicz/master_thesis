using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {

    public Vector3 teleportTo;
    public Transform cameraRig;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("TELEPORTING");
        cameraRig.position = teleportTo;
    }

}

