using UnityEngine;
public class mqttController : MonoBehaviour
{
    public string nameController = "Controller";
    public string tagOfTheMQTTReceiver = "";
    public GameObject objectToControl;
    private float numValue = 0.0f;

    public mqttReceiver _eventSender;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver).Length > 0)
        {
            _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReceiver>();
        }
        else
        {
            Debug.LogError("At least one GameObject with mqttReceiver component and Tag == tagOfTheMQTTReceiver needs to be provided");
        }
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        numValue = float.Parse(newMsg);
        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }

     private void Update()
    {
        float step = 0.5f * Time.deltaTime;

        Vector3 rotationVector = new Vector3(objectToControl.transform.localEulerAngles.x, -numValue * 4.5f, objectToControl.transform.localEulerAngles.z);

        objectToControl.transform.localRotation = Quaternion.Lerp(objectToControl.transform.localRotation, Quaternion.Euler(rotationVector), step);

    }
}