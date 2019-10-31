using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int points = 0;   //variavel contadora de pontos
    
    public int Points   //getset da variavel para somar pelo valor recebido em 'value' e chamar a função de update
    {
        get
        {
            return points;
        }

        set
        {
            points += value;

            UpdatePointsText();
        }
    }

    void Awake()
    {
        scoreText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();    //referencia ao text de pontos
    }

    void UpdatePointsText()
    {
        scoreText.text = Points.ToString();     //alterar o texto da variavel para a quantidade de pontos
    }
}