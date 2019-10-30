using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    bool gameEnded = false;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LostGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            SceneManager.LoadScene("GameOver");
            
        }
    }
    public void WinGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            SceneManager.LoadScene("GameWin");

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay"); 
    }

}
