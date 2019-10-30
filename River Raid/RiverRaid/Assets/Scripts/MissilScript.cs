﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilScript : MonoBehaviour
{

    public float speed = 1.3f;
    public Rigidbody2D rb_missil;
    public float timeLimit = 1.5f;
    private float timer = 0;
    private ScoreManager sManager;
    
    void Start()
    {
        rb_missil.velocity = transform.up * speed;
        sManager = GameObject.Find("Points").GetComponent<ScoreManager>();
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
        if (c.gameObject.tag == "Enemy")
        {
            Destroy(c.gameObject);
            Destroy(gameObject);

            sManager.Points = 1;

        }
        if (c.gameObject.tag == "Civilian")
        {
            Destroy(c.gameObject);
            Destroy(gameObject);

            sManager.Points = -1;

        }
    }

}