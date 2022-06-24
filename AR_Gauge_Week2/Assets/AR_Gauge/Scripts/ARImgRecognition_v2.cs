using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using M2MqttUnity;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class ARImgRecognition_v2 : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;

    public List<GameObject> GameObjectToSpawn = new List<GameObject>(); //List of GameObjects / Prefab we want to instantiate on the images
    public List<Texture2D> TwoDCutoutToSpawn = new List<Texture2D>(); //List of GameObjects / Prefab we want to instantiate on the images

    private List<GameObject> InstatiatedGObject = new List<GameObject>();//Internal List of the GameObjects instantiated
    private float timer; //check for how long the marker is out of the camera view
    private mqttReceiverList _mqttReceiver;
    public bool checkTracking = false;

    public List<string> topicsToSubscribes = new List<string>(); //List of topics to subscribes



    private void Awake()
    {
        //Why are we instantiating 2 objects instead of 4?
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject item in GameObjectToSpawn)
        {
            InstatiatedGObject.Add(Instantiate(item, Vector3.zero, Quaternion.identity));
            InstatiatedGObject[InstatiatedGObject.Count - 1].name = item.name;  //AR object 0
            InstatiatedGObject[InstatiatedGObject.Count - 1].GetComponent<mqttControllerPlant>().topic = topicsToSubscribes[InstatiatedGObject.Count - 1];  //AR object 0
            InstatiatedGObject[InstatiatedGObject.Count - 1].SetActive(false);



            Debug.Log(InstatiatedGObject[InstatiatedGObject.Count - 1].GetComponent<mqttControllerPlant>().topic);
        }

        if (GameObject.FindGameObjectsWithTag("wind").Length > 0)
        {
            Debug.Log("Game object found");
            _mqttReceiver = GameObject.FindGameObjectsWithTag("wind")[0].gameObject.GetComponent<mqttReceiverList>();

            _mqttReceiver.topicSubscribe=topicsToSubscribes;

            _mqttReceiver.Connect();
        }
        else
        {
            Debug.LogError("At least one GameObject with mqttReceiver component and Tag == tagOfTheMQTTReceiver needs to be provided");
        }

    }


    private void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
        Debug.Log("onEnable");
    }

    private void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
        Debug.Log("onDisable");
    }


    IEnumerator timerMarker(int index)
    {
        while (timer < 2)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            yield return null;
        }
        timer = 0;
        InstatiatedGObject[index].SetActive(false);
    }


    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.updated)
        {
            //string to evaluate is the name of the marker provided in XR Reference Image
            if (trackedImage.referenceImage.name == "Marker-01")
            {   int index=0;
                InstatiatedGObject[index].transform.position = trackedImage.transform.position;
                InstatiatedGObject[index].transform.localEulerAngles = trackedImage.transform.localEulerAngles;
                InstatiatedGObject[index].transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.mainTexture = TwoDCutoutToSpawn[index];

                if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                {
                    timer = 0;
                    Debug.Log("Tracking...");
                    if (!checkTracking)
                    {
                        InstatiatedGObject[index].SetActive(true);
                    }
                }

                else if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
                {
                    Debug.Log("Limited...");
                    StartCoroutine(timerMarker(index));
                }

            }

           //string to evaluate is the name of the marker provided in XR Reference Image
            if (trackedImage.referenceImage.name == "Marker-02")
            {   int index=1;
                InstatiatedGObject[index].transform.position = trackedImage.transform.position;
                InstatiatedGObject[index].transform.localEulerAngles = trackedImage.transform.localEulerAngles;
                InstatiatedGObject[index].transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.mainTexture = TwoDCutoutToSpawn[index];

                if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                {
                    timer = 0;
                    Debug.Log("Tracking...");
                    if (!checkTracking)
                    {
                        InstatiatedGObject[index].SetActive(true);
                    }
                }

                else if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
                {
                    Debug.Log("Limited...");
                    StartCoroutine(timerMarker(index));
                }

            }

           //string to evaluate is the name of the marker provided in XR Reference Image
            if (trackedImage.referenceImage.name == "Marker-03")
            {   int index=2;
                InstatiatedGObject[index].transform.position = trackedImage.transform.position;
                InstatiatedGObject[index].transform.localEulerAngles = trackedImage.transform.localEulerAngles;
                InstatiatedGObject[index].transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.mainTexture = TwoDCutoutToSpawn[index];

                if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                {
                    timer = 0;
                    Debug.Log("Tracking...");
                    if (!checkTracking)
                    {
                        InstatiatedGObject[index].SetActive(true);
                    }
                }

                else if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
                {
                    Debug.Log("Limited...");
                    StartCoroutine(timerMarker(index));
                }

            }

            //string to evaluate is the name of the marker provided in XR Reference Image
            if (trackedImage.referenceImage.name == "Marker-04")
            {   int index=3;
                InstatiatedGObject[index].transform.position = trackedImage.transform.position;
                InstatiatedGObject[index].transform.localEulerAngles = trackedImage.transform.localEulerAngles;
                InstatiatedGObject[index].transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.mainTexture = TwoDCutoutToSpawn[index];

                if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                {
                    timer = 0;
                    Debug.Log("Tracking...");
                    if (!checkTracking)
                    {
                        InstatiatedGObject[index].SetActive(true);
                    }
                }

                else if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
                {
                    Debug.Log("Limited...");
                    StartCoroutine(timerMarker(index));
                }

            }



        }

    }
}
