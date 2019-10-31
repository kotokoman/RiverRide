using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody2D boia;          // rigidbody do prefab do projetil
    public Rigidbody2D missil;
    public Transform saida;             // empty object para marcar a posição da saída do projetil

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootMissil();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShootBoia();
        }
    }

    void ShootBoia()  // função para instanciar o projetil na posição e rotação da saída
    {
        Instantiate(boia, saida.position, saida.rotation);        
    }
    void ShootMissil()  // função para instanciar o projetil na posição e rotação da saída
    {
        Instantiate(missil, saida.position, saida.rotation);
    }
}

