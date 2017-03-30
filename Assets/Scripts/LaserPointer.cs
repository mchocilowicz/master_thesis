using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    public GameObject laserPrefab;

    private GameObject laser;

    private Transform laserTransform;

    private Vector3 hitPoint;

    public Transform cameraRigTransform;
    public GameObject teleportMarkerPrefab;
    private GameObject marker;
    private Transform teleportMarkerTransform;
    public Transform headTransform;
    public Vector3 teleportMarkerOffset;
    public LayerMask teleportMask;
    private bool shouldTeleport;

    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    private void ShowLaser (RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }

    private void Teleport()
    {
        shouldTeleport = false;
        marker.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        marker = Instantiate(teleportMarkerPrefab);
        teleportMarkerTransform = marker.transform;
    }
	

	void Update () {

        if (Controller.GetHairTriggerDown())
        {
            RaycastHit hit;

            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                marker.SetActive(true);
                teleportMarkerTransform.position = hitPoint + teleportMarkerOffset;
                shouldTeleport = true;
            }
        }

       else
        {
            laser.SetActive(false);
            marker.SetActive(false);
        }

        if (Controller.GetHairTriggerUp() && shouldTeleport)
        {
            Teleport();
        }

	}
}
