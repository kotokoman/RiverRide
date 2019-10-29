using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float cameraSpeed = 0.3f;
    public float thruster = 1.2f;

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {

            gameObject.transform.Translate(0, 0.1f * (cameraSpeed * thruster), 0);
        }

        gameObject.transform.Translate(0, 0.1f * cameraSpeed, 0);
    }
}
