using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changeColour : MonoBehaviour
{
    public string tagOfTheARObject = "ARObject";
    private GameObject instGObject;

    public void redThis()
    {
        if (GameObject.FindGameObjectsWithTag(tagOfTheARObject).Length > 0)
        {

            instGObject = GameObject.FindGameObjectsWithTag(tagOfTheARObject)[0].gameObject;
            instGObject.GetComponent<MeshRenderer>().material.color = new Color(251.0f/255.0f, 84.0f/255.0f, 84.0f/255.0f, 0);
        }
        else
        {
            Debug.LogError("ARObject not created");
        }


    }
    public void blueThis()
    {
        if (GameObject.FindGameObjectsWithTag(tagOfTheARObject).Length > 0)
        {

            instGObject = GameObject.FindGameObjectsWithTag(tagOfTheARObject)[0].gameObject;
            instGObject.GetComponent<MeshRenderer>().material.color = new Color(84.0f/255.0f, 136.0f/255.0f, 250.0f/255.0f, 0);
        }
        else
        {
            Debug.LogError("ARObject not created");
        }
    }
}
