using UnityEngine;
public class mqttControllerCube : MonoBehaviour
{
    public string nameController = "Controller";
    public string tagOfTheMQTTReceiver = "";
    public GameObject objectToControl;

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
        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
        DoPulse();
    }

     private void Update()
    {

    }

    public void DoPulse()
         {
         System.Collections.Hashtable hash =
                   new System.Collections.Hashtable();
         hash.Add("amount", new Vector3(0.15f, 0.15f, 0f));
         hash.Add("time", 1f);
         


         iTween.PunchScale(objectToControl, hash);
         }
}