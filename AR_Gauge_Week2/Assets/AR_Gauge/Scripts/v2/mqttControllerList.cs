using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mqttControllerList : MonoBehaviour
{
    public string nameController = "Controller 1";
    public string tagOfTheMQTTReceiver = "";

    public string topic = "";

    public TextMeshProUGUI value_Temperature;
    public TextMeshProUGUI value_Humidity;
    public TextMeshProUGUI value_Moisture;

    public mqttReceiverList _eventSender;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver).Length > 0)
        {
            _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReceiverList>();
        }
        else
        {
            Debug.LogError("At least one GameObject with mqttReceiver component and Tag == tagOfTheMQTTReceiver needs to be provided");
        }
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(mqttObj mqttObject)
    {
        /*
       if(mqttObject.topic=="student/CASA0014/plant/ucfnwho/temperature"){
       value_Temperature.text=System.Math.Round(float.Parse(mqttObject.msg),2).ToString()+" C";
       Debug.Log(value_Temperature.text);}

       if(mqttObject.topic=="student/CASA0014/plant/ucfnwho/humidity"){
       value_Humidity.text= mqttObject.msg+" %";}

       if(mqttObject.topic=="student/CASA0014/plant/ucfnwho/moisture"){
       value_Moisture.text=mqttObject.msg;}

*/
    }

    


}