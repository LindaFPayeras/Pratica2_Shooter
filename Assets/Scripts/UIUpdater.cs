using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.VectorGraphics;

public class IU : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesText;

    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] private SceneLoader sceneLoader;

    private void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
           sceneLoader.GameOverLose();
        }
    }   

    private void UpdateEnemies(int enemies)
    {
        enemiesText.text = "Enemies: " + enemies.ToString() + "/3";
        if (enemies >= 3 )
        {
            sceneLoader.GameOverWin();
            
        }
    }  

    void Start()
    {
        UpdateEnemies(GameManager.instance.Enemies);
        GameManager.OnEnemiesChanged += UpdateEnemies;
        UpdateLives(GameManager.instance.Lives);
        GameManager.OnLivesChanged += UpdateLives;
    }

    void OnDestroy()     
    {
        GameManager.OnEnemiesChanged -= UpdateEnemies;
        GameManager.OnLivesChanged -= UpdateLives;
    }

   
}