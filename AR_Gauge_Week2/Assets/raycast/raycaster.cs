using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycaster : MonoBehaviour
{
    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //send a Ray from the Camera in the direction of the mouse pointer
            
            if (Physics.Raycast(ray, out hit)) //if the Ray hit a GameObject with a Collider on it (no need of a rigidbody)
            {

                Debug.Log(hit.transform.gameObject.name); //print the name of the GameObject

                
            }
        }
    }
}
