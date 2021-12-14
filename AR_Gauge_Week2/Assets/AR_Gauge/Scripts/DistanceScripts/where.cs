using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class where : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance = 0f;
    public float angle = 0f;
    //GameObject objToFind;

    public List<GameObject> objList = new List<GameObject>();

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in objList)
        {
            if (item.GetComponent<ping>().pingData > 4)
            {
                distance = Vector3.Distance(item.transform.position, Camera.main.transform.position);
                angle = Vector3.SignedAngle(item.transform.position, Camera.main.transform.forward, Vector3.up);

                Debug.Log("Object: " + item.name + "| Distance: " + distance + "|Angle: " + angle);
            }
        }


        //distance = Vector3.Distance(objToFind.transform.position, Camera.main.transform.position);
        //angle = Vector3.Angle(objToFind.transform.position, Camera.main.transform.forward);
        ///angle = Vector3.SignedAngle(objToFind.transform.position, Camera.main.transform.forward, Vector3.up);
    }
}
