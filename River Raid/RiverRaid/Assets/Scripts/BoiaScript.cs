using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiaScript : MonoBehaviour
{

    public float speed = 1.3f;
    public Rigidbody2D rb_boia;
    public float timeLimit = 1.5f;
    private float timer = 0;

    
    void Start()
    {
        rb_boia.velocity = transform.up * speed;
    }

    private void Update()
    {
        //Criar uma variável contadora
        timer += Time.deltaTime; //Atribuir o valor de "timer" com o tempo de atualização dos frames        
        //Comparar o valor do contador com o tempo limite
        //Se for igual ou maior...
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

        }
    }

}
