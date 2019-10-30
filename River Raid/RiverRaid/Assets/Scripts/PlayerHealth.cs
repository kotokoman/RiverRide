using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private CameraControls camera;
    private ScoreManager sManager;

    public Slider fuelSlider;
    public float fuelInicial = 100f;
    private float fuelAtual;
    public float fuelDecreaser = -2f;

    private bool isMorto = false;
    private bool isWin = false;


    void OnEnable()
    {
        fuelAtual = fuelInicial;
    }


    void Start()
    {
        InvokeRepeating("DecreaseFuel", 0.3f, 0.3f);
        sManager = GameObject.Find("Points").GetComponent<ScoreManager>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraControls>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            fuelDecreaser = fuelDecreaser * 2;
            
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            fuelDecreaser = fuelDecreaser / 2;
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
            UseFuel(15f);
        }
        if (c.gameObject.tag == "Finish")
        {
            OnWin();
        }
    }

    public void DecreaseFuel()
    {
        
        
        UseFuel(fuelDecreaser);
                
    }

    public void UseFuel(float amount)    // função com parametro de dano para descontar da vida atual e fazer a verificação se o player ainda está vivo
    {
        fuelAtual += amount;

        SetFuelUI();

        if (fuelAtual <= 0f && !isMorto)
        {
            OnDeath();
        }
    }

    private void SetFuelUI()       // seta o value do slider para o valor da vida atual
    {
        fuelSlider.value = fuelAtual;

    }

    void OnDeath()           // função executada quando o player morre para mudar a Scene para o Game Over
    {
        isMorto = true;

        FindObjectOfType<SceneManagement>().LostGame();
    }
    void OnWin()           // função executada quando o player morre para mudar a Scene para o Game Over
    {
        isWin = true;

        FindObjectOfType<SceneManagement>().WinGame();
    }
}
