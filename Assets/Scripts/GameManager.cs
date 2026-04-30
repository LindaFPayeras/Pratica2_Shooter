using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private int lives = 3;
    public int Lives => lives; 

    private int enemies ;
    
    public int Enemies => enemies;

    public static event Action<int> OnEnemiesChanged;
    public static event Action<int> OnLivesChanged;
    public static event Action OnGameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }   
    }

    public void AddEnemie()
    {
        enemies++;
        Debug.Log("Enemies killed: " + enemies);
        if (enemies >= 3)
        {
            Debug.Log("¡Has ganado!");
            OnEnemiesChanged?.Invoke(enemies);
            enemies = 0;

        }
        
    }

    public void LoseLife(PlayerControllerFPS player)
    {
        lives--;
        Debug.Log("Vidas: " + lives);
        OnLivesChanged?.Invoke(lives);

        if (lives > 0)
        {
            player.Respawn();
        }
        else
        {
            Debug.Log("Game Over");
            lives = 3;
        }
    }

    
}