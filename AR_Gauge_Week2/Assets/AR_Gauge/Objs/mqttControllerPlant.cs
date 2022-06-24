using UnityEngine;
using TMPro;

public class mqttControllerPlant : MonoBehaviour
{
    public string topic = "";
    private mqttReceiverList _mqttReceiver;

    private void Start()
    {

        if (GameObject.FindGameObjectsWithTag("wind").Length > 0)
        {
            Debug.Log("Game object found");
            _mqttReceiver = GameObject.FindGameObjectsWithTag("wind")[0].gameObject.GetComponent<mqttReceiverList>();
        }
        else
        {
            Debug.LogError("At least one GameObject with mqttReceiver component and Tag == tagOfTheMQTTReceiver needs to be provided");
        }
        _mqttReceiver.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(mqttObj mqttObject)
    {

        if (mqttObject.topic == topic)
        {
            this.gameObject.transform.Find("MSG_MQTT").gameObject.GetComponent<TextMeshPro>().text = mqttObject.msg;
            Debug.Log(mqttObject.topic + " |||" + mqttObject.msg);
        }
    }

}
