using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiaScript : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody2D rb_boia;
    public float timeLimit = 1.5f;
    private float timer = 0;
    private ScoreManager sManager;
    
    void Start()
    {
        rb_boia.velocity = transform.up * speed;       //adicionar "movimento" à boia
        sManager = GameObject.Find("Points").GetComponent<ScoreManager>();  //referenciar o script de pontos
    }

    private void Update()
    {
        timer += Time.deltaTime; 

        if (timer >= timeLimit)
        {
            //Resetar o contador
            timer = 0;
            //Destruir o Game Object
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Civilian")
        {
            Destroy(c.gameObject);
            Destroy(gameObject);

            sManager.Points = 1;

        }
        if (c.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);

        }
        if (c.gameObject.tag == "Fuel")
        {
            Destroy(gameObject);

        }
    }

}
