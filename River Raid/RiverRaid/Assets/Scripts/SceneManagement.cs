using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    bool gameEnded = false;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");   //carrega cena de gameplay após start
    }

    public void LostGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            SceneManager.LoadScene("GameOver");  //carrega cena de game over caso o player perca
            
        }
    }
    public void WinGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            SceneManager.LoadScene("GameWin");   // carrega cena de game win caso o player chegue no final

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");    //carrega cena de gameplay caso o player perca e reinicie
    }

}
