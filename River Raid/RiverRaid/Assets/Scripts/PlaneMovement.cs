using UnityEngine;

public class PlaneMovement : MonoBehaviour
{

    public float movSPD = 1.1f;

    void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            gameObject.transform.Translate(-0.1f * movSPD, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            gameObject.transform.Translate(0.1f * movSPD, 0, 0);
        }
    }
}
