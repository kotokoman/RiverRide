using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    bool gameEnded = false;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            SceneManager.LoadScene("GameOver");
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay"); 
    }

}
