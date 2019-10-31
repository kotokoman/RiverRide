using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform trPlayer;
    public float enemyTranslate = 0.12f;
    public float enemyChase = 1.5f;
    private bool enemyHit = false;


    void Start()
    {
        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;        //referencia ao player

    }

    void FixedUpdate()
    {

        if (!enemyHit)
        {
            gameObject.transform.Translate(0.1f * enemyTranslate, 0, 0);   // faz o inimigo ficar andando para o lado
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, trPlayer.position, enemyChase * Time.deltaTime);     //faz o inimigo perseguir o player
        }

       
    }

    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag == "Bounds")
        {
            enemyTranslate = enemyTranslate * -1;  //faz o inimigo ir para o outro lado quando bater na parede
        }

        if (c.gameObject.tag == "Boia")
        {
            Destroy(c.gameObject);
            enemyHit = true;

        }
    }
}
