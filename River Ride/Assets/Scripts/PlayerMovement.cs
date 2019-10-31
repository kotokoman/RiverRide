using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

            gameObject.transform.Translate(-0.1f * movSPD, 0, 0);  //move o player para a esquerda
            
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            gameObject.transform.Translate(0.1f * movSPD, 0, 0); // move o player para a direita
        }
    }
}
