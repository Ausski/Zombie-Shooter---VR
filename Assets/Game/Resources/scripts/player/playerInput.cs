using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour {

    public static bool joystickControllerDetected; //if a joystick controller is detected or not

    void Start()
    {
        string[] detectedJoystick = Input.GetJoystickNames(); //gets detected joystick names

        if (detectedJoystick.Length != 0)
        {
            switch (detectedJoystick[0]) //checks primary name
            {
                case "Controller (XBOX 360 For Windows)":
                    joystickControllerDetected = true; //detect xbox controller
                    break;

                default:
                    joystickControllerDetected = false; //no controller preset
                    break;
            }
        }
    }
}