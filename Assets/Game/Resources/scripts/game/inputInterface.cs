using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class inputInterface : MonoBehaviour {

    public static bool detection_VRHeadset = false; //if a VR headset is detected or not
    public static bool detection_joystickController = false;
    public static bool detection_leftHandController = false;
    public static bool detection_rightHandController = false;
    

    public static Vector2 input_charMovementAxes;
    public static Vector2 input_cameraRotationAxes;

    public static int input_handlessGrab;

    public static int input_rightHandGrab;
    public static int input_leftHandGrab;

    void Awake()
    {
        detection_VRHeadset = XRDevice.isPresent; //sets if a VR device is present or not

        string[] joystickNameList = Input.GetJoystickNames();

        if (joystickNameList.Length != 0)
        {
            for (int i = 0; i < joystickNameList.Length; i++)
            {
                switch (joystickNameList[0]) //checks primary name
                {
                    case "Controller (XBOX 360 For Windows)":
                        detection_joystickController = true; //detect xbox controller
                        break;


                    case "OpenVR Controller - Left":
                        detection_leftHandController = true;
                        break;

                    case "OpenVR Controller - Right":
                        detection_rightHandController = true;
                        break;
                }
            }
        }
    }

    void FixedUpdate()
    {

    }
}
