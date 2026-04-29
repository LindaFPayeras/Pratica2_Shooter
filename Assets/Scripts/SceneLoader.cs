using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
        Debug.Log("Ha cambiado de pantalla");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Ha cambiado de pantalla");
    } 
    public void GameOverLose()
    {
        SceneManager.LoadScene("Lose");
        Debug.Log("Ha cambiado de pantalla");
    }

    public void GameOverWin()
    {
        SceneManager.LoadScene("Victory");
        Debug.Log("Ha cambiado de pantalla");
    }
}
