using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class cameraControl : MonoBehaviour {

    public float screenFOV = 60f; //FOV on screen with when no headset is in use
    public float headsetFOV = 106.1888f; //FOV inside the headset when it is in use

    private Camera cameraComponent; //the camera component of the attached object

    void Start()
    {
        if (inputInterface.detection_VRHeadset) //checks if a VR headset is present
        {
            SetCameraFOV(headsetFOV); //set camera FOV to the desired headset FOV
        }
        else
        {
            SetCameraFOV(screenFOV); //set camera FOV to the desired screen (non-headset) FOV
        }

        InputTracking.Recenter();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InputTracking.Recenter();
            }
        }
    }

    void SetCameraFOV(float desiredFOV) //sets camera FOV to desired FOV
    {
        cameraComponent.fieldOfView = desiredFOV; //set camera FOV
    }
}
