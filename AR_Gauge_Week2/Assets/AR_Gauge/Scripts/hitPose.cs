using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class hitPose : MonoBehaviour
{
    public GameObject gameObjectToInstantiate; //the Prefab GameObject to instantiate in the AR environment. To be added in the inspector window
    private GameObject spawnedObject; //the Prefab Instantiate in the scene. Used internally by the script 
    private ARRaycastManager _arRaycastManager; //part of the ARSession GO
    private Vector2 touchPosition; //XZ position of the user Tap

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
public Ray ray;

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    public bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(index: 0).position;
            return true;
        }
        touchPosition = default;
        return false;

    }

    // Update is called once per frame
    public void spawnObject()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
        }
    }

}