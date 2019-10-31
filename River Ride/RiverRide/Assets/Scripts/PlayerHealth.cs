using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private CameraControls camera;
    private ScoreManager sManager;

    public Slider fuelSlider;
    public float fuelMax = 100f;
    private float fuelAtual;
    public float fuelDecreaser = -2f;

    private bool isMorto = false;
    
    void OnEnable()
    {
        fuelAtual = fuelMax;    //seta a quantidade de fuel
    }


    void Start()
    {
        InvokeRepeating("DecreaseFuel", 0.3f, 0.3f); //chama a função DecreaseFuel a cada 0.3s
        sManager = GameObject.Find("Points").GetComponent<ScoreManager>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraControls>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            fuelDecreaser = fuelDecreaser * 2;  //dobra o gasto de fuel
            
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            fuelDecreaser = fuelDecreaser / 2;   //diminui pela metade o gasto de fuel
        }
    }


    void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log("Nome do objeto: " + c.gameObject.name);

        if (c.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);

            OnDeath();
        }

        if (c.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            OnDeath();
        }

        if (c.gameObject.tag == "Civilian")
        {
            c.gameObject.SetActive(false);
            sManager.Points = -1;
        }
        if(c.gameObject.tag == "Fuel")
        {
            c.gameObject.SetActive(false);
            UseFuel(15f);    //aumenta a quantidade de fuel
        }
        if (c.gameObject.tag == "Finish")
        {
            OnWin();
        }
    }

    public void DecreaseFuel()
    {
        
        UseFuel(fuelDecreaser);    //desconta do fuel o valor em fuelDecraser
                
    }

    public void UseFuel(float amount)    // função com parametro de dano para descontar do fuel atual e fazer a verificação se o player ainda está vivo
    {
        fuelAtual += amount;

        SetFuelUI();

        if (fuelAtual <= 0f && !isMorto)
        {
            OnDeath();
        }
    }

    private void SetFuelUI()       // seta o value do slider para o valor do fuel atual
    {
        fuelSlider.value = fuelAtual;

    }

    void OnDeath()           // função executada quando o player morre para mudar a Scene para o Game Over
    {
        isMorto = true;

        FindObjectOfType<SceneManagement>().LostGame();
    }
    void OnWin()           // função executada quando o player morre para mudar a Scene para o Game Win
    {
       
        FindObjectOfType<SceneManagement>().WinGame();
    }
}
