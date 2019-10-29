using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private CameraControls camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraControls>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log("Nome do objeto: " + c.gameObject.name);

        if (c.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);

            camera.cameraSpeed = 0.0f;
        }

        if (c.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            camera.cameraSpeed = 0.0f;
        }

        if (c.gameObject.tag == "Civilian")
        {
            c.gameObject.SetActive(false);
        }
    }
}
