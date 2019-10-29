using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform trPlayer;
    public float enemyTranslate = 0.12f;
    public float enemyChase = 1.5f;
    public float enemyTurn = 2f;
    private bool enemyHit = false;


    void Start()
    {
        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void FixedUpdate()
    {

        if (!enemyHit)
        {
            gameObject.transform.Translate(0.1f * enemyTranslate, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), enemyTurn * Time.deltaTime);

            transform.position += transform.forward * enemyChase * Time.deltaTime;
        }

       
    }

    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag == "Bounds")
        {
            enemyTranslate = enemyTranslate * -1;
        }

        if (c.gameObject.tag == "Boia")
        {
            Destroy(c.gameObject);
            enemyHit = true;

        }
    }
}
