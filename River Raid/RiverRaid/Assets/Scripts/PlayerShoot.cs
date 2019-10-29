using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody2D boia;          // rigidbody do prefab do projetil
    public Transform saida;             // empty object para marcar a posição da saída do projetil

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    void Shoot()  // função para instanciar o projetil na posição e rotação da saída e atribuir a velocidade e direção do projetil
    {
        Instantiate(boia, saida.position, saida.rotation);        
    }
}
